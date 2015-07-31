

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Runtime.CompilerServices;

namespace IShow.Common.Log
{
    internal class FileLogger
    {
        #region static
        public static FileLogger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FileLogger();
                    }
                }
            }
            return _instance;
        }
        public static string LogFileName
        {
            get;
            set;
        }

        private static FileLogger _instance = null;
        private static object _lock = new object();
        private static object _queueLock = new object();
        private static AutoResetEvent _resetEvent = new AutoResetEvent(false);
        #endregion

        #region public
        public void Log(string message,
            LOGSEVERITY eSeverity,
            string sCallerMethodName ,
            int iCallerLineInFile ,
            string sCallerFileName )
        {
            try
            {
                string formattedMessage = FormatLogRecord(
                    message, 
                    eSeverity, 
                    sCallerMethodName, 
                    iCallerLineInFile, 
                    sCallerFileName);

                AddLogMessageToQueue(formattedMessage);
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region protected
        #endregion

        #region private
        private FileLogger()
        {
            try
            {
                WriteLogInBackground();
            }
            catch
            {
            }
        }
        private string GetTimeStamp()
        {
            return DateTime.Now.ToString(@"HH:mm:ss:fff");
        }
        private string FormatLogRecord(
            string customMessage, 
            LOGSEVERITY eSeverity, 
            string sCallerMethodName, 
            int iCallerLineInFile, 
            string sCallerFileName)
        {
            string formatedLogRecord = "";

            try
            {
                string sCallerFileNameWithoutPath = sCallerFileName;
                int iIndex = sCallerFileName.LastIndexOf('\\');
                if (iIndex > -1)
                {
                    sCallerFileNameWithoutPath = sCallerFileName.Substring(iIndex + 1);
                }

                formatedLogRecord = string.Format("{0}:{1}  {2}<{3}:{4}>  {5}\r\n",
                    GetTimeStamp(),
                    eSeverity,
                    sCallerFileNameWithoutPath,
                    iCallerLineInFile,
                    sCallerMethodName,
                    customMessage);  
            }
            catch
            {
                formatedLogRecord = "";
            }

            return formatedLogRecord;
        }
        private bool AddLogMessageToQueue(string strMessage)
        {
            bool isAddOk = true;

            try
            {
                lock (_queueLock)
                {
                    _queue.Enqueue(strMessage);
                }
                _resetEvent.Set();

                isAddOk = true;
            }
            catch
            {
                isAddOk = false;
            }
            return isAddOk;
        }
        private DirectoryInfo GetLogFolder()
        {
            DirectoryInfo logFolder = null;
            try
            {
                string logFolderFullPath = System.Environment.GetEnvironmentVariable(@"Temp") + @"\IShow\IShowOrder\";
                logFolder = new DirectoryInfo(logFolderFullPath);
                if (logFolder.Exists == false)
                {
                    logFolder.Create();
                }
            }
            catch
            {
                logFolder = null;
            }
            return logFolder;
        }
        private FileStream OpenLogFile()
        {
            FileStream file = null;
            try
            {
                DirectoryInfo logFolder = GetLogFolder();

                string logFileName = string.Format(@"{0}{1}_{2}.txt",
                    logFolder.FullName,
                    (string.IsNullOrEmpty(FileLogger.LogFileName) == false) ? FileLogger.LogFileName : "LOG",
                    DateTime.Now.ToString(@"yy_MM_dd"));
                file = new FileStream(logFileName, FileMode.OpenOrCreate | FileMode.Append);
            }
            catch
            {
                file = null;
            }
            return file;
        }
        private void WriteLogInBackground()
        {
            ThreadPool.QueueUserWorkItem(state =>
                {
                    try
                    {
                        while (true)
                        {
                            _resetEvent.WaitOne(-1);

                            //TODO: open new file each loop for handling delete log file during app running case. Should change to only one time?
                            using (FileStream file = OpenLogFile())
                            {
                                List<string> logs = new List<string>();

                                lock (_queueLock)
                                {
                                    while (_queue.Count >= 1)
                                    {
                                        logs.Add(_queue.Dequeue());
                                    }
                                }

                                foreach (string log in logs)
                                {
                                    byte[] data = new UTF8Encoding().GetBytes(log);
                                    file.Write(data, 0, data.Length);
                                }

                                file.Flush();
                                file.Close();
                            }
                        }
                    }
                    catch
                    {
                    }
                });
        }

        private Queue<string> _queue = new Queue<string>();
        #endregion
    }
}
