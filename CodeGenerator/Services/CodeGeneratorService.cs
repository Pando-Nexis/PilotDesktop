using Newtonsoft.Json;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PilotDesktop.Program;
using PilotDesktop.General.Services;
using PilotDesktop.CodeGenerator.Models;

namespace PilotDesktop.General.Services
{
    internal class CodeGeneratorService
    {
        public static void SetTemplatePath()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "TemplateFiles");
            if (Directory.Exists(path))
            {
                CodeGeneratorItem.PathTemplates = path;
                //CodeGeneratorItem.TemplateDirectory = new DirectoryInfo(path);
            }

            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
        }

        public static bool CreateStructure(string pathToSourceFiles, string pathToDestinationFiles = "", List<string> optionList = null)
        {
            if (string.IsNullOrWhiteSpace(pathToDestinationFiles))
            {
                pathToDestinationFiles = pathToSourceFiles;
            }
            var errorDir = string.Empty;
            var source = GetPathToTemplates(pathToSourceFiles);
            if (!string.IsNullOrWhiteSpace(source))
            {
                var destination = GetPathToDestination(pathToDestinationFiles);
                if (!string.IsNullOrWhiteSpace(destination))
                {
                    FilesAndFolderService.ChangeFileVariableNames(FilesAndFolderService.CopyFilesRecursively(new DirectoryInfo(source), new DirectoryInfo(destination), optionList: optionList));
                    return true;
                }
            }
            return false;
        }

        public static string GetPathToTemplates(string templatePath)
        {
            var errHeading = string.Empty;
            var errString = string.Empty;
            if (string.IsNullOrWhiteSpace(CodeGeneratorItem.PathTemplates)){
                SetTemplatePath();
            }
            if (!string.IsNullOrWhiteSpace(CodeGeneratorItem.PathTemplates) && !string.IsNullOrWhiteSpace(templatePath))
            {
                var source = Path.Combine(CodeGeneratorItem.PathTemplates, templatePath);
                var sourceExists = Directory.Exists(source);
                if (sourceExists)
                {
                    return source;
                }
                else
                {
                    errHeading = "Är följande sökväg korrekt?";
                    errString = "addonDestination: (" + source + ")";
                }
            }
            else
            {
                errHeading = "Sätts värdena för Addon korrekt i programmet?";
                errString = "\"Följande variabler saknar kanske värden?\r\r CodeGeneratorItem.PathTemplates: (" + CodeGeneratorItem.PathTemplates + ")\r\r"
                                     + "addonPath: (" + templatePath + ")";
            }
            CreateNotificationBox(errHeading, errString);

            return string.Empty;
        }
        public static string GetPathToDestination(string addonPath)
        {
            var errHeading = string.Empty;
            var errString = string.Empty;
            if (!string.IsNullOrWhiteSpace(CodeGeneratorItem.PathProject) && !string.IsNullOrWhiteSpace(addonPath))
            {
                var destination = Path.Combine(CodeGeneratorItem.PathProject, addonPath);
                var destinationExists = Directory.Exists(destination);

                if (destinationExists)
                    return destination;
                else
                {
                    errHeading = "Är följande sökväg korrekt?";
                    errString = "addonDestination: (" + destination + ")";
                }
            }
            else
            {
                errHeading = "Sätts värdena för Addon korrekt i programmet?";
                errString = "\"Följande variabler saknar kanske värden?\r\r CodeGeneratorItem.PathProject: (" + CodeGeneratorItem.PathProject + ")\r\r"
                                     + "addonPath: (" + addonPath + ")";
            }
            CreateNotificationBox(errHeading, errString);

            return string.Empty;
        }

        public static void CreateNotificationBox(string header, string body)
        {
            var confirm = MessageBox.Show(header, body, MessageBoxButtons.OK);
        }
    }
}
