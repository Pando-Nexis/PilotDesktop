using PilotDesktop.CodeGenerator.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PilotDesktop.General.Services
{
    public static class StringService
    {
        public static string FixStringPascalCase(string str)
        {
            str = CleanInput(str);
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

        public static string CleanInput(string value)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(value, "[^a-zA-Z0-9_ ]", String.Empty);                
            }
            // If we timeout when replacing invalid characters,
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
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

            if (isInFile && str.Contains(prefix + CodeGeneratorConstants.AddonDestinationFolderName + sufix))
            {
                str = str.Replace(prefix + CodeGeneratorConstants.AddonDestinationFolderName + sufix, CodeGeneratorItem.UseSolutionInseadOfAddons ? CodeGeneratorConstants.SolutionFolderName : CodeGeneratorConstants.AddonsFolderName);
            }
            if (CodeGeneratorItem.UseSolutionInseadOfAddons && str.Contains(CodeGeneratorConstants.AddonsFolderName))
            {
                str.Replace(CodeGeneratorConstants.AddonsFolderName, CodeGeneratorConstants.SolutionFolderName);
            }
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
            if (str.Contains(prefix + CodeGeneratorConstants.AddonOptionByName + sufix))
            {
                // Checking if there is an option name present.
                // If there is AND it's found in the optionList show it,
                // otherwise continue
                str = str.Replace(prefix + CodeGeneratorConstants.AddonOptionByName + sufix, "");
                bool? optionFound = null;
                if (optionList != null && optionList.Count() > 0)
                {
                    optionFound = optionList.Select(x => str.ToLower() == x.ToLower())?.Where(y => y == true).FirstOrDefault();
                }
                if (optionFound == null || optionFound == false)
                {
                    return "continue";
                }
            }
            if (str.Contains(prefix + CodeGeneratorConstants.AddonOptionByPath + sufix))
            {
                // Checking if there is an option part path present.
                // If there is AND it's found in the optionList show it,
                // otherwise continue
                str = str.Replace(prefix + CodeGeneratorConstants.AddonOptionByPath + sufix, "");
                bool? optionFound = null;
                if (optionList != null && optionList.Count() > 0)
                {
                    optionFound = optionList.Select(x => fullName.ToLower().Contains(x.ToLower()))?.Where(y => y == true).FirstOrDefault();
                }
                if (optionFound == null || optionFound == false)
                {
                    return "continue";
                }
            }

            return str;
        }
    }
}
