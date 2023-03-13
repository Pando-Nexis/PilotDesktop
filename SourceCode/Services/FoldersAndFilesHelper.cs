using PilotDesktop.SourceCode.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.SourceCode.Services
{
    public static class FoldersAndFilesHelper
    {
        private static List<string> _excludedDirectories = new List<string>() {
                                                                        "node_modules",
                                                                        "files",
                                                                        "test",
                                                                        "bin",
                                                                        "obj",
                                                                        "dist",
                                                                        "_addons",
                                                                        "_config",
                                                                        ProjectConstants.AddOn.ToLower(),
                                                                        ProjectConstants.Solution.ToLower()
                                                                    };
        private static List<string> _excludedFiles = new List<string>() {  "AnalysisReport.sarif".ToLower(),
                                                                "upgrade-assistant.clef".ToLower()
                                                              };
        public static void GetFoldersAndFilesForTreeView(string path, ref TreeNode treeNode)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                treeNode.Nodes.Add(GetFileTreeNode(Path.GetFileName(file), file));
            }
            foreach (var directory in Directory.GetDirectories(path))
            {
                if (!string.IsNullOrEmpty(directory))
                {
                    var directoryNode = GetDirectoryTreeNode(directory);
                    GetFoldersAndFilesForTreeView(directory as string, ref directoryNode);
                    treeNode.Nodes.Add(directoryNode);
                }
            }


        }
        public static TreeNode GetFileTreeNode(string fileName, string path)
        {
            var node = new TreeNode();

            node.Text = fileName;
            node.Tag = path;
            node.Text = fileName;
            return node;

        }
        public static TreeNode GetDirectoryTreeNode(string folder)
        {
            var node = new TreeNode();
            node.Text = GetFolderName(folder);
            return node;
        }

        public static string GetFolderName(string path)
        {
            if (Directory.Exists(path))
                return new DirectoryInfo(path)?.Name ?? string.Empty;

            return "Error";
        }
        public static void CopyFiles(string masterProjectDirectoryPath, string createProjectPath, bool isAddon = false)
        {
            
            foreach (var file in Directory.GetFiles(masterProjectDirectoryPath))
            {
                if (IncludeFile(file, isAddon))
                {
                    var newFilePath = Path.Combine(createProjectPath, Path.GetFileName(file));
                    File.Copy(file, newFilePath);
                }
            }

        }
        public static bool IncludeFile(string filePath, bool isAddon = false)
        {
            var fileName = Path.GetFileName(filePath);
            if (!isAddon)
            {
            }
            if (fileName.StartsWith(".") && fileName!=".gitignore")
                return false;
            if (_excludedFiles.Contains(fileName.ToLower()))
                return false;
            if (fileName.EndsWith(FileTypeConstants.Sln))
                return false;
           
            return true;
        }
        public static void CreateSubFolders(string masterProjectDirectoryPath, string createProjectPath, bool isAddon = false)
        {
            foreach (var childDirectory in Directory.GetDirectories(masterProjectDirectoryPath))
            {
                if (IncludDirectory(childDirectory, isAddon))
                {
                    string newDirectoryPath = Path.Combine(createProjectPath, FoldersAndFilesHelper.GetFolderName(childDirectory));
                    Directory.CreateDirectory(newDirectoryPath);
                    CopyFiles(childDirectory, newDirectoryPath, isAddon);
                    CreateSubFolders(childDirectory, newDirectoryPath, isAddon);
                }

            }
        }
        public static void CopySpecificFolder(string masterProjectDirectoryPath, string createProjectPath, string folderName)
        {
            foreach (var childDirectory in Directory.GetDirectories(masterProjectDirectoryPath))
            {
                string newDirectoryPath = Path.Combine(createProjectPath, FoldersAndFilesHelper.GetFolderName(childDirectory));
                if (IncludDirectory(childDirectory) && FoldersAndFilesHelper.GetFolderName(childDirectory) == folderName)
                {
                    Directory.CreateDirectory(newDirectoryPath);
                    CopyFiles(childDirectory, newDirectoryPath);
                    CreateSubFolders(childDirectory, newDirectoryPath);
                }
                CopySpecificFolder(childDirectory, newDirectoryPath, folderName);

            }
        }

        public static bool IncludDirectory(string childDirectory, bool isAddon = false)
        {
            var directoryName = FoldersAndFilesHelper.GetFolderName(childDirectory);
            if (!isAddon)
            {

                //if (childDirectory.ToLower().Contains("PandoNexis.AddOns.Extensions\\PN".ToLower()))
                //    return false;
                //if (directoryName.ToLower() == "Solution.Extensions".ToLower())
                //    return false;
            }
            if (directoryName.StartsWith("."))
                return false;
            if (_excludedDirectories.Contains(directoryName.ToLower()))
                return false;
            return true;

        }

        public static string GetFolderPath(string filePath)
        {
            var chunks = filePath.Split('\\');
            var index = chunks.Count() - 1;
            var nloop = 0;
            var result = string.Empty;
            while (index > nloop)
            {
                result += chunks[nloop] + '\\';
                nloop++;
            }
            return result;
        }
        public static string GetIndexsCssPath(string projectPath)
        {
           if(!Directory.Exists(Path.Combine(projectPath,
                                                      FolderConstants.Src,
                                                      ProjectConstants.Mvc,
                                                      FolderConstants.Client,
                                                      FolderConstants.Styles,
                                                      FolderConstants.Addons
                                                      )))
            {
                Directory.CreateDirectory(Path.Combine(projectPath,
                                                      FolderConstants.Src,
                                                      ProjectConstants.Mvc,
                                                      FolderConstants.Client,
                                                      FolderConstants.Styles,
                                                      FolderConstants.Addons
                                                      ));
            }
            return Path.Combine(projectPath,
                                                      FolderConstants.Src,
                                                      ProjectConstants.Mvc,
                                                      FolderConstants.Client,
                                                      FolderConstants.Styles,
                                                      FolderConstants.Addons,
                                                      FileTypeConstants.IndexScss);
        }

    }
}
