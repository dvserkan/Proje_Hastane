using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            FrmHastagiris hastagiris = new FrmHastagiris();
            hastagiris.Show();
            this.Hide();
        } //HASTA GİRİŞ

        private void button2_Click(object sender, EventArgs e) // DOKTOR GİRİŞ
        {
            FrmDoktorgiris doktorgiris = new FrmDoktorgiris();
            doktorgiris.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) // SEKRETER GİRİŞ
        {
            FrmSekreterGiris sekretergiris = new FrmSekreterGiris();
            sekretergiris.Show();
            this.Hide();
        }

        private void FrmGirisler_Load(object sender, EventArgs e) // EKRANDA TARİH SAAT TİMER KULLANIMI
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) // TİMER KULLANIMI
        {
            label4.Text = DateTime.Now.ToShortDateString();
            label5.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        } // EXİT KOMUTU

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
