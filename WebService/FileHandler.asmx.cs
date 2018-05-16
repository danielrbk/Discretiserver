using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using Discretistation;
using Newtonsoft.Json;
using WebService.FileServer;
using System.IO.Compression;
namespace WebService
{
    /// <summary>
    /// Summary description for FileHandler
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FileHandler : System.Web.Services.WebService
    {
        private static int X = 0;
        public string PrepareForRun(string documentName, Byte[] fileByteStream, Byte[] vmap)
        {
            string eventSource = "InputReciever";
            if (!EventLog.SourceExists(ConstantDefinitions.appName))
                EventLog.CreateEventSource(ConstantDefinitions.appName, eventSource);
            EventLog.WriteEntry(ConstantDefinitions.appName, "Input recieved", EventLogEntryType.Information);
            //documentName = documentName.Split('.')[0];
            DateTime date = DateTime.Now;

            #region Save raw data
            // Create dir dedicated to dataset
            string dir = ConstantDefinitions.UNPARSED_FILE_FOLDER + "\\" + documentName + "_" +
                         date.ToString("yyyy_MM_dd_H_mm_ss");
            Directory.CreateDirectory(dir);
            // Save raw dataset
            string fileName = documentName + "_" + date.ToString("yyyy_MM_dd_H_mm_ss") + ".csv";
            string filePath = dir + "\\" + fileName;
            FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            file.Write(fileByteStream, 0, fileByteStream.Length);
            file.Close();

            // Save vmap
            filePath = dir + "\\vmap_" + fileName;
            file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            file.Write(vmap, 0, vmap.Length);
            file.Close();
            #endregion

            #region Save data in our client accessible location
            string[] guid = Guid.NewGuid().ToString().Split('-');
            string fileURL = String.Concat(guid);
            string dirPath = ConstantDefinitions.PARSED_FILE_FOLDER + "\\" + fileURL;
            Directory.CreateDirectory(dirPath);
            filePath = dirPath + "\\" + fileURL + ".csv";
            file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            file.Write(fileByteStream, 0, fileByteStream.Length);
            file.Close();
            filePath = dirPath + "\\vmap.csv";
            file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            file.Write(vmap, 0, vmap.Length);
            file.Close();
            File.WriteAllText(dirPath + "\\" + "name.txt", documentName);
            #endregion

            return fileURL + ";" + filePath;

        }

        [WebMethod]
        public string Discretization(string path)
        { //run_cmd(ConstantDefinitions.PYTHON_RUN_CMD_PATH, "input_path, output_path_folder, method_name, args");
            File.WriteAllText(@"C:\Server\test.txt",path);
            List<string> new_path = new List<string>();
            foreach (string single_path in path.Split(' '))
            {
                string[] args = single_path.Split('/');
                string fileName = args[0];
                string methodName = args[1];
                string[] configs = args[2].Split('_');
                string inputPath = GUID_To_File_Path(fileName);
                string outputPath = Discretization_To_File_Path(fileName, methodName, configs, true, true);
                new_path.Add(single_path);
            }
            System.Threading.Thread.Sleep(10000);
            return run_cmd(ConstantDefinitions.PYTHON_RUN_CMD_PATH, ConstantDefinitions.PARSED_FILE_FOLDER + " " + String.Join(" ",new_path)).ToString();

        }


        public string GUID_To_File_Path(string fileName)
        {
            return ConstantDefinitions.PARSED_FILE_FOLDER + "\\" + fileName + "\\" + fileName + ".csv";
        }

        public string Discretization_To_File_Path(string fileName, string methodName, string[] args, bool discretizing, bool creating)
        {
            string path = ConstantDefinitions.PARSED_FILE_FOLDER + "\\" + fileName + "\\" + methodName + "\\" + String.Join("_", args);
            if (discretizing && Directory.Exists(path))
                return null;
            Directory.CreateDirectory(path);
            return path;
        }

        public static string ToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }

