using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmDuyurular : Form
    {
        public FrmDuyurular()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmDuyurular_Load(object sender, System.EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter dt2 = new SqlDataAdapter("Select Duyuru from Tbl_Duyurular", bgl.baglanti());
            dt2.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
