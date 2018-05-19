using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MathServer
{
    /// <summary>
    /// UDP service protocol
    /// </summary>
    class UDP : IServiceProtocol
    {
        public void getResult(MathService ms)
        {
            Console.WriteLine("UDP protocol being used.");
            UdpClient client = new UdpClient(4000);
            try
            {
                while (true)
                {
                    var endPoint = new IPEndPoint(IPAddress.Any, 0);
                    string s = "";
                    while (true)
                    {
                        var receiveBytes = client.Receive(ref endPoint);
                        s = Encoding.ASCII.GetString(receiveBytes);
                        if (s == "Close")
                            break;
                        var x = Encoding.ASCII.GetBytes("Result:  " + ms.Delegate(s));
                        client.Send(x, x.Length, endPoint);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
