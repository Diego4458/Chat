using System;
using Log;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    class Program
    {
        public static string ip;
        public static int port;

        static void Main(string[] args)
        {

            Config_load();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            UdpClient client = new UdpClient();
            Logger.Debug(ep.ToString());
            client.Connect(ep);
            Console.WriteLine("Digite Seu Nome");
            string a = Console.ReadLine();
            if (a.Length != 0)
            {
                byte[] packet = Encoding.ASCII.GetBytes(a);
                client.Send(packet, packet.Length);
            }
            while (true)
            {
                Console.Clear();
                Console.Write(">>");
                a =Console.ReadLine();
                if(a.Length !=0)
                {  
                    byte[] packet = Encoding.ASCII.GetBytes(a);
                    client.Send(packet, packet.Length);
                }
            }

            
        }

        public static void Config_load()
        {
            try
            {
                ip = ConfigurationSettings.AppSettings.Get("ip");
                port = Convert.ToInt32(ConfigurationSettings.AppSettings.Get("port"));
            }
            catch (Exception)
            {
                Logger.Error("Erro Ao Tentar Iniciar o Servidor");
            }
        }
    }
}
