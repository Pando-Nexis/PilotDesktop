using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.General.Services
{
    public static class CodeGeneratorConstants
    {
        // Todo Aspen: Fix all Files
        // Todo Aspen: Fix all Source paths
        // Todo Aspen: Fix all Logic (search-replace: PNAddon and pn-addon)

        
        public const string PathSource_Api = "Litium.Accelerator.Mvc\\Controllers\\API\\PNAddon";

        public const string Path_StylesAddons = "Litium.Accelerator.Mvc\\Client\\Styles\\_Addons";
        public const string Path_StylesApi = "Litium.Accelerator.Mvc\\Controllers\\Api\\_Addons";
        public const string Path_ScriptsAddons = "Litium.Accelerator.Mvc\\Client\\Scripts\\_Addons";
        //public const string PathDestination_StylesAddons = "Litium.Accelerator.Mvc\\Client\\Styles\\_Addons";

        public const string Path_DestinationPnAddonsExtensions = "PandoNexis.AddOns.Extensions";
        public const string PathDestination_Api = "Litium.Accelerator.Mvc\\Controllers\\Api\\_Addons";
        public const string PathDestination_ViewsAddons = "Litium.Accelerator.Mvc\\Views\\_Addons";
        public const string PathDestination_ViewsAddonsBlock = PathDestination_ViewsAddons + "Blocks";


        public const string AddonNameReplace = "PNAddonTemp";
        public const string AddonNameReplaceKebabCase = "pn-addon-temp-kebab";
        public const string AddonNameReplaceCamelCase = "pnAddonTempCamel";
        public const string AddonNameReplaceAllLettersLower = "pn_addontemplower";
        public const string AddonNameReplaceAllLettersUpper = "PN_ADDONTEMP_UPPER";
        public const string AddonOptionByPath = "pn_option_";
        public const string AddonOptionByName = "pn_option_by_name_";
    }
}
