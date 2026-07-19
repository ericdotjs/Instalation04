using Ark.Models.Config;
using SevenZip;
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

        public static bool extractHCEEK7z(Config configModel, string path, string projectName)
        {
            try
            {
                string file7z = $"{configModel.HEEKPath}\\{ConstantsGlobals.FOLDER_NAME}.7z";
                Directory.CreateDirectory($"{path}\\{projectName}");
                SevenZipExtractor.SetLibraryPath("7z.dll");
                if(File.Exists(file7z))
                    using (var extractor = new SevenZipExtractor(file7z))
                    {
                        extractor.ExtractArchive(Path.Combine(path, projectName));
                    }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
