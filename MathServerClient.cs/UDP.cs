using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MathServiceClient
{
    /// <summary>
    /// UDP service protocol
    /// </summary>
    class UDP:IServiceProtocol
    {
        /// <summary>
        /// sending messeges to server using UDP
        /// </summary>
        public void SendMessege()
        {
            Console.WriteLine("UDP protocol being used.");
            try
            {
                var client = new UdpClient();
                client.Connect("127.0.0.1", 4000);
                var endPoint = new IPEndPoint(IPAddress.Any, 4000);
                string s = "";
                while (s != "Close")
                {
                    Console.Write("Enter string (operator:first_value:second_value) : ");
                    s = Console.ReadLine();
                    var senddata = Encoding.ASCII.GetBytes(s);
                    client.Send(senddata, senddata.Length);
                    var receiveBytes = client.Receive(ref endPoint);
                    Console.WriteLine(Encoding.ASCII.GetString(receiveBytes));
                }
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
