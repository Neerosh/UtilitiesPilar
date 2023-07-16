using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilitiesPilar.Classes
{
    public static class FileFilterService
    {
        public static void FilterFiles(FileFilterSetting fileFilterSetting, int fileFilterId, Form form)
        {
            Task.Run(() => {

                Database database = new Database();
                string returnMessage = "Task executed successfully.";

                try
                {
                    if (!Directory.Exists(fileFilterSetting.FolderDestination))
                        throw new Exception("Folder does not exists.");

                    List<FileFilterCondition> fileFilterList = database.SelectAllFileFilterConditions(fileFilterId);
                    List<string> fileListOrigin = new List<string>();
                    List<string> fileListOriginAux = new List<string>();
                    List<string> filteredFileList = new List<string>();
                    SearchOption searchOption = SearchOption.TopDirectoryOnly;

                    foreach (FileFilterCondition condition in fileFilterList)
                    {
                        if (condition.IncludeFolders)
                            searchOption = SearchOption.AllDirectories;
                        else
                            searchOption = SearchOption.TopDirectoryOnly;

                        if (condition.UserFolderOriginAux)
                        {
                            fileListOriginAux = Directory.GetFiles(fileFilterSetting.FolderOriginAux, "*", searchOption).ToList();
                            filteredFileList.AddRange(CopyActionFile(fileFilterSetting, condition, fileListOriginAux));
                        }
                        else
                        {
                            fileListOrigin = Directory.GetFiles(fileFilterSetting.FolderOrigin, "*", searchOption).ToList();
                            filteredFileList.AddRange(CopyActionFile(fileFilterSetting, condition, fileListOrigin));
                        }
                    }

                    if (filteredFileList != null)
                    {

                        if (fileFilterSetting.ZipFiles && !String.IsNullOrEmpty(fileFilterSetting.ZipFilename))
                        {
                            string zipFilename = fileFilterSetting.FolderDestination + "\\" +
                                                 fileFilterSetting.ZipFilename + ".zip";

                            if (File.Exists(zipFilename))
                                File.Delete(zipFilename);

                            using (ZipArchive zip = ZipFile.Open(zipFilename, ZipArchiveMode.Create))
                            {
                                foreach (string filename in filteredFileList)
                                {
                                    zip.CreateEntryFromFile(filename, filename.Replace(fileFilterSetting.FolderDestination + "\\", fileFilterSetting.ZipFilename + "\\"));
                                }
                            }

                            foreach (string filename in filteredFileList)
                            {
                                File.Delete(filename);
                            }

                            foreach (FileFilterCondition condition in fileFilterList.Where(item => !String.IsNullOrEmpty(item.SubFolderPath)))
                            {

                                foreach (string dir in Directory.GetDirectories(fileFilterSetting.FolderDestination))
                                {
                                    if (dir.Equals(fileFilterSetting.FolderDestination + "\\" + condition.SubFolderPath))
                                    {
                                        Directory.Delete(dir, true);
                                    }
                                }
                            }
                        }
                        
                    }
                    else
                        returnMessage = "None of the files found match this filter.";

                }
                catch (Exception ex)
                {
                    returnMessage = "Error: " + ex.Message;
                }

                form.Invoke(new Action(() => { MessageBox.Show(returnMessage); }));

            });
        }

        private static List<string> CopyActionFile(FileFilterSetting fileFilterSetting, FileFilterCondition fileCondition, List<string> fileList)
        {
            List<string> tempFileList = new List<string>();
            List<string> returnFileList = new List<string>();
            List<string> conditionExtensions = new List<string>();
            List<string> conditionFilenames = new List<string>();

            if (!String.IsNullOrEmpty(fileCondition.FileExtension) && fileCondition.FileExtension.Contains(";"))
                conditionExtensions = fileCondition.FileExtension.Split(';').ToList();
            else
                conditionExtensions.Add(fileCondition.FileExtension);

            if (fileCondition.Condition.Contains(";"))
                conditionFilenames = fileCondition.Condition.Split(';').ToList();
            else
                conditionFilenames.Add(fileCondition.Condition);

            switch (fileCondition.Type)
            {
                case "AllFilesExcept":
                    tempFileList.AddRange(fileList.Where(item => !conditionFilenames.Contains(item.Substring(item.LastIndexOf('\\') + 1))
                        ).ToList());
                    break;
                case "FilenameContains":
                    tempFileList.AddRange(fileList.Where(item => conditionFilenames.Any(any => item.Substring(item.LastIndexOf('\\') + 1).Contains(any))
                        ).ToList());
                    break;
                case "FilenameExact":
                    tempFileList.AddRange(fileList.Where(item => conditionFilenames.Contains(item.Substring(item.LastIndexOf('\\') + 1))
                        ).ToList());
                    break;
                case "FilenameEndsWith":
                    tempFileList.AddRange(fileList.Where(item => conditionFilenames.Any(any => item.EndsWith(any))
                        ).ToList());
                    break;
                case "FilenameStartsWith":
                    tempFileList.AddRange(fileList.Where(item => conditionFilenames.Any(any => item.Substring(item.LastIndexOf('\\') + 1).StartsWith(any))
                        ).ToList());
                    break;
                default:
                    //AllFiles
                    tempFileList.AddRange(fileList);
                    break;
            }

            if (tempFileList != null && !String.IsNullOrEmpty(fileCondition.FileExtension))
            {
                tempFileList = tempFileList.Where(item => conditionExtensions.Any(any => item.EndsWith(any))).ToList();
            }

            if (tempFileList != null)
            {
                foreach (string filename in tempFileList)
                {
                    string copiedFilename = string.Empty;
                    string destination = fileFilterSetting.FolderDestination;

                    if (!String.IsNullOrEmpty(fileCondition.SubFolderPath))
                        destination += "\\" + fileCondition.SubFolderPath;

                    if (fileCondition.UserFolderOriginAux)
                        copiedFilename = filename.Replace(fileFilterSetting.FolderOriginAux, destination);
                    else
                        copiedFilename = filename.Replace(fileFilterSetting.FolderOrigin, destination);

                    if (!copiedFilename.EndsWith(filename.Substring(filename.LastIndexOf('\\'))))
                        copiedFilename += "\\" + filename.Substring(filename.LastIndexOf('\\'));

                    CreateDirectories(copiedFilename);

                    File.Copy(filename, copiedFilename, fileFilterSetting.OverwriteFiles);
                    returnFileList.Add(copiedFilename);
                }
            }
            return returnFileList;
        }

        private static void CreateDirectories(string filepath)
        {
            string[] paths = filepath.Split('\\');

            for (int i = 0; i < (paths.Length-1); i++)
            {
                int idxEnd = filepath.IndexOf(paths[i] + "\\") + (paths[i] + "\\").Length;
                string path = filepath.Substring(0, idxEnd);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }

        }

    }
}
