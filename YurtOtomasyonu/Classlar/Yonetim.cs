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
using YurtOtomasyonu.Classlar;


namespace YurtOtomasyonu.classlar
{
    class Yonetim:Baglanti
    {

//--------------------------------------------YURT ISLEMLERI--------------------------------------------

        public void yurtEkle(string yurt_Ad, string yurt_Adres)
        {
            OracleCommand cmd = new OracleCommand(@"BEGIN
                                                    PROC_YURT_EKLE(:yurt_Ad,:yurt_Adres);
                                                    END;", baglan);

            cmd.Parameters.Add(":yurt_Ad", yurt_Ad);
            cmd.Parameters.Add(":yurt_Adres", yurt_Adres);
            try
            {
                baglantiAc();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Yurt Başarıyla Eklenmiştir");
                baglantiKapat();
            }
            catch (Exception)
            {
                MessageBox.Show("Yurt Ekleme Hatası");
                throw;
            }
        }

        public void yurtGuncelle(string yurt_ID, string yurt_Ad, string yurt_Adres)
        {

            OracleCommand cmd = new OracleCommand(@"BEGIN        
                                                    PROC_YURT_GUNCELLE(:yurt_ID,:yurt_Ad,:yurt_Adres);
                                                    END;", baglan);

            cmd.Parameters.Add(":yurt_ID", yurt_ID);
            cmd.Parameters.Add(":yurt_Ad", yurt_Ad);
            cmd.Parameters.Add(":yurt_Adres", yurt_Adres);
            try
            {
                baglantiAc();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Yurt Başarıyla Güncellendi");
                baglantiKapat();
            }
            catch (Exception)
            {
                MessageBox.Show("Yurt Güncelleme Hatası");
                throw;
            }
        }



        public void YurtSil(string yurt_Ad, string yurt_Adres)
        {
            OracleCommand cmd = new OracleCommand(@"DELETE FROM YURT WHERE YURTAD=:yurt_Ad AND YURTADRES=:yurt_Adres", baglan);

            cmd.Parameters.Add(":yurt_Ad", yurt_Ad);
            cmd.Parameters.Add(":yurt_Adres", yurt_Adres);
            try
            {
                baglantiAc();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Yurt Başarıyla Silinmiştir");
                baglantiKapat();
            }
            catch (Exception)
            {
                MessageBox.Show("Yurt Silme Hatası");
                throw;
            }
        }
//-----------------------------------------------YURT ISLEMLERI BITIS--------------------------------------------------------------


//----------------------------------------------ODA ISLEMLERI------------------------------------------------------------
        public String Id;
        public void odaEkle(string odanumarasi, string odakati, string odablok, string kisisayisi, string odatipi, string odadurumu, string yurtID)
        {
            
            OracleCommand cmd = new OracleCommand("PROC_ODA_EKLE", baglan);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("ODA_NUMARASI", OracleDbType.Int16).Value =odanumarasi;
            cmd.Parameters.Add("ODA_KATI", OracleDbType.Int16).Value = odakati;
            cmd.Parameters.Add("ODA_BLOK", OracleDbType.NVarchar2).Value = odablok;
            cmd.Parameters.Add("KISI_SAYISI", OracleDbType.Int16).Value = kisisayisi;
            cmd.Parameters.Add("ODA_TIPI", OracleDbType.NVarchar2).Value = odatipi;
            cmd.Parameters.Add("ODA_DURUMU", OracleDbType.Int16).Value = odadurumu;
            cmd.Parameters.Add("YURT_ID", OracleDbType.Int16).Value = yurtID; 
     
           /* try
            {*/
                baglantiAc();
                //cmd.Transaction.Commit();
                cmd.ExecuteNonQuery();
                //Id = cmd.ExecuteScalar().ToString();

                MessageBox.Show("Oda Başarıyla Eklenmiştir");
            /*}
            catch (Exception)
            {
                MessageBox.Show("Oda Ekleme Hatası");
                throw;
            }*/
            baglantiKapat();
            
           

        }
        
//----------------------------------------------ODA ISLEMLERI BITIS------------------------------------------------------------

//----------------------------------------------YATAK ISLEMLERI----------------------------------------------------------------

        public void yatakEkle(string yataknumarasi,string yatakdurumu, string odaID)
        {
            baglantiAc();
            OracleCommand cmd = new OracleCommand("PROC_YATAK_EKLE", baglan);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("YATAK_NUMRASI", OracleDbType.NVarchar2).Value = yataknumarasi;
            cmd.Parameters.Add("ODA_ID", OracleDbType.Int16).Value = odaID;
            cmd.Parameters.Add("YATAK_DURUM", OracleDbType.Int16).Value = yatakdurumu;
           
           /* try
            {*/
                cmd.ExecuteNonQuery();
                MessageBox.Show("Yatak Başarıyla Eklenmiştir");
            /*}
            catch (Exception)
            {
                MessageBox.Show("Oda Ekleme Hatası");
                throw;
            }*/
            baglantiKapat();
        }



//----------------------------------------------YATAK ISLEMLERI BITIS----------------------------------------------------------

//----------------------------------------------OGRENCI ISLEMLERI--------------------------------------------------------------

        public void ogrenciEkle(string ad, string soyad,string tc,string kangrubu, string tel,DateTime tarih,string adres,string mail,string ogretim,string odaId)
        {
            baglantiAc();
            OracleCommand cmd = new OracleCommand(@"PROC_OGR_EKLE", baglan);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Ogrenci_Ad", OracleDbType.NVarchar2).Value = ad;
            cmd.Parameters.Add("Ogrenci_Soyad", OracleDbType.NVarchar2).Value = soyad;
            cmd.Parameters.Add("Ogrenci_TC", OracleDbType.NVarchar2).Value = tc;
            cmd.Parameters.Add("Ogrenci_KanGrubu", OracleDbType.NVarchar2).Value = kangrubu;
            cmd.Parameters.Add("Ogrenci_Tel", OracleDbType.NVarchar2).Value = tel;
            cmd.Parameters.Add("Ogrenci_KayitTarihi", OracleDbType.Date).Value = tarih;
            cmd.Parameters.Add("Ogrenci_Adres", OracleDbType.NVarchar2).Value = adres;
            cmd.Parameters.Add("Ogrenci_Mail", OracleDbType.NVarchar2).Value = mail;
            cmd.Parameters.Add("Ogrenci_Ogretim", OracleDbType.NVarchar2).Value = ogretim;
            cmd.Parameters.Add("Yatak_ID", OracleDbType.Int16).Value = odaId;

          /*  try
            {*/
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ogrenci Başarıyla Eklenmiştir");
           /* }
            catch (Exception)
            {
                MessageBox.Show("Ogrenci Ekleme Hatası");
                throw;
            }*/
            baglantiKapat();

        }

        public void ogrenciSil(string ogrenciID) 
        {
            baglantiAc();
            OracleCommand cmd = new OracleCommand(@"BEGIN
                                                    PROC_YURT_EKLE(:yurt_Ad,:yurt_Adres);
                                                    END;",baglan);
            cmd.Parameters.Add(":ad", ogrenciID);
            try
            {
                MessageBox.Show("Öğrenci Başarıyla Silinmiştir");
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Öğrenci Silme Hatası");
                throw;
            }
            baglantiKapat();
        }

        public void ogrenciGuncelle(string ad, string soyad, string tc, string kangrubu, string tel, string adres, string mail, string ogretim, string odaId) 
        {
            baglantiAc();
            OracleCommand cmd = new OracleCommand(@"PROC_OGR_GUNCELLE", baglan);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Ogrenci_Ad", OracleDbType.NVarchar2).Value = ad;
            cmd.Parameters.Add("Ogrenci_Soyad", OracleDbType.NVarchar2).Value = soyad;
            cmd.Parameters.Add("Ogrenci_TC", OracleDbType.Varchar2).Value = tc;
            cmd.Parameters.Add("Ogrenci_KanGrubu", OracleDbType.NVarchar2).Value = kangrubu;
            cmd.Parameters.Add("Ogrenci_Tel", OracleDbType.NVarchar2).Value = tel;
            cmd.Parameters.Add("Ogrenci_Adres", OracleDbType.NVarchar2).Value = adres;
            cmd.Parameters.Add("Ogrenci_Mail", OracleDbType.NVarchar2).Value = mail;
            cmd.Parameters.Add("Ogrenci_Ogretim", OracleDbType.NVarchar2).Value = ogretim;
            cmd.Parameters.Add("Yatak_ID", OracleDbType.Int16).Value = odaId;

            
            cmd.ExecuteNonQuery();
            
                MessageBox.Show("Öğrenci Başarıyla Güncellendi");

                baglantiKapat();
             
        }
        //--------------------------------------OGRENCI ISLEM BITISI----------------------------------------------------------------

        //------------------------------------------DISIPLIN ISLEMLERI------------------------------------------------------
        public void ogrenciDisiplinEkle(string ogrenciDisiplin_Durum, string ogrenci_ID)
        {
            OracleCommand cmd = new OracleCommand("PROC_DISIPLIN_EKLE", baglan);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("ogrenciDisiplin_Durum", OracleDbType.NVarchar2).Value = ogrenciDisiplin_Durum;
            cmd.Parameters.Add("ogrenci_ID", OracleDbType.Int16).Value = ogrenci_ID;
            
            try
            {
                baglantiAc();
                MessageBox.Show("Disiplin Başarıyla Eklenmiştir");
                cmd.ExecuteNonQuery();
                baglantiKapat();
            }
            catch (Exception)
            {
                MessageBox.Show("Disiplin Ekleme Hatası");
                throw;
            }
        }

        public string DisOgrenciBul(string tc)
        {
            OracleCommand cmd = new OracleCommand("DIS_OGRENCIBUL", baglan);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("TC", OracleDbType.NVarchar2).Value = tc;
            OracleParameter parametre = new OracleParameter();
            parametre = cmd.Parameters.Add("OGRID", OracleDbType.Int32, ParameterDirection.Output);//parametre pointer gibi out parametreini tutuyor

            try
            {
                baglantiAc();
                cmd.ExecuteNonQuery();
                baglantiKapat();
                return parametre.Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Disiplin Hatası");
                throw;
            }
        }
        public string ogrenciDisiplinGoster(string ID)
        {
            string disiplin="";
            OracleCommand cmd = new OracleCommand("BEGIN Select OGRENCIDISIPLINDURUM INTO :disiplin FROM OGRENCIDISIPLIN WHERE OGRENCIDISIPLINID = :ID; END;", baglan);
           
            cmd.Parameters.Add(":disiplin",disiplin);
            cmd.Parameters.Add(":ID", ID);

          
                baglantiAc();
               cmd.ExecuteNonQuery();
                return disiplin;
                baglantiKapat();
         
        }
        //----------------------------------------------DISIPLIN ISLEM BITISI-------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------
        
        
        public string odaAra(string ODANO)
        {
            
            OracleCommand cmd = new OracleCommand("SELECT ODAID FROM ODA WHERE ODANUMARASI=:ODANO", baglan);
            baglantiAc();
            cmd.Parameters.Add(":ODANO", ODANO);
            dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr["ODAID"].ToString();
                
            }
            baglantiKapat();
            return Id;
        }
     

        //-------------------------------------------------------------------------------------------------------------

       
       

        public void odemeEkle(String odemeNo, String taksitSayisi, String odeme, String kalan, String toplam, String tarih, String ogrenciId, String personelId) 
        {
            OracleCommand cmd = new OracleCommand(@"BEGIN
                                                    PROC_YURT_EKLE(:yurt_Ad,:yurt_Adres);
                                                    END;", baglan);

            cmd.Parameters.Add(":odemeNo", Convert.ToInt16(odemeNo));
            cmd.Parameters.Add(":taksitSayisi", Convert.ToInt16(taksitSayisi));
            cmd.Parameters.Add(":odeme", Convert.ToInt16(odeme));
            cmd.Parameters.Add(":kalan", Convert.ToInt16(kalan));
            cmd.Parameters.Add(":toplam", Convert.ToInt16(toplam));
            cmd.Parameters.Add("tarih", tarih);
            cmd.Parameters.Add(":ogrenciId", ogrenciId);
            cmd.Parameters.Add(":personelId", personelId);
        
        }
        public void odemeSil() 
        { 
        }
       
      public void odemeGuncelle(String odemeNo, String taksitSayisi,String odeme,String kalan,String toplam,String tarih,String ogrenciId,String personelId) 
        {
            int kalan_int = Convert.ToInt16(kalan) - Convert.ToInt16(odeme);
            OracleCommand cmd = new OracleCommand(@"BEGIN
                                                    PROC_YURT_EKLE(:yurt_Ad,:yurt_Adres);
                                                    END;", baglan);
            
            //parametreler string alındıgı icin veritabanına atmadan önce ceviri yaptim
            cmd.Parameters.Add(":odemeNo",Convert.ToInt16(odemeNo));
            cmd.Parameters.Add(":taksitSayisi", Convert.ToInt16(taksitSayisi));
            cmd.Parameters.Add(":odeme", Convert.ToInt16(odeme));
            cmd.Parameters.Add(":kalan",kalan_int);
            cmd.Parameters.Add(":toplam", Convert.ToInt16(toplam));
            cmd.Parameters.Add("tarih",tarih);
            cmd.Parameters.Add(":ogrenciId",ogrenciId);
            cmd.Parameters.Add(":personelId", personelId);
        }
         //---------------------------------------------------------------
      public void ogrenciGirisCikisEkle(string ogrenciGirisCikis_ID, string o_giris, string o_tarih, string o_izin, string ogrenci_Id)
      {
          OracleCommand cmd = new OracleCommand(@"BEGIN
                                                    PROC_YURT_EKLE(:yurt_Ad,:yurt_Adres);
                                                    END;", baglan);

          cmd.Parameters.Add(":ogrenciGirisCikis_ID", ogrenciGirisCikis_ID);
          cmd.Parameters.Add(":o_giris", o_giris);
          cmd.Parameters.Add(":o_tarih", o_tarih);
          cmd.Parameters.Add(":o_izin", o_izin);
          cmd.Parameters.Add(":ogrenci_Id", ogrenci_Id);
          try
          {
              MessageBox.Show("Giriş Çıkış Başarıyla Eklenmiştir");
              cmd.ExecuteNonQuery();
          }
          catch (Exception)
          {
              MessageBox.Show("Giriş Çıkış Ekleme Hatası");
              throw;
          }
      }

//------------------------------------------DATA GRID VIEW İŞlEMLERİ----------------------------------------------------
      public void ogrenciCekme(string tc) 
      {
          baglantiAc();
          OracleCommand cmd = new OracleCommand(@"Select OgrenciAd,OgrenciSoyad,OgrenciTC,OgrenciKanGrubu,OgrenciTel,OgrenciAdres,OgrenciMail,OgrenciOgretim
                                                    FROM Ogrenci");
         cmd.Parameters.Add(":tc",tc);
         var dr = cmd.ExecuteReader();

         while (dr.Read())
         {
             
         }
      }

      /*-------------------------PERSONEL SİL-----------------------------------*/
      public void PersonelSil(String perID)
      {
          OracleCommand cmd = new OracleCommand(@"DELETE FROM PERSONEL WHERE PERSONELID=:perID", baglan);

          cmd.Parameters.Add(":perID", perID);
          try
          {
              baglantiAc();
              cmd.ExecuteNonQuery();
              MessageBox.Show("Personel Başarıyla Silinmiştir");
              baglantiKapat();
          }
          catch (Exception)
          {
              MessageBox.Show("Personel Silme Hatası");
              throw;
          }
      }

        //---------------------------------

      public void personelEkle(string PersonelAd, string PersonelSoyad, string Kidem, string Tel, string Adres, string Maas, string Yetki,string Sifre,string Yurt)
      {

          OracleCommand cmd = new OracleCommand("PROC_PER_EKLE", baglan);
          cmd.CommandType = CommandType.StoredProcedure;

          cmd.Parameters.Add("Personel_Ad", OracleDbType.NVarchar2).Value = PersonelAd;
          cmd.Parameters.Add("Personel_Soyad", OracleDbType.NVarchar2).Value = PersonelSoyad;
          cmd.Parameters.Add("Personel_Kidem", OracleDbType.NVarchar2).Value = Kidem;
          cmd.Parameters.Add("Personel_Tel", OracleDbType.NVarchar2).Value = Tel;
          cmd.Parameters.Add("Personel_Adres", OracleDbType.NVarchar2).Value = Adres;
          cmd.Parameters.Add("Personel_Maas", OracleDbType.Int16).Value = Maas;
          cmd.Parameters.Add("Personel_Yetki", OracleDbType.NVarchar2).Value = Yetki;
          cmd.Parameters.Add("Personel_Sifre", OracleDbType.NVarchar2).Value = Yetki;
          cmd.Parameters.Add("YURT_ID", OracleDbType.Int16).Value = Yurt;

          /* try
           {*/
          baglantiAc();
          //cmd.Transaction.Commit();
          cmd.ExecuteNonQuery();
          //Id = cmd.ExecuteScalar().ToString();

          MessageBox.Show("Personel Başarıyla Eklenmiştir");
          /*}
          catch (Exception)
          {
              MessageBox.Show("Personel Ekleme Hatası");
              throw;
          }*/
          baglantiKapat();



      }
        

        /*------------------------------BİTİŞ-----------------------------------------**/

        /*------------------------------PERSONEL GÜNCELLE-----------------------------------*/
      public void personelGuncelle(String id,string PersonelAd, string PersonelSoyad, string Kidem, string Tel, string Adres, string Maas, string Yetki, string Sifre, string Yurt)
      {

          OracleCommand cmd = new OracleCommand("PROC_PER_GUNCELLE", baglan);
          cmd.CommandType = CommandType.StoredProcedure;

          cmd.Parameters.Add("Personel_ID", OracleDbType.NVarchar2).Value = id;
          cmd.Parameters.Add("Personel_Ad", OracleDbType.NVarchar2).Value = PersonelAd;
          cmd.Parameters.Add("Personel_Soyad", OracleDbType.NVarchar2).Value = PersonelSoyad;
          cmd.Parameters.Add("Personel_Kidem", OracleDbType.NVarchar2).Value = Kidem;
          cmd.Parameters.Add("Personel_Tel", OracleDbType.NVarchar2).Value = Tel;
          cmd.Parameters.Add("Personel_Adres", OracleDbType.NVarchar2).Value = Adres;
          cmd.Parameters.Add("Personel_Maas", OracleDbType.Int16).Value = Maas;
          cmd.Parameters.Add("Personel_Yetki", OracleDbType.NVarchar2).Value = Yetki;
          cmd.Parameters.Add("Personel_Sifre", OracleDbType.NVarchar2).Value = Yetki;
          cmd.Parameters.Add("YURT_ID", OracleDbType.Int16).Value = Yurt;

          /* try
           {*/
          baglantiAc();
          //cmd.Transaction.Commit();
          cmd.ExecuteNonQuery();
          //Id = cmd.ExecuteScalar().ToString();

          MessageBox.Show("Personel Başarıyla Eklenmiştir");
          /*}
          catch (Exception)
          {
              MessageBox.Show("Personel Ekleme Hatası");
              throw;
          }*/
          baglantiKapat();

      }
        /*------------------------------BİTİŞ-----------------------------------------**/
     public String yatakId;
      public void YatakGoster()
      {
          baglantiAc();
          OracleCommand cmd = new OracleCommand(@"
          SELECT Y.YATAKID,Y.YATAKNUMRASI,O.ODANUMARASI,O.KISISAYISI FROM YATAK Y INNER JOIN ODA O ON Y.ODAID = O.ODAID 
            Where
            Y.YATAKDURUM = 0
          ", baglan);
          da = new OracleDataAdapter(cmd);
          dt = new DataTable();
          da.Fill(dt);        

      }


        /*------------------------------BİTİŞ-----------------------------------------**/
   

/*****************************************************************************************************************************\
\***************************************************** LOGIN *****************************************************************/

      public string login(string kullaniciAdi, string sifre) 
      {
          //girilen kullanıcı adından yetkisine bakılacak ve kullanıcıdaki sifre ile girilen sifre esit mi diye bakılacak
          OracleCommand cmd = new OracleCommand("LOGIN", baglan);
          cmd.CommandType = CommandType.StoredProcedure;

          cmd.Parameters.Add("kADI", OracleDbType.NVarchar2).Value = kullaniciAdi;
          cmd.Parameters.Add("kSIFRE", OracleDbType.NVarchar2).Value = sifre;

          OracleParameter parametre = new OracleParameter();
          parametre = cmd.Parameters.Add("kYETKI", OracleDbType.NVarchar2, ParameterDirection.Output);
          parametre.Size = 15;
              baglantiAc();
              cmd.ExecuteNonQuery();
              baglantiKapat();
              return parametre.Value.ToString();
          
      }
      /*ARAMA METODU PROCEDURE İLE */
      public String ad, soyad, kan, tel, adres, mail, ogretim, yatak;
     public void ara(String ogr_id)
     {
         OracleCommand cmd = new OracleCommand("OGRENCIARA", baglan);
         cmd.CommandType = CommandType.StoredProcedure;

         cmd.Parameters.Add("OGRENCI_TC", OracleDbType.NVarchar2).Value = ogr_id;
         cmd.Parameters.Add("OGRENCI_AD", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
         cmd.Parameters["OGRENCI_AD"].Size = 20;
         cmd.Parameters.Add("OGRENCI_SOYAD", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
         cmd.Parameters["OGRENCI_SOYAD"].Size = 20;
         cmd.Parameters.Add("OGRENCI_KANGRUBU", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
         cmd.Parameters["OGRENCI_KANGRUBU"].Size = 20;
         cmd.Parameters.Add("OGRENCI_TEL", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
         cmd.Parameters["OGRENCI_TEL"].Size = 20;
         cmd.Parameters.Add("OGRENCI_ADRES", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
         cmd.Parameters["OGRENCI_ADRES"].Size = 20;
         cmd.Parameters.Add("OGRENCI_MAIL", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
         cmd.Parameters["OGRENCI_MAIL"].Size = 20;
         cmd.Parameters.Add("OGRENCI_OGRETIM", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
         cmd.Parameters["OGRENCI_OGRETIM"].Size = 20;
         cmd.Parameters.Add("YATAK_ID", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
         cmd.Parameters["YATAK_ID"].Size = 20;
         baglantiAc();
         cmd.ExecuteNonQuery(); 
         ad = cmd.Parameters["OGRENCI_AD"].Value.ToString();
         soyad = cmd.Parameters["OGRENCI_SOYAD"].Value.ToString();
         kan = cmd.Parameters["OGRENCI_KANGRUBU"].Value.ToString();
         tel = cmd.Parameters["OGRENCI_TEL"].Value.ToString();
         adres = cmd.Parameters["OGRENCI_ADRES"].Value.ToString();
         mail = cmd.Parameters["OGRENCI_MAIL"].Value.ToString();
         ogretim = cmd.Parameters["OGRENCI_OGRETIM"].Value.ToString();
         yatak = cmd.Parameters["YATAK_ID"].Value.ToString();
         baglantiKapat();
     }
    }
}
