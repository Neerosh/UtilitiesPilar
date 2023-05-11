using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesPilar.Classes
{
    internal class Tool
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }

        public Tool(int id, string name, string description, string filePath)
        {
            Id = id;
            Name = name;
            Description = description;
            FilePath = filePath;
        }

        public Tool(string name, string description, string filePath)
        {
            Name = name;
            Description = description;
            FilePath = filePath;
        }
        public Tool(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Tool(string name)
        {
            Name = name;
        }


        public Dictionary<string, string> SqlKeyValues()
        {
            Dictionary<string, string> returnDictionary = new Dictionary<string, string>() 
            {
                {"Id", Id >= 0 ? Id.ToString() : ""},
                {"Name", "'"+Name+"'" },
                {"Description", "'"+Description+"'"},
                {"FilePath", "'"+FilePath+"'" }
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
