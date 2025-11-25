using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace MilenialPark.Views.Reports
{
    public partial class FrmTestPrint : Form
    {
        public FrmTestPrint()
        {
            InitializeComponent();
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {

        }

        private void FrmTestPrint_Load(object sender, EventArgs e)
        {
            int index = 1;
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                richTextBox1.Text += index + "-" +  printer + "\n";
                index++;
            }
        }
    }
}
