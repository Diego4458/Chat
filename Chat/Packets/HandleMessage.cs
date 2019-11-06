using System;
using Chat.Global;
using Chat.Log;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Packets
{
    class HandleMessage
    {
        public void Messages(Listener packets)
        {
            packets.DataReceivedEvent += Packets_DataReceivedEvent;
        }

        private void Packets_DataReceivedEvent(object sender, ReceiveDataArgs args)
        {
            log.MSG(Encoding.ASCII.GetString(args.ReivedBytes));
            //Console.WriteLine("Received Message From[{0}:{1}]:\r\n{2}",args.Ipadress,args.port,Encoding.ASCII.GetString(args.ReivedBytes));
        }
    }
}
