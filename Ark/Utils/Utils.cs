using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ark.Utils
{
    public static class Utils
    {
        public static bool isHeekValidatedDirectory(string path)
        {
            return Path.Exists($"{path}\\tags") && Path.Exists($"{path}\\data") && File.Exists($"{path}\\tool.exe");
        }
    }
}
