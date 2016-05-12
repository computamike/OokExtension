using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOK_Project_Template
{
    internal static class IconRegistration
    {
        private static string _folder = IconRegistration.GetFolder();

        public static void RegisterIcons()
        {
            try
            {
                using (RegistryKey classes = Registry.CurrentUser.OpenSubKey("SoftWare\\Classes", true))
                {
                    if (classes == null)
                        return;
                    IconRegistration.AddIcon(classes, "CoffeeScript.ico", ".cson");
                    IconRegistration.AddIcon(classes, "CoffeeScript.ico", ".iced");
                    IconRegistration.AddIcon(classes, "LiveScript.ico", ".ls", ".livescript", ".lsc");
                    IconRegistration.AddIcon(classes, "Markdown.ico", ".md", ".mdown", ".markdown", ".mkd", ".mkdn", ".mdwn", ".mmd");
                    IconRegistration.AddIcon(classes, "WebVTT.ico", ".vtt");
                    IconRegistration.AddIcon(classes, "Bundle.ico", ".bundle");
                    IconRegistration.AddIcon(classes, "Font.ico", ".wof", ".woff", ".woff2", ".eot");
                    IconRegistration.AddIcon(classes, "Git.ico", ".gitignore", ".gitattributes");
                    IconRegistration.AddIcon(classes, "GenericScript.ico", ".appcache", JsHintCompiler.ConfigFileName, ".weignore", ".jshintignore", TsLintCompiler.ConfigFileName, JsCodeStyleCompiler.ConfigFileName, CoffeeLintCompiler.ConfigFileName, RtlCssCompiler.ConfigFileName, ".sjs", ".jsonld", ".bowerrc");
                    IconRegistration.AddIcon(classes, "Jigsaw.ico", ".sprite");
                }
            }
            catch
            {
            }
        }

        private static void AddIcon(RegistryKey classes, string iconName, params string[] extensions)
        {
            foreach (string str in extensions)
            {
                using (RegistryKey subKey = classes.CreateSubKey(str + "\\DefaultIcon"))
                    subKey.SetValue(string.Empty, (object)(IconRegistration._folder + iconName));
            }
        }

        private static string GetFolder()
        {
            return Path.Combine(Path.GetDirectoryName(typeof(IconRegistration).Assembly.Location), "Resources\\Icons\\");
        }
    }
}
