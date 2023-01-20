using PilotDesktop.SourceCode.Constants;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace PilotDesktop.SourceCode.Services;

public class SourceCodeProjectService
{



    #region AddOns
    public void CreateAddonProject(string masterProjectDirectoryPath, string createProjectPath, List<string> addOns)
    {
        var masterAddonProjectPath = Path.Combine(masterProjectDirectoryPath, FolderConstants.Src, ProjectConstants.AddOn);
        var createAddonProjectPath = masterAddonProjectPath.Replace(masterProjectDirectoryPath, createProjectPath);
        Directory.CreateDirectory(createAddonProjectPath);

        foreach (var addOn in addOns)
        {
            AddAddons(masterProjectDirectoryPath, createProjectPath, addOn);
        }

        var resxFiles = Directory.GetFiles(createAddonProjectPath, FileFilterConstants.Resx, SearchOption.AllDirectories)?.ToList() ?? new List<string>();

        CreateCsProjeFile(Path.Combine(masterAddonProjectPath, ProjectConstants.AddOn + FileTypeConstants.Csproj), Path.Combine(createAddonProjectPath, ProjectConstants.AddOn + FileTypeConstants.Csproj), createAddonProjectPath, resxFiles);


        CreatePandoNexisJsFile(masterProjectDirectoryPath, createProjectPath, addOns);
        CreateAddonReducerFile(createProjectPath, addOns);
        CreateAddonIndexScss(createProjectPath, addOns);

        var viewPaths = new List<string>();
        GetViews(masterProjectDirectoryPath, FileTypeConstants.Views, addOns, ref viewPaths);
        AddModifiedFiles(masterProjectDirectoryPath, createProjectPath, viewPaths, addOns);

        var modifieldPaths = new List<string>();
        GetAllModifiedFiles(masterProjectDirectoryPath, FileTypeConstants.Modified, ref modifieldPaths);
        AddModifiedFiles(masterProjectDirectoryPath, createProjectPath, modifieldPaths, addOns);
    }

    public void AddAddonToProject(string masterProjectDirectoryPath, string createProjectPath, List<string> addOns)
    {
        var masterAddonProjectPath = Path.Combine(masterProjectDirectoryPath, FolderConstants.Src, ProjectConstants.AddOn);
        var createAddonProjectPath = masterAddonProjectPath.Replace(masterProjectDirectoryPath, createProjectPath);
        if (!Directory.Exists(createAddonProjectPath))
            Directory.CreateDirectory(createAddonProjectPath);

        foreach (var addOn in addOns)
        {
            if (!Directory.Exists(Path.Combine(createAddonProjectPath, addOn)))
                AddAddons(masterProjectDirectoryPath, createProjectPath, addOn);
        }

        addOns = GetAddons(createAddonProjectPath);

        var resxFiles = Directory.GetFiles(createAddonProjectPath, FileFilterConstants.Resx, SearchOption.AllDirectories)?.ToList() ?? new List<string>();

        CreateCsProjeFile(Path.Combine(masterAddonProjectPath, ProjectConstants.AddOn + FileTypeConstants.Csproj), Path.Combine(createAddonProjectPath, ProjectConstants.AddOn + FileTypeConstants.Csproj), createAddonProjectPath, resxFiles);

        CreatePandoNexisJsFile(masterProjectDirectoryPath, createProjectPath, addOns);
        CreateAddonReducerFile(createProjectPath, addOns);
        CreateAddonIndexScss(createProjectPath, addOns);

        var viewPaths = new List<string>();
        GetViews(masterProjectDirectoryPath, FileTypeConstants.Views, addOns, ref viewPaths);
        AddModifiedFiles(masterProjectDirectoryPath, createProjectPath, viewPaths, addOns);

        var modifieldPaths = new List<string>();
        GetAllModifiedFiles(masterProjectDirectoryPath, FileTypeConstants.Modified, ref modifieldPaths);
        AddModifiedFiles(masterProjectDirectoryPath, createProjectPath, modifieldPaths, addOns);
    }

    public List<string> GetAddons(string projectPath)
    {
        var result = new List<string>();
        foreach (var directory in Directory.GetDirectories(projectPath))
        {
            result.Add(FoldersAndFilesHelper.GetFolderName(directory));
        }
        return result;
    }

