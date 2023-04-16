using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Windows.Forms;

namespace UtilitiesPilar.Classes
{
    internal class Database
    {
        private SQLiteConnection connection = new SQLiteConnection("Data Source=UtilitiesPilar.db");
        private SQLiteCommand Sqlcommand = new SQLiteCommand();

        public Database()
        {
            CreateTables();
        }

        private void CreateTables()
        {
            string command = @"CREATE TABLE IF NOT EXISTS Tools (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name VARCHAR(50) NOT NULL,
                                Description VARCHAR(100) NOT NULL,
                                FilePath VARCHAR(2000) NOT NULL,
                                UNIQUE (Name)
                            );";

            string executionResult = RunCommandNonQuery(command);

            if (executionResult.Contains("Error"))
            {
                MessageBox.Show(executionResult, "Creating Tables",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public Tool SelectTool(string name)
        {
            Tool tool = null;
            SQLiteDataReader reader = null;
            string command = @"SELECT * FROM Tools WHERE name = '" + name + "'";
            try
            {
                reader = RunCommandNonQueryReader(command);
                while (reader.Read())
                {
                    tool = new Tool(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Select Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                connection.Close();
            }
            return tool;
        }

        public void UpdateTool(Tool tool)
        {
            string executionResult = RunCommandInsertOrUpdate(tool.SqlKeyValues(), tool.SqlKeyValuesWhere(), "tools");

            if (executionResult.Contains("Error"))
            {
                MessageBox.Show(executionResult, "Update/Create Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string RunCommandNonQuery(string commandText)
        {
            string result = "";
            try
            {
                connection.Open();
                Sqlcommand.Connection = connection;
                Sqlcommand.CommandText = commandText;
                Sqlcommand.ExecuteNonQuery();
                result = "Command Executed Successfully";
            }
            catch (Exception ex)
            {
                result = "Error: "+ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        private SQLiteDataReader RunCommandNonQueryReader(string commandText)
        {
            SQLiteDataReader reader;
            try
            {
                connection.Open();
                Sqlcommand.Connection = connection;
                Sqlcommand.CommandText = commandText;
                Sqlcommand.ExecuteNonQuery();
                reader = Sqlcommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                reader = null;
            }
            //Connection remains open

            return reader;
        }

        private string RunCommandInsertOrUpdate(Dictionary<string,string> keyValues,Dictionary<string,string> keyValuesWhere,string table)
        {
            string result = "";
            int index = 0;

            string command;

            string insertFields = "(";
            string insertFieldsValues = "(";
            string updateFields = "SET ";
            string whereFields = "";

            foreach (var pair in keyValues.Where(item => item.Value != ""))
            {
                insertFields += pair.Key + ",";
                insertFieldsValues += pair.Value + ",";
                updateFields += pair.Key + " = " + pair.Value + ",";
            }

            foreach (var pair in keyValuesWhere.Where(item => item.Value != ""))
            {
                whereFields += pair.Key + " = " + pair.Value ;
            }

            index = insertFields.LastIndexOf(",");
            insertFields = insertFields.Substring(0, index) + ")";

            index = insertFieldsValues.LastIndexOf(",");
            insertFieldsValues = insertFieldsValues.Substring(0, index)+")";

            index = updateFields.LastIndexOf(",");
            updateFields = updateFields.Substring(0, index);

            command = "INSERT OR IGNORE INTO " + table + " " + insertFields + " values " + insertFieldsValues+";";

            if (whereFields != "")
            {
                index = whereFields.LastIndexOf("AND");
                if (index > -1)
                    whereFields = "WHERE (" + whereFields.Substring(0, index)+")";
                command += "\nUPDATE " + table + " " + updateFields + " WHERE " + whereFields;
            }

            try
            {
                connection.Open();
                Sqlcommand.CommandText = command;
                Sqlcommand.ExecuteNonQuery();

                result = "Command Executed Successfully";
            }
            catch (Exception ex)
            {
                result = "Error: "+ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return result;
        }


    }
}
