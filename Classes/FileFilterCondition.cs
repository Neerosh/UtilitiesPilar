using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesPilar.Classes
{
    /* File Filter Types:  example file => filename.mp3
     * FilenameExact => Condition = filename.mp3
     * FilenameContains => Condition = filename
     * FilenameEndsWith => Condition = .mp3
     * FilenameStartsWith => Condition = file
    */
    internal class FileFilterCondition
    {
        public int Id { get; }
        public int FileFilterId { get; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }
        public string FileExtension { get; set; }


        public FileFilterCondition(int fileFilterId, string name, string type, string condition)
        {
            FileFilterId = fileFilterId;
            Name = name;
            Type = type;
            Condition = condition;
        }
        public FileFilterCondition(int fileFilterId, string name, string type, string condition,string fileExtension)
        {
            FileFilterId = fileFilterId;
            Name = name;
            Type = type;
            Condition = condition;
            FileExtension = fileExtension;
        }
        public FileFilterCondition(int id, int fileFilterId, string name, string type, string condition, string fileExtension)
        {
            Id = id;
            FileFilterId = fileFilterId;
            Name = name;
            Type = type;
            Condition = condition;
            FileExtension = fileExtension;
        }

        public Dictionary<string, string> SqlKeyValues()
        {
            Dictionary<string, string> returnDictionary = new Dictionary<string, string>()
            {
                {"Id", Id.ToString()},
                {"FileFilterId", FileFilterId.ToString()},
                {"Name", "'"+Name+"'" },
                {"Type", "'"+Type+"'"},
                {"Condition", "'"+Condition+"'" },
                {"FileExtension", "'"+FileExtension+"'" },
            };

            return returnDictionary;
        }

        public Dictionary<string, string> SqlKeyValuesWhere()
        {
            Dictionary<string, string> returnDictionary = new Dictionary<string, string>()
            {
                {"Id", Id > 0 ? Id.ToString() : ""},
            };

            return returnDictionary;
        }
    }

}
