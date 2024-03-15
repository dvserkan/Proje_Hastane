using Proje_Hastane.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Proje_Hastane
{
    public partial class FrmRandevuListesi : Form 
    {

        public FrmRandevuListesi()
        {
            InitializeComponent();
        }

        public RandevuListesi list = null;  // OLUŞTURDUĞUM CLASSI GLOBAL ALANDA NESNEYE DÖNÜŞTÜRÜYORUM.
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void Dtngrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            int secilen = Dtngrid.SelectedCells[0].RowIndex;
            list = new RandevuListesi();
            list.Txtid = Dtngrid.Rows[secilen].Cells[0].Value.ToString();
            list.Msktag = Dtngrid.Rows[secilen].Cells[1].Value.ToString();
            list.MskSaatg = Dtngrid.Rows[secilen].Cells[2].Value.ToString();
            list.Cmbdokg = Dtngrid.Rows[secilen].Cells[4].Value.ToString();
            list.Cmbbransg = Dtngrid.Rows[secilen].Cells[3].Value.ToString();
            list.Txttecg = Dtngrid.Rows[secilen].Cells[6].Value.ToString();
            Close();
        }

        private void FrmRandevuListesi_Load(object sender, System.EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dt1 = new SqlDataAdapter("Select * From Tbl_Randevular Order By RandevuTarih desc , RandevuSaat desc", bgl.baglanti());
            dt1.Fill(dt);
            Dtngrid.DataSource = dt;
        }

      
    }
}
