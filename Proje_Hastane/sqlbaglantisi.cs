using Proje_Hastane.Helper;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Proje_Hastane
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti() // SQL BAGLANTI METODU OLUŞTURUYORUM.
        {
            var s = iniValues.getValue("MainC");
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            SqlConnection baglan = new SqlConnection(s);
            baglan.Open();
            return baglan;

            //SqlConnection baglan = new SqlConnection("Data Source=.\\POSSQL;Initial Catalog=HastaneProje;User ID=sa ; Password=sql123_;"); = ESKİ BAĞLANTI
        }

    }
}



