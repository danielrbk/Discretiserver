using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using Discretistation;

namespace ProgramRunner
{
    /// <summary>
    /// Summary description for FileServer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FileServer : System.Web.Services.WebService
    {

        [WebMethod]
        public string run_cmd(string cmd, string args)
        {   //run_cmd(ConstantDefinitions.PYTHON_RUN_CMD_PATH, "input_path, output_path_folder, method_name, args")    
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = ConstantDefinitions.PYTHON_PATH;
                File.WriteAllText(ConstantDefinitions.PARSED_FILE_FOLDER + "\\help.txt", "python " + cmd + " " + args);
                info.Arguments = string.Format("{0} {1}", cmd, args);

                System.Diagnostics.Process p =
                    System.Diagnostics.Process.Start(info);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "hi fayn, this is proof that i get to the end";
        }
    }
}
