using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Controller;
using MilenialPark.Master;
using MilenialPark.Views;
using QRCoder;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MilenialPark.Reports;
using MilenialPark.Views.Reports;
using CrystalDecisions.Shared;
using System.Runtime.InteropServices;

namespace MilenialPark.Views.Transaction
{
    public class PrinterHelper
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string printerName);

        public static void SetPrinterAsDefault(string printerName)
        {
            if (!SetDefaultPrinter(printerName))
            {
                throw new System.ComponentModel.Win32Exception();
            }
        }
    }

    public partial class FrmScanQRCODE : Form
    {
        #region properties 

        public ControllerShop controllerShop = new ControllerShop();
        public ControllerTransaction controllerTrans = new ControllerTransaction();
        public BindingSource bind = new BindingSource();
        public BindingSource bind2 = new BindingSource();
        public string filepath;
        public DataTable dt2 = new DataTable();
        DateTime from;
        DateTime to;
        string SearchCard = "";

        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        public DataSet dsQR = new DataSet();
        public ReportDocument reportQRDoc2 = new ReportDocument();
        public ControllerReport controllerReport = new ControllerReport();

        public ReportDocument reportDoc = new ReportDocument();
        public string substring3;

        #endregion

        public FrmScanQRCODE()
        {
            InitializeComponent();
        }

        private void FrmScanQRCODE_Load(object sender, EventArgs e)
        {
            txtSearchQR.Focus();
        }

        private void txtSearchQR_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string transID;
                string NoUrut;
                string tmp = txtSearchQR.Text;
                if (tmp.Contains("(") && tmp.Contains(")"))
                {
                    
                    tmp = tmp.Replace("(", "");
                    tmp = tmp.Replace(")", "");
                    string[] dataqr = tmp.Split('&');

                    dt = controllerTrans.getOnetransactionTiketDetail(dataqr[1], Convert.ToInt32(dataqr[2]));

                    if(dt.Rows.Count > 0)
                    {
                        lblItemID.Text = dt.Rows[0]["ItemID"].ToString();
                        lblItemName2.Text = dt.Rows[0]["ItemName"].ToString();
                        //lblItemDesc.Text = dt.Rows[0]["ItemDesc"].ToString();
                        //pbfoodImage.Image = Image.FromFile(objShopItem.ImageFilePath);
                        lblPrice.Text = Convert.ToDecimal(dt.Rows[0]["Price"]).ToString("#,##0");
                        NUDQty.Value = Convert.ToDecimal(dt.Rows[0]["Qty"]);
                        //lblTopUpAmount.Text = Convert.ToDecimal(dt.Rows[0]["TopUpAmount"]).ToString("#,##0");
                        lblCategory.Text = dt.Rows[0]["Category"].ToString();
                        lblWaktuBermain.Text = dt.Rows[0]["WaktuBermain"].ToString();
                        lblToleransi.Text = dt.Rows[0]["Toleransi"].ToString();
                        lblStatus.Text = dt.Rows[0]["OrderStatus"].ToString();

                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        string code = "(&" + dataqr[1] + "&" + dataqr[2] + ")";
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        Bitmap qrCodeImage = qrCode.GetGraphic(5);

                        byte[] yourByteArray;
                        using (var mStream = new System.IO.MemoryStream())
                        {
                            qrCodeImage.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp);
                            yourByteArray = mStream.ToArray();
                            pbfoodImage.Image = qrCodeImage;
                        }
                    }
                }
            }
        }

        private void btnPalceOrder_Click(object sender, EventArgs e)
        {
            if(lblStatus.Text != "BOUGHT")
            {
                ClsFungsi.Pesan("TIKET SUDAH PERNAH DIPAKAI !!!"); 
            }
            else
            {
                string tmp;
                string tmp2;
                List<string> listqrcode = new List<string>();
                List<string> listitemname = new List<string>();
                // get list ticket and 
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Category"].ToString() != "ACTIVITY")
                    {
                        tmp = "(&" + row["TransactionID"].ToString() + "&" + row["NoUrut"].ToString() + ")";
                        tmp2 = row["ItemName"].ToString();
                        listqrcode.Add(tmp);
                        listitemname.Add(tmp2);
                    }
                }

                List<byte[]> listQrCodes = new List<byte[]>();
                QRCodeGenerator qrGenerator = new QRCodeGenerator();

                foreach (String t in listqrcode)
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(t, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(5);

                    byte[] yourByteArray;
                    using (var mStream = new System.IO.MemoryStream())
                    {
                        qrCodeImage.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp);
                        yourByteArray = mStream.ToArray();
                        listQrCodes.Add(yourByteArray);
                    }
                }

                dsQR = controllerTrans.LoadListQRCodes(listQrCodes, listqrcode, listitemname);
                // Show or Print Tiket 

                reportQRDoc2 = new PrintQRCode();
                reportQRDoc2.SetDataSource(dsQR);

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Data Ticket berhasil Diload !!! \n Lanjut Cetak Ticket ?", "Print Ticket ? ", buttons);
                if (result == DialogResult.Yes)
                {
                    //Reports.FrmShowReport formListItem = new Reports.FrmShowReport(reportQRDoc2);
                    //formListItem.ShowDialog();

                    reportQRDoc2.PrintToPrinter(1, false, 0, 0);
                }
                else
                {

                }
            }
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            if (lblStatus.Text != "BOUGHT")
            {
                ClsFungsi.Pesan("TIKET SUDAH PERNAH DIPAKAI !!!");
            }
            else
            {
                string tmp;
                string tmp2;
                List<string> listqrcode = new List<string>();
                List<string> listitemname = new List<string>();
                // get list ticket and 
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Category"].ToString() != "ACTIVITY")
                    {
                        tmp = "(&" + row["TransactionID"].ToString() + "&" + row["NoUrut"].ToString() + ")";
                        tmp2 = row["ItemName"].ToString();
                        listqrcode.Add(tmp);
                        listitemname.Add(tmp2);
                    }
                }

                List<byte[]> listQrCodes = new List<byte[]>();
                QRCodeGenerator qrGenerator = new QRCodeGenerator();

                foreach (String t in listqrcode)
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(t, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(5);

                    byte[] yourByteArray;
                    using (var mStream = new System.IO.MemoryStream())
                    {
                        qrCodeImage.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp);
                        yourByteArray = mStream.ToArray();
                        listQrCodes.Add(yourByteArray);
                    }
                }

                dsQR = controllerTrans.LoadListQRCodes(listQrCodes, listqrcode, listitemname);
                // Show or Print Tiket 
                string printerA = "EPSON L15150 Series IT";
                 

                reportQRDoc2 = new PrintQRCode();
                reportQRDoc2.SetDataSource(dsQR);

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Data Ticket berhasil Diload !!! \n Lanjut Cetak Ticket ?", "Print Ticket ? ", buttons);
                if (result == DialogResult.Yes)
                {

                    if (System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().Contains(printerA))
                    {
                        reportQRDoc2.PrintOptions.PrinterName = printerA;

                        try
                        {
                            PrinterHelper.SetPrinterAsDefault(printerA);
                            reportQRDoc2.PrintToPrinter(1, false, 0, 0);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to set default printer: " + ex.Message);
                        }

                        //// Optional: Set paper options
                        //reportDoc.PrintOptions.PaperSize = PaperSize.PaperA4;
                        //reportDoc.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    }
                    //Reports.FrmShowReport formListItem = new Reports.FrmShowReport(reportQRDoc2);
                    //formListItem.ShowDialog();

                    
                }
                else
                {

                }
            }
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            if (lblStatus.Text != "BOUGHT")
            {
                ClsFungsi.Pesan("TIKET SUDAH PERNAH DIPAKAI !!!");
            }
            else
            {
                string tmp;
                string tmp2;
                List<string> listqrcode = new List<string>();
                List<string> listitemname = new List<string>();
                // get list ticket and 
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Category"].ToString() != "ACTIVITY")
                    {
                        tmp = "(&" + row["TransactionID"].ToString() + "&" + row["NoUrut"].ToString() + ")";
                        tmp2 = row["ItemName"].ToString();
                        listqrcode.Add(tmp);
                        listitemname.Add(tmp2);
                    }
                }

                List<byte[]> listQrCodes = new List<byte[]>();
                QRCodeGenerator qrGenerator = new QRCodeGenerator();

                foreach (String t in listqrcode)
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(t, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(5);

                    byte[] yourByteArray;
                    using (var mStream = new System.IO.MemoryStream())
                    {
                        qrCodeImage.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp);
                        yourByteArray = mStream.ToArray();
                        listQrCodes.Add(yourByteArray);
                    }
                }

                dsQR = controllerTrans.LoadListQRCodes(listQrCodes, listqrcode, listitemname);
                // Show or Print Tiket 
                string printerB = "EPSON L565 IT";

                reportQRDoc2 = new PrintQRCode();
                reportQRDoc2.SetDataSource(dsQR);

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Data Ticket berhasil Diload !!! \n Lanjut Cetak Ticket ?", "Print Ticket ? ", buttons);
                if (result == DialogResult.Yes)
                {
                    if (System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().Contains(printerB))
                    {
                        reportQRDoc2.PrintOptions.PrinterName = printerB;

                        try
                        {
                            PrinterHelper.SetPrinterAsDefault(printerB);
                            reportQRDoc2.PrintToPrinter(1, false, 0, 0);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to set default printer: " + ex.Message);
                        }


                        //// Optional: Set paper options
                        //reportDoc.PrintOptions.PaperSize = PaperSize.PaperA4;
                        //reportDoc.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    }

                    //Reports.FrmShowReport formListItem = new Reports.FrmShowReport(reportQRDoc2);
                    //formListItem.ShowDialog();

                    //reportQRDoc2.PrintToPrinter(1, false, 0, 0);
                }
                else
                {

                }
            }
        }
    }
}
