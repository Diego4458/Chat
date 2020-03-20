
using System;
using Global;
using System.Configuration;
using System.Net;
using System.Net.Sockets;

namespace Chat.Global
{
    class Listener
    {
        public string ip;
        public int port;
        public void Listen()
        {
            Config_load();
            UdpClient listener = new UdpClient(port);
            IPEndPoint serverep = new IPEndPoint(IPAddress.Parse(ip), port);
            bool Chat_alive = true;
            while (Chat_alive)
            {
                byte[] data = listener.Receive(ref serverep);
                RaiseDataReceived(new ReceiveDataArgs(serverep.Address, serverep.Port, data));
            }
        }


        public delegate void DataReceived(object sender, ReceiveDataArgs args);

        public event DataReceived DataReceivedEvent;
        private void RaiseDataReceived(ReceiveDataArgs args)
        {
            if (DataReceivedEvent == null)
            {

            }
            else
            {
                DataReceivedEvent(this, args);
            }
        }

        public void Config_load()
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

    public class ReceiveDataArgs
    {
        public IPAddress Ipadress { get; set; }
        public int port { get; set; }
        public byte[] ReivedBytes;

        public ReceiveDataArgs(IPAddress ip, int port, byte[] data)
        {
            this.Ipadress = ip;
            this.port = port;
            this.ReivedBytes = data;
        }
    }

}
