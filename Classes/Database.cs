using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Xml.Linq;
using System.ComponentModel;

namespace UtilitiesPilar.Classes
{
    internal class Database
    {
        private SQLiteConnection connection = new SQLiteConnection("Data Source=UtilitiesPilar.db");
        private SQLiteCommand Sqlcommand = new SQLiteCommand();

        public Database()
        {
            CreateTables();
            CreateDefaultFileFilter();
        }

        private void CreateTables()
        {
            string command = @"CREATE TABLE IF NOT EXISTS Tools (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name VARCHAR(50) NOT NULL,
                                Description VARCHAR(100) NOT NULL,
                                FilePath VARCHAR(2000) NOT NULL,
                                UNIQUE (Name)
                            );
                            CREATE TABLE IF NOT EXISTS FileFilters (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name VARCHAR(50) NOT NULL,
                                Description VARCHAR(100) NOT NULL,
                                UNIQUE (Name)
                            );
                            CREATE TABLE IF NOT EXISTS FileFilterConditions (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                FileFilterId INTEGER NOT NULL,
                                Name VARCHAR(50) NOT NULL,
                                Type Varchar(30) NOT NULL,                      
                                Condition Varchar(1000) NOT NULL,
                                FileExtension Varchar(30) NOT NULL,
                                UNIQUE (FileFilterId,Type,Condition,FileExtension),
                                FOREIGN KEY(FileFilterId) REFERENCES FileFilters(Id) ON DELETE CASCADE
                            );
                            CREATE TABLE IF NOT EXISTS FileFilterSettings (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                FileFilterId INTEGER NOT NULL,
                                Name VARCHAR(50) NOT NULL,
                                FolderOrigin Varchar(1000) NOT NULL,                      
                                FolderDestination Varchar(1000) NOT NULL,
                                ZipFilename Varchar(100) NOT NULL,
                                ZipFiles Boolean NOT NULL,
                                OverwriteFiles Boolean NOT NULL,
                                UNIQUE (Id),
                                FOREIGN KEY(FileFilterId) REFERENCES FileFilters(Id) ON DELETE CASCADE
                            );";

            string executionResult = RunCommandNonQuery(command);

            if (executionResult.Contains("Error"))
            {
                MessageBox.Show(executionResult, "Creating Tables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDefaultFileFilter() 
        { 
            FileFilter fileFilter = new FileFilter("TaskToDoAutomation QA", "TaskToDoAutomation version designated to quality assurance.");
            FileFilterCondition fileFilterCondition;

            UpdateFileFilter(fileFilter);
            fileFilter = SelectFileFilter(fileFilter.Name);

            if (fileFilter != null)
            {
                fileFilterCondition = new FileFilterCondition(fileFilter.Id, "Predefined Condition", "FilenameStartsWith", "TaskToDo", ".dll");
                UpdateFileFilter(fileFilterCondition);

                fileFilterCondition = new FileFilterCondition(fileFilter.Id, "Predefined Condition", "FilenameExact", "TaskToDo.exe");
                UpdateFileFilter(fileFilterCondition);
            }
        }

        public Tool SelectTool(string name)
        {
            SQLiteDataReader reader = null;
            Tool tool = null;
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

        public BindingList<FileFilter> SelectAllFileFilters( int? fileFilterId)
        {
            BindingList<FileFilter> fileFilters = new BindingList<FileFilter>();
            SQLiteDataReader reader = null;
            string command = @"SELECT * FROM FileFilters";
            if (fileFilterId != null)
                command += " WHERE Id = " + fileFilterId;

            try
            {
                reader = RunCommandNonQueryReader(command);
                while (reader.Read())
                {
                    FileFilter fileFilter = new FileFilter(reader.GetInt32(0), reader.GetString(1),
                        reader.GetString(2));
                    fileFilters.Add(fileFilter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SelectAll FileFilters", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                connection.Close();
            }
            return fileFilters;
        }

        public FileFilter SelectFileFilter(string name)
        {
            FileFilter fileFilter = null;
            SQLiteDataReader reader = null;
            string command = @"SELECT * FROM FileFilters WHERE name = '" + name + "'";
            try
            {
                reader = RunCommandNonQueryReader(command);
                while (reader.Read())
                {
                    fileFilter = new FileFilter(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Select FileFilter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                connection.Close();
            }
            return fileFilter;
        }
        public void UpdateFileFilter(FileFilter fileFilter)
        {
            string executionResult = RunCommandInsertOrUpdate(fileFilter.SqlKeyValues(), fileFilter.SqlKeyValuesWhere(), "FileFilters");

            if (executionResult.Contains("Error"))
            {
                MessageBox.Show(executionResult, "Update/Create FileFilter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<FileFilterCondition> SelectAllFileFilterConditions(int? fileFilterId) 
        {
            List<FileFilterCondition> fileFilterConditions = new List<FileFilterCondition>();
            SQLiteDataReader reader = null;
            string command = @"SELECT * FROM FileFilterConditions";
            if (fileFilterId != null)
                command += " WHERE fileFilterId = " + fileFilterId;

            try
            {
                reader = RunCommandNonQueryReader(command);
                while (reader.Read())
                {
                    FileFilterCondition fileFiltercondition = new FileFilterCondition(reader.GetInt32(0), reader.GetInt32(1),
                        reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    fileFilterConditions.Add(fileFiltercondition);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SelectAll FileFilterConditions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                connection.Close();
            }
            return fileFilterConditions;

        }
        public void UpdateFileFilter(FileFilterCondition fileFilterCondition)
        {
            string executionResult = RunCommandInsertOrUpdate(fileFilterCondition.SqlKeyValues(), fileFilterCondition.SqlKeyValuesWhere(), "FileFilterConditions");

            if (executionResult.Contains("Error"))
            {
                MessageBox.Show(executionResult, "Update/Create FileFilterCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public FileFilterSetting SelectFileFilterSetting(string name)
        {
            FileFilterSetting fileFilterSetting = null;
            SQLiteDataReader reader = null;
            string command = @"SELECT * FROM FileFilterSettings WHERE id = 0";
            try
            {
                reader = RunCommandNonQueryReader(command);
                while (reader.Read())
                {
                    fileFilterSetting = new FileFilterSetting(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetString(5), reader.GetBoolean(6), reader.GetBoolean(7));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Select FileFilterSetting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                connection.Close();
            }
            return fileFilterSetting;
        }
        public void UpdateFileFilterSetting(FileFilterSetting fileFilterSetting)
        {
            string executionResult = RunCommandInsertOrUpdate(fileFilterSetting.SqlKeyValues(), fileFilterSetting.SqlKeyValuesWhere(), "fileFilterSettings");

            if (executionResult.Contains("Error"))
            {
                MessageBox.Show(executionResult, "Update/Create fileFilterSetting", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SQLiteDataReader reader = null;
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
