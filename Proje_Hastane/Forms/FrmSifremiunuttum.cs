using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane.Forms
{
    public partial class FrmSifremiunuttum : Form
    {
        public FrmSifremiunuttum()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tcgetir, özelkodgetir;

        private void button1_Click(object sender, EventArgs e)
        {

            Txtözelkod.Text = özelkodgetir;
            Txttctası.Text = tcgetir;
            //1. formdan buraya ilk olarak tc
            //1. formdan buraya ikinci olarak özelkarakteri taşımam laızm.

            if (Txtözelkod.Text == TxtÖzelkods.Text)
            {
                SqlCommand komut1 = new SqlCommand("Update Tbl_Hastalar Set HastaSifre =@p1 Where HastaTC =@p2 ", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtYenisifre.Text);
                komut1.Parameters.AddWithValue("@p2", Txttctası.Text);
                komut1.ExecuteNonQuery();
                MessageBox.Show("Şifreniz Değiştirilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Girmiş Olduğunuz Özel Kod Mailinizde Gönderilen Kod İle Uyuşmamaktadır.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void FrmSifremiunuttum_Load(object sender, EventArgs e)
        {

        }
    }
}
