using System.Collections.Generic;

namespace UtilitiesPilar.Classes
{
    public class FileFilterSetting
    {
        public int Id { get; }
        public int FileFilterId { get; }

        public string Name { get; set; }
        public string FolderOrigin { get; set; }
        public string FolderOriginAux { get; set; }
        public string FolderDestination { get; set; }
        public string ZipFilename { get; set; }
        public bool ZipFiles { get; set; }
        public bool OverwriteFiles { get; set; }

        public FileFilterSetting(int id, int fileFilterId, string name)
        {
            Id = id;
            FileFilterId = fileFilterId;
            Name = name;
        }

        public FileFilterSetting(int id, int fileFilterId, string name, string folderOrigin, string folderDestination,
            string zipFilename, bool zipFiles, bool overwriteFiles, string folderOriginAux)
        {
            Id = id;
            FileFilterId = fileFilterId;
            Name = name;
            FolderOrigin = folderOrigin;
            FolderDestination = folderDestination;
            ZipFilename = zipFilename;
            ZipFiles = zipFiles;
            OverwriteFiles = overwriteFiles;
            FolderOriginAux = folderOriginAux;
        }

        public Dictionary<string, string> SqlKeyValues()
        {
            Dictionary<string, string> returnDictionary = new Dictionary<string, string>()
            {
                {"Id", Id > 0 ? Id.ToString() : ""},
                {"FileFilterId", FileFilterId.ToString()},
                {"Name", "'"+Name+"'" },
                {"FolderOrigin","'"+FolderOrigin+"'" },
                {"FolderOriginAux","'"+FolderOriginAux+"'" },
                {"FolderDestination", "'"+FolderDestination+"'"},
                {"ZipFilename", "'"+ZipFilename+"'" },
                {"ZipFiles", ZipFiles.ToString() },
                {"OverwriteFiles", OverwriteFiles.ToString() },
            };

            return returnDictionary;
        }

        public Dictionary<string, string> SqlKeyValuesWhere()
        {
            Dictionary<string, string> returnDictionary = new Dictionary<string, string>()
            {
                {"Id", Id >= 0 ? Id.ToString() : ""},
            };

            return returnDictionary;
        }
    }

}
