using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MathServer
{
    /// <summary>
    /// TCP service protocol
    /// </summary>
    class TCP : IServiceProtocol
    {
        /// <summary>
        /// getting result using UDP
        /// </summary>
        /// <param name="ms"></param>
        public void getResult(MathService ms)
        {
            Console.WriteLine("TCP protocol being used");
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Any, 4000);
                listener.Start();
                while (true)
                {
                    var client = listener.AcceptTcpClient();
                    var reader = new StreamReader(client.GetStream());
                    var writer = new StreamWriter(client.GetStream());
                    string s = reader.ReadLine();
                    while (s != "Close")
                    {
                        writer.WriteLine("Result:  {0}", ms.Delegate(s));
                        writer.Flush();
                        s = reader.ReadLine();
                    }
                    reader.Close();
                    writer.Close();
                    client.Close();
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
                    listener.Stop();
                }
            }
        }
    }
}
