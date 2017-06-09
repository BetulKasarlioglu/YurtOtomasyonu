using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YurtOtomasyonu.Formlar;

namespace YurtOtomasyonu
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnOgrenciIsleri_Click(object sender, EventArgs e)
        {
            Ogrenci ogrEkle = new Ogrenci();
            ogrEkle.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            YonetimIslemleri yonetim = new YonetimIslemleri();
            yonetim.Show();
            this.Hide();
        }
    }
}
