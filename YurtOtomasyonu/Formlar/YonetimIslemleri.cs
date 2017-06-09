using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using YurtOtomasyonu.classlar;
using YurtOtomasyonu.Classlar;

namespace YurtOtomasyonu.Formlar
{
    
    public partial class YonetimIslemleri : Form
        
    {
        Yonetim yonetim = new Yonetim();
        public String odaID;
        public YonetimIslemleri()
        {
            InitializeComponent();
         
        }

        private void gbYatak_Enter(object sender, EventArgs e)
        {

        }

        private void UpDownKisi_ValueChanged(object sender, EventArgs e)
        {
            int i=Convert.ToInt16(UpDownKisi.Value.ToString());


            if (i == 1)
            {
                txtYatak1.Visible = true;
                txtYatak2.Visible = false;
                txtYatak3.Visible = false;
                txtYatak4.Visible = false;
            }
            if(i==2)
            {
                txtYatak1.Visible = true;
                txtYatak2.Visible = true;
                txtYatak3.Visible = false;
                txtYatak4.Visible = false;
            }
            if(i==3)
            {
                txtYatak1.Visible = true;
                txtYatak2.Visible = true;
                txtYatak3.Visible = true;
                txtYatak4.Visible = false;
            }
            if(i==4)
            {
                txtYatak1.Visible = true;
                txtYatak2.Visible = true;
                txtYatak3.Visible = true;
                txtYatak4.Visible = true;
            }
          
                    
        }

        private void Yonetim_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet5.ODA' table. You can move, or remove it, as needed.
            this.oDATableAdapter.Fill(this.dataSet5.ODA);
            // TODO: This line of code loads data into the 'dataSet4.YURT' table. You can move, or remove it, as needed.
            this.yURTTableAdapter.Fill(this.dataSet4.YURT);
            // TODO: This line of code loads data into the 'dataSet3.PERSONEL' table. You can move, or remove it, as needed.
            this.pERSONELTableAdapter.Fill(this.dataSet3.PERSONEL);

        }

        private void btnYurtKaydet_Click(object sender, EventArgs e)
        {
            yonetim.yurtEkle(txtYurtAdi.Text,txtYurtAdresi.Text);
            txtYurtAdi.Text = "";
            txtYurtAdresi.Text = "";
        }

        private void btnYurtGuncelle_Click(object sender, EventArgs e)
        {
            
            yonetim.yurtGuncelle(comboBoxYurt.SelectedValue.ToString(),txtYeniYurtAdi.Text,txtYeniYurtAdresi.Text);

        }

        private void btnYurtSil_Click(object sender, EventArgs e)
        {

            yonetim.YurtSil(txtYurtAdi.Text, txtYurtAdresi.Text);
        }

        private void btnOgrenciIsleri_Click(object sender, EventArgs e)
        {
            Ogrenci ogrEkle = new Ogrenci();
            ogrEkle.Show();
            this.Hide();

        }

        private void btnOdaEkle_Click(object sender, EventArgs e)
        {
            yonetim.odaEkle(UpDownNumara.Value.ToString(),UpDownKat.Value.ToString(),txtOdaBlok.Text,UpDownKisi.Value.ToString(),comboOdaTipi.Text,"0",comboYurt.SelectedValue.ToString());
            
            odaID =  yonetim.odaAra(UpDownNumara.Value.ToString());
            btnYatakEkle.Enabled = true;

        }

        private void btnYatakEkle_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(UpDownKisi.Value.ToString());

            if (i == 1)
            {
                yonetim.yatakEkle(txtYatak1.Text, "0", odaID);
            }
            if (i == 2)
            {
                yonetim.yatakEkle(txtYatak1.Text, "0", odaID);
                yonetim.yatakEkle(txtYatak2.Text, "0", odaID);
            }
            if (i == 3)
            {
                yonetim.yatakEkle(txtYatak1.Text, "0", odaID);
                yonetim.yatakEkle(txtYatak2.Text, "0", odaID);
                yonetim.yatakEkle(txtYatak3.Text, "0", odaID);
            }
            if (i == 4)
            {
                yonetim.yatakEkle(txtYatak1.Text, "0", odaID);
                yonetim.yatakEkle(txtYatak2.Text, "0", odaID);
                yonetim.yatakEkle(txtYatak3.Text, "0", odaID);
                yonetim.yatakEkle(txtYatak4.Text, "0", odaID);
            }
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnYatakEkle.Enabled = true;
            try
            {
                odaID = comboBox1.SelectedValue.ToString();
                yonetim.yatakEkle(txtYatak1.Text, "0", odaID);
            }
            catch (Exception)
            {
                
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        String id="0";
        private void button1_Click(object sender, EventArgs e)
        {
            yonetim.PersonelSil(id);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPerAD.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPerSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtKidem.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtTelefon.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPerAdres.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtMaas.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtYetki.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            cbPerYurt.DisplayMember = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();            

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            if ((txtKidem.Text != "Admin" || txtKidem.Text != "Yönetici") && txtYetki.Text == "1")
            { MessageBox.Show("Uygunsuz Yetki"); txtYetki.Text = ""; }
            else if ((txtKidem.Text == "Admin" || txtKidem.Text == "Yönetici") && txtYetki.Text != "1")
            { MessageBox.Show("Uygunsuz Yetki"); txtYetki.Text = ""; }
            else
            yonetim.personelEkle(txtPerAD.Text, txtPerSoyad.Text, txtKidem.Text, txtTelefon.Text, txtPerAdres.Text, txtMaas.Text, txtYetki.Text, txtSifre.Text, cbPerYurt.SelectedValue.ToString());
        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            yonetim.personelGuncelle(id,txtPerAD.Text, txtPerSoyad.Text, txtKidem.Text, txtTelefon.Text, txtPerAdres.Text, txtMaas.Text, txtYetki.Text, txtSifre.Text, cbPerYurt.SelectedValue.ToString());
        }    
      }
        
    }

