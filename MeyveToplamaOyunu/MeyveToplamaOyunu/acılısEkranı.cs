using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeyveToplamaOyunu
{
    public partial class acılısEkranı : Form
    {
        public acılısEkranı()
        {
            InitializeComponent();
        }

        private void acılısEkranı_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
            timer1.Stop();
        }
    }
}
