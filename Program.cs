using PilotDesktop.Pilot.Objects;
using PilotDesktop.Settings.Objects;
using PilotDesktop.Settings.Services;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PilotDesktop
{
    internal static class Program
    {
        public static PilotApplicationSettings _pilotApplicationSettings = new PilotApplicationSettings();
        public static List<PilotCustomer> _customers = new List<PilotCustomer>();
       
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
     var settingService = new PilotApplicationSettingsService();
            _pilotApplicationSettings = settingService.GetSettings();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PilotNavigator());
        }

        public static class General
        {
            public static string FixStringPascalCase(string str)
            {
                if (!str.Contains(" "))
                {
                    return FirstLetterToUpper(str);
                }

                TextInfo info = CultureInfo.CurrentCulture.TextInfo;
                var strList = str.Split(" ");

                str = string.Empty;
                foreach (var item in strList)
                {
                    if (string.IsNullOrWhiteSpace(item))
                    {
                        continue;
                    }
                    str += FirstLetterToUpper(item);
                }

                return str;
            }

            public static string ConvertStringToKebabCase(string str)
            {
                str = PascalToKebabCase(str.Replace("PN", string.Empty));
                return "pn-" + str;
            }

            public static string PascalToKebabCase(string value)
            {
                if (string.IsNullOrEmpty(value))
                    return value;

                return Regex.Replace(
                    value,
                    "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z0-9])",
                    "-$1",
                    RegexOptions.Compiled)
                    .Trim()
                    .ToLower();
            }

            public static string FirstLetterToUpper(string str)
            {
                if (str.Length > 1)
                    return char.ToUpper(str[0]) + str.Substring(1);
                else
                {
                    return str.ToUpper();
                }
            }

            public static void SetTemplatePath()
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "TemplateFiles");
                if (Directory.Exists(path))
                {
                    Global.PathTemplates = path;
                    //Global.TemplateDirectory = new DirectoryInfo(path);
                }

                //if (!Directory.Exists(path))
                //    Directory.CreateDirectory(path);
            }


            public static DirectoryInfo? CheckPNLitiumDir(DirectoryInfo d)
            {
                var folderSrc = d;

                if (folderSrc.Name.ToLower() != "src")
                {
                    if (folderSrc.Parent.Name.ToLower() == "src")
                    {
                        return folderSrc.Parent;
                    }
                    DirectoryInfo[] folders = folderSrc.GetDirectories();
                    folderSrc = folders.FirstOrDefault(x => x.Name.ToLower() == "src");
                }
                if (folderSrc != null)
                {
                    DirectoryInfo[] folders = folderSrc.GetDirectories();
                    var PNAddonsFolder = folders.FirstOrDefault(x => x.Name.ToLower() == Global.PathDestinationPnAddonsExtensions.ToLower());
                    if (PNAddonsFolder != null)
                    {
                        return folderSrc;
                    }
                }

                return null;
            }

            public static DirectoryInfo CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target, bool isSubNode = false)
            {
                var sourceDirectories = source.GetDirectories();
                var newFolderName = string.Empty;
                foreach (DirectoryInfo dir in sourceDirectories)
                {
                    var newName = ReplacePartString(dir.Name);
                    if (!isSubNode)
                    {
                        newFolderName = newName;
                    }
                    CopyFilesRecursively(dir, target.CreateSubdirectory(newName), true);
                }
                foreach (FileInfo file in source.GetFiles())
                {
                    var newName = ReplacePartString(file.Name);
                    file.CopyTo(Path.Combine(target.FullName, newName));
                }
                if (!isSubNode)
                {
                    return target.GetDirectories()?.Where(x => x.Name == newFolderName)?.FirstOrDefault();
                }
                return null;
            }


            public static void CreateStylingStructure()
            {
                var source = Path.Combine(Global.PathTemplates, Global.PathSource_StylesAddons);
                var destination = Path.Combine(Global.PathProject, Global.PathDestination_StylesAddons);
                if (Directory.Exists(source) && Directory.Exists(destination))
                {
                    ChangeFileVariableNames(CopyFilesRecursively(new DirectoryInfo(source), new DirectoryInfo(destination)));
                }
            }

            /// <summary>
            ///     GO THROUGH ALL FILES AND FOLDERS AND, IF EXISTS,
            ///     REPLACE PART FILE/FOLDER/VARIABLE-NAME 
            ///     WITH THE FOLLOWING: 
            ///     
            ///     PNAddonTemp 	        // Replace                      (Constant: AddonNameReplace, Value: Global.AddonName)                  
            ///     pn-addon-temp-kebab     // Replace kebab-case           (Constant: AddonNameReplaceKebabCase, Value: Global.AddonNameKebabCase) 
            ///     pnAddonTempCamel 	    // Replace camelCase            (Constant: AddonNameReplaceCamelCase, Value: Global.AddonNameCamelCase) 
            ///     pn_addontemplower	    // Replace all letters small    (Constant: AddonNameReplaceAllLettersSmall, Value: Global.AddonNameAllLowerCase) 
            ///     
            /// </summary>
            /// <param name="dir"></param>        
            public static void ChangeFileVariableNames(DirectoryInfo dir)
            {
                var sourceDirectories = dir.GetDirectories();
                foreach (DirectoryInfo subDir in sourceDirectories)
                {
                    ChangeFileVariableNames(subDir);
                }

                foreach (FileInfo file in dir.GetFiles())
                {
                    string str = File.ReadAllText(file.FullName);
                    str = ReplacePartString(str, true);
                    File.WriteAllText(file.FullName, str);
                }
            }

            private static string ReplacePartString(string str, bool isInFile = false)
            {
                var prefix = isInFile ? "[" : string.Empty;
                var sufix = isInFile ? "]" : string.Empty;
                if (isInFile)
                {
                    var test = "";
                }
                if (str.Contains(prefix + Global.AddonNameReplace + sufix))
                {
                    str = str.Replace(prefix + Global.AddonNameReplace + sufix, Global.AddonName);
                }
                if (str.Contains(prefix + Global.AddonNameReplaceKebabCase + sufix))
                {
                    str = str.Replace(prefix + Global.AddonNameReplaceKebabCase + sufix, Global.AddonNameKebabCase);
                }
                if (str.Contains(prefix + Global.AddonNameReplaceCamelCase + sufix))
                {
                    str = str.Replace(prefix + Global.AddonNameReplaceCamelCase + sufix, Global.AddonNameCamelCase);
                }
                if (str.Contains(prefix + Global.AddonNameReplaceAllLettersSmall + sufix))
                {
                    str = str.Replace(prefix + Global.AddonNameReplaceAllLettersSmall + sufix, Global.AddonNameAllLowerCase);
                }

                return str;
            }
        }


        public static class Global
        {
            // Todo Aspen: Fix all Files
            // Todo Aspen: Fix all Source paths
            // Todo Aspen: Fix all Logic (search-replace: PNAddon and pn-addon)

            public static string PathProject { get; internal set; }
            public static string PathTemplates { get; internal set; }

            public const string PathSource_Api = "AddonsMvc\\API\\PNAddon";

            public const string PathSource_StylesAddons = "AddonsMvc\\Styles";

            public const string PathDestinationPnAddonsExtensions = "PandoNexis.AddOns.Extensions";
            public const string PathDestination_Api = "Litium.Accelerator.Mvc\\Controllers\\Api\\_Addons";
            public const string PathDestination_StylesAddons = "Litium.Accelerator.Mvc\\Client\\Styles\\_Addons";
            public const string PathDestination_Scripts = "Litium.Accelerator.Mvc\\Client\\Scripts";
            public const string PathDestination_ScriptsAddons = PathDestination_Scripts + "\\_Addons";
            public const string PathDestination_ViewsAddons = "Litium.Accelerator.Mvc\\Views\\_Addons";
            public const string PathDestination_ViewsAddonsBlock = PathDestination_ViewsAddons + "Blocks";


            public const string AddonNameReplace = "PNAddonTemp";
            public const string AddonNameReplaceKebabCase = "pn-addon-temp-kebab";
            public const string AddonNameReplaceCamelCase = "pnAddonTempCamel";
            public const string AddonNameReplaceAllLettersSmall = "pn_addontemplower";

            private static string addonName; // field
            public static string AddonName
            {
                get { return addonName; }
                set
                {
                    addonName = value;
                    AddonNameKebabCase = General.ConvertStringToKebabCase(value);
                    AddonNameCamelCase = "pn" + value.Replace("PN", string.Empty);
                    AddonNameAllLowerCase = value.ToLower();
                }
            }
            public static string AddonNameKebabCase { get; set; } = string.Empty;
            public static string AddonNameCamelCase { get; set; } = string.Empty;
            public static string AddonNameAllLowerCase { get; set; } = string.Empty;


            internal static bool ignoreChange;

            public static DirectoryInfo ProjectDirectory { get; set; }
            //public static DirectoryInfo TemplateDirectory { get; set; }
            public static String AddonType { get; set; } = string.Empty;
            public static bool UseNewWebsiteSettings { get; internal set; }
            public static bool UseNewFields { get; internal set; }
            public static bool UseConstants { get; internal set; }
            public static bool UsePageTemplate { get; internal set; }
            public static bool UseServices { get; internal set; }
            public static bool UseViewModels { get; internal set; }
            public static bool UseBuilders { get; internal set; }
            public static bool UseApi { get; internal set; }
            public static bool UseReducers { get; internal set; }
            public static bool UseREACT { get; internal set; }
            public static bool UseStyling { get; internal set; }
            public static string? MainType { get; internal set; }
        }
    }
}