using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuariosStefanini._00.Tools
{
    public static class EnvironmentVariablesManager
    {
        public static string GetVariable(string variableKey, string valueDefault = null)
        {
            string environmentVariable = Environment.GetEnvironmentVariable(variableKey);
            string appSetting = ConfigurationManager.AppSettings[variableKey];
            return !string.IsNullOrEmpty(environmentVariable) ? environmentVariable : !string.IsNullOrEmpty(appSetting) ? appSetting : valueDefault;
        }

        public static string URLApp => GetVariable("URLApp", "https://cadastro-de-usuarios.s3.us-east-1.amazonaws.com/index.html");
    }
}
