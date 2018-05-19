using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceClient
{
    /// <summary>
    /// TCP service protocol
    /// </summary>
    class TCP : IServiceProtocol
    {
        /// <summary>
        /// sending messeges to server using TCP
        /// </summary>
        public void SendMessege()
        {
            Console.WriteLine("TCP protocol being used.");
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 4000);
                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());
                String s = "";
                while (s != "Close")
                {
                    Console.Write("Enter string (operator:first_value:second_value) : ");
                    s = Console.ReadLine();
                    Console.WriteLine();
                    writer.WriteLine(s);
                    writer.Flush();
                    var server_s = reader.ReadLine();
                    Console.WriteLine(server_s);
                }
                reader.Close();
                writer.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
