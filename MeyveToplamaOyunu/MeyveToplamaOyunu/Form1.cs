using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeyveToplamaOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        int sorusayısı = 5;
        int seviye = 1;
        int skor = 0;
        byte hak = 3;
        bool suruklenmedurumu = false; //Class seviyesinde bir field(değişken) tanımlıyoruz ki,MouseDown da biz bunu true yapacağız,MouseUpta false değerini alacak ve MouseMove eventında true ise hareket edecek.     
        Point ilkkonum; //Global bir değişken tanımlıyoruz ki, ilk tıkladığımız andaki konumunu çıka
        Baglanti a = new Baglanti();
        private void Form1_Load(object sender, EventArgs e)
        {
            lblsoru.Text = "";
            oturum();
            //baslangıc();
            button1.Parent = pictureBox1;
            button1.BackColor = Color.Transparent;
            button2.Parent = pictureBox1;
            button2.BackColor = Color.Transparent;
            button3.Parent = pictureBox1;
            button3.BackColor = Color.Transparent;
            button4.Parent = pictureBox1;
            button4.BackColor = Color.Transparent;
            button5.Parent = pictureBox1;
            button5.BackColor = Color.Transparent;
            pictureBox5.Parent = pictureBox1;
            pictureBox5.BackColor = Color.Transparent;
            butonlar.Add(button1);
            butonlar.Add(button2);
            butonlar.Add(button3);
            butonlar.Add(button4);
            butonlar.Add(button5);
            timer1.Interval = 1000;
            lblsüre.BackColor = Color.YellowGreen;
            lblsüre.ForeColor = Color.Gray;
            baslangıc();

            listBox1.Items.Add("- Oyun başla alanına tıklandığında oyun başlar.");
            listBox1.Items.Add("- Her soru için 20 saniye süre vardır.");
            listBox1.Items.Add("- Sırasıyla bir , iki ve üçüncü seviyeler vardır.");
            listBox1.Items.Add("- 20 saniye içinde soruya cevap verilmez ise sistem bir sonraki soruya otomatik geçer.");
            listBox1.Items.Add("- Her aşamada sırasıyla 5 ,10 ve 15 soru vardır.");
            listBox1.Items.Add("- Her aşama için 3 yanlış cevap hakkı vardır.");
            listBox1.Items.Add("- Her doğru cevap için +1 puan yanlış cevap içinse -1 puan yazılır");
            listBox1.Items.Add("- Her yeni aşamaya geçildiğinde yanlış cevap hakkı 3 olarak güncellenir.");
            listBox1.Items.Add("- 3 cevap hakkını dolduran veya oyunun son sonuna gelindiğinde oyun biter");
            listBox1.Items.Add("- Oyun bittiğinde skorunuz güncel tarih bilgisi ile veritabanına kaydedilir.");

            listBox1.Hide();



        }
        private void baslangıc()
        {

            lblsorusayısı.Text = "";
            lblseviye.Text = "";
            lblskor.Text = "";
            lblsoru.Text = "";
            obaslat.Enabled = true;
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.GridColor = Color.Gray;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = a.skorlarıListele();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true;

        }
        public string[] islemler = new string[] { "+", "-", "*", "/" };
        float cevap;
        string soru;
        //soru uret metodumuzda seviye şartına göre rastgele sayılarımızı uretip hesapla metoduna gonderiyoruz
        public void soruUret()
        {
            Random rnd = new Random();

            if (seviye == 1)
            {

                hesapla(rnd.Next(1, 100), rnd.Next(1, 100), islemler[rnd.Next(0, 2)]);

                if (sorusayısı == 1)
                {
                    sorusayısı = 11;
                    seviye = 2;
                    hak = 3;
                }
            }
            else if (seviye == 2)
            {

                hesapla(rnd.Next(1, 100), rnd.Next(1, 100), islemler[rnd.Next(2, 4)]);
                if (sorusayısı == 1)
                {
                    sorusayısı = 16;
                    seviye = 3;
                    hak = 3;
                }
            }
            else if (seviye == 3)
            {

                if (sorusayısı == 1)
                {
                    oyunSonu();
                }
                else
                {
                    hesapla(rnd.Next(1, 100), rnd.Next(1, 100), islemler[rnd.Next(0, 4)]);

                }




            }
            lblseviye.Text = seviye.ToString();


        }
        List<Button> butonlar = new List<Button>();
        int dogrucvp;
        public int oturumsahibi;
        //verileri yaz metodumuzda sorunun dogru cevabını parametre olarak gonderiyoruz oyundakı 5 elmanın rastgele birine dogru cevabı yazdırıp
        //diğer elmalara da doğru cevap ile aynı basamak sayısına sahip başka sayılar yazdırıyoruz
        public void verileriyaz(float cevap)
        {
            lblsoru.Text = soru;
            string seçenek = "";
            Random r = new Random();
            dogrucvp = r.Next(0, 5);
            for (int i = 0; i < butonlar.Count; i++)
            {
                if (dogrucvp == i)
                {
                    butonlar[i].Text = cevap.ToString();
                    continue;
                }

                for (int j = 0; j < cevap.ToString().Length; j++)
                {
                    seçenek += r.Next(0, 10).ToString();
                }
                butonlar[i].Text = seçenek;
                seçenek = "";
            }


        }
        //hesapla metodumuzda 1.sayı 2. sayı ve işlem tipini parametre olarak gödererek il başta soruyu string olarak yazdırmak için değişkene atıyoruz daha sonra gönderilen
        //işlem tipine göre hesaplamayı yapıp verileri yaz metoduna dogru cevabı gonderiyoruz
        public float hesapla(int s1, int s2, string islem)
        {

            soru = s1.ToString() + " " + islem + " " + s2.ToString() + " =?";

            switch (islem)
            {
                case "+":
                    cevap = s1 + s2;
                    break;
                case "-":
                    cevap = s1 - s2;
                    break;
                case "/":
                    cevap = s1 / s2;
                    break;
                case "*":
                    cevap = s1 * s2;
                    break;

            }
            if (s1 < s2 || s1 % s2 != 0)
            {
                soruUret();
            }


            verileriyaz(cevap);
            return cevap;
        }
        Point duzen;
        
        private void MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            suruklenmedurumu = true; //işlemi burada true diyerek başlatıyoruz.
            button.Cursor = Cursors.SizeAll; //SizeAll yapmamımızın amacı taşırken hoş görüntü vermek için
            ilkkonum = e.Location; //İlk konuma gördüğünüz gibi değerimizi atıyoruz.
            duzen = button.Location;
        }
        public void MouseMove(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if (suruklenmedurumu) // suruklenmedurumu==true ile aynı.
            {
                button.Left = e.X + button.Left - (ilkkonum.X);
                // button.left ile soldan uzaklığını ayarlıyoruz. Yani e.X dediğimizde buton üzerinde mouseun hareket ettiği pixeli alacağız + butonun soldan uzaklığını ekliyoruz son olarakta ilk mouseın tıklandığı alanı çıkarıyoruz yoksa butonun en solunda olur mouse imleci. Alttakide aynı şekilde Y koordinati için geçerli
                button.Top = e.Y + button.Top - (ilkkonum.Y);

            }

        }
        bool oyundurumu = true;
        private void MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            suruklenmedurumu = false; //Sol tuştan elimizi çektik artık yani sürükle işlemi bitti.

            if (button.Location.X > 452 && button.Location.Y > 428 && button.Text != "")
            {
                cevapKontrol(cevap, button);
                timer1.Stop();
                if (oyundurumu)
                {
                    timer1.Start();
                }

                progressBar1.Value = 100;
                saniye = 20;
                //button.Location = duzen;
            }
            else
            {

                button.Cursor = Cursors.Default; //İmlecimiz(Cursor) default değerini alıyor.
                button.Location = duzen;
            }
            button.Location = duzen;




        }
        //sisteme girdikten sonra oturum sahibinin kullanıcı adı bilgisini ilgili alana yazdırıyoruz
        private void oturum()
        {
            SqlCommand cmd = new SqlCommand();
            a.conn.Open();
            cmd.Connection = a.conn;
            cmd.CommandText = "select * from kullanici where id=" + oturumsahibi;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                oyuncuadı.Text = rd["kullanıcıAdi"].ToString();
            }
            a.conn.Close();

        }
        //cevap kontrol metodunda double ve button nesnesi parametresini veriyoruz gelen buttonun değeri ile dogru cevabın değerini karşılaştırıp ilgili işlemi yapıyoruz
        private void cevapKontrol(double c, Button btn)
        {

            if (sorusayısı != 0 && hak != 0)
            {

                if (c.ToString() == btn.Text)
                {

                    skor++;
                    soruUret();

                }
                else if (hak == 1)
                {
                    skor--;
                    hak--;
                    oyunSonu();
                    hakkontrol(hak);

                }
                else
                {
                    skor--;
                    hak--;
                    soruUret();
                    hakkontrol(hak);
                }

                sorusayısı--;
                durumbilgisi();
                //lblsorusayısı.Text = sorusayısı.ToString();
                //lblhak.Text = hak.ToString();
                //lblskor.Text = skor.ToString();

            }
            else
                oyunSonu();

        }
        //kullanıcının haklarını kontrol ediyoruz
        private void hakkontrol(int hak)
        {
            PictureBox[] pboxlar = { pkalp1, pkalp2, pkalp3 };
            for (int i = 0; i < pboxlar.Length; i++)
            {

                if (hak == 2)
                {
                    pboxlar[2].Hide();
                    break;
                }
                else if (hak == 1)
                {
                    pboxlar[1].Hide();
                    break;
                }
                else
                    pboxlar[0].Hide();
            }
        }
        //herhangi bir şekilde oyun sonlndıgı zaman kullanmak uzere oyun sonu metodumuzu yazıyoruz ve skor kaydet metodunu kullanarak kullanıcının skorunu kaydediyoruz ve başlangıc durumuna geçiyoruz
        private void oyunSonu()
        {
            timer1.Stop();
            a.skorKaydet(oturumsahibi, skor);
            foreach (Button p in butonlar)
            {
                p.Text = "";
            }
            lblsoru.Text = "";
            skor = 0;
            lblsüre.Text = "";
            baslangıc();
            başlangıçd();
            oyundurumu = false;

        }
        void başlangıçd()
        {

            sorusayısı = 6;
            seviye = 1;
            skor = 0;
            hak = 3;

        }
        private void durumbilgisi()
        {


            lblskor.Text = skor.ToString();
            lblsorusayısı.Text = sorusayısı.ToString();
            lblseviye.Text = seviye.ToString();
        }



        private void pictureBox5_DragEnter(object sender, DragEventArgs e)
        {

        }
        bool b = true;
        private void obaslat_Click(object sender, EventArgs e)
        {

            obaslat.Enabled = false;
            if (b == false)
            {
                baslangıc();
            }

            soruUret();
            durumbilgisi();
            timer1.Start();
            oyundurumu = true;
            pkalp1.Show();
            pkalp2.Show();
            pkalp3.Show();




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        int saniye = 20;
        //suremızı kontol için timer nesnesının tick olayına sure kontrol kodlarımızı yazıyoruz 
        private void timer1_Tick(object sender, EventArgs e)
        {

            saniye--;
            lblsüre.Text = saniye.ToString() + " Saniye";
            progressBar1.Value -= 100 / 20;
            if (saniye == 0)
            {
                timer1.Stop();
                soruUret();
                sorusayısı--;
                saniye = 20;
                progressBar1.Value = 100;
                durumbilgisi();
                timer1.Start();
            }
            else if (sorusayısı == 0)
            {
                timer1.Stop();
                oyunSonu();
            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Giris g = new Giris();
            g.Show();
            this.Hide();

        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            listBox1.Show();
        }

        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            listBox1.Hide();
        }
    }
}
