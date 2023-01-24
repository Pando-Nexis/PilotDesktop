using PilotDesktop.General.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.CodeGenerator.Models
{
    internal class CodeGeneratorItem
    {
        public static string? PathProject { get; internal set; } = string.Empty;
        public static string? PathTemplates { get; internal set; } = string.Empty;

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
                AddonNameAllUpperCase = value.ToUpper();
            }
        }
        public static string AddonNameKebabCase { get; set; } = string.Empty;
        public static string AddonNameCamelCase { get; set; } = string.Empty;
        public static string AddonNameAllLowerCase { get; set; } = string.Empty;
        public static string AddonNameAllUpperCase { get; set; } = string.Empty;

        internal static bool ignoreChange;

        public static DirectoryInfo ProjectDirectory { get; set; }
        //public static DirectoryInfo TemplateDirectory { get; set; }
        public static String AddonType { get; set; } = string.Empty;
        public static String DestinationFolderName { get; set; } = string.Empty;
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
        public static string? MainType { get; internal set; } = string.Empty;
        public static bool UseSolutionInseadOfAddons { get; internal set; }
    }
}