        [WebMethod]
        public string SendDatasetAndVmapToServer(string datasetName,Byte[] fileByteStream, Byte[] vmap)
        {
            Dictionary<string, string> values;
            try
            {
                values = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ConstantDefinitions.JSON_PATH));
            }
            catch (FileNotFoundException e)
            {
                values = new Dictionary<string, string>();
            }
            
            string hexString;
            using (MD5 md5 = MD5.Create())
            {
                hexString = ToHex(md5.ComputeHash(fileByteStream), false);
                if (values.ContainsKey(hexString))
                    return values[hexString];
            }
            string[] res = PrepareForRun(datasetName, fileByteStream, vmap).Split(';');
            values.Add(hexString, res[0]);
            File.WriteAllText(ConstantDefinitions.JSON_PATH,JsonConvert.SerializeObject(values));
            return res[0];
        }

        [WebMethod]
        public string RunExpertAbstraction(string datasetName, Byte[] fileByteStream)
        {
            return "lol";
        }

        [WebMethod]
        public Byte[] GetFile(string fileNames)
        {
            string[] guid = Guid.NewGuid().ToString().Split('-');
            string request_id = String.Concat(guid);
            string root_folder = ConstantDefinitions.DOWNLOAD_PREPARATION_FOLDER + request_id;
            int index = 0;
            int files = 0;
            string file_name = "";
            bool create_directory = true;
            string rawDatasetName = "", save_path_folder = "";
            string curr_dataset = "";
            Directory.CreateDirectory(root_folder);
            try
            {
                string[] names = fileNames.Split(' ');
                Array.Sort(names);
                foreach (string fileName in names)
                {
                    if (String.IsNullOrEmpty(fileName))
                        break;
                    string path, name, filePath;
                    create_directory = false;
                    string[] args = fileName.Split('/');
                    name = args[0];
                    if (!name.Equals(curr_dataset))
                    {
                        create_directory = true;
                        curr_dataset = name;
                    }
                    filePath = GUID_To_File_Path(name);

                    if (create_directory)
                    {
                        rawDatasetName = File.ReadAllText(ConstantDefinitions.PARSED_FILE_FOLDER + "\\" + name + "\\" + "name.txt");
                        save_path_folder = root_folder + "\\" + rawDatasetName;
                        index = 1;
                        while (Directory.Exists(save_path_folder))
                        {
                            save_path_folder = root_folder + "\\" + rawDatasetName + "_" + index;
                            index += 1;
                        }
                        Directory.CreateDirectory(save_path_folder);
                    }


                    if (args.Length == 1)
                    {
                        path = filePath;
                        File.Copy(path, save_path_folder + "\\" + "dataset.csv");
                        files += 1;
                    }
                    else if (args[1].ToLower() == "vmap")
                    {
                        path = ConstantDefinitions.PARSED_FILE_FOLDER + "\\" + name + "\\vmap.csv";
                        File.Copy(path, save_path_folder + "\\" + "vmap.csv");
                        files += 1;
                    }
                    else if (args.Length == 3)
                    {
                        string methodName = args[1];
                        string[] configs = args[2].Split('_');
                        path = Discretization_To_File_Path(name, methodName, configs, false, false);
                        string SourcePath = path;
                        string DestinationPath = save_path_folder + "\\" + methodName + "\\" + String.Join("_", configs);
                        Directory.CreateDirectory(DestinationPath);
                        foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                            SearchOption.AllDirectories))
                            Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

                        string tempPath;
                        //Copy all the files & Replaces any files with the same name
                        foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                            SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);     
                            files += 1;
                        }
                        File.Delete(DestinationPath + "\\finished.log");
                    }
                }
                string file_path = ConstantDefinitions.DOWNLOAD_PREPARATION_FOLDER + "\\" + request_id + ".zip";
                if (files == 1)
                {
                    file_path = ConstantDefinitions.DOWNLOAD_PREPARATION_FOLDER + "\\" + request_id + ".csv";
                    File.Copy(Directory.GetFiles(ConstantDefinitions.DOWNLOAD_PREPARATION_FOLDER + "\\" + request_id, "*.*")[0],file_path);
                }
                else
                {
                    ZipFile.CreateFromDirectory(root_folder, file_path);
                }
                
                Directory.Delete(root_folder, true);
                FileStream file = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                int len = (int)(file.Length);
                Byte[] content = new Byte[len];
                file.Read(content, 0, len);
                file.Close();
                File.Delete(file_path);
                return content;
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
            return null;
        }

        [WebMethod]
        public bool IsFileExists(string fileName)
        {
            string path, name;
            string[] args = fileName.Split('/');
            name = args[0];
            string methodName = args[1];
            string[] configs = args[2].Split('_');
            path = Discretization_To_File_Path(name, methodName, configs, false, false);
            if (File.Exists(path + "\\" + "finished.log"))
                return true;
            return false;
        }

        private static string run_cmd(string cmd, string args)
        {
            var fs = new FileServerSoapClient();
            return fs.run_cmd(cmd, args);
            //run_cmd(ConstantDefinitions.PYTHON_RUN_CMD_PATH, "input_path, output_path_folder, method_name, args")    
            /*try
            {
                Process.Start("IExplore.exe", "www.northwindtraders.com");
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = ConstantDefinitions.PYTHON_PATH;
                File.WriteAllText(ConstantDefinitions.PARSED_FILE_FOLDER + "\\help.txt", "cmd running: " + cmd + " " + args);
                info.Arguments = string.Format("{0} {1}", cmd, args);
            
                System.Diagnostics.Process p =
                    System.Diagnostics.Process.Start(info);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "hi fayn, this is proof that i get to the end";*/
        }
    }
}
