using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBasics.Packets
{
    public class PacketIn
    {
        private List<string> NewString;

        public String ReadString()
        {
            string info = NewString[0];
            NewString.RemoveAt(0);
            return info;
            
        }

        public int ReadInt()
        {
            string info = NewString[0];
            NewString.RemoveAt(0);
            return Convert.ToInt32(info);
        }

        public Double ReadDouble()
        {
            string info = NewString[0];
            NewString.RemoveAt(0);
            return Convert.ToDouble(info);
        }

        public float ReadFloat()
        {
            string info = NewString[0];
            NewString.RemoveAt(0);
            return Convert.ToSingle(info);
        }

        public DateTime ReadDateTime()
        {
            string info = NewString[0];
            NewString.RemoveAt(0);
            return Convert.ToDateTime(info);
        }

        public void ReadPacket(byte[] data)
        {
            string tex = Encoding.ASCII.GetString(data);
            string local = string.Empty;
            List<String> FinalData = new List<string>();
            for(int x=0;x<tex.Length;x++)
            {
                if(tex[x].ToString() != ";")
                {
                    local += tex[x];
                }
                else
                {
                    FinalData.Add(local);
                    local = string.Empty;
                }
            }
            NewString = FinalData;
        }

    }
}
