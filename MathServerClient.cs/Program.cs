using System;
using System.IO;
using System.Net.Sockets;

namespace MathServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
           String protocol_string = "";
           TcpClient client = new TcpClient("127.0.0.1", 4000);
           var writer = new StreamWriter(client.GetStream());
           Console.WriteLine("Choose Protocol");
           protocol_string = Console.ReadLine();
           writer.WriteLine(protocol_string);
           writer.Close();
           client.Close();
           IServiceProtocol protocol;
           if (protocol_string == "TCP")
               protocol = new TCP();
           else 
               protocol = new UDP();
           protocol.SendMessege();
        }
    }
}
