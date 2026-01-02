using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MilenialPark // change namespace to your project if needed
{
    public static class DataGridViewHelper
    {
        // ---------- THEME MODEL ----------
        public sealed class GridTheme
        {
            public Color Surface;            // grid background
            public Color SurfaceAlt;         // alternating rows
            public Color TextPrimary;
            public Color TextSecondary;

            public Color HeaderBack;         // column header
            public Color HeaderText;

            public Color GridLines;

            public Color SelectionBack;
            public Color SelectionText;

            public Color RowHeaderBack;
            public Color RowHeaderText;
            public Color RowHeaderSelectBack;

            public Color ReadonlyBack;
            public Color ReadonlyText;

            public Color Accent;             // focus outline

            public Font BodyFont;
            public Font HeaderFont;

            // sizing feel
            public int RowHeight;
            public int HeaderHeight;
            public int RowHeaderWidth;
        }

        // ---------- POS LIGHT PINK THEME (MATCHING YOUR SCREENSHOT) ----------
        // You can tune only these two if you want:
        // HeaderPink = the main pink bar color in your UI
        // AccentBlue = nice selection + focus
        private static readonly Color HeaderPink = Color.FromArgb(255, 76, 123);   // hot pink (close to your bars)
        private static readonly Color AccentBlue = Color.FromArgb(0, 120, 215);    // Windows accent blue

        public static readonly GridTheme PosLightPink = new GridTheme
        {
            Surface = Color.White,
            SurfaceAlt = Color.FromArgb(246, 248, 252),

            TextPrimary = Color.FromArgb(35, 35, 35),
            TextSecondary = Color.FromArgb(90, 90, 90),

            HeaderBack = HeaderPink,
            HeaderText = Color.White,

            GridLines = Color.FromArgb(220, 220, 220),

            SelectionBack = Color.FromArgb(204, 228, 247), // soft light-blue selection
            SelectionText = Color.FromArgb(20, 20, 20),

            RowHeaderBack = Color.FromArgb(235, 235, 235),
            RowHeaderText = Color.FromArgb(60, 60, 60),
            RowHeaderSelectBack = Color.FromArgb(215, 215, 215),

            ReadonlyBack = Color.FromArgb(245, 245, 245),
            ReadonlyText = Color.FromArgb(80, 80, 80),

            Accent = AccentBlue,

            BodyFont = new Font("Segoe UI", 9.5f, FontStyle.Regular),
            HeaderFont = new Font("Segoe UI", 9.5f, FontStyle.Bold),

            RowHeight = 26,
            HeaderHeight = 28,
            RowHeaderWidth = 28
        };

        // ---------- PUBLIC API ----------
        public static void ApplyPOSStyle(DataGridView dgv)
        {
            ApplyPOSStyle(dgv, PosLightPink, true, false);
            RemoveFocusRectangle(dgv);
        }

        public static void ApplyPOSStyle(DataGridView dgv, bool readOnly, bool multiSelect)
        {
            ApplyPOSStyle(dgv, PosLightPink, readOnly, multiSelect);
        }

        public static void ApplyPOSStyle(DataGridView dgv, GridTheme theme, bool readOnly, bool multiSelect)
        {
            if (dgv == null) return;
            if (theme == null) theme = PosLightPink;

            dgv.SuspendLayout();

            // General
            dgv.EnableHeadersVisualStyles = false;
            dgv.Font = theme.BodyFont;
            dgv.BackgroundColor = Color.FromArgb(170, 170, 170); // gray empty area like your screenshot
            dgv.BorderStyle = BorderStyle.FixedSingle;

            dgv.RowTemplate.Height = theme.RowHeight;
            dgv.ColumnHeadersHeight = theme.HeaderHeight;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.RowHeadersVisible = true;
            dgv.RowHeadersWidth = theme.RowHeaderWidth;

            dgv.MultiSelect = multiSelect;
            dgv.ScrollBars = ScrollBars.Both;

            // Headers
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = theme.HeaderBack;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = theme.HeaderText;
            dgv.ColumnHeadersDefaultCellStyle.Font = theme.HeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = theme.HeaderBack;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = theme.HeaderText;

            // Rows (cells)
            dgv.DefaultCellStyle.BackColor = theme.Surface;
            dgv.DefaultCellStyle.ForeColor = theme.TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = theme.SelectionBack;
            dgv.DefaultCellStyle.SelectionForeColor = theme.SelectionText;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = theme.SurfaceAlt;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = theme.TextPrimary;

            // Row header strip
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.BackColor = theme.RowHeaderBack;
            dgv.RowHeadersDefaultCellStyle.ForeColor = theme.RowHeaderText;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = theme.RowHeaderSelectBack;
            dgv.RowHeadersDefaultCellStyle.SelectionForeColor = theme.RowHeaderText;

            if (dgv.TopLeftHeaderCell != null)
            {
                dgv.TopLeftHeaderCell.Style.BackColor = theme.RowHeaderBack;
                dgv.TopLeftHeaderCell.Style.ForeColor = theme.RowHeaderText;
            }

            // Grid lines (clean like POS)
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = theme.GridLines;

            // Behavior
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // you choose sizing mode below
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = readOnly;
            dgv.EditMode = readOnly ? DataGridViewEditMode.EditProgrammatically : DataGridViewEditMode.EditOnEnter;

            // Prevent annoying popup dialogs for bad formatted values (images, etc.)
            dgv.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e)
            {
                e.ThrowException = false;
            };

            // Focus outline
            AttachFocusCueHandlers(dgv, theme);

            // performance (reduces flicker)
            EnableDoubleBuffering(dgv);

            dgv.ResumeLayout(true);
        }

        // ---------- OPTIONAL SIZING MODES (call after binding) ----------

        /// <summary>
        /// Compact: content-fit but clamped so grid stays tight and scrollable.
        /// Good for POS list grids.
        /// </summary>
        public static void SizeCompact(DataGridView dgv, int minWidth, int maxWidth)
        {
            if (dgv == null || dgv.Columns.Count == 0) return;

            const int extraPadding = 12;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.PerformLayout();

            foreach (DataGridViewColumn c in dgv.Columns)
            {
                int w = c.Width + extraPadding;
                if (w < minWidth) w = minWidth;
                if (w > maxWidth) w = maxWidth;

                c.MinimumWidth = minWidth;
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                c.Width = w;
            }

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        /// <summary>
        /// Full content sizing: makes columns wide enough for visible content (may be wide; uses scrollbars).
        /// </summary>
        public static void SizeFullContent(DataGridView dgv, int minWidth)
        {
            if (dgv == null || dgv.Columns.Count == 0) return;

            const int extraPadding = 14;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.PerformLayout();

            foreach (DataGridViewColumn c in dgv.Columns)
            {
                int w = c.Width + extraPadding;
                if (w < minWidth) w = minWidth;

                c.MinimumWidth = minWidth;
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                c.Width = w;
            }

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        // ---------- READONLY COLUMN STYLING ----------
        public static void MarkReadOnlyColumns(DataGridView dgv, params string[] columnNames)
        {
            MarkReadOnlyColumns(dgv, PosLightPink, columnNames);
        }

        public static void MarkReadOnlyColumns(DataGridView dgv, GridTheme theme, params string[] columnNames)
        {
            if (dgv == null || theme == null || columnNames == null) return;

            for (int i = 0; i < columnNames.Length; i++)
            {
                string name = columnNames[i];
                if (string.IsNullOrEmpty(name)) continue;
                if (!dgv.Columns.Contains(name)) continue;

                DataGridViewColumn col = dgv.Columns[name];
                col.ReadOnly = true;
                col.DefaultCellStyle.BackColor = theme.ReadonlyBack;
                col.DefaultCellStyle.ForeColor = theme.ReadonlyText;

                Font baseFont = dgv.DefaultCellStyle.Font ?? theme.BodyFont;
                col.DefaultCellStyle.Font = new Font(baseFont, FontStyle.Italic);
            }
        }

        // ---------- INTERNAL HELPERS ----------
        private static void EnableDoubleBuffering(DataGridView dgv)
        {
            try
            {
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, dgv, new object[] { true });
            }
            catch
            {
                // ignore
            }
        }

        private class FocusHandlers
        {
            public PaintEventHandler PaintHandler;
            public EventHandler FocusHandler;
        }

        private static void AttachFocusCueHandlers(DataGridView dgv, GridTheme theme)
        {
            FocusHandlers existing = dgv.Tag as FocusHandlers;
            if (existing != null) return;

            FocusHandlers fh = new FocusHandlers();

            fh.PaintHandler = delegate (object sender, PaintEventArgs e)
            {
                if (dgv.Focused || dgv.ContainsFocus)
                {
                    using (Pen pen = new Pen(theme.Accent, 2))
                    {
                        Rectangle r = dgv.ClientRectangle;
                        r.Width -= 1;
                        r.Height -= 1;
                        e.Graphics.DrawRectangle(pen, r);
                    }
                }
            };

            fh.FocusHandler = delegate (object sender, EventArgs e)
            {
                dgv.Invalidate();
            };

            dgv.Paint += fh.PaintHandler;
            dgv.GotFocus += fh.FocusHandler;
            dgv.LostFocus += fh.FocusHandler;

            if (dgv.Tag == null || dgv.Tag is FocusHandlers)
                dgv.Tag = fh;

            dgv.Disposed += delegate
            {
                try { dgv.Paint -= fh.PaintHandler; } catch { }
                try { dgv.GotFocus -= fh.FocusHandler; } catch { }
                try { dgv.LostFocus -= fh.FocusHandler; } catch { }
            };
        }

        private static void RemoveFocusRectangle(DataGridView dgv)
        {
            dgv.CellPainting += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Focus);
                e.Handled = true;
            };
        }

    }
}
