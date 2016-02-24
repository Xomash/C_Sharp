using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LabKhomandiak04
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = IPGlobalProperties.GetIPGlobalProperties();
            var b = a.GetActiveTcpConnections();
            foreach(var c in b)
            {
                Console.WriteLine(c.LocalEndPoint.Port.ToString() +" "+ c.State.ToString());
            }
            Console.ReadLine();
        }
    }
}
