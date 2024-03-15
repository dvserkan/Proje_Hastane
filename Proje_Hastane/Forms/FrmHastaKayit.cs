using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnKayıtYap_Click(object sender, EventArgs e)
        {

            add();
        }

        public void add()
        {
            if (!String.IsNullOrEmpty(TxtAd.Text) && !String.IsNullOrEmpty(TxtSoyad.Text) && !String.IsNullOrEmpty(MskTc.Text) && !String.IsNullOrEmpty(TxtSifre.Text) && !String.IsNullOrEmpty(CmbCinsiyet.Text) && !String.IsNullOrEmpty(TxtAd.Text) && !String.IsNullOrEmpty(Txmail.Text))
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (HastaAd , HastaSoyad , HastaTC , HastaTelefon , HastaSifre , HastaCinsiyet , HastaMail) values (@p1 , @p2 , @p3 , @p4 , @p5 , @p6 , @p7) SELECT @@IDENTITY", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut.Parameters.AddWithValue("@p3", MskTc.Text);
                komut.Parameters.AddWithValue("@p4", MskTel.Text);
                komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
                komut.Parameters.AddWithValue("@p6", CmbCinsiyet.Text);
                komut.Parameters.AddWithValue("@p7", Txmail.Text.Trim());
                var sonuc = komut.ExecuteScalar();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt İşlemi Tamamlanmıştır. Şifreniz : " + TxtSifre.Text, "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Eksik Alanlar Doldurulmadan Kayıt Yapılamaz", "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
