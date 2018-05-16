using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Discretistation
{
    public static class ConstantDefinitions
    {
        public const string appName = "TD4C";

        #region Data Constants

        public static char SQL_VAR = '@';

        #endregion

        public const string PARSED_FILE_FOLDER = @"C:\Users\rejabek\Server\Datasets\";
        public const string UNPARSED_FILE_FOLDER = @"C:\Users\rejabek\Server\Raw\";
        public const string DOWNLOAD_PREPARATION_FOLDER = @"C:\Users\rejabek\Server\Downloads\";
        public const string JSON_PATH = @"C:\Users\rejabek\Server\files.txt";
        public const long FILE_SIZE_LIMIT = 5 * 1024 * 1024;
        public const string RESULT_FILE_EXTENSION = ".csv";
        public const string PYTHON_PATH = "C:\\ProgramData\\Anaconda3\\python.exe";

        public const string PYTHON_RUN_CMD_PATH =
            "C:\\Users\\rejabek\\PycharmProjects\\Discretisation\\Discretization_Interface.py";
    }
}