

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace IShow.Common.Log
{
    public enum LOGSEVERITY
    {
        Trace = 0, //Reserved for later
        Debug = 1, //Reserved for later
        Information = 2,
        Warning = 3, //Reserved for later
        Error = 4,
        Fatal = 5, //Reserved for later
        None = 6, //Reserved for later
    };

    public enum LOGTYPES
    {
        None = 0x0,
        Pipe = 0x1,
        Discovery = 0x2,
        Send = 0x4,
        Download = 0x8,
        DisvoveryReceiver = 0x10,
        DiscoverySender = 0x20,
    }

    public static class Logger
    {
        #region static
        public static LOGTYPES LogTypes
        {
            get
            {
#if DEBUG
                return _logAllTypes;
#else
                return ReadOutputLogTypesFromRegistry();
#endif
            }
        }
        public static void LogMethodEntry(
            LOGSEVERITY eSeverity = LOGSEVERITY.Information)
        {
            var sf = new StackTrace(true).GetFrame(1);
            var method = sf.GetMethod();
            Log("entry...", eSeverity, sf.GetMethod().Name, sf.GetFileLineNumber(), method.ReflectedType.Name);
        }
        public static void LogMethodExit(
            LOGSEVERITY eSeverity = LOGSEVERITY.Information)
        {
            var sf = new StackTrace(true).GetFrame(1);
            var method = sf.GetMethod();
            Log("exit.", eSeverity, sf.GetMethod().Name, sf.GetFileLineNumber(), method.ReflectedType.Name);
        }
        public static void LogMethodException(
            string exception,
            LOGSEVERITY eSeverity = LOGSEVERITY.Error)
        {
            var sf = new StackTrace(true).GetFrame(1);
            var method = sf.GetMethod();
            Log(string.Format("Got exception = {0}!", exception), eSeverity, method.Name, sf.GetFileLineNumber(), method.ReflectedType.Name);
        }

        public static void Log(string message, LOGSEVERITY eSeverity = LOGSEVERITY.Information)
        {
            var sf = new StackTrace(true).GetFrame(1);
            var method = sf.GetMethod();
            Log(message, eSeverity, sf.GetMethod().Name, sf.GetFileLineNumber(), method.ReflectedType.Name);
        }
        public static void SetLogFileName(string logFileName)
        {
            FileLogger.LogFileName = logFileName;
        }

        private static void Log( 
            string message,
            LOGSEVERITY eSeverity,
            string sCallerMethodName,
            int iCallerLineInFile,
            string sCallerFileName)
        {
            try
            {
                _instance = FileLogger.GetInstance();

                //Based on changed log level, we only use Information and Error for now, 
                //so treat all fatal as error, all other items are treat as information.
                LOGSEVERITY convertedLogSeverity = _logSeverityMap[eSeverity];
#if DEBUG
                _instance.Log(message, convertedLogSeverity, sCallerMethodName, iCallerLineInFile, sCallerFileName);
#else
                LOGSEVERITY convertedLogSeverityInRegistry = _logSeverityMap[ReadOutputLogLevelFromRegistry()];
                if (_IsInfoLogTrunedOn == true
                    || IsAllowedToLog(convertedLogSeverity, convertedLogSeverityInRegistry) == true)
                {
                    _instance.Log(message, convertedLogSeverity, sCallerMethodName, iCallerLineInFile, sCallerFileName);
                }
#endif
            }
            catch
            {
            }
        }

        private static bool IsAllowedToLog(
            LOGSEVERITY convertedLogSeverity, 
            LOGSEVERITY convertedLogSeverityInRegistry)
        {
            bool IsAllowed = false;
            try
            {
                if (convertedLogSeverityInRegistry == LOGSEVERITY.Information)
                {
                    IsAllowed = true;
                }
                else
                {
                    IsAllowed = (convertedLogSeverityInRegistry == convertedLogSeverity);
                }
            }
            catch
            {
                IsAllowed = false;
            }
            return IsAllowed;
        }

        private static LOGSEVERITY ReadOutputLogLevelFromRegistry()
        {
            LOGSEVERITY logSeverity = LOGSEVERITY.Error;
            try
            {
                //TODO: get latest reg value when write each log for handling value change during app running. Should change to one time?
                RegistryKey ishowOrderAppKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\IShow\IShowOrder");
                if (ishowOrderAppKey == null)
                {
                    logSeverity = LOGSEVERITY.Error;
                }
                else
                {
                    logSeverity = (LOGSEVERITY)(ishowOrderAppKey.GetValue(@"LOGLEVEL"));
                }
                ishowOrderAppKey.Close();
            }
            catch
            {
                logSeverity = LOGSEVERITY.Error;
            }
            return logSeverity;
        }
        private static bool _IsInfoLogTrunedOn
        {
            get
            {
                bool isInfoLogTrunedOn = false;

                try
                {
                    var cmdline = System.Environment.CommandLine;

                    isInfoLogTrunedOn = cmdline.ToLower().Contains(_logswitchcmdline.ToLower());
                }
                catch
                {
                    isInfoLogTrunedOn = false;
                }

                return isInfoLogTrunedOn;
            }
        }

        private static LOGTYPES ReadOutputLogTypesFromRegistry()
        {
            LOGTYPES logTypes = LOGTYPES.None;

            try
            {
                RegistryKey ishowOrderAppKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\IShow\IShowOrder");
                if (ishowOrderAppKey == null)
                {
                    logTypes = LOGTYPES.None;
                }
                else
                {
                    logTypes = (LOGTYPES)(ishowOrderAppKey.GetValue(@"LOGTYPES"));
                }
                ishowOrderAppKey.Close();
            }
            catch
            {
                logTypes = LOGTYPES.None;
            }

            return logTypes;
        }

        private static FileLogger _instance = null;
        private static string _logswitchcmdline = @"-TurnOnInfoLog";
        private static LOGTYPES _logAllTypes =
            LOGTYPES.None
            | LOGTYPES.Pipe
            | LOGTYPES.Send
            | LOGTYPES.Download
            | LOGTYPES.Discovery
            | LOGTYPES.DiscoverySender
            | LOGTYPES.DiscoverySender;
        private static IDictionary<LOGSEVERITY, LOGSEVERITY> _logSeverityMap = new Dictionary<LOGSEVERITY, LOGSEVERITY>()
        {
            {LOGSEVERITY.Trace, LOGSEVERITY.Information},
            {LOGSEVERITY.Debug, LOGSEVERITY.Information},
            {LOGSEVERITY.Information, LOGSEVERITY.Information},
            {LOGSEVERITY.Warning, LOGSEVERITY.Information},
            {LOGSEVERITY.Error, LOGSEVERITY.Error},
            {LOGSEVERITY.Fatal, LOGSEVERITY.Error},
            {LOGSEVERITY.None, LOGSEVERITY.Error},
        };
        #endregion
    }
}
