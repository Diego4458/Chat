using NetworkBasics.Packets;
using System;
using System.Net;
using System.Net.Sockets;

namespace NetworkBasics
{
    public class Client
    {
        public Boolean ImAlive = false;
        private UdpClient client = new UdpClient();
        public Client(IPEndPoint Ip)
        {
            client.Connect(Ip);
            ImAlive = true;
        }

        public void Close()
        {
            client.Close();
        }

        public void SendPacket(PacketOut pkt)
        {
            client.Send(pkt.SendPacket(), pkt.SendPacket().Length);
        }
    }

    /*
        public static string ip;
        public static int port;

        static void Main(string[] args)
        {

            Config_load();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            UdpClient client = new UdpClient();
            Debug.Log(ep.ToString());
            client.Connect(ep);
            Console.WriteLine("Digite Seu Nome");
            PacketOut teste = new PacketOut();
            teste.WriteInt(1);
            teste.WriteString(Console.ReadLine());
            teste.SendPacket(client);
            while (true)
            {
                Console.Clear();
                Console.Write(">>");
                teste = new PacketOut();
                teste.WriteInt(2);
                teste.WriteString(Console.ReadLine());
                teste.SendPacket(client);
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
     */
}
