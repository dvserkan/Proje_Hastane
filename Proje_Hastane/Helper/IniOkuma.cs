using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Hastane.Helper
{
    public class IniOkuma
    {
        #region DLL Import

        [DllImport("kernel32", SetLastError = true)]
        internal static extern int WritePrivateProfileString(string Bolum, string Anahtar, string Deger, string pFile);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern int WritePrivateProfileStruct(string Bolum, string Anahtar, string Deger,
        int VarsayilanUzunluk, string Dosya);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern int GetPrivateProfileString(string Bolum, string Anahtar, string pVarsayilan,
        byte[] prReturn, int pBufferLen, string pFile);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern int GetPrivateProfileStruct(string Bolum, string Anahtar, byte[] prReturn, int pBufferLen,
        string pFile);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);


        #endregion

        #region Değişkenler

        private string ls_IniFileName;
        private int li_BufferLen = 4096;

        #endregion

        #region Ini Oku

        public IniOkuma(string iniFileName)
        {
            ls_IniFileName = iniFileName;
        }

        #endregion

        #region Ini Dosyayi
        public string iniFile
        {
            get
            {
                return (ls_IniFileName);
            }
            set
            {
                ls_IniFileName = value;
            }
        }
        #endregion

        #region Bufferlen

        public int BufferLen
        {
            get
            {
                return li_BufferLen;
            }
            set
            {
                if (value > 32767)
                {
                    li_BufferLen = 32767;
                }
                else
                    if (value < 1)
                {
                    li_BufferLen = 1;
                }
                else
                {
                    li_BufferLen = value;
                }
            }
        }

        #endregion

        #region Değer Oku
        public string readValue(string partName, string keyName, string valueName)
        {
            return (getString(partName, keyName, valueName));
        }
        #endregion

        #region Değer Oku 2

        public string readValue(string partName, string keyName)
        {
            return (getString(partName, keyName, ""));
        }

        #endregion

        #region Değer Yaz

        public void writeValue(string partName, string keyName, string value)
        {
            WritePrivateProfileString(partName, keyName, value, ls_IniFileName);
        }

        #endregion

        #region Değer Sil

        public void deleteValue(string partName, string keyName)
        {
            WritePrivateProfileString(partName, keyName, null, ls_IniFileName);
        }

        #endregion

        #region Değerleri Oku

        public void readValues(string partName, ref Array values)
        {
            values = getString(partName, null, null).Split((char)0);
        }

        #endregion

        #region Bölümleri Oku

        public void readParts(ref Array parts)
        {
            parts = getString(null, null, null).Split((char)0);
        }

        #endregion

        #region Bölüm Sil

        public void deleteParts(string Bolum)
        {
            WritePrivateProfileString(Bolum, null, null, ls_IniFileName);
        }

        #endregion

        #region String Getir

        private string getString(string Bolum, string Anahtar, string Varsayilan)
        {
            var DonusDegeri = Varsayilan;
            var bRet = new byte[li_BufferLen];
            var i = GetPrivateProfileString(Bolum, Anahtar, Varsayilan, bRet, li_BufferLen, ls_IniFileName);
            DonusDegeri = Encoding.GetEncoding(1254).GetString(bRet, 0, i).TrimEnd((char)0);
            return (DonusDegeri);
        }

        #endregion

        public List<string> GetKeys(string category)
        {
            var buffer = new byte[4096];
            GetPrivateProfileSection(category, buffer, 4096, ls_IniFileName);
            var tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');
            var result = new List<string>();
            foreach (var entry in tmp)
            {
                result.Add(entry.Substring(0, entry.IndexOf("=")));
            }
            return result;
        }
    }


    class iniValues
    {
        internal static string getValue(string KeyName)
        {
            var retValue = "";
            var FilePath = System.Windows.Forms.Application.StartupPath + @"\settings.ini";
            if (System.IO.File.Exists(FilePath))
            {
                var reader = new IniOkuma(FilePath);
                retValue = reader.readValue("settings", KeyName);
            }
            else
            {
                System.IO.File.WriteAllText(FilePath, "");
            }
            return retValue;
        } // OKUMA
        internal static void setValue(string KeyName, string KeyValue)
        {
            var FilePath = System.Windows.Forms.Application.StartupPath + @"\settings.ini";
            if (!System.IO.File.Exists(FilePath))
            {
                System.IO.File.WriteAllText(FilePath, "");
            }
            var reader = new IniOkuma(FilePath);
            reader.writeValue("settings", KeyName, KeyValue);
        } // SET ETME
        internal static void deleteValue(string KeyName)
        {
            var FilePath = System.Windows.Forms.Application.StartupPath + @"\settings.ini";
            if (!System.IO.File.Exists(FilePath))
            {
                System.IO.File.WriteAllText(FilePath, "");
            }
            var reader = new IniOkuma(FilePath);
            reader.deleteValue("settings", KeyName);
        } // SİLME

    }
}
