using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YurtOtomasyonu.classlar;

namespace YurtOtomasyonu
{
    public partial class Login : Form
    {
        Yonetim yonetim=new Yonetim();
        public string yetki="";
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            yetki = yonetim.login(txtKullanici.Text,txtSifre.Text);

            if (yetki != "1")
            {
                
                Anasayfa anasayfa = new Anasayfa();
                anasayfa.button3.Visible = false;
                anasayfa.Show();
                this.Hide();
                label3.Text = yetki;
            }
            else 
            {
                Anasayfa anasayfa = new Anasayfa();
                anasayfa.Show();
                this.Hide();
            }


        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.YURT' table. You can move, or remove it, as needed.
            this.yURTTableAdapter.Fill(this.dataSet1.YURT);

        }
    }
}
