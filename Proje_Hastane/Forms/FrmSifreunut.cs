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
using Proje_Hastane.Models;
using System.Net.Mail;
using Proje_Hastane.Helper;
using Proje_Hastane.Forms;

namespace Proje_Hastane
{
    public partial class FrmSifreunut : Form
    {
        public FrmSifreunut()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        Mailgönder gönder = new Mailgönder();
        SqlCodes özelg = new SqlCodes();
        private void button1_Click(object sender, EventArgs e)
        {
            Lblözel.Text = özelg.charindex(Lblözel.Text);
            SqlCommand komut1 = new SqlCommand("Select HastaTC,HastaSifre,HastaMail From Tbl_Hastalar Where HastaTC = @p1 and HastaMail =@p2", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", MskTC.Text);
            komut1.Parameters.AddWithValue("@p2", Txtmail.Text.Trim());
            SqlDataReader oku = komut1.ExecuteReader();

            if (oku.Read())
            { 
                 if (!String.IsNullOrEmpty(Txtmail.Text.Trim()))
                 {
                    //gönder.Gonder("ŞİFRENİZ", "TC KİMLİK NO : " + MskTC.Text + "\n" + "ŞİFRENİZ : " + oku["HastaSifre"], Txtmail.Text);
                    gönder.Gonder("ÖZEL KOD", "TC KİMLİK NO : " + MskTC.Text + "\n" + "Özel Kod : " + Lblözel.Text , Txtmail.Text.Trim());
                    MessageBox.Show(" Lütfen Mail Adresinize Gelen Kodu Açılan Ekranda \n" + " ÖZEL KOD " + " Bölümüne Giriniz.","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    FrmSifremiunuttum sifreunut = new FrmSifremiunuttum();
                    sifreunut.tcgetir = MskTC.Text;
                    sifreunut.özelkodgetir = Lblözel.Text;
                    sifreunut.ShowDialog();
                    Close();
                 }
                 else
                 {
                     MessageBox.Show("Lütfen Mail Adresinizi Giriniz.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                 }
            }
            else
            {
                MessageBox.Show("Girmiş Olduğunuz Bilgiler Sistemde Kayıtlı Değildir.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
