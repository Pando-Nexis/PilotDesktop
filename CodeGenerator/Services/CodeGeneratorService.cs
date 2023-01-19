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

        public static void CreateStylingStructure()
        {
            var source = Path.Combine(CodeGeneratorItem.PathTemplates, CodeGeneratorConstants.PathSource_StylesAddons);
            var destination = Path.Combine(CodeGeneratorItem.PathProject, CodeGeneratorConstants.PathDestination_StylesAddons);
            if (Directory.Exists(source) && Directory.Exists(destination))
            {
                FilesAndFolderService.ChangeFileVariableNames(FilesAndFolderService.CopyFilesRecursively(new DirectoryInfo(source), new DirectoryInfo(destination)));
            }
        }

    }
}
