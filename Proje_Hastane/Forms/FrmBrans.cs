using Proje_Hastane.Helper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }
        SqlCodes sql = new SqlCodes();
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnEkle_Click(object sender, System.EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("INSERT INTO Tbl_Branslar (BransAd) VALUES (@p2)", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p2", TxtBrans.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }

        private void FrmBrans_Load(object sender, System.EventArgs e)
        {
            
            dataGridView1.DataSource = sql.HastaCek();
        }
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtBrans.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            Txtid.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Update Tbl_Branslar Set BransAd=@p1 Where Bransid=@p2",bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", TxtBrans.Text);
            komut3.Parameters.AddWithValue("@p2", Txtid.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut4 = new SqlCommand("Delete From Tbl_Branslar Where Bransid=@p1", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", Txtid.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
        }
    }
}
