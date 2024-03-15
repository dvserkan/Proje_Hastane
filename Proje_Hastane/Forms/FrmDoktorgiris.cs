using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmDoktorgiris : Form
    {
        public FrmDoktorgiris()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        private void Btngirisyap_Click(object sender, System.EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Select * from Tbl_Doktorlar Where DoktorTC=@p1 AND DoktorSifre=@p2", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", MskTc.Text);
            komut1.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader k1 = komut1.ExecuteReader();
            if (k1.Read())
            {
                FrmDoktordetay doktordetay = new FrmDoktordetay();
                doktordetay.tcgetir = MskTc.Text;
                doktordetay.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Tc Kimlik & Şifreyi Hatalı Girdiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();

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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGirisler girisler = new FrmGirisler();
            Close();
            girisler.ShowDialog();
        }
    }
}
