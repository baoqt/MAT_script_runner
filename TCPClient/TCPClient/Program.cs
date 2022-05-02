using System;
using System.Net.Sockets;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 13000;
                TcpClient client = new TcpClient("192.168.1.117", port);
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] startdata = System.Text.Encoding.ASCII.GetBytes("Start,Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n");
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n");
                    Byte[] stopdata = System.Text.Encoding.ASCII.GetBytes("Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n" +
                    "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World,Stop\n");

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(startdata, 0, startdata.Length);

                Console.WriteLine("Sent: {0}", startdata.ToString());

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                Byte[] receiveData = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(receiveData, 0, receiveData.Length);
                responseData = System.Text.Encoding.ASCII.GetString(receiveData, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", data.ToString());

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                receiveData = new Byte[256];

                // String to store the response ASCII representation.
                responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                bytes = stream.Read(receiveData, 0, receiveData.Length);
                responseData = System.Text.Encoding.ASCII.GetString(receiveData, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // Send the message to the connected TcpServer.
                stream.Write(stopdata, 0, stopdata.Length);

                Console.WriteLine("Sent: {0}", stopdata.ToString());

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                receiveData = new Byte[256];

                // String to store the response ASCII representation.
                responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                bytes = stream.Read(receiveData, 0, receiveData.Length);
                responseData = System.Text.Encoding.ASCII.GetString(receiveData, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                
                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}
