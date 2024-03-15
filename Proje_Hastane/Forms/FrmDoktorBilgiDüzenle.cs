using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }

        
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tcgetir;

        private void FrmDoktorBilgiDüzenle_Load(object sender, System.EventArgs e)
        {
            MskTc.Text = tcgetir;

            //BRANŞ GETİR
            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar Order By Bransid", bgl.baglanti());
            SqlDataReader k2 = komut2.ExecuteReader();
            while (k2.Read())
            {
                Cmbbrans.Items.Add(k2[0]);
            }
            bgl.baglanti().Close();


            //DOKTORUN BİLGİLERİNİ GETİR EKRANA EKLE
            SqlCommand komut1 = new SqlCommand("Select  * from Tbl_Doktorlar Where DoktorTC=@p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", MskTc.Text);
            SqlDataReader k1 = komut1.ExecuteReader();
            while (k1.Read())
            {
                TxtDoktorid.Text = k1[0].ToString();
                TxtAd.Text = k1[1].ToString();
                TxtSoyad.Text = k1[2].ToString();
                Cmbbrans.Text = k1[3].ToString();
                MskTc.Text = k1[4].ToString();
                TxtSifre.Text = k1[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void BtnBilgiGüncelle_Click(object sender, EventArgs e) // DOKTOR BİLGİLERİNİ GÜNCELLE
        {
            if (!String.IsNullOrEmpty(TxtAd.Text))
            {
            SqlCommand komut4 = new SqlCommand("Update Tbl_Doktorlar Set DoktorAd=@p1 , DoktorSoyad=@p2 , DoktorBrans=@p3 , DoktorTC=@p4 , DoktorSifre=@p5 Where Doktorid=@p6", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut4.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut4.Parameters.AddWithValue("@p3", Cmbbrans.Text);
            komut4.Parameters.AddWithValue("@p4", MskTc.Text);
            komut4.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut4.Parameters.AddWithValue("@p6", TxtDoktorid.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Kaydı Güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt Girilmeden Güncellenemez.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
