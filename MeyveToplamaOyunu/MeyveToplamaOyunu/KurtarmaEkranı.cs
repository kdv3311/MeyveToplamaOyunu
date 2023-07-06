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
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Configuration;
using System.Web;



namespace MeyveToplamaOyunu
{
    public partial class KurtarmaEkranı : Form
    {
        public KurtarmaEkranı()
        {
            InitializeComponent();
        }


        Baglanti b = new Baglanti();
        //eger mail adresi sistemde varsa mail gonderme işlemini gerceklestiriyoruz
        private void button1_Click(object sender, EventArgs e)
        {
            if (textkurtarma.Text != "")
            {
                if (kullanıcıkontrol())
                {
                    mailgonder(textkurtarma.Text, kodolustur());
                    textkurtarma.Text = "";
                    textkurtarma.Focus();
                    btnkod.Show();
                }


            }
            else
                MessageBox.Show("BURASI BOŞ GEÇİLEMEZ..!");
        }
        public int id;
        //girilen e posta sistemde kayıtlı ise sifre yenıleme kodunun gonderilmesine onay veriyoruz
        public bool kullanıcıkontrol()
        {

            if (textkurtarma.Text != "")
            {
                SqlCommand cmd = new SqlCommand();
                b.conn.Open();
                cmd.Connection = b.conn;
                cmd.CommandText = "select * from kullanici where email='" + textkurtarma.Text + "'";
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {

                    id = Convert.ToInt32(rd[id].ToString());
                    textkurtarma.PlaceholderText = "KODU GİRİNİZ";
                    kodg.Name = "kod";
                    b.conn.Close();

                    return true;


                }
                else
                {
                    MessageBox.Show("BU E-POSTAYA AİT KULLANICI BULUNAMADI...!!");
                    b.conn.Close();

                    return false;
                }
            }
            else
            {
                MessageBox.Show("BOŞ GEÇİLEMEZ...!!");
                b.conn.Close();

                return false;
            }



        }


        //---------------------KURTARMA EPOSTASI GÖNDERME-----------------------------------

        public void mailgonder(string ma, string kod)
        {


            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;

            sc.Credentials = new NetworkCredential("tarihbilincix1@gmail.com", "hcsxmkqmpnbmhpns");

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("tarihbilincix1@gmail.com", "KURTARMA E-POSTASI");

            mail.To.Add(ma);


            mail.Subject = "KURTARMA";
            mail.IsBodyHtml = true;
            mail.Body = "KURTARMA KODUNUZ :" + kod;

            sc.Send(mail);

            kodg.Hide();
        }
        string a = "";
        //sifre yenıleme için kod olusturuyoruz
        public string kodolustur()
        {
            a = "";
            Random sayı = new Random();
            for (int i = 0; i <= 5; i++)
            {
                a += sayı.Next(1, 10).ToString();
            }
            return a;
        }
        private void KurtarmaEkranı_Load(object sender, EventArgs e)
        {
            btnkod.Hide();

        }
        //girilen sifre dogru ise yenı sifre yazılacak forma gonderiyoruz
        private void btnkod_Click(object sender, EventArgs e)
        {
            if (textkurtarma.Text == a)
            {

                Sifreyenilecs sy = new Sifreyenilecs();
                sy.Show();
                sy.idd = id;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girilen Kod hatalı");
                textkurtarma.Text = "";
                textkurtarma.Focus();
            }

        }

        //-----------------------------------------------------------------------------

    }

}

