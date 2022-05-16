using System;
using System.Net.Sockets;

namespace TCPClient
{
    class Program
    {
        static void SendData(NetworkStream stream, Byte[] data, int times)
        {   
            Byte[] startArr = System.Text.Encoding.ASCII.GetBytes("Start,");
            Byte[] stopArr = System.Text.Encoding.ASCII.GetBytes("Stop,");

            stream.Write(startArr, 0, startArr.Length);

            for (int i = 0; i < times; i++)
            {
                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", data.ToString());

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                Byte[] receiveData = new Byte[256];

                // String to store the response ASCII representation.
                string responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(receiveData, 0, receiveData.Length);
                responseData = System.Text.Encoding.ASCII.GetString(receiveData, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
            }
            stream.Write(stopArr, 0, stopArr.Length);
        }

        static void SendDataFromFile(NetworkStream stream, String path)
        {   
            Byte[] startArr = System.Text.Encoding.ASCII.GetBytes("Start,");
            Byte[] stopArr = System.Text.Encoding.ASCII.GetBytes("Stop,");
            String text = System.IO.File.ReadAllText(path);
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(text);

            stream.Write(startArr, 0, startArr.Length);


            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", data.ToString());

            // Receive the TcpServer.response.

            // Buffer to store the response bytes.
            Byte[] receiveData = new Byte[256];

            // String to store the response ASCII representation.
            string responseData = String.Empty;
            Int32 bytes = 0;

            for (int i = 0; i < Math.Ceiling((double) data.Length / (double) 3000); i ++)
            {
            // Read the first batch of the TcpServer response bytes.
            bytes = stream.Read(receiveData, 0, receiveData.Length);
            responseData = System.Text.Encoding.ASCII.GetString(receiveData, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
            }

            stream.Write(stopArr, 0, stopArr.Length);

            // Read final result of mat script
            bytes = stream.Read(receiveData, 0, receiveData.Length);
            responseData = System.Text.Encoding.ASCII.GetString(receiveData, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
            bytes = stream.Read(receiveData, 0, receiveData.Length);
            responseData = System.Text.Encoding.ASCII.GetString(receiveData, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
        }
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

                String message = String.Empty;

                for (int i = 0; i < 33; i++)
                {
                    message += "Hello World,Hello World,Hello World,Hello World,Hello World,Hello World\n";
                }
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                SendDataFromFile(stream, @"C:\Users\baoqt\OneDrive\Documents -  OneDrive\GitHub\tena\Data\Input\IMU\Block\2_300.csv");
                //SendData(stream, data, 7);
                //SendData(stream, data, 2);
                //SendData(stream, data, 11);

                // Send the message to the connected TcpServer.
                
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
