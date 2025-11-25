using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilenialPark.Master
{
    public class ClsFungsi
    {
        /// <summary>
        /// untuk mengubah data menjadi string
        /// </summary>
        /// <param name="xVar">data masukan</param>
        /// <returns>data string</returns>
        public static string C2Q(object xVar)
        {
            if (xVar == null)
                return "NULL";
            else if (xVar is string)
                return "'" + xVar.ToString().Replace("'", "‘") + "'";  // ' dipakai di query
            else if (xVar is DateTime)
                return " convert(datetime,'" + Convert.ToDateTime(xVar).ToShortDateString() + "',103) "; //.ToShortDateString()
            else if (xVar is Boolean)
                return (Convert.ToBoolean(xVar) ? "1" : "0");
            else if (xVar is Decimal)
                return xVar.ToString().Replace(",", ".");
            //else if (xVar is System.Drawing.Image)
            //    return (System.Drawing.Image)xVar;
            else
                return xVar.ToString();
        }

        public static string C2QTime(object xVar)//date with time
        {
            if (xVar == null)
                return "NULL";
            else if (xVar is string)
                return "'" + xVar.ToString().Replace("'", "‘") + "'";  // ' dipakai di query
            else if (xVar is DateTime)
                return " convert(datetime,'" + xVar.ToString().Replace('.', ':') + "', 103) "; //.ToShortDateString()
            else if (xVar is Boolean)
                return (Convert.ToBoolean(xVar) ? "1" : "0");
            else if (xVar is Decimal)
                return xVar.ToString().Replace(",", ".");
            else
                return xVar.ToString();
        }

        public static string toWhere(List<Tuple<string, string>> lstData, string col1, string col2)
        {
            string query = "Where ";
            foreach (string a in lstData.Select(el => el.Item1).Distinct())
            {
                query += "(" + col1 + "='" + a + "' and " + col2 + " in (";
                foreach (Tuple<string, string> b in lstData.Where(n => n.Item1 == a))
                {
                    query += "'" + b.Item2 + "'";
                    if (!b.Equals(lstData.Where(n => n.Item1 == a).Last()))
                        query += ",";
                }
                query += ")) ";
                if (!a.Equals(lstData.Select(el => el.Item1).Distinct().Last()))
                    query += " or ";
            }
            return query;
        }

        public static string toWhere(List<Tuple<string, string, string>> lstData, string col1, string col2, string col3)
        {
            string query = "Where ";
            foreach (var a in lstData.Select(el => new { el.Item1, el.Item2 }).Distinct())
            {
                query += "(" + col1 + "='" + a.Item1 + "' and " + col2 + "='" + a.Item2 + "' and " + col3 + " in (";
                foreach (Tuple<string, string, string> b in lstData.Where(n => n.Item1 == a.Item1 && n.Item2 == a.Item2))
                {
                    query += "'" + b.Item3 + "'";
                    if (!b.Equals(lstData.Where(n => n.Item2 == a.Item2).Last()))
                        query += ",";
                }
                query += ")) ";
                if (!a.Equals(lstData.Select(el => new { el.Item1, el.Item2 }).Distinct().Last()))
                    query += " or ";
            }
            return query;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData">data yang akan menjadi kriteria</param>
        /// <param name="col1">nama kolom where</param>
        /// <returns></returns>
        public static string toWhereIN(List<string> lstData, string col1)
        {
            string query = col1 + " in (";
            foreach (string b in lstData)
            {
                query += "'" + b + "'";
                if (!b.Equals(lstData.Last()))
                    query += ",";
            }
            query += ") ";
            return query;
        }


        public static string toWhere(List<string> lstData, string col1)
        {
            string query = "Where " + col1 + " in (";
            foreach (string b in lstData)
            {
                query += "'" + b + "'";
                if (!b.Equals(lstData.Last()))
                    query += ",";
            }
            query += ") ";
            return query;
        }

        public static string truncateStr(string val, int maxLen)
        {
            if (string.IsNullOrEmpty(val)) return val;
            return val.Length <= maxLen ? val : val.Substring(0, maxLen);
        }

        /// <summary>
        /// Memanggil Message Box
        /// </summary>
        /// <param name="Pesan">Pesan yang akan di tampilkan</param>
        /// <param name="tipe">Tipe dari Pesan (INFO/ERROR)</param>
        /// 
        public static void Pesan(string Pesan = "Harap Lakukan Proses Update Pada Aplikasi Ini.", string tipe = "INFO")
        {
            if (tipe.ToUpper() == "INFO")
            {
                MessageBox.Show(Pesan, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (tipe.ToUpper() == "ERROR")
            {
                MessageBox.Show(Pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static bool Pesan(string Pesan, string pertanyaan, string tipe)
        {
            return (MessageBox.Show(Pesan, pertanyaan, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ? true : false;
        }
    }
}
