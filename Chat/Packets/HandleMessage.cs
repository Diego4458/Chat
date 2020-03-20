using Chat.Global;
using Global;
using NetworkBasics.Packets;
using System;
using System.Text;

namespace Chat.Packets
{
    class HandleMessage
    {
        struct users
        {
            public int port;
            public String name;
        }

        private users[] usuarios = new users[100];

        public void Messages(Listener packets)
        {
            packets.DataReceivedEvent += Packets_DataReceivedEvent;
        }

        private void Packets_DataReceivedEvent(object sender, ReceiveDataArgs args)
        {
            PacketIn Data = new PacketIn();
            Data.ReadPacket(args.ReivedBytes);
            int PacketNumb = Data.ReadInt();
            switch (PacketNumb)
            {
                case 1:
                    {
                        Debug.Log(string.Format("Novo Usuario: {0}",Data.ReadString()));
                    }
                    break;
                default:
                    {
                        Debug.Warn(string.Format("Package Sem Dados: {0}", PacketNumb));
                    }
                    break;
            }
        }
    }
}
