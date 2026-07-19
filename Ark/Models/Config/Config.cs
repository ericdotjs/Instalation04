using System;
using System.Collections.Generic;
using System.Text;

namespace Ark.Models.Config
{
    public class Config
    {
        public string HEEKPath { get; set; } = string.Empty;
        public string TagsPath { get; set; } = string.Empty;
        public string DataPath { get; set; } = string.Empty;

        public bool mainPathsFilled()
        {
            return HEEKPath != string.Empty && TagsPath != string.Empty && DataPath != string.Empty;
        }
    }
}
