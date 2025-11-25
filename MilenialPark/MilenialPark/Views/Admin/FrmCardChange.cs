using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilenialPark.Views.Admin
{
    public partial class FrmCardChange : Form
    {
        public FrmCardChange()
        {
            InitializeComponent();
        }

        private void FrmCardChange_Load(object sender, EventArgs e)
        {
            cbxCause.SelectedIndex = 0;
        }
    }
}
