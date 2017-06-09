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
using YurtOtomasyonu.Classlar;
using YurtOtomasyonu.Formlar;

namespace YurtOtomasyonu
{
    public partial class Ogrenci : Form
    {
        Login login = new Login();
        Yonetim yonetim = new Yonetim();

        public Ogrenci()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            YonetimIslemleri yonetim = new YonetimIslemleri();
            yonetim.Show();
            this.Hide();
        }
        //---------------------------------Ogrenci Ekleme Paneli-----------------------------------------------
        private void btnOgrAra_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTC.Text = "";
            txtMail.Text = "";
            txtTel.Text = "";
            txtKan.Text = "";
            txtOgretim.Text = "";
            txtAdres.Text = "";
            btnOgrEkleGuncele.Text = "Güncelle";
           
            dateTarih.Enabled = false;
            //ogrenci bilgilerini doldurma

            yonetim.ara(txtAra.Text);
            txtAd.Text = yonetim.ad;
            txtSoyad.Text = yonetim.soyad;
            txtTC.Text = txtAra.Text;
            
            txtKan.Text = yonetim.kan;
            txtTel.Text = yonetim.tel;
            txtAdres.Text = yonetim.adres;
            txtMail.Text = yonetim.mail;
            txtOgretim.Text = yonetim.ogretim;
            id = yonetim.yatak;     

        }

        private void btnOgrEkle_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTC.Text = "";
            txtMail.Text = "";
            txtTel.Text = "";
            txtKan.Text = "";
            txtOgretim.Text = "";
            txtAdres.Text = "";
            btnOgrEkleGuncele.Text = "Ekle";
        }


        String id,ad;
        private void Ogrenci_Load(object sender, EventArgs e)
        {
            if (login.label3.Text != "1") button3.Visible = false;
            // TODO: This line of code loads data into the 'dataSet9.OGRENCI' table. You can move, or remove it, as needed.
            this.oGRENCITableAdapter.Fill(this.dataSet9.OGRENCI);
            yonetim.YatakGoster();
            dgYatak.DataSource = yonetim.dt;
            id=yonetim.yatakId;
            yonetim.baglantiKapat();

        }

       
        private void btnOgrEkleGuncele_Click(object sender, EventArgs e)
        {
            DateTime newDate = System.Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

            if (btnOgrEkleGuncele.Text == "Ekle") 
            {
                yonetim.ogrenciEkle(txtAd.Text, txtSoyad.Text, txtTC.Text, txtKan.Text, txtTel.Text, newDate, txtAdres.Text, txtMail.Text, txtOgretim.Text, id);
            }
            else if (btnOgrEkleGuncele.Text == "Güncelle") 
            {
                yonetim.ogrenciGuncelle(txtAd.Text,txtSoyad.Text,txtTC.Text,txtKan.Text,txtTel.Text,txtAdres.Text,txtMail.Text,txtOgretim.Text, id);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.oDATableAdapter.FillBy1(this.dataSet2.ODA);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



        private void dgYatak_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           id = dgYatak.Rows[e.RowIndex].Cells[0].Value.ToString();

            lblBilgi.Text ="Oda Seçiminiz   :" + dgYatak.Rows[e.RowIndex].Cells[2].Value.ToString() + " numaralı oda";
            lblBilgi2.Text="Yatak Seçiminiz :" + dgYatak.Rows[e.RowIndex].Cells[1].Value.ToString() + " numaralı yatak";
        }


        //-----------------------------Disiplin Paneli-------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
           string ogrId= yonetim.DisOgrenciBul(txtAra.Text);// ogrencinin idsini yukardaki txtden cekti
           yonetim.ogrenciDisiplinEkle(txtDisiplin.Text,ogrId);//disiplin ekledi

        }

        private void btnDisGoster_Click(object sender, EventArgs e)
        {
            string ogrId = yonetim.DisOgrenciBul(txtAra.Text);// ogrencinin idsini yukardaki txtden cekti
            txtDisiplin.Text=yonetim.ogrenciDisiplinGoster(ogrId);
        }

       //-----------------------------------------------------------------------------------------------------
        
    }
}
