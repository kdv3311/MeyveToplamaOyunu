using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MeyveToplamaOyunu
{
    public partial class Sifreyenilecs : Form
    {
        public Sifreyenilecs()
        {
            InitializeComponent();
        }
        public int idd;
        private void Sifreyenilecs_Load(object sender, EventArgs e)
        {

        }
        Baglanti b = new Baglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtsifre.Text.Length >= 8)
            {

                try
                {
                    if (b.conn.State == ConnectionState.Closed)
                        b.conn.Open();
                    // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                    string kayit = "UPDATE kullanici SET sifre=@sifre  where id= " + idd;
                    // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                    SqlCommand komut = new SqlCommand(kayit, b.conn);
                    //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.


                    komut.Parameters.AddWithValue("@sifre", txtsifre.Text);




                    //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                    komut.ExecuteNonQuery();
                    //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                    b.conn.Close();
                    MessageBox.Show("Şifre güncelleme İşlemi Gerçekleşti.");

                    this.Hide();

                }

                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
            else
            {
                MessageBox.Show("Şifreniz en az 8 karakterden oluşmalıdir.");
            }

        }

        private void Sifreyenilecs_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
