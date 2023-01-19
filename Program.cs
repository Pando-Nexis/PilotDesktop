using PilotDesktop.Pilot.Objects;
using PilotDesktop.Settings.Objects;
using PilotDesktop.Settings.Services;
using System.Globalization;
using System.Text.RegularExpressions;
using PilotDesktop.General.Services;

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
                    AddonNameKebabCase = StringService.ConvertStringToKebabCase(value);
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