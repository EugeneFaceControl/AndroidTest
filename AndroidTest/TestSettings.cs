using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidTest
{
    public class TestSettings
    {
        public string ApkPath { get; set; }

        /// <summary>
        ///     Gets variable value from App.config by its key name
        /// </summary>
        /// <param name="key">key name</param>
        /// <returns>value associated with key</returns>
        private string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public TestSettings()
        {
            ApkPath = Get("apkPath");
        }
    }

}
