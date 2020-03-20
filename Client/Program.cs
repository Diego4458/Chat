using System;
using Global;
using System.Configuration;
using System.Net;
using System.Text;
using NetworkBasics.Packets;
using NetworkBasics;

namespace client
{
    class Program
    {
        public static string ip;
        public static int port;

        static void Main(string[] args)
        {

            Config_load();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            Debug.Log(ep.ToString());
            Client Connection = new Client(ep);
            Console.WriteLine("Digite Seu Nome");
            PacketOut teste = new PacketOut();
            teste.WriteInt(1);
            teste.WriteString(Console.ReadLine());
            Connection.SendPacket(teste);
            while (Connection.ImAlive)
            {
                Console.Clear();
                Console.Write(">>");
                teste = new PacketOut();
                teste.WriteInt(2);
                teste.WriteString(Console.ReadLine());
                Connection.SendPacket(teste);
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
                Debug.Error("Erro Ao Tentar Iniciar o Servidor");
            }
        }
    }
}
