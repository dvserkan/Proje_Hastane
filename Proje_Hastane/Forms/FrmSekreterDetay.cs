using Proje_Hastane.Helper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmSekreterDetay : Form 
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }


        public string tcgetir;
        sqlbaglantisi bgl = new sqlbaglantisi();
        SqlCodes sql = new SqlCodes();

        public void FrmSekreterDetay_Load(object sender, EventArgs e)
        {

            //TC GETİR
            TxtTc.Text = tcgetir;

            //AD SOYAD GETİR
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter Where SekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", TxtTc.Text);
            SqlDataReader k1 = komut1.ExecuteReader();
            while (k1.Read())
            {
                TxtAdSoyad.Text = k1[0].ToString();
            }
            bgl.baglanti().Close();


            /*BRANŞLARI GETİR ESKİ KULLANIM.
            DataTable dt = new DataTable();
            SqlDataAdapter dt1 = new SqlDataAdapter("Select BransAd as [Branşlar] From Tbl_Branslar", bgl.baglanti());
            dt1.Fill(dt);
            dataGridView1.DataSource = dt;*/


            //BRANŞLARI GETİR YENİ KULLANIM **
            dataGridView1.DataSource = sql.HastaCek();


            /*DOKTORLARI GETİR ESKİ KULLANIM
            DataTable dt2 = new DataTable();
            SqlDataAdapter dt3 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) AS [Doktorlar],DoktorBrans From Tbl_Doktorlar", bgl.baglanti());
            dt3.Fill(dt2);
            dataGridView2.DataSource = dt2;*/


            //DOKTORLARI GETİR YENİ KULLANIM **
            dataGridView2.DataSource = sql.Doktorget();



            //BUTTON BRANŞLARI GETİR
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
            SqlDataReader k2 = komut2.ExecuteReader();
            while (k2.Read())
            {
                Cmbbrans.Items.Add(k2[0]);
            }
            bgl.baglanti().Close();

        }

        private void Cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SEÇİLEN BRANŞA GÖRE DOKTOR GETİRME.

            Cmbdoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", Cmbbrans.Text);
            SqlDataReader k3 = komut3.ExecuteReader();
            while (k3.Read())
            {
                Cmbdoktor.Items.Add(k3[0] + " " + k3[1]);
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Msktarih.Text) && !String.IsNullOrEmpty(Msksaat.Text) && !String.IsNullOrEmpty(Cmbbrans.Text) && !String.IsNullOrEmpty(Cmbdoktor.Text))
            {

            SqlCommand komut4 = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) Values (@p1 , @p2 , @p3 , @p4)", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", Msktarih.Text);
            komut4.Parameters.AddWithValue("@p2", Msksaat.Text);
            komut4.Parameters.AddWithValue("@p3", Cmbbrans.Text);
            komut4.Parameters.AddWithValue("@p4", Cmbdoktor.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturulmuştur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Randevu Bilgileri Doldurulmadan Kayıt işlemi Yapılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Msktarih.Text) && !String.IsNullOrEmpty(Msktarih.Text) && !String.IsNullOrEmpty(Cmbbrans.Text) && !String.IsNullOrEmpty(Cmbdoktor.Text))
            {
            SqlCommand komut4 = new SqlCommand("Update Tbl_Randevular Set RandevuTarih=@p1 ,RandevuSaat=@p2 ,RandevuBrans=@p3,RandevuDoktor=@p4 Where Randevuid=@p5", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", Msktarih.Text);
            komut4.Parameters.AddWithValue("@p2", Msksaat.Text);
            komut4.Parameters.AddWithValue("@p3", Cmbbrans.Text);
            komut4.Parameters.AddWithValue("@p4", Cmbdoktor.Text);
            komut4.Parameters.AddWithValue("@p5", Txtidg.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Randevu Bilgileri Doldurulmadan Güncelleme işlemi Yapılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       
        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RchDuyuru.Text))
            {

                SqlCommand komut5 = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@p1)", bgl.baglanti());
                komut5.Parameters.AddWithValue("@p1", RchDuyuru.Text);
                komut5.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Duyuru Oluşturulmuştur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Duyuru Yazılmadan Oluşturulamaz","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Btnlistele_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi randevuliste = new FrmRandevuListesi();
            randevuliste.ShowDialog();

            if (randevuliste.list != null)
            {
                Txtidg.Text = randevuliste.list.Txtid.ToString();
                Msktarih.Text = randevuliste.list.Msktag.ToString();
                Msksaat.Text = randevuliste.list.MskSaatg.ToString();
                Cmbbrans.Text = randevuliste.list.Cmbbransg.ToString();
                Cmbdoktor.Text = randevuliste.list.Cmbdokg.ToString();
                MskTC.Text = randevuliste.list.Txttecg.ToString();

            }


        }

        private void BtnBranspanel_Click(object sender, EventArgs e)
        {
            FrmBrans bransekle = new FrmBrans();
            bransekle.Show();

        }

        private void BtnDoktorpanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli doktorekle = new FrmDoktorPaneli();
            doktorekle.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular duyurus = new FrmDuyurular();
            duyurus.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmGirisler girisler = new FrmGirisler();
            Close();
            girisler.ShowDialog();
        }
    }
}