    public void AddModifiedFiles(string masterProjectDirectoryPath, string createProjectPath, List<string> modifiedPaths, List<string> addOns)
    {
        var addLine = true;
        var currentAddonName = string.Empty;
        foreach (var viewPath in modifiedPaths)
        {
            var destFile = new List<string>();
            var source = File.ReadAllLines(masterProjectDirectoryPath + viewPath);

            foreach (var sourceLine in source)
            {
                if (sourceLine.Replace(" ", "").Contains(ConfigConstants.BeginAddOn.Replace(" ", "")))
                {
                    var addonName = sourceLine.Replace(ConfigConstants.BeginAddOn, "").Replace(" ", "");
                    if (!addOns.Contains(addonName))
                    {
                        addLine = false;
                        currentAddonName = addonName;
                    }
                }
                if (addLine)
                {
                    destFile.Add(sourceLine);
                }
                if (sourceLine.Replace(" ", "").Contains(ConfigConstants.EndAddOn.Replace(" ", "")))
                {
                    var addonName = sourceLine.Replace(ConfigConstants.EndAddOn, "").Replace(" ", "");
                    if (addonName == currentAddonName)
                    {
                        addLine = true;
                        currentAddonName = string.Empty;
                    }
                }
            }
            if (!Directory.Exists(FoldersAndFilesHelper.GetFolderPath(createProjectPath + viewPath)))
                Directory.CreateDirectory(FoldersAndFilesHelper.GetFolderPath(createProjectPath + viewPath));

            File.WriteAllLines(createProjectPath + viewPath, destFile);
        }

    }
    private void GetViews(string masterProjectDirectoryPath, string fileName, List<string> addons, ref List<string> paths)
    {
        foreach (var addon in addons)
        {
            var configPath = Path.Combine(masterProjectDirectoryPath, FolderConstants.Src, ProjectConstants.AddOn, addon, FolderConstants.Config);
            if (!Directory.Exists(configPath))
                continue;

            var configViews = Path.Combine(configPath, fileName);
            if (!File.Exists(configViews))
                continue;

            var lines = File.ReadAllLines(configViews);

            if (lines.Length > 0)
            {
                foreach (var line in lines)
                {
                    if (!paths.Contains(line))
                        paths.Add(line);
                }
            }
        }

    }
    private void GetAllModifiedFiles(string masterProjectDirectoryPath, string fileName, ref List<string> modifieldPaths)
    {
        var masterAddonPath = Path.Combine(masterProjectDirectoryPath, FolderConstants.Src, ProjectConstants.AddOn);
        foreach (var folder in Directory.GetDirectories(masterAddonPath))
        {
            var configPath = Path.Combine(folder, FolderConstants.Config);
            if (!Directory.Exists(configPath))
                continue;
            var filePath = Path.Combine(configPath, fileName);

            if (!File.Exists(filePath))
                continue;

            var lines = File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                foreach (var line in lines)
                {
                    if (!modifieldPaths.Contains(line))
                        modifieldPaths.Add(line);
                }
            }
        }
    }

    private void CreateAddonIndexScss(string createProjectPath, List<string> addOns)
    {

        var indexScss = new List<string>();
        GetCssIndex(createProjectPath, addOns, ref indexScss);




        File.WriteAllLines(FoldersAndFilesHelper.GetIndexsCssPath(createProjectPath), indexScss);
    }

    private void CreateAddonReducerFile(string createProjectPath, List<string> addons)
    {
        var reducers = new List<string>();
        GetReducers(createProjectPath, addons, ref reducers);

        var lines = new List<string>();

        foreach (var reducer in reducers)
        {
            var name = reducer.Substring(0, 2).ToLower() + reducer.Substring(2);
            lines.Add($"{ConfigConstants.JsImport}{name}{ConfigConstants.JsImportFrom}{reducer}{ConfigConstants.JsReducers}");
        }
        lines.Add("");
        lines.Add("");
        lines.Add(ConfigConstants.JsExportConstantReducers);
        foreach (var reducer in reducers)
        {

            var name = reducer.Substring(0, 2).ToLower() + reducer.Substring(2);
            lines.Add($"    ...{name},");
        }
        lines.Add(ConfigConstants.JsEndOfExport);

        if (!Directory.Exists(Path.Combine(createProjectPath,FolderConstants.Src,ProjectConstants.Mvc,FolderConstants.Client,FolderConstants.Script,FolderConstants.Addons)))
        {
            Directory.CreateDirectory(Path.Combine(createProjectPath,
                                       FolderConstants.Src,
                                       ProjectConstants.Mvc,
                                       FolderConstants.Client,
                                       FolderConstants.Script,
                                       FolderConstants.Addons));
        }


        File.WriteAllLines(Path.Combine(createProjectPath,
                                       FolderConstants.Src,
                                       ProjectConstants.Mvc,
                                       FolderConstants.Client,
                                       FolderConstants.Script,
                                       FolderConstants.Addons,
                                       FileTypeConstants.Reducers), lines);
    }


    private void GetReducers(string projectPath, List<string> addOns, ref List<string> reducers)
    {
        foreach (var addOn in addOns)
        {
            var configPath = Path.Combine(projectPath, FolderConstants.Src, ProjectConstants.Mvc, FolderConstants.Client, FolderConstants.Script, FolderConstants.Addons, addOn);


            if (!Directory.Exists(configPath))
                continue;

            var reducerJsPath = Path.Combine(configPath, FileTypeConstants.Reducers);
            if (!File.Exists(reducerJsPath))
                continue;


            reducers.Add(addOn);

        }
    }
    private void GetCssIndex(string projectPath, List<string> addOns, ref List<string> cssIndex)
    {
        foreach (var addOn in addOns)
        {
            var configPath = Path.Combine(projectPath, FolderConstants.Src, ProjectConstants.Mvc, FolderConstants.Client, FolderConstants.Styles, FolderConstants.Addons, addOn);


            if (!Directory.Exists(configPath))
                continue;

            var reducerJsPath = Path.Combine(configPath, FileTypeConstants.IndexScss);
            if (!File.Exists(reducerJsPath))
                continue;


            cssIndex.Add(ConfigConstants.CssImport + addOn + ConfigConstants.CssIndex);

        }
    }

    private void CreatePandoNexisJsFile(string masterProjectDirectoryPath, string createProjectPath, List<string> addOns)
    {
        var pandoNexisJsImports = new List<string>();
        var pandoNexisJsComponent = new List<string>();
        GetPandoNexisJsEntities(masterProjectDirectoryPath, addOns, ref pandoNexisJsImports, ref pandoNexisJsComponent);

        var sourcePNjs = File.ReadAllLines(Path.Combine(masterProjectDirectoryPath, FolderConstants.Src, ProjectConstants.Mvc, FolderConstants.Client, FolderConstants.Script, FileTypeConstants.PandoNexisJs));

        var destPNjsPath = Path.Combine(createProjectPath, FolderConstants.Src, ProjectConstants.Mvc, FolderConstants.Client, FolderConstants.Script, FileTypeConstants.PandoNexisJs);
        var destPNj = new List<string>();
        var importLines = false;
        var importLinesAdded = false;
        var componentLines = false;
        var componentLinesAdded = false;

        foreach (var line in sourcePNjs)
        {
            if (!importLines && !componentLines)
            {
                destPNj.Add(line);
            }

            if (line.Replace(" ", "").Contains(ConfigConstants.EndImport.Replace(" ", "")))
            {
                destPNj.Add(line);
                importLines = false;
            }

            if (line.Replace(" ", "").Contains(ConfigConstants.EndComponent.Replace(" ", "")))
            {
                destPNj.Add(line);
                componentLines = false;
            }

            if (!importLinesAdded && importLines)
            {
                destPNj.AddRange(pandoNexisJsImports);
                importLinesAdded = true;
            }
            if (!componentLinesAdded && componentLines)
            {
                destPNj.AddRange(pandoNexisJsComponent);
                componentLinesAdded = true;
            }

            if (line.Replace(" ", "").Contains(ConfigConstants.BeginImport.Replace(" ", "")))
            {
                importLines = true;
            }
            if (line.Replace(" ", "").Contains(ConfigConstants.BeginComponent.Replace(" ", "")))
            {
                componentLines = true;
            }
        }
        File.WriteAllLines(destPNjsPath, destPNj.ToArray());
    }

    public void AddAddons(string masterProjectPath, string createProjectPath, string addOn)
    {
        var addonPath = Path.Combine(masterProjectPath, FolderConstants.Src, ProjectConstants.AddOn, addOn);
        var newAddonPath = Path.Combine(createProjectPath, FolderConstants.Src, ProjectConstants.AddOn, addOn);
        Directory.CreateDirectory(newAddonPath);
        FoldersAndFilesHelper.CopyFiles(addonPath, newAddonPath, true);
        FoldersAndFilesHelper.CreateSubFolders(addonPath, newAddonPath, true);
        FoldersAndFilesHelper.CopySpecificFolder(Path.Combine(masterProjectPath, FolderConstants.Src, ProjectConstants.Mvc), Path.Combine(createProjectPath, FolderConstants.Src, ProjectConstants.Mvc), addOn);

        var configPath = Path.Combine(addonPath, FolderConstants.Config);

    }

    public void GetPandoNexisJsEntities(string projectPath, List<string> addons, ref List<string> pandoNexisJsImports, ref List<string> pandoNexisJsComponents)
    {
        foreach (var addon in addons)
        {
            var configPath = Path.Combine(projectPath, FolderConstants.Src, ProjectConstants.AddOn, addon, FolderConstants.Config);


            if (!Directory.Exists(configPath))
                return;

            var configJsPath = Path.Combine(configPath, FileTypeConstants.PandoNexisJsMerge);
            if (!File.Exists(configJsPath))
                return;


            var lines = File.ReadLines(configJsPath);
            var importLines = false;
            var componentLines = false;
            foreach (var line in lines)
            {
                if (line.Replace(" ", "").Contains(ConfigConstants.EndImport.Replace(" ", "")))
                    importLines = false;
                if (line.Replace(" ", "").Contains(ConfigConstants.EndComponent.Replace(" ", "")))
                    componentLines = false;

                if (importLines)
                    pandoNexisJsImports.Add(line);
                if (componentLines)
                    pandoNexisJsComponents.Add(line);

                if (line.Replace(" ", "").Contains(ConfigConstants.BeginImport.Replace(" ", "")))
                    importLines = true;
                if (line.Replace(" ", "").Contains(ConfigConstants.BeginComponent.Replace(" ", "")))
                    componentLines = true;
            }
        }
    }


    #endregion

    #region Solution
    public void CreateSolutionProject(string masterProjectDirectoryPath, string createProjectPath)
    {
        var masterSolutionProjectPath = Path.Combine(masterProjectDirectoryPath, FolderConstants.Src, ProjectConstants.Solution);
        var createSolutionProjectPath = masterSolutionProjectPath.Replace(masterProjectDirectoryPath, createProjectPath);
        Directory.CreateDirectory(createSolutionProjectPath);

        FoldersAndFilesHelper.CreateSubFolders(masterSolutionProjectPath, createSolutionProjectPath);

        var resxFiles = Directory.GetFiles(createSolutionProjectPath, FileFilterConstants.Resx, SearchOption.AllDirectories)?.ToList() ?? new List<string>();

        CreateCsProjeFile(Path.Combine(masterSolutionProjectPath, ProjectConstants.Solution + FileTypeConstants.Csproj), Path.Combine(createSolutionProjectPath, ProjectConstants.Solution + FileTypeConstants.Csproj), createSolutionProjectPath, resxFiles);

    }
    #endregion

    #region Generate Files
    public void CreateCsProjeFile(string masterFilePath, string createFilePath, string createProjectPath, List<string> resxFiles)
    {
        var xmlString = File.ReadAllText(masterFilePath);


        XmlDocument newDoc = new XmlDocument();
        var settings = new XmlWriterSettings { Encoding = Encoding.Unicode, OmitXmlDeclaration = true, Indent = true };

        using (var writer = XmlWriter.Create(createFilePath, settings))
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            writer.WriteStartDocument();
            writer.WriteStartElement(doc.FirstChild.Name);
            writer.WriteAttributeString(doc.FirstChild.Attributes[0].Name, doc.FirstChild.Attributes[0].Value);



            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node.Name == XmlConstants.PropertyGroup)
                {
                    writer.WriteStartElement(node.Name);
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        writer.WriteElementString(child.Name, child.InnerText);
                    }
                    writer.WriteEndElement();
                }
                else if (node.Name == XmlConstants.ItemGroup)
                {
                    var addedNode = false;
                    if (node.ChildNodes[0].Name == XmlConstants.PackageReference || node.ChildNodes[0].Name == XmlConstants.ProjectReference)
                    {
                        writer.WriteStartElement(XmlConstants.ItemGroup);

                        foreach (XmlNode childnode in node.ChildNodes)
                        {
                            writer.WriteStartElement(childnode.Name);
                            if (childnode.Attributes != null)
                            {
                                var tot = childnode.Attributes.Count;
                                var i = 0;
                                while (tot > i)
                                {
                                    writer.WriteAttributeString(childnode.Attributes[i].Name, childnode.Attributes[i].Value);
                                    i++;
                                }
                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                }
            }
            if (resxFiles != null)
            {
                writer.WriteStartElement(XmlConstants.ItemGroup);
                foreach (var file in resxFiles)
                {
                    writer.WriteStartElement(XmlConstants.LitiumLocalization);
                    writer.WriteAttributeString(XmlConstants.Include, file.Replace(createProjectPath + "\\", ""));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndDocument();
        }
    }

    public void CreateSlnFile(string masterProjectDirectoryPath, string createProjectPath)
    {
        var directoryName = FoldersAndFilesHelper.GetFolderName(createProjectPath);
        var newSlnPath = Path.Combine(createProjectPath, directoryName + FileTypeConstants.Sln);
        File.Copy(masterProjectDirectoryPath, newSlnPath);
    }
    #endregion



    #region Folder Helpers


    #endregion


}
