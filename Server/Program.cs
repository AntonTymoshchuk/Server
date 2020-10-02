using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpListener tcpListener = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7573));
                tcpListener.Start();
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Console.WriteLine("\n  Client accepted!");
                    
                    NetworkStream networkStream = tcpClient.GetStream();
                    if (networkStream.DataAvailable == true)
                    {
                        StreamReader streamReader = new StreamReader(networkStream);
                        string message = streamReader.ReadToEnd();
                        Console.WriteLine("\n  Message : {0}", message);
                        streamReader.Close();
                        networkStream.Close();
                    }

                    //tcpClient = tcpListener.AcceptTcpClient();
                    //networkStream = tcpClient.GetStream();
                    //StreamWriter streamWriter = new StreamWriter(networkStream);
                    //streamWriter.WriteLine("Response");
                    //streamWriter.Close();
                    //networkStream.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("\n  Error : {0}", exception.Message);
            }
        }
    }
}
