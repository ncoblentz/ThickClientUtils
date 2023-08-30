using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace ThickClientUtils
{
    public static class Logger
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Log(string message)
        {
            Log(message, 3);
        }
        public static void Log(string message, int? howfarback=2)
        {
            Tuple<string, string, string> stackInfo = GetCallStack(howfarback);
            Log(stackInfo.Item1, stackInfo.Item2, stackInfo.Item3, message);
        }

        public static void Log(string filename, string classname, string methodname, string message)
        {
            _logger.Info($"{filename} - {classname}.{methodname}: {message}");
        }
        private static Tuple<string,string,string> GetCallStack(int? howfarback=2)
        {
            string classname = "?";
            string methodname = "?";
            string filename = "?";

            if (!howfarback.HasValue) 
            {
                howfarback = 1;
            }

            try
            {
                StackTrace stackTrace = new StackTrace();
                if (stackTrace.FrameCount >= howfarback.Value + 1)
                {
                    filename = stackTrace.GetFrame(howfarback.Value).GetFileName();
                    MethodBase methodBase = stackTrace.GetFrame(howfarback.Value).GetMethod();
                    methodname = methodBase.Name;
                    classname = methodBase.DeclaringType.Name;
                }
            }
            catch(Exception e)
            {
                _logger.Error("GetCallStack failed: "+e.Message);
            }

            return new Tuple<string, string, string>(filename, classname, methodname);

        }
       
    }
}
