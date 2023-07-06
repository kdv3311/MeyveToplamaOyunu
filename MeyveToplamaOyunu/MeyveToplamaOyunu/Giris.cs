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

namespace MeyveToplamaOyunu
{
    public partial class Giris : Form
    {

        public Giris()
        {
            InitializeComponent();
            Init_Data();
        }
        Baglanti b = new Baglanti();

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        //kayıt kısmına tıklandıgında kayıt formuna yonlendırıyoruz
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kayıt kayıt = new Kayıt();
            kayıt.Show();
            this.Hide();
        }
        //beni hatırla bolumu için ınıt data ve save dataya ilgili bilgileri veriyoruz
        private void Init_Data()
        {
            if (Properties.Settings.Default.kullanıcıadı != string.Empty)
            {
                if (Properties.Settings.Default.remember == true)
                {
                    kullanıcıadi.Text = Properties.Settings.Default.kullanıcıadı;
                    txtsifre.Text = Properties.Settings.Default.sifre;
                    checkBox1.Checked = true;
                }
                else
                {
                    kullanıcıadi.Text = Properties.Settings.Default.kullanıcıadı;
                }
            }
        }
        private void Save_Data()
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.kullanıcıadı = kullanıcıadi.Text.Trim();
                Properties.Settings.Default.remember = true;
                Properties.Settings.Default.sifre = txtsifre.Text.Trim();
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.kullanıcıadı = "";
                Properties.Settings.Default.sifre = "";
                Properties.Settings.Default.remember = false;
                Properties.Settings.Default.Save();
            }
        }
        private void Giris_Load(object sender, EventArgs e)
        {

        }

        //giriş kısmnda giren bilgiler ile kullanıcı kontrolu yapıp ilgili forma gönceriyoruz
        private void giris()
        {
            if (kullanıcıadi.Text != "" && txtsifre.Text != "")
            {
                SqlCommand cmd = new SqlCommand();
                b.conn.Open();
                cmd.Connection = b.conn;
                cmd.CommandText = "select * from kullanici where kullanıcıAdi='" + kullanıcıadi.Text + "' and sifre='" + txtsifre.Text + "'";
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {

                    if (Convert.ToInt32(rd["erisim"]) == 1)
                    {
                        Yönetim y = new Yönetim();
                        y.aos = Convert.ToInt32(rd["id"].ToString());
                        y.Show();
                        b.conn.Close();
                        this.Hide();
                    }
                    else
                    {
                        Form1 anasayfa = new Form1();
                        anasayfa.oturumsahibi = Convert.ToInt32(rd["id"].ToString());
                        anasayfa.Show();
                        b.conn.Close();
                        this.Hide();
                    }
                }
                else
                {

                    MessageBox.Show("girdiğiniz bilgiler hatalı veya eksik...!!");
                    b.conn.Close();

                }
            }
            else
            {
                MessageBox.Show("lütfen boş alanları doldurunuz..!");
                b.conn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            giris();
            Save_Data();


        }
        //şifremi unuttum kısmına tıklandıgında şifre yenıleme formuna yonlendırıyoruz
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KurtarmaEkranı kur = new KurtarmaEkranı();
            kur.Show();
        }

        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
