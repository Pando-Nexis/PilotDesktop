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

namespace PilotDesktop.General.Services
{
    internal class CodeGeneratorService
    {        
        public static void SetTemplatePath()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "TemplateFiles");
            if (Directory.Exists(path))
            {
                Global.PathTemplates = path;
                //Global.TemplateDirectory = new DirectoryInfo(path);
            }

            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
        }

        public static void CreateStylingStructure()
        {
            var source = Path.Combine(Global.PathTemplates, Global.PathSource_StylesAddons);
            var destination = Path.Combine(Global.PathProject, Global.PathDestination_StylesAddons);
            if (Directory.Exists(source) && Directory.Exists(destination))
            {
                FilesAndFolderService.ChangeFileVariableNames(FilesAndFolderService.CopyFilesRecursively(new DirectoryInfo(source), new DirectoryInfo(destination)));
            }
        }

    }
}
