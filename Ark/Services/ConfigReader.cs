using System;
using System.Collections.Generic;
using System.Text;
using Ark.Models.Config;
using Ark.Utils;
using Microsoft.VisualBasic;

namespace Ark.Services
{
    public class ConfigReader 
    {
        public bool Emptypaths = true;
        ConfigurationBuilder _ConfigurationBuilder;
        Config ConfigModel;

        public ConfigReader(ConfigurationBuilder builder,Config configModel) {
        this._ConfigurationBuilder = builder;
        this.ConfigModel = configModel;
        ReadValues();    
        }

        public void ReadValues()
        {    
               this.ConfigModel.HEEKPath = _ConfigurationBuilder.Read(ConstantsGlobals.HEEK_PATHS, ConstantsGlobals.HEEK_FOLDER);
               this.ConfigModel.TagsPath = _ConfigurationBuilder.Read(ConstantsGlobals.HEEK_PATHS, ConstantsGlobals.HEEK_TAG);
               this.ConfigModel.DataPath = _ConfigurationBuilder.Read(ConstantsGlobals.HEEK_PATHS, ConstantsGlobals.HEEK_DATA);
        }

        public void WriteValuesPaths(string path)
        {
             Dictionary<string, string> Settings = new Dictionary<string, string>() {
            { ConstantsGlobals.HEEK_FOLDER,"" },
            { ConstantsGlobals.HEEK_TAG,"" },
            { ConstantsGlobals.HEEK_DATA,"" },
            };

            Settings[ConstantsGlobals.HEEK_FOLDER] = path;
            Settings[ConstantsGlobals.HEEK_TAG] = $"{Settings[ConstantsGlobals.HEEK_FOLDER]}\\tags";
            Settings[ConstantsGlobals.HEEK_DATA] = $"{Settings[ConstantsGlobals.HEEK_FOLDER]}\\data";

            foreach(var entry in Settings)
            {
                this._ConfigurationBuilder.Write(ConstantsGlobals.HEEK_PATHS, entry.Key, entry.Value);
            }
        }
    }
}
