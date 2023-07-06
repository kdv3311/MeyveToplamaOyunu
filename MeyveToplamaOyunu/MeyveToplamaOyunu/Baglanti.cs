using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MeyveToplamaOyunu
{
    // Baglantı adında bir class oluşturuyoruz ve aynı kodu tekrar yazmamak için burada genel olarak kullanacagımız metotlarımızı yazıyoruz
    internal class Baglanti
    {   //publik erişiminde sql baglantımızı içeren bir connection olusturuyoruz
        public SqlConnection conn = new SqlConnection("server=.; Initial Catalog=meyvetoplamaoyunu;Integrated Security=SSPI");

        //kullanıcı ekleyecegimiz metodu yazıyoruz parametre olarak kullanıcı nesnemizi veriyoruz
        public bool KullanıcıEkle(Kullanici k)
        {


            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "insert into kullanici(kullanıcıAdi, email,sifre,erisim) values (@kadı,@email,@sifre,@erisim)";
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, conn);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@kadı", k.kullaniciadi);
                komut.Parameters.AddWithValue("@email", k.email);
                komut.Parameters.AddWithValue("@sifre", k.sifre);
                komut.Parameters.AddWithValue("@erisim", k.erisim);

                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                conn.Close();
                MessageBox.Show("Kayıt başarılı.");
                return true;
            }

            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                return false;
            }
        }
        //kullanıcı guncellemme metodumuzu yazıyoruz
        //güncelle metodumuzu yazıyoruz kullanıcı nesnemizi parametre olarak veriyoruz burada parametre olarak gelen kullanıcı nesnesinin propertylerinden id kısmını şart olarak kullanıyoruz
        public bool Guncelle(Kullanici k)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "UPDATE kullanici SET kullanıcıAdi = @kullanıcıAdi , email=@email , sifre=@sifre , erisim=@erisim where kullanıcıAdi= '" + k.kullaniciadi + "'";
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, conn);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@kullanıcıAdi", k.kullaniciadi);
                komut.Parameters.AddWithValue("@email", k.email);

                komut.Parameters.AddWithValue("@sifre", k.sifre);
                komut.Parameters.AddWithValue("@erisim", k.erisim);




                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                conn.Close();
                MessageBox.Show("Güncelleme İşlemi Gerçekleşti.");
                return true;
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                return false;
            }

        }

        //sil metodumuzu cagırıyoruz ve parametre olarak id degerini gonderiyoruz silme işleminde veritabanında ki kayıtlardan parametre olarak gönderilen id eşit olan kayıt silinecektir
        public bool sil(int id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string sil = "Delete From kullanici where id=" + id;
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(sil, conn);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.


                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                conn.Close();

                return true;
            }

            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                return false;
            }
        }
        //kullanıcı listelemek için datatable geri dönus tipinde metot yazarak ilgili datagridwiev nesnesine datasource olarak atayacagız
        public DataTable KullaniciListele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT id,kullanıcıAdi,email,sifre,erisim FROM kullanici", conn);
            DataTable tablo = new DataTable();
            conn.Open();
            adapter.Fill(tablo);
            conn.Close();
            return tablo;
        }
        // skorları listelemek için kullanıcı ve skorlar tablosunu join ile birleştirerek kullanıcı adı , skor ,tarih olarak verimizi çekip ilgili datagridwieve datasource olarak atıyoruz
        public DataTable skorlarıListele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT k.kullanıcıAdi, s.skor, s.tarih FROM kullanici as k inner join skorlar as s on k.id = s.kıd ", conn);
            DataTable tablo = new DataTable();
            conn.Open();
            adapter.Fill(tablo);
            conn.Close();
            return tablo;
        }
        //veri tabanında yeni girilen mail adresi ile aynı olan adres var mi diye kontrol etmek için mail kontrol metodumuzu yazıyoruz
        public bool mailKontrol(string mail)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from kullanici where email='" + mail + "'";
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                conn.Close();
                return true;
            }
            else
            {
                MessageBox.Show("BU E-POSTAYA AİT KULLANICI BULUNAMADI...!!");
                conn.Close();

                return false;
            }
        }
        //admin panelinde seçilen oyuncunun parametresini seçılenoyuncu metoduna göndererek ilgili kullanıcının skor bilgilerini çekiyoruz
        public DataTable secılenoyuncu(int id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT k.kullanıcıAdi, s.skor, s.dtarih FROM kullanici as k inner join skorlar as s on k.id = s.id where s.id=" + id, conn);
            DataTable tablo = new DataTable();
            conn.Open();
            adapter.Fill(tablo);

            conn.Close();
            return tablo;
        }
        //skor kaydet metodu ile  parametre olarak gönderilen id ve skorr degerlerini alarak ilgili id sahip oyuncu için veritabanına skorr olarak gelen parametreyi ekliyoruz
        public bool skorKaydet(int id, int skorr)
        {

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                    string kayit = "insert into skorlar (kıd, skor,tarih) values (@kıd,@skor,@tarih)";
                    // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                    SqlCommand komut = new SqlCommand(kayit, conn);
                    //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                    komut.Parameters.AddWithValue("@kıd", id);
                    komut.Parameters.AddWithValue("@skor", skorr.ToString());
                    komut.Parameters.AddWithValue("@tarih", String.Format("{0:g}", DateTime.Now));


                    //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                    komut.ExecuteNonQuery();
                    //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                    conn.Close();
                    MessageBox.Show("Oyun bitti, skorunuz kaydedildi. :)");
                    return true;
                }
               

            }

            catch (Exception hata)
            {
                conn.Close();
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                return false;
            }
            return false;


        }
        
        
    }
}
