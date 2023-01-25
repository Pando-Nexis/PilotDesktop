using PilotDesktop.SourceCode.Constants;

namespace PilotDesktop.General.Services
{
    public static class CodeGeneratorConstants
    {
        public const string PathSource_Api = ProjectConstants.Mvc + "\\Controllers\\API\\PNAddon";

        public const string Path_StylesAddons = ProjectConstants.Mvc + "\\Client\\Styles\\_Addons";
        public const string Path_StylesApi = ProjectConstants.Mvc + "\\Controllers\\Api\\_Addons";
        public const string Path_ScriptsAddons = ProjectConstants.Mvc + "\\Client\\Scripts\\_Addons";
      
        public const string PathDestination_Api = ProjectConstants.Mvc + "\\Controllers\\Api\\_Addons";
        public const string PathDestination_ViewsAddons = ProjectConstants.Mvc + "\\Views\\_Addons";
        public const string PathDestination_ViewsAddonsBlock = PathDestination_ViewsAddons + "Blocks";

        public const string AddonsFolderName = "_Addons";
        public const string SolutionFolderName = "_Solution";

        public const string AddonNameReplace = "PNAddonTemp";
        public const string AddonNameReplaceKebabCase = "pn-addon-temp-kebab";
        public const string AddonNameReplaceCamelCase = "pnAddonTempCamel";
        public const string AddonNameReplaceAllLettersLower = "pn_addontemplower";
        public const string AddonNameReplaceAllLettersUpper = "PN_ADDONTEMP_UPPER";
        public const string AddonOptionByPath = "pn_option_";
        public const string AddonOptionByName = "pn_option_by_name_";
        public const string AddonDestinationFolderName = "pn_destination_folder_name"; // _Addons or _Solution
    }
}
