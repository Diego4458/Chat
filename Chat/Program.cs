using Chat.Global;
using Log;
using Chat.Packets;
using System;
using System.Threading;

namespace Chat
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Chat Server";
            try
            {
                Listener server = new Listener();
                HandleMessage hdc = new HandleMessage();
                Thread serverthd = new Thread(() => server.Listen());
                serverthd.Start();
                Thread datahnd = new Thread(() => hdc.Messages(server));
                datahnd.Start();
                Console.Write("Servidor Iniciado");
                while (true)
                {
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

    }


}
