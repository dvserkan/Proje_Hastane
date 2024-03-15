using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmDoktordetay : Form
    {
        public FrmDoktordetay()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tcgetir;

        private void FrmDoktordetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = tcgetir;

            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar Where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader k1 = komut.ExecuteReader();
            while (k1.Read())
            {
                Lbladsoyad.Text = k1[0] + " " + k1[1];
            }
            bgl.baglanti().Close();


            

            //Randevu Verilerini Çek;
            DataTable dt = new DataTable();
            SqlDataAdapter dt1 = new SqlDataAdapter("Select HastaSikayet,* From Tbl_Randevular Where RandevuDoktor='" + Lbladsoyad.Text + "'", bgl.baglanti());
            dt1.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btnduyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular duyurular = new FrmDuyurular();
            duyurular.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        // DOKTOR RANDEVULAR LİSTESİNE TIKLADIĞINDA HASTASININ ŞİKAYETİ DİREK EKRANINA GELMESİ SAĞLANDI.
        {
            

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Rchsikayet.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void Btngüncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDüzenle bilgidüzenle = new FrmDoktorBilgiDüzenle();
            bilgidüzenle.tcgetir = LblTC.Text;
            bilgidüzenle.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGirisler girisler = new FrmGirisler();
            Close();
            girisler.ShowDialog();
        }
    }
}
