using System;
using Chat.Log;
using Chat.Global;
using Chat.Packets;
using System.Configuration;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Chat
{
    class Program
    {
        public static void Main(string[] args)
        {
            Listener server = new Listener();
            HandleMessage hdc = new HandleMessage();
            Thread serverthd = new Thread(() => server.Listen());
            serverthd.Start();
            Thread datahnd = new Thread(() => hdc.Messages(server));
            datahnd.Start();

            while(true)
            {
                Thread.Sleep(100);
            }
        }

    }

    
}
