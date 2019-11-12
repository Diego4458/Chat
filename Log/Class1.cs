using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public class Logger
    {
        public static void Debug(string text)
        {
            Console.WriteLine("[DEBUG] {0}", text);
        }
        public static void Warn(string text)
        {
            Console.WriteLine("[WARN] {0}", text);
        }

        public static void Log(string text)
        {
            Console.WriteLine("[LOG] {0}", text);
        }

        public static void Error(string text)
        {
            Console.WriteLine("[ERROR] {0}", text);
        }

        public static void MSG(string text,string User)
        {
            Console.WriteLine("[MSG] {1}: {0}", text ,User);
        }

    }
}
