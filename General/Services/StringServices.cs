using Newtonsoft.Json;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static PilotDesktop.Program;

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

        public static string ReplacePartString(string str, bool isInFile = false)
        {
            var prefix = isInFile ? "[" : string.Empty;
            var sufix = isInFile ? "]" : string.Empty;

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
}
