using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Proje_Hastane
{
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tcgetir;
        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            MskTc.Text = tcgetir;

            SqlCommand komut1 = new SqlCommand("Select * from Tbl_Hastalar Where HastaTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", MskTc.Text);
            SqlDataReader k1 = komut1.ExecuteReader();
            while (k1.Read())
            {
                TxtAd.Text = k1[1].ToString();
                TxtSoyad.Text = k1[2].ToString();
                MskTel.Text = k1[4].ToString();
                TxtSifre.Text = k1[5].ToString().Trim();
                CmbCinsiyet.Text = k1[6].ToString();
                Txmail.Text = k1[7].ToString().Trim();
            }
            bgl.baglanti().Close();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            //MESAJ BOX EVET HAYIR KULLANIMI
            DialogResult secenek = MessageBox.Show("Kayıtlar Güncellenicek Eminmisiniz ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (secenek == DialogResult.Yes)
            {
                SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar Set HastaAd=@p1 , HastaSoyad=@p2 , HastaTelefon=@p3 , HastaSifre=@p4 , HastaCinsiyet=@p5 , HastaMail=@p7 Where HastaTC=@p6", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut2.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut2.Parameters.AddWithValue("@p3", MskTel.Text);
                komut2.Parameters.AddWithValue("@p4", TxtSifre.Text);
                komut2.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
                komut2.Parameters.AddWithValue("@p6", MskTc.Text);
                komut2.Parameters.AddWithValue("@p7", Txmail.Text.Trim());
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bilgileriniz Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else if (secenek == DialogResult.No)
            {
                Close();
            }

           

        }
    }
}
