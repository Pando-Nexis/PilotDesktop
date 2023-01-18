using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.SourceCode.Constants
{
    public static class ProjectConstants
    {

        public const string Extention = "PandoNexis.Accelerator.Extensions";
        public const string AddOn = "PandoNexis.AddOns.Extensions";
        public const string Solution = "Solution.Extensions";
        public const string Mvc = "Litium.Accelerator.Mvc";



    }
    public static class FileTypeConstants
    {
        public static string Sln = ".sln";
        public static string Csproj = ".csproj";
        public static string Cs = ".cs";
        public static string PandoNexisJsMerge = "pandoNexis.js_merge";
        public static string Views = "views.txt";
        public static string Modified = "modified.txt";
        public static string PandoNexisJs = "pandoNexis.js";
        public static string IndexScss = "index.scss";
        public static string Reducers = "reducers.js";
    }
    public static class FileFilterConstants
    {

        public static string Resx = "*.resx";
    }
    public static class FolderConstants
    {

        public static string Src = "Src";
        public static string Controllers = "Controllers";
        public static string Addons = "_Addons";
        public static string Config = "_config";
        public static string Client = "Client";
        public static string Script = "Scripts";
        public static string Styles = "Styles";
    }
    public static class PathsConstants
    { 
        public const string AddonControllers = "Litium.Accelerator.Mvc\\Controllers\\_Addons";
    }
    public static class ConfigConstants
    {
        public static string BeginImport = "//PandoNexis: BEGIN IMPORT";
        public static string EndImport = "//PandoNexis: END IMPORT";
        public static string BeginComponent = "//PandoNexis: BEGIN COMPONENT";
        public static string EndComponent = "//PandoNexis: END COMPONENT";

        public static string BeginAddOn = "//PandoNexis: BEGIN ADDON";
        public static string EndAddOn = "//PandoNexis: END ADDON";

        public static string CssImport = "@import '";
        public static string CssIndex = "/index';";

        public static string JsImport = "import { ";
        public static string JsImportFrom = " } from './";
        public static string JsReducers = "/reducers';";
        public static string JsExportConstantReducers = "export const addonReducers = {";
        public static string JsEndOfExport = "};";
    }
    
}
