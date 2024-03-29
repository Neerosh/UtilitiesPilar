﻿using System.Collections.Generic;

namespace UtilitiesPilar.Classes
{
    /* FileExtension => allow multiple extensions separated by ;
     * File Filter Types:  example file => filename.mp3
     * FilenameExact => Condition = fileA.mp3;fileB.mp3 => allow multiple name separated by ;
     * FilenameContains => Condition = filename
     * FilenameEndsWith => Condition = .mp3
     * FilenameStartsWith => Condition = file
     * AllFilesExcept => Condition = fileA.mp3;fileB.mp3 => files to remove separated by ;
     */
    internal class FileFilterCondition
    {
        public int Id { get; }
        public int FileFilterId { get; }

        public string Name { get; set; }
        public string SubFolderPath { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }
        public string FileExtension { get; set; }
        public bool UserFolderOriginAux { get; set; }
        public bool IncludeFolders{ get; set; }

        public FileFilterCondition(int id, int fileFilterId)
        {
            Id = id;
            FileFilterId = fileFilterId;
        }

        public FileFilterCondition(int id, int fileFilterId, string name, string type, string condition, string fileExtension, string subFolderPath = "", bool includeFolders = false)
        {
            Id = id;
            FileFilterId = fileFilterId;
            Name = name;
            Type = type;
            Condition = condition;
            FileExtension = fileExtension;
            SubFolderPath = subFolderPath;
            IncludeFolders = includeFolders;
        }
        public FileFilterCondition(int id, int fileFilterId, string name, string type, string condition, string fileExtension, bool userFolderOriginAux, string subFolderPath = "", bool includeFolders = false)
        {
            Id = id;
            FileFilterId = fileFilterId;
            Name = name;
            Type = type;
            Condition = condition;
            FileExtension = fileExtension;
            UserFolderOriginAux = userFolderOriginAux;
            SubFolderPath = subFolderPath;
            IncludeFolders = includeFolders;
        }

        public Dictionary<string, string> SqlKeyValues()
        {
            Dictionary<string, string> returnDictionary = new Dictionary<string, string>()
            {
                {"Id",  Id >= 0 ? Id.ToString() : ""},
                {"FileFilterId", FileFilterId.ToString()},
                {"Name", "'"+Name+"'" },
                {"Type", "'"+Type+"'"},
                {"Condition", "'"+Condition+"'" },
                {"FileExtension", "'"+FileExtension+"'" },
                {"UserFolderOriginAux", UserFolderOriginAux ? "true" : "false" },
                {"SubFolderPath","'"+SubFolderPath+"'" },
                {"IncludeFolders", IncludeFolders ? "true" : "false" }
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
