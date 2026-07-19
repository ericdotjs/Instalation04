using System;
using System.Collections.Generic;
using System.Text;
using Ark.Utils;

namespace Ark.Services
{
    public class ConfigReader 
    {
        ConfigurationBuilder _ConfigurationBuilder;
        public Dictionary<string, string> Settings = new Dictionary<string, string>() {
            { ConstantsGlobals.HEEK_FOLDER,"" },
            { ConstantsGlobals.HEEK_TAG,"" },
            { ConstantsGlobals.HEEK_DATA,"" },
        };

        public ConfigReader(ConfigurationBuilder builder) {
        this._ConfigurationBuilder = builder;
       // ReadValues();    
        }

        public void ReadValues()
        {
            foreach(var entry in Settings)
            {
               Settings[entry.Key] = _ConfigurationBuilder.Read(ConstantsGlobals.HEEK_PATHS, entry.Key);
            }
        }

        public void WriteValuesPaths(string path)
        {
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
