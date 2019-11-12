using Chat.Global;
using Log;
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
            string tex = Encoding.ASCII.GetString(args.ReivedBytes);
            Logger.Warn(args.ReivedBytes.ToString());
            for (int x = 0; usuarios.Length > x; x++)
            {
                if (usuarios[x].name == null)
                {
                    usuarios[x].name = tex;
                    usuarios[x].port = args.port;
                    break;
                }
                else if (usuarios[x].port == args.port)
                {
                    if (tex.Contains("/"))
                    {
                        if (tex.Contains("CD"))
                        {
                            for (int y = 0; usuarios.Length > y; y++)
                            {
                                if (usuarios[y].name != null)
                                {
                                    Console.WriteLine("{0} = {1}", y.ToString(), usuarios[y].name);
                                }
                            }

                        }
                    }
                    else
                    {
                        Logger.MSG(tex, usuarios[x].name);
                    }
                    break;
                }
            }
            //string a = Encoding.ASCII.GetString(args.ReivedBytes);
            // log.MSG(a, args.port);
            //Console.WriteLine("Received Message From[{0}:{1}]:\r\n{2}",args.Ipadress,args.port,Encoding.ASCII.GetString(args.ReivedBytes));
        }
    }
}
