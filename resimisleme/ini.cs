using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resimkucult
{
    class ini
    {
        public static string INIFileName { get; private set; }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        public static void Yaz(string BolumAdı, string DegiskenAdı, string DegiskenDegeri)
        {
             INIFileName = Application.StartupPath + @"\config.ini";
            WritePrivateProfileString(BolumAdı, DegiskenAdı, DegiskenDegeri, INIFileName);
        }
        public static void AnonsVTYaz(string BolumAdı, string DegiskenAdı, string DegiskenDegeri)
        {
             INIFileName = Application.StartupPath + @"\config.ini";
            WritePrivateProfileString(BolumAdı, DegiskenAdı, DegiskenDegeri, INIFileName);
        }
        public static StringBuilder Oku(string BolumAdı, string DegiskenAdı)
        {
             INIFileName = Application.StartupPath + @"\config.ini";
            StringBuilder sb = new StringBuilder(500);
            GetPrivateProfileString(BolumAdı, DegiskenAdı, "", sb, sb.Capacity, INIFileName);
            return sb;
        }
    }
}

