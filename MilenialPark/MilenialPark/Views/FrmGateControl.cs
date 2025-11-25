using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using MilenialPark.Controller;
using MilenialPark.Master;
using MilenialPark.Views;

namespace MilenialPark.Views
{
    public partial class FrmGateControl : Form
    {
        #region properties

        public SerialPort sp = new SerialPort();
        public ControllerShop controllerShop = new ControllerShop();
        public ControllerTransaction controllerTrans = new ControllerTransaction();
        public DataTable dt = new DataTable();

        DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59); 

        #endregion

        public FrmGateControl()
        {
            InitializeComponent();
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (ComboPort.SelectedIndex != -1)
            {
                if (sp.IsOpen == false)
                {
                    sp.PortName = ComboPort.SelectedItem.ToString();
                    sp.Open();
                    PortStatus.Text = "Connected";
                    PortStatus.BackColor = Color.FromArgb(0, 255, 0);
                }
                sp.DataReceived += serialPort_DataReceived;
            }
        }

        private void btnRefrs_Click(object sender, EventArgs e)
        {
            ComboPort.SelectedIndex = -1;
            ComboPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                ComboPort.Items.Add(port);  
            }
            if (ports.Length > 0)
            {
                ComboPort.SelectedIndex = 0;
            }
        }

        private void FrmGateControl_Load(object sender, EventArgs e)
        {
            btnRefrs_Click(null, null);

            //if (!ClsStaticVariables.controllerUser.objUser.HakAkses.Contains("admin"))
            //{
            //    lblmanual.Visible = false;
            //    txtGateCode.Visible = false;
            //    btnSend.Visible = false;
            //}
        }

        public void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string s = sp.ReadLine();
            this.BeginInvoke(new Action(() =>
            {
                rtxDataIO.Text += s;

                if (s.Contains("(") && s.Contains(")") && s.Contains(","))
                {
                    string[] data = s.Split(',');
                    data[0] = data[0].Replace("(", "");
                    data[1] = data[1].Replace(")\r", "");
                    string[] dataqr = data[0].Split('&');
                    try
                    {
                        // check In or Out 
                        if (Convert.ToInt32(data[1]) == 2)
                        {
                            // IN 
                            // check Enter 
                            start = start.AddDays(-240);
                            dt = controllerTrans.getTiketwithTID(dataqr[1], "BOUGHT", Convert.ToInt32(dataqr[2]), start, end);
                            if (dt.Rows.Count == 1)
                            {
                                ClsStaticVariable.QRCODEtoReply = dt.Rows[0]["TransactionID"].ToString();
                                ClsStaticVariable.NoUrut = Convert.ToInt32(dt.Rows[0]["NoUrut"]);
                                rtxDataIO.Text += "*" + data[1].ToString().Replace("\r", "") + "," + "buka" + "," + "SELAMAT DATANG" + "#";
                                string reply = "*" + data[1].ToString().Replace("\r", "") + "," + "buka" + "," + "SELAMAT DATANG" + "#";
                                sp.WriteLine(reply);
                            }
                            else
                            {
                                rtxDataIO.Text += "*" + data[1].ToString().Replace("\r", "") + "," + "tutup" + "," + "TIDAK ADA TIKET / SDH DIGUNAKAN" + "#";
                                string reply = "*" + data[1].ToString().Replace("\r", "") + "," + "tutup" + "," + "TIDAK ADA TIKET / SDH DIGUNAKAN" + "#";
                                sp.WriteLine(reply);
                            }
                        }
                        //else if (Convert.ToInt32(data[1]) == 3)
                        //{
                        //    // OUT 
                        //    dt = controllerTrans.getTiketwithTID(dataqr[1], "ENTER-IN", Convert.ToInt32(dataqr[2]), start, end);
                        //    if (dt.Rows.Count == 1)
                        //    {
                        //        controllerTrans.UpdateOrderStatusTiket(dt.Rows[0]["TransactionID"].ToString(), Convert.ToInt32(dt.Rows[0]["NoUrut"]), "ENTER-OUT");
                        //        rtxDataIO.Text += "*" + data[1].ToString().Replace("\r", "") + "," + "buka" + "," + "SELAMAT JALAN" + "#";
                        //        string reply = "*" + data[1].ToString().Replace("\r", "") + "," + "buka" + "," + "SELAMAT JALAN" + "#";
                        //        sp.WriteLine(reply);
                        //    }
                        //    else
                        //    {
                        //        rtxDataIO.Text += "*" + data[1].ToString().Replace("\r", "") + "," + "tutup" + "," + "TIDAK ADA TIKET / SDH DIGUNAKAN" + "#";
                        //        string reply = "*" + data[1].ToString().Replace("\r", "") + "," + "tutup" + "," + "TIDAK ADA TIKET / SDH DIGUNAKAN" + "#";
                        //        sp.WriteLine(reply);
                        //    }
                        //}
                    }
                    catch (Exception ex)
                    {
                        rtxDataIO.Text += "Terjadi error pada scan Card , pesan error = " + ex.Message;
                    }
                }
                else if (s.Contains("[") && s.Contains("]") && s.Contains("OK"))
                {
                    if(ClsStaticVariable.QRCODEtoReply != "-" && ClsStaticVariable.NoUrut > 0)
                    {
                        try
                        {
                            controllerTrans.UpdateOrderStatusTiket(ClsStaticVariable.QRCODEtoReply, ClsStaticVariable.NoUrut, "ENTER-IN");
                            ClsStaticVariable.QRCODEtoReply = "-";
                            ClsStaticVariable.NoUrut = 0;
                            rtxDataIO.Text += "Data Updated!!!";
                        }
                        catch (Exception ex)
                        {
                            rtxDataIO.Text += "Terjadi error pada scan Card , pesan error = " + ex.Message;
                        }
                    }
                }
            }));
        }

        private void btnDisc_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                PortStatus.Text = "Disconnected";
                PortStatus.BackColor = Color.FromArgb(255, 0, 0);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtxDataIO.Text = "";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
            {
                if (sp.IsOpen)
                {
                    string reply = "*" + txtGateCode.Text.Replace("\r", "") + "," + "buka" + "," + "ADMIN ACCESS" + "#";
                    sp.WriteLine(reply);
                }
            }
            else
            {
                MessageBox.Show("Maaf anda tidak memiliki akses untuk menggunakan fitur ini , hubungi admin anda !!!");
            }
        }

        private void FrmGateControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnDisc_Click(null, null);
        }
    }
}
