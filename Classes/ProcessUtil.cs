using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesPilar.Classes
{
    public class ProcessUtil
    {

        private Process process;

        public Process StartProcess(string filepath)
        {
            process = Process.Start(filepath);
            return process;
        }
        public bool KillProcess()
        {
            bool result = false;

            if (process != null && !process.HasExited)
            { 
                process.Kill();
                process = null;
                result = true;
            }
               
            return result;
        }

        public string CheckStatusProcess()
        {
            string status = "Process Not Found";

            if (process != null && process.Id != 0)
            {
                if (process.HasExited)
                    status = "Process Terminated";
                if (!process.HasExited)
                    status = "Process Running";
            }

            return status;
        }

        public bool HasStarted() {
            return process != null ? true : false;  
        }
        public int GetProcessId() { 
            int result = 0;

            if (process != null && process.Id > 0)
            { 
                result = process.Id;
            }

            return result;
        }
    }
}
