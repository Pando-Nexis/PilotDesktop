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
    internal class FilesAndFolderService
    {
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
                var PNAddonsFolder = folders.FirstOrDefault(x => x.Name.ToLower() == CodeGeneratorConstants.PathDestinationPnAddonsExtensions.ToLower());
                if (PNAddonsFolder != null)
                {
                    return folderSrc;
                }
            }
            return null;
        }

        public static DirectoryInfo? CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target, bool isSubNode = false)
        {
            var sourceDirectories = source.GetDirectories();
            var newFolderName = string.Empty;
            foreach (DirectoryInfo dir in sourceDirectories)
            {
                var newName = StringService.ReplacePartString(dir.Name);
                if (!isSubNode)
                {
                    newFolderName = newName;
                }
                CopyFilesRecursively(dir, target.CreateSubdirectory(newName), true);
            }
            foreach (FileInfo file in source.GetFiles())
            {
                var newName = StringService.ReplacePartString(file.Name);
                file.CopyTo(Path.Combine(target.FullName, newName));
            }
            if (!isSubNode)
            {
                return target.GetDirectories()?.Where(x => x.Name == newFolderName)?.FirstOrDefault();
            }
            return null;
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
                str = StringService.ReplacePartString(str, true);
                File.WriteAllText(file.FullName, str);
            }
        }
    }
}
