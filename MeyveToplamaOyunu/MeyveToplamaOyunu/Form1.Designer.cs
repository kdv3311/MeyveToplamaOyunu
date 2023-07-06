using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MeyveToplamaOyunu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            pkalp3 = new PictureBox();
            pkalp2 = new PictureBox();
            pkalp1 = new PictureBox();
            lblsorusayısı = new Label();
            label7 = new Label();
            lblskor = new Label();
            lblseviye = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            obaslat = new Button();
            groupBox2 = new GroupBox();
            button5 = new Button();
            ımageList1 = new ImageList(components);
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pictureBox5 = new PictureBox();
            groupBox4 = new GroupBox();
            lblsüre = new Label();
            progressBar1 = new ProgressBar();
            lblsoru = new Label();
            pictureBox1 = new PictureBox();
            elmal4 = new Label();
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            label9 = new Label();
            oyuncuadı = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            linkLabel1 = new LinkLabel();
            listBox1 = new ListBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pkalp3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pkalp2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pkalp1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(224, 224, 224);
            groupBox1.Controls.Add(pkalp3);
            groupBox1.Controls.Add(pkalp2);
            groupBox1.Controls.Add(pkalp1);
            groupBox1.Controls.Add(lblsorusayısı);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblskor);
            groupBox1.Controls.Add(lblseviye);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(obaslat);
            groupBox1.Location = new Point(799, 40);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(462, 185);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "OYUN AYARLARI";
            // 
            // pkalp3
            // 
            pkalp3.Image = Properties.Resources.kalp;
            pkalp3.Location = new Point(167, 136);
            pkalp3.Name = "pkalp3";
            pkalp3.Size = new Size(26, 23);
            pkalp3.SizeMode = PictureBoxSizeMode.StretchImage;
            pkalp3.TabIndex = 11;
            pkalp3.TabStop = false;
            // 
            // pkalp2
            // 
            pkalp2.Image = Properties.Resources.kalp;
            pkalp2.Location = new Point(135, 136);
            pkalp2.Name = "pkalp2";
            pkalp2.Size = new Size(26, 23);
            pkalp2.SizeMode = PictureBoxSizeMode.StretchImage;
            pkalp2.TabIndex = 10;
            pkalp2.TabStop = false;
            // 
            // pkalp1
            // 
            pkalp1.Image = Properties.Resources.kalp;
            pkalp1.Location = new Point(101, 136);
            pkalp1.Name = "pkalp1";
            pkalp1.Size = new Size(26, 23);
            pkalp1.SizeMode = PictureBoxSizeMode.StretchImage;
            pkalp1.TabIndex = 9;
            pkalp1.TabStop = false;
            // 
            // lblsorusayısı
            // 
            lblsorusayısı.AutoSize = true;
            lblsorusayısı.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblsorusayısı.Location = new Point(104, 102);
            lblsorusayısı.Name = "lblsorusayısı";
            lblsorusayısı.Size = new Size(23, 25);
            lblsorusayısı.TabIndex = 8;
            lblsorusayısı.Text = "5";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(19, 102);
            label7.Name = "label7";
            label7.Size = new Size(79, 25);
            label7.TabIndex = 7;
            label7.Text = "SORU :";
            // 
            // lblskor
            // 
            lblskor.AutoSize = true;
            lblskor.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblskor.Location = new Point(104, 64);
            lblskor.Name = "lblskor";
            lblskor.Size = new Size(23, 25);
            lblskor.TabIndex = 5;
            lblskor.Text = "0";
            // 
            // lblseviye
            // 
            lblseviye.AutoSize = true;
            lblseviye.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblseviye.Location = new Point(104, 30);
            lblseviye.Name = "lblseviye";
            lblseviye.Size = new Size(23, 25);
            lblseviye.TabIndex = 4;
            lblseviye.Text = "1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(6, 30);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 3;
            label3.Text = "SEVİYE :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(20, 64);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 2;
            label2.Text = "SKOR :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(33, 136);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 1;
            label1.Text = "CAN :";
            // 
            // obaslat
            // 
            obaslat.BackColor = Color.Cyan;
            obaslat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            obaslat.Location = new Point(304, 133);
            obaslat.Name = "obaslat";
            obaslat.Size = new Size(152, 46);
            obaslat.TabIndex = 0;
            obaslat.Text = "OYUNU BAŞLAT";
            obaslat.UseVisualStyleBackColor = false;
            obaslat.Click += obaslat_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.SkyBlue;
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(pictureBox5);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(781, 837);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "OYUN ALANI";
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Popup;
            button5.ImageIndex = 0;
            button5.ImageList = ımageList1;
            button5.Location = new Point(627, 205);
            button5.Name = "button5";
            button5.Size = new Size(97, 115);
            button5.TabIndex = 20;
            button5.UseVisualStyleBackColor = true;
            button5.MouseDown += MouseDown;
            button5.MouseMove += MouseMove;
            button5.MouseUp += MouseUp;
            // 
            // ımageList1
            // 
            ımageList1.ColorDepth = ColorDepth.Depth24Bit;
            ımageList1.ImageStream = (ImageListStreamer)resources.GetObject("ımageList1.ImageStream");
            ımageList1.TransparentColor = Color.Transparent;
            ımageList1.Images.SetKeyName(0, "pngwing.com.png");
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Popup;
            button4.ImageIndex = 0;
            button4.ImageList = ımageList1;
            button4.Location = new Point(466, 164);
            button4.Name = "button4";
            button4.Size = new Size(97, 115);
            button4.TabIndex = 19;
            button4.UseVisualStyleBackColor = true;
            button4.MouseDown += MouseDown;
            button4.MouseMove += MouseMove;
            button4.MouseUp += MouseUp;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Popup;
            button3.ImageIndex = 0;
            button3.ImageList = ımageList1;
            button3.Location = new Point(349, 92);
            button3.Name = "button3";
            button3.Size = new Size(97, 115);
            button3.TabIndex = 18;
            button3.UseVisualStyleBackColor = true;
            button3.MouseDown += MouseDown;
            button3.MouseMove += MouseMove;
            button3.MouseUp += MouseUp;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Popup;
            button2.ImageIndex = 0;
            button2.ImageList = ımageList1;
            button2.Location = new Point(195, 119);
            button2.Name = "button2";
            button2.Size = new Size(97, 115);
            button2.TabIndex = 17;
            button2.UseVisualStyleBackColor = true;
            button2.MouseDown += MouseDown;
            button2.MouseMove += MouseMove;
            button2.MouseUp += MouseUp;
            // 
            // button1
            // 
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderColor = SystemColors.Control;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ImageIndex = 0;
            button1.ImageList = ımageList1;
            button1.Location = new Point(81, 307);
            button1.Name = "button1";
            button1.Size = new Size(97, 115);
            button1.TabIndex = 16;
            button1.UseVisualStyleBackColor = true;
            button1.MouseDown += MouseDown;
            button1.MouseMove += MouseMove;
            button1.MouseUp += MouseUp;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = Properties.Resources.pngwing_com__1_;
            pictureBox5.Location = new Point(452, 428);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(294, 235);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 9;
            pictureBox5.TabStop = false;
            pictureBox5.DragEnter += pictureBox5_DragEnter;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.FromArgb(224, 224, 224);
            groupBox4.Controls.Add(lblsüre);
            groupBox4.Controls.Add(progressBar1);
            groupBox4.Controls.Add(lblsoru);
            groupBox4.Location = new Point(6, 28);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(769, 88);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "SORULAR";
            // 
            // lblsüre
            // 
            lblsüre.AutoSize = true;
            lblsüre.Location = new Point(367, 61);
            lblsüre.Name = "lblsüre";
            lblsüre.Size = new Size(0, 21);
            lblsüre.TabIndex = 2;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.Blue;
            progressBar1.ForeColor = Color.Red;
            progressBar1.Location = new Point(118, 59);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(563, 23);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 1;
            progressBar1.Value = 100;
            // 
            // lblsoru
            // 
            lblsoru.ForeColor = Color.Red;
            lblsoru.Location = new Point(162, 0);
            lblsoru.Name = "lblsoru";
            lblsoru.Size = new Size(454, 85);
            lblsoru.TabIndex = 0;
            lblsoru.Text = "label16";
            lblsoru.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.OrangeRed;
            pictureBox1.Image = Properties.Resources.agac;
            pictureBox1.Location = new Point(6, 122);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(769, 709);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // elmal4
            // 
            elmal4.BackColor = Color.Transparent;
            elmal4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            elmal4.Location = new Point(129, 49);
            elmal4.Name = "elmal4";
            elmal4.Size = new Size(76, 23);
            elmal4.TabIndex = 10;
            elmal4.Text = "elma4";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Controls.Add(elmal4);
            groupBox3.Location = new Point(805, 344);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(462, 505);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "SKORLAR";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = Color.FromArgb(224, 224, 224);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(450, 477);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(799, 262);
            label9.Name = "label9";
            label9.Size = new Size(149, 25);
            label9.TabIndex = 9;
            label9.Text = "OYUNCU ADI :";
            // 
            // oyuncuadı
            // 
            oyuncuadı.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            oyuncuadı.Location = new Point(950, 262);
            oyuncuadı.Name = "oyuncuadı";
            oyuncuadı.Size = new Size(305, 25);
            oyuncuadı.TabIndex = 9;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(1183, 11);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(82, 15);
            linkLabel1.TabIndex = 10;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Oyun Kuralları";
            linkLabel1.MouseLeave += linkLabel1_MouseLeave;
            linkLabel1.MouseHover += linkLabel1_MouseHover;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.LightGray;
            listBox1.Font = new Font("Segoe UI", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            listBox1.ForeColor = Color.FromArgb(64, 64, 64);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Location = new Point(542, 33);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(695, 277);
            listBox1.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1295, 861);
            Controls.Add(listBox1);
            Controls.Add(linkLabel1);
            Controls.Add(oyuncuadı);
            Controls.Add(label9);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OYUN EKRANI";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pkalp3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pkalp2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pkalp1).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button obaslat;
        private GroupBox groupBox2;
        private Label label3;
        private Label label2;
        private Label label7;
        private Label lblhak;
        private Label lblskor;
        private Label lblseviye;
        private Label lblsorusayısı;
        private Label label9;
        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        private GroupBox groupBox4;
        private Label oyuncuadı;
        private Panel panel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox elma1;
        private PictureBox pictureBox5;
        private PictureBox pictureBox1;
        private PictureBox elma2;
        private PictureBox elma3;
        private PictureBox elma4;
        private PictureBox elma5;
        private ImageList ımageList1;
        private Label label10;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label elmal4;
        private Label label15;
        private Button button1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private Label lblsüre;
        private Label lblsoru;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox6;
        private PictureBox pkalp1;
        private PictureBox pkalp2;
        private PictureBox pkalp3;
        private ListBox listBox1;
    }
}