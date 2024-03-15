using Proje_Hastane.Helper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmHastadetay : Form
    {
        public FrmHastadetay()
        {
            InitializeComponent();
        }



        public string tcgetir;
        sqlbaglantisi bgl = new sqlbaglantisi();
        SqlCodes codes = new SqlCodes();
        private void FrmHastadetay_Load(object sender, EventArgs e)
        {
            
            LblTc.Text = tcgetir;

            //AD SOYAD GETİR
            SqlCommand komut1 = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar Where HastaTC=@p1");

            var sonuc = codes.GetDataTable(komut1);

            komut1.Parameters.AddWithValue("@p1", tcgetir);
            SqlDataReader k1 = komut1.ExecuteReader();
            while (k1.Read())
            {
                LblAdsoyad.Text = k1[0] + " " + k1[1];
            }
            bgl.baglanti().Close();

            //RANDEVU GEÇMİŞİ
            DataTable dt = new DataTable();
            SqlDataAdapter dt2 = new SqlDataAdapter("Select * From Tbl_Randevular Where RandevuDurum=1  AND HastaTC=" + tcgetir, bgl.baglanti());
            dt2.Fill(dt);
            dataGridView1.DataSource = dt;


            // BRANŞ GETİR
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
            //DOKTOR GETİR 
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

        private void BtnRandevual_Click(object sender, EventArgs e)
        {
            //RANDEVU OLUŞTUR.
            if (!String.IsNullOrEmpty(Rchsikayet.Text))
            {

                SqlCommand komut6 = new SqlCommand("Update Tbl_Randevular Set RandevuDurum=1 , HastaTC=@p2 , HastaSikayet=@p3 Where Randevuid=@p4", bgl.baglanti());
                komut6.Parameters.AddWithValue("@p2", LblTc.Text);
                komut6.Parameters.AddWithValue("@p3", Rchsikayet.Text);
                komut6.Parameters.AddWithValue("@p4", Txtid.Text);
                komut6.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Randevu Oluşturulmuştur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FrmHastadetay_Load(null, null);
            }
            else
            {
                MessageBox.Show("Randevu Seçilmeden veya \nŞikayet Girilmeden Kayıt Oluşturulamaz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter dt2 = new SqlDataAdapter("Select * from Tbl_Randevular Where RandevuBrans='" + Cmbbrans.Text + "'" + "AND RandevuDoktor='" + Cmbdoktor.Text + "' AND RandevuDurum = 0" , bgl.baglanti());
            dt2.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void Lnkbilgidüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDüzenle bilgidüzenle = new FrmBilgiDüzenle();
            bilgidüzenle.tcgetir = LblTc.Text;
            bilgidüzenle.Show();

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int deger = dataGridView2.SelectedCells[0].RowIndex;

            Txtid.Text = dataGridView2.Rows[deger].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGirisler girisler = new FrmGirisler();
            Close();
            girisler.ShowDialog();
        }
    }
}
