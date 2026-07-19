using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Ark.Services
{
    public class ConfigurationBuilder
    {
        private string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"instalation04.ini");
        public bool isExist = false;
        public ConfigurationBuilder() {
            InitDontExist();
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue,
            StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern bool WritePrivateProfileString(string section, string key, string value, string filePath);

        public string Read(string section, string key)
        {
            var buffer = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", buffer, 255, path);
            return buffer.ToString();
        }

        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        public void InitDontExist()
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                isExist = true;
            }
            else
            {
                isExist = true;
            }
        }
    }
}
