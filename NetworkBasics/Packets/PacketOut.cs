using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBasics.Packets
{
    public class PacketOut
    {
        private string FinalString = string.Empty;

        public void WriteString(String txt)
        {
            FinalString += txt + ";";
        }

        public void WriteInt(int number)
        {
            FinalString += number.ToString() + ";";
        }

        public void WriteDouble(Double number)
        {
            FinalString += number.ToString() + ";";
        }

        public void WriteFloat(float number)
        {
            FinalString += number.ToString() + ";";
        }

        public void WriteDateTime(DateTime date)
        {
            FinalString += date.ToString() + ";";
        }

        public byte[] SendPacket()
        {
            return Encoding.ASCII.GetBytes(FinalString);
        }

    }
}
