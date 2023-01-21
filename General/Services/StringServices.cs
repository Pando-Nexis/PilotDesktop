using PilotDesktop.CodeGenerator.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PilotDesktop.General.Services
{
    public static class StringService
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

        public static string ReplacePartString(string str, bool isInFile = false, string fullName = "", List<string> optionList = null)
        {
            var prefix = isInFile ? "[" : string.Empty;
            var sufix = isInFile ? "]" : string.Empty;

            if (str.Contains(prefix + CodeGeneratorConstants.AddonNameReplace + sufix))
            {
                str = str.Replace(prefix + CodeGeneratorConstants.AddonNameReplace + sufix, CodeGeneratorItem.AddonName);
            }
            if (str.Contains(prefix + CodeGeneratorConstants.AddonNameReplaceKebabCase + sufix))
            {
                str = str.Replace(prefix + CodeGeneratorConstants.AddonNameReplaceKebabCase + sufix, CodeGeneratorItem.AddonNameKebabCase);
            }
            if (str.Contains(prefix + CodeGeneratorConstants.AddonNameReplaceCamelCase + sufix))
            {
                str = str.Replace(prefix + CodeGeneratorConstants.AddonNameReplaceCamelCase + sufix, CodeGeneratorItem.AddonNameCamelCase);
            }
            if (str.Contains(prefix + CodeGeneratorConstants.AddonNameReplaceAllLettersLower + sufix))
            {
                str = str.Replace(prefix + CodeGeneratorConstants.AddonNameReplaceAllLettersLower + sufix, CodeGeneratorItem.AddonNameAllLowerCase);
            }
            if (str.Contains(prefix + CodeGeneratorConstants.AddonNameReplaceAllLettersUpper + sufix))
            {
                str = str.Replace(prefix + CodeGeneratorConstants.AddonNameReplaceAllLettersUpper + sufix, CodeGeneratorItem.AddonNameAllUpperCase);
            }
            if (str.Contains(prefix + CodeGeneratorConstants.AddonOption + sufix))
            {
                // Checking if there is an option name present.
                // If there is AND it's found in the optionList show it,
                // otherwise continue
                str = str.Replace(prefix + CodeGeneratorConstants.AddonOption + sufix, "");
                if (optionList== null || optionList.Count()==0 || optionList.Select(x => fullName.ToLower().Contains(x.ToLower())) == null)
                {
                    return "continue";
                }
            }

            return str;
        }
    }
}
