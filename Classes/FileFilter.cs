using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesPilar.Classes
{
    internal class FileFilter
    {
        public int Id { get; }
        public string Name {  get; set; }
        public string Description { get; set; }

        public FileFilter(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public FileFilter(string name, string description)
        { 
            Name = name;
            Description = description;
        }


        public Dictionary<string, string> SqlKeyValues()
        {
            Dictionary<string, string> returnDictionary = new Dictionary<string, string>()
            {
                {"Id", Id >= 0 ? Id.ToString() : "" },
                {"Name", "'"+Name+"'" },
                {"Description", "'"+Description+"'"}
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
