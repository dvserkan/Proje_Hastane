using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Proje_Hastane
{
    public partial class FrmHastagiris : Form
    {
        public FrmHastagiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void Btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar Where HastaTc=@p1 And HastaSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmHastadetay hastadetay = new FrmHastadetay();
                hastadetay.tcgetir = MskTc.Text;
                hastadetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş TC & Şifreniz Hatalı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();

        }

        private void Lbküyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit frmkayıt = new FrmHastaKayit();
            frmkayıt.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                TxtSifre.UseSystemPasswordChar = false;
            }
            else
            {
                TxtSifre.UseSystemPasswordChar = true;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSifreunut sifreunut = new FrmSifreunut();
            sifreunut.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGirisler girisler = new FrmGirisler();
            Close();
            girisler.ShowDialog();
        }
    }
}
