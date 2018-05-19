using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MathServer
{
    class Program
    {
        static void Main(string[] args)
        {
           MathService ms = new MathService();
           TcpListener listener = null;
           StreamReader reader = null;
           TcpClient client = null;
           string protocol = "";
           try
           {
               listener = new TcpListener(IPAddress.Any, 4000);
               listener.Start();
               while (true)
               {
                   client = listener.AcceptTcpClient();
                   reader = new StreamReader(client.GetStream());
                   protocol = reader.ReadLine();
                   if (protocol == "TCP" || protocol == "UDP")
                       break;
               }
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
           }
           finally
           {
               if (listener != null)
               {
                   reader.Close();
                   client.Close();
                   listener.Stop();
               }
           }
           IServiceProtocol serviceProtocol;
           if (protocol == "TCP")
               serviceProtocol = new TCP();
           else
               serviceProtocol = new UDP();
           serviceProtocol.getResult(ms);
        }
    }
}
