using Proje_Hastane.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Hastane.Helper
{
   public class SqlCodes
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public DataTable HastaCek()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter dt2 = new SqlDataAdapter("Select BransAd,Bransid from Tbl_Branslar Order By Bransid", bgl.baglanti());
            dt2.Fill(dt1);

            return dt1;
        }

        public DataTable Doktorget()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter dt3 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) AS [Doktorlar],DoktorBrans From Tbl_Doktorlar", bgl.baglanti());
            dt3.Fill(dt2);
            return dt2;
        }

        public string charindex(string özelgüven)
        {
            string[] karakter1 = { "a", "b", "c", "d", "e", "f", "g", "l", "m", "n", "o" };
            string[] karakter2 = { "A", "B", "C", "J", "L", "M", "N", "Ş", "G" };
            string[] karakter3 = { "+", "-", "!", "/", "&" };

            Random özel = new Random();
            int özel1, özel2, özel3, özel4, özel5;

            özel1 = özel.Next(0, karakter1.Length);
            özel2 = özel.Next(0, karakter2.Length);
            özel3 = özel.Next(0, karakter3.Length);
            özel4 = özel.Next(0, 6);
            özel5 = özel.Next(0, 7);

            özelgüven = karakter1[özel1].ToString() + karakter2[özel2].ToString() + karakter3[özel3].ToString() + özel4.ToString() + özel5.ToString();

            return özelgüven;
        }

        public DataTable GetDataTable(SqlCommand cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, bgl.baglanti().ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDataTable(string command,int i)
        {
            SqlDataAdapter da = new SqlDataAdapter(command, bgl.baglanti().ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }

   
}
