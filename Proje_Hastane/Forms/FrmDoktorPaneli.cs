using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        private void BtnEkle_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtAd.Text))
            {
            SqlCommand komut = new SqlCommand("insert into Tbl_Doktorlar (DoktorAD , DoktorSoyad , DoktorBrans , DoktorTC , DoktorSifre) Values (@p1 , @p2 , @p3 , @p4 , @p5 )", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", Cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4", MskTC.Text);
            komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Ekleme İşlemi Tamamlanmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bilgiler Girilmeden Kayıt Yapılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt3 = new DataTable();
            SqlDataAdapter dt4 = new SqlDataAdapter("Select * From Tbl_Doktorlar Order By Doktorid", bgl.baglanti());
            dt4.Fill(dt3);
            dataGridView1.DataSource = dt3;

            
            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar Order By Bransid", bgl.baglanti());
            SqlDataReader k2 = komut2.ExecuteReader();
            while (k2.Read())
            {
                Cmbbrans.Items.Add(k2[0]);
            }
            bgl.baglanti().Close();


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Delete From Tbl_Doktorlar Where DoktorTC=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", MskTC.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Kaydı Silinmiştir", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut4 = new SqlCommand("Update Tbl_Doktorlar Set DoktorAd=@p1 , DoktorSoyad=@p2 , DoktorBrans=@p3 , DoktorTC=@p4 , DoktorSifre=@p5 Where Doktorid=@p6", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut4.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut4.Parameters.AddWithValue("@p3", Cmbbrans.Text);
            komut4.Parameters.AddWithValue("@p4", MskTC.Text);
            komut4.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut4.Parameters.AddWithValue("@p6", Txtdoktorid.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Kaydı Güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            Txtdoktorid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            Cmbbrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }
    }
}
