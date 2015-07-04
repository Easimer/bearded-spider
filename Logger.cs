using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EasimerDemoScene
{
    class Logger
    {
        public static void LogRaw(string logMessage, TextWriter w)
        {
            w.WriteLine("{0}", logMessage);
        }
        public static void Log(string msg)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Logger.LogRaw(msg, w);
            }
        }
    }
}
