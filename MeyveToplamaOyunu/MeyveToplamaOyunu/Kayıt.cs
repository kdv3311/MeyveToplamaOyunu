using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;

namespace MeyveToplamaOyunu
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();
        }

        Baglanti b = new Baglanti();

        //girilen bilgiler şartlara uygun ise kayıt işlemini gerceklestiriyoruz
        private void button1_Click(object sender, EventArgs e)
        {
            if (kullanıcıadıkontrol(kullanıcıadi.Text))
            {
                if (Email_Format_Kontrol(txteposta.Text))
                {
                    if (txtsifre.Text.Length < 8)
                    {
                        MessageBox.Show("Şifre en az 8 karakterden oluşmalıdır...!!!!!");
                    }
                    else
                    {
                        if (txtsifre.Text.ToString() == txtsifretekrar.Text.ToString())
                        {
                            Kullanici k = new Kullanici();
                            k.kullaniciadi = kullanıcıadi.Text;
                            k.email = txteposta.Text;
                            k.sifre = txtsifre.Text;
                            k.erisim = 0;
                            b.KullanıcıEkle(k);
                            Giris g=new Giris();
                            g.Show();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("Lütfen şifrenizi kontrol ediniz ...!!!!");

                    }

                }
                else
                {
                    MessageBox.Show("lütfen geçerli bir e posta giriniz..!");
                    txteposta.Focus();
                }
            }

        }

        //mail adresi dogru formattamı diye kontrol edip işleme onay veriyoruz
        public static bool Email_Format_Kontrol(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Kayıt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

        private void Kayıt_Load(object sender, EventArgs e)
        {

        }

        //girilen bilgilerle aynı ısme veyahut maile sahıp kullanıcı varsa kayıta izin verimiyoruz
        public bool kullanıcıadıkontrol(string kullanıcı)
        {
            SqlCommand cmd = new SqlCommand();
            b.conn.Open();
            cmd.Connection = b.conn;
            cmd.CommandText = "select * from kullanici where kullanıcıAdi='" + kullanıcı + "'";
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {


                b.conn.Close();
                MessageBox.Show("Kullanıcı adı başka bir kişi tarafından kullanılmakta");
                kullanıcıadi.Focus();
                return false;




            }
            else
            {


                b.conn.Close();
                return true;
            }

        }
        private void txtsifretekrar_TextChanged(object sender, EventArgs e)
        {
            if (txtsifre.Text.ToString() != txtsifretekrar.Text.ToString())
            {
                label2.Text = "Şifreler eşleşmiyor.";
                label2.ForeColor = Color.Red;
            }
            else
            {
                label2.Text = "Şifreler eşleşti";
                label2.ForeColor = Color.Green;

            }
        }
    }
}
