using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
    public class Debug
    {
        public static void Log(String msg)
        {
            Console.WriteLine(string.Format("[{0}] [Log]: {1}",TimeFormated(),msg));
        }

        public static void Warn(String msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format("[{0}] [Warn]: {1}", TimeFormated(), msg));
            Console.ResetColor();
        }

        public static void Error(String msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format("[{0}] [Error]: {1}", TimeFormated(), msg));
            Console.ResetColor();
        }

        public static void Temporaly(String msg, String Name)
        {
            Console.WriteLine(string.Format("[{0}] [MSG]: {1}", TimeFormated(), msg));
        }

        private static string TimeFormated()
        {
            return DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }

    }
}
