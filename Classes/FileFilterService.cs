using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

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
                    List<string> fileListOrigin = Directory.GetFiles(fileFilterSetting.FolderOrigin).ToList();
                    List<string> fileListOriginAux = new List<string>();
                    List<string> filteredFileList = new List<string>();

                    if (!String.IsNullOrEmpty(fileFilterSetting.FolderOriginAux))
                        fileListOriginAux = Directory.GetFiles(fileFilterSetting.FolderOriginAux).ToList();

                    foreach (FileFilterCondition condition in fileFilterList)
                    {
                        if (condition.UserFolderOriginAux)
                            filteredFileList.AddRange(CopyAction(fileFilterSetting, condition, fileListOriginAux));
                        else
                            filteredFileList.AddRange(CopyAction(fileFilterSetting, condition, fileListOrigin));
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
                                    zip.CreateEntryFromFile(filename, filename.Replace(fileFilterSetting.FolderDestination + "\\", ""));
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

        private static List<string> CopyAction(FileFilterSetting fileFilterSetting, FileFilterCondition fileCondition, List<string> fileList)
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

                    string copiedFilename = fileFilterSetting.FolderDestination + "\\" + filename.Substring(filename.LastIndexOf('\\') + 1);

                    if (!String.IsNullOrEmpty(fileCondition.SubFolderPath))
                        copiedFilename = fileFilterSetting.FolderDestination + "\\" + fileCondition.SubFolderPath + "\\" + filename.Substring(filename.LastIndexOf('\\') + 1);

                    if (!Directory.Exists(copiedFilename.Substring(0,copiedFilename.LastIndexOf('\\'))))
                        Directory.CreateDirectory(copiedFilename.Substring(0, copiedFilename.LastIndexOf('\\')));

                    File.Copy(filename, copiedFilename, fileFilterSetting.OverwriteFiles);
                    returnFileList.Add(copiedFilename);
                }
            }
            return returnFileList;
        }
    }
}
