using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;



namespace YurtOtomasyonu.Classlar
{
    class Baglanti
    {
        public OracleConnection baglan = new OracleConnection("DATA SOURCE =localhost:1521/xe;PASSWORD=hr;PERSIST SECURITY INFO= True; USER ID=HR");
        public OracleCommand cmd;
        public int rowsUpdate = 0;
        public string mesaj = "mesaj";
        public OracleDataReader dr;
        public DataTable dt = new DataTable();
        public OracleDataAdapter da;
        
        public void baglantiAc()
        {
            if (baglan.State == ConnectionState.Closed)
            {
                baglan.Open();
            }
        }

        public void baglantiKapat()
        {
            if (baglan.State == ConnectionState.Open)
            {
                baglan.Close();
            }
        }
    }
}
