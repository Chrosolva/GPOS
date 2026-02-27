using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
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

        // ---------- POS LIGHT PINK THEME ----------
        private static readonly Color HeaderPink = Color.FromArgb(255, 76, 123);
        private static readonly Color AccentBlue = Color.FromArgb(0, 120, 215);

        public static readonly GridTheme PosLightPink = new GridTheme
        {
            Surface = Color.White,
            SurfaceAlt = Color.FromArgb(246, 248, 252),

            TextPrimary = Color.FromArgb(35, 35, 35),
            TextSecondary = Color.FromArgb(90, 90, 90),

            HeaderBack = HeaderPink,
            HeaderText = Color.White,

            GridLines = Color.FromArgb(220, 220, 220),

            SelectionBack = Color.FromArgb(204, 228, 247),
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

        // ---------- POS CALM BLUE THEME ----------
        private static readonly Color CalmBlue = Color.FromArgb(74, 119, 184);       // soft slate blue
        private static readonly Color AccentTeal = Color.FromArgb(0, 153, 188);      // action/accent color

        public static readonly GridTheme PosCalmBlue = new GridTheme
        {
            // Surfaces (important for eye fatigue)
            Surface = Color.FromArgb(250, 252, 255),        // not pure white (reduces glare)
            SurfaceAlt = Color.FromArgb(240, 244, 250),

            // Text
            TextPrimary = Color.FromArgb(28, 32, 38),
            TextSecondary = Color.FromArgb(95, 105, 120),

            // Header
            HeaderBack = CalmBlue,
            HeaderText = Color.White,

            // Grid
            GridLines = Color.FromArgb(214, 221, 230),

            // Selection (very important for cashier usability)
            SelectionBack = Color.FromArgb(210, 228, 245),   // soft highlight (not aggressive)
            SelectionText = Color.FromArgb(20, 24, 28),

            // Row header
            RowHeaderBack = Color.FromArgb(235, 240, 246),
            RowHeaderText = Color.FromArgb(70, 80, 95),
            RowHeaderSelectBack = Color.FromArgb(215, 225, 236),

            // Readonly cells
            ReadonlyBack = Color.FromArgb(245, 247, 250),
            ReadonlyText = Color.FromArgb(100, 110, 125),

            // Accent color (buttons, active cell, focus)
            Accent = AccentTeal,

            // Fonts
            BodyFont = new Font("Segoe UI", 9.5f, FontStyle.Regular),
            HeaderFont = new Font("Segoe UI", 9.5f, FontStyle.Bold),

            // Layout
            RowHeight = 26,
            HeaderHeight = 28,
            RowHeaderWidth = 28
        };

        // ---------- INTERNAL PER-DGV STATE (prevents handler stacking) ----------
        private sealed class GridState
        {
            public bool Attached;

            public DataGridViewDataErrorEventHandler DataErrorHandler;
            public DataGridViewCellPaintingEventHandler CellPaintingHandler;

            public PaintEventHandler FocusPaintHandler;
            public EventHandler FocusInvalidateHandler;

            // fix "blue glitch" when horizontal scroll: repaint empty area
            public PaintEventHandler EmptyAreaPaintHandler;
            public ScrollEventHandler ScrollHandler;

            public DataGridViewColumnEventHandler ColumnWidthChangedHandler; // ❌ no (ColumnWidthChanged is DataGridViewColumnEventHandler)
            public EventHandler SizeChangedHandler;

            public EventHandler DataSourceChangedHandler;

            public DataGridViewColumnEventHandler ColumnAddedHandler;   // ✅ correct type
            public DataGridViewColumnEventHandler ColumnRemovedHandler; // ✅ correct type
        }

        private static readonly ConditionalWeakTable<DataGridView, GridState> _states =
            new ConditionalWeakTable<DataGridView, GridState>();

        // ---------- PUBLIC API ----------
        public static void ApplyPOSStyle(DataGridView dgv)
        {
            ApplyPOSStyle(dgv, PosLightPink, true, false);
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

            // ---- General ----
            dgv.EnableHeadersVisualStyles = false;
            dgv.Font = theme.BodyFont;

            // background for empty area
            dgv.BackgroundColor = Color.FromArgb(170, 170, 170);
            dgv.BorderStyle = BorderStyle.FixedSingle;

            dgv.RowTemplate.Height = theme.RowHeight;
            dgv.ColumnHeadersHeight = theme.HeaderHeight;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.RowHeadersVisible = true;
            dgv.RowHeadersWidth = theme.RowHeaderWidth;

            dgv.MultiSelect = multiSelect;

            // IMPORTANT: do not force Both; you can set Both in your form after Apply
            if (dgv.ScrollBars == ScrollBars.None)
                dgv.ScrollBars = ScrollBars.Both;

            // ---- Headers ----
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = theme.HeaderBack;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = theme.HeaderText;
            dgv.ColumnHeadersDefaultCellStyle.Font = theme.HeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = theme.HeaderBack;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = theme.HeaderText;

            // ---- Cells ----
            dgv.DefaultCellStyle.BackColor = theme.Surface;
            dgv.DefaultCellStyle.ForeColor = theme.TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = theme.SelectionBack;
            dgv.DefaultCellStyle.SelectionForeColor = theme.SelectionText;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = theme.SurfaceAlt;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = theme.TextPrimary;

            // ---- Row header strip ----
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

            // ---- Grid lines ----
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = theme.GridLines;

            // Optional: reduce shimmer on horizontal scroll
            try
            {
                dgv.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                dgv.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            }
            catch { }

            // ---- Behavior ----
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.ReadOnly = readOnly;
            dgv.EditMode = readOnly ? DataGridViewEditMode.EditProgrammatically : DataGridViewEditMode.EditOnEnter;

            // performance
            EnableDoubleBuffering(dgv);

            // attach handlers only once (prevents stacking + glitch)
            AttachOnce(dgv, theme);

            // keep right side clean
            EnsureLastVisibleColumnFill(dgv);

            dgv.ResumeLayout(true);
        }

        // ---------- OPTIONAL SIZING MODES ----------
        public static void SizeCompact(DataGridView dgv, int minWidth, int maxWidth)
        {
            if (dgv == null || dgv.Columns == null || dgv.Columns.Count == 0) return;

            const int extraPadding = 12;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.PerformLayout();

            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if (!c.Visible) continue;

                int w = c.Width + extraPadding;
                if (w < minWidth) w = minWidth;
                if (w > maxWidth) w = maxWidth;

                c.MinimumWidth = minWidth;
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                c.Width = w;
            }

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            EnsureLastVisibleColumnFill(dgv);
            dgv.Invalidate();
        }

        public static void SizeFullContent(DataGridView dgv, int minWidth)
        {
            if (dgv == null || dgv.Columns == null || dgv.Columns.Count == 0) return;

            const int extraPadding = 14;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.PerformLayout();

            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if (!c.Visible) continue;

                int w = c.Width + extraPadding;
                if (w < minWidth) w = minWidth;

                c.MinimumWidth = minWidth;
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                c.Width = w;
            }

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            EnsureLastVisibleColumnFill(dgv);
            dgv.Invalidate();
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
            catch { }
        }

        private static void EnsureLastVisibleColumnFill(DataGridView dgv)
        {
            if (dgv == null || dgv.Columns == null || dgv.Columns.Count == 0) return;

            DataGridViewColumn lastVisible = null;
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if (c.Visible) lastVisible = c;
            }

            if (lastVisible != null)
                lastVisible.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private static void AttachOnce(DataGridView dgv, GridTheme theme)
        {
            var st = _states.GetOrCreateValue(dgv);
            if (st.Attached) return;

            // prevent DataError popups
            st.DataErrorHandler = (sender, e) => { e.ThrowException = false; };
            dgv.DataError += st.DataErrorHandler;

            // remove focus rectangle on cells
            st.CellPaintingHandler = (sender, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Focus);
                e.Handled = true;
            };
            dgv.CellPainting += st.CellPaintingHandler;

            // focus outline (border)
            st.FocusPaintHandler = (sender, e) =>
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
            st.FocusInvalidateHandler = (sender, e) => dgv.Invalidate();
            dgv.Paint += st.FocusPaintHandler;
            dgv.GotFocus += st.FocusInvalidateHandler;
            dgv.LostFocus += st.FocusInvalidateHandler;

            // ---- fix blue artifacts when horizontal scroll: repaint empty area ----
            st.EmptyAreaPaintHandler = (sender, e) =>
            {
                try
                {
                    int rightEdge = dgv.RowHeadersVisible ? dgv.RowHeadersWidth : 0;

                    foreach (DataGridViewColumn c in dgv.Columns)
                    {
                        if (!c.Visible) continue;
                        Rectangle r = dgv.GetColumnDisplayRectangle(c.Index, true);
                        if (r.Width > 0)
                            rightEdge = Math.Max(rightEdge, r.Right);
                    }

                    Rectangle emptyRight = new Rectangle(
                        rightEdge,
                        0,
                        Math.Max(0, dgv.ClientRectangle.Width - rightEdge),
                        dgv.ClientRectangle.Height
                    );

                    Rectangle emptyBottom = new Rectangle(
                        0,
                        dgv.DisplayRectangle.Bottom,
                        dgv.ClientRectangle.Width,
                        Math.Max(0, dgv.ClientRectangle.Height - dgv.DisplayRectangle.Bottom)
                    );

                    using (var br = new SolidBrush(dgv.BackgroundColor))
                    {
                        e.Graphics.FillRectangle(br, emptyRight);
                        e.Graphics.FillRectangle(br, emptyBottom);
                    }
                }
                catch { }
            };
            dgv.Paint += st.EmptyAreaPaintHandler;

            st.ScrollHandler = (sender, e) =>
            {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    dgv.Invalidate();
            };
            dgv.Scroll += st.ScrollHandler;

            // ColumnWidthChanged uses DataGridViewColumnEventHandler
            st.ColumnWidthChangedHandler = (sender, e) => dgv.Invalidate();
            dgv.ColumnWidthChanged += st.ColumnWidthChangedHandler;

            st.SizeChangedHandler = (sender, e) => dgv.Invalidate();
            dgv.SizeChanged += st.SizeChangedHandler;

            st.DataSourceChangedHandler = (sender, e) =>
            {
                EnsureLastVisibleColumnFill(dgv);
                dgv.Invalidate();
            };
            dgv.DataSourceChanged += st.DataSourceChangedHandler;

            // ColumnAdded/Removed use DataGridViewColumnEventHandler
            st.ColumnAddedHandler = (sender, e) =>
            {
                EnsureLastVisibleColumnFill(dgv);
                dgv.Invalidate();
            };
            dgv.ColumnAdded += st.ColumnAddedHandler;

            st.ColumnRemovedHandler = (sender, e) =>
            {
                EnsureLastVisibleColumnFill(dgv);
                dgv.Invalidate();
            };
            dgv.ColumnRemoved += st.ColumnRemovedHandler;

            // cleanup when disposed
            dgv.Disposed += (sender, e) =>
            {
                try { dgv.DataError -= st.DataErrorHandler; } catch { }
                try { dgv.CellPainting -= st.CellPaintingHandler; } catch { }

                try { dgv.Paint -= st.FocusPaintHandler; } catch { }
                try { dgv.GotFocus -= st.FocusInvalidateHandler; } catch { }
                try { dgv.LostFocus -= st.FocusInvalidateHandler; } catch { }

                try { dgv.Paint -= st.EmptyAreaPaintHandler; } catch { }
                try { dgv.Scroll -= st.ScrollHandler; } catch { }
                try { dgv.ColumnWidthChanged -= st.ColumnWidthChangedHandler; } catch { }
                try { dgv.SizeChanged -= st.SizeChangedHandler; } catch { }
                try { dgv.DataSourceChanged -= st.DataSourceChangedHandler; } catch { }
                try { dgv.ColumnAdded -= st.ColumnAddedHandler; } catch { }
                try { dgv.ColumnRemoved -= st.ColumnRemovedHandler; } catch { }
            };

            st.Attached = true;
        }
    }
}