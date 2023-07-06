using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MeyveToplamaOyunu
{
    public partial class Yönetim : Form
    {
        public Yönetim()
        {
            InitializeComponent();
        }
        Baglanti b = new Baglanti();

        SqlDataAdapter adapter;
        DataTable tablo;
        private void Yönetim_FormClosed(object sender, FormClosedEventArgs e)
        {
            Giris g = new Giris();
            g.Show();
            this.Hide();
        }
        public void güncelle(int id)
        {
            try
            {
                if (b.conn.State == ConnectionState.Closed)
                    b.conn.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "UPDATE kullanici SET kullanıcıAdi = @kullanıcıAdi , email=@email , sifre=@sifre , erisim=@erisim where id= " + id;
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, b.conn);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@kullanıcıAdi", txtkullanıcı.Text);
                komut.Parameters.AddWithValue("@email", txteposta.Text);

                komut.Parameters.AddWithValue("@sifre", txtsifre.Text);
                if (checkBox1.Checked == true)
                    komut.Parameters.AddWithValue("@erisim", 1);
                else
                    komut.Parameters.AddWithValue("@erisim", 0);



                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                b.conn.Close();
                MessageBox.Show("Güncelleme İşlemi Gerçekleşti.");
                txtsifre.Text = "";
                txteposta.Text = "";
                txtkullanıcı.Text = "";
                KullanıcılarıGetir();
            }

            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        void KullanıcılarıGetir()
        {

            adapter = new SqlDataAdapter("SELECT id,kullanıcıAdi,email,sifre,erisim FROM kullanici", b.conn);
            tablo = new DataTable();
            b.conn.Open();
            adapter.Fill(tablo);

            dataGridView1.ForeColor = Color.Black;
            dataGridView1.GridColor = Color.Gray;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = tablo;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            b.conn.Close();

        }
        private void Yönetim_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = b.KullaniciListele();
        }
        int a;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            a = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            if (e.ColumnIndex == 0)
                sil(a);
            else
            {
                secılenoyuncu(a);
                txtkullanıcı.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txteposta.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtsifre.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() == "1")
                {
                    checkBox1.Checked = true;
                }
                else
                    checkBox1.Checked = false;
            }



        }
        public int aos;
        public void sil(int id)
        {

            try
            {
                if (b.conn.State == ConnectionState.Closed)
                    b.conn.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "Delete From kullanici where id=" + id;
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, b.conn);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.


                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                b.conn.Close();
                MessageBox.Show("silme işlemi gerçekleşti.");
                dataGridView1.DataSource = b.KullaniciListele();
            }

            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.oturumsahibi = aos;
            anasayfa.Show();

        }
        public void secılenoyuncu(int id)
        {
            adapter = new SqlDataAdapter("SELECT k.kullanıcıAdi, s.skor, s.tarih FROM kullanici as k inner join skorlar as s on k.id = s.kıd where s.kıd=" + id, b.conn);
            tablo = new DataTable();
            b.conn.Open();
            adapter.Fill(tablo);


            dataGridView2.DataSource = tablo;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            b.conn.Close();

        }

        private void BTNGUNCELLE_Click(object sender, EventArgs e)
        {

            güncelle(a);

        }
        private bool kullanıcıkontrol(string kadı, string mail)
        {
            SqlCommand cmd = new SqlCommand();
            b.conn.Open();
            cmd.Connection = b.conn;
            cmd.CommandText = "select * from kullanici where email='" + mail + "' or kullanıcıAdi='" + kadı + "'";
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                b.conn.Close();
                return false;
            }


            else
            {
                b.conn.Close();
                return true;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();
            k.kullaniciadi = txtkullanıcı.Text;
            k.email = txteposta.Text;
            k.sifre = txtsifre.Text;
            if (checkBox1.Checked == true)
            {
                k.erisim = 1;
            }
            else
                k.erisim = 0;
            try
            {
                if (txtsifre.Text.Length < 8)
                {
                    MessageBox.Show("şifre en az 8 karakterden oluşmalı");
                }
                else if (kullanıcıkontrol(txtkullanıcı.Text, txteposta.Text))
                {
                    //b.conn.Open();
                    //// Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                    //string kayit = "insert into kullanici(kullanıcıAdi, email,sifre,erisim) values (@kadı,@email,@sifre,@erisim)";
                    //// müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                    //SqlCommand komut = new SqlCommand(kayit, b.conn);
                    //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.

                    b.KullanıcıEkle(k);

                    ////Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                    //komut.ExecuteNonQuery();
                    ////Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                    //b.conn.Close();
                    //MessageBox.Show("Kayıt İşlemi Gerçekleşti.");
                    txtsifre.Text = "";
                    txteposta.Text = "";
                    txtkullanıcı.Text = "";

                    KullanıcılarıGetir();
                }
                else
                    MessageBox.Show("Uyarı! halihazırda bu  kullanıcı adı veya e-mail adresine sahip bir kayıt var..! ");
            }

            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
    }
}
