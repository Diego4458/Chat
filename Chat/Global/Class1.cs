using System;

namespace Chat.Log
{
    class log
    {
        public static void Debug(string stg)
        {
            Console.WriteLine("[DEBUG] {0}",stg);
        }
        public static void Error(string stg)
        {
            Console.WriteLine("[EROR] {0}", stg);
        }
        public static void Warn(string stg)
        {
            Console.WriteLine("[WARN] {0}", stg);
        }

        public static void MSG(string stg)
        {
            DateTime a = DateTime.Now;
            string b = String.Format("[{0}:{1}:{2}] ", a.Hour, a.Minute, a.Second);
            Console.WriteLine("{1} [MENSAGEM] {0}", stg, b);
        }

        public static void Log(string stg)
        {
            DateTime a = DateTime.Now;
            string b = String.Format("[{0}:{1}:{2}] ", a.Hour, a.Minute,a.Second) ;
            Console.WriteLine("{1}[LOG] {0}", stg, b);
        }
    }
}
