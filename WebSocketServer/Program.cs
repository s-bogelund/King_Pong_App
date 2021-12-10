using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace WebSocketServer
{
	public class Server
	{
		public static int Main(String[] args)
		{
			StartServer();
			return 0;
		}

		public static async void StartServer() // starts server in a new thread
		{
			await Task.Run(async () =>
			{
				InitServer();
			});
		}
		public static void InitServer()
		{
			// Get Host IP Address that is used to establish a connection
			// In this case, we get one IP address of localhost that is IP : 127.0.0.1
			// If a host has multiple addresses, you will get a list of addresses
			IPHostEntry host = Dns.GetHostEntry("localhost"); // must be RPi address, doesn't need ws?
			IPAddress ipAddress = host.AddressList[0];
			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 10000);

			try
			{

				// Create a Socket that will use Tcp protocol
				Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				// A Socket must be associated with an endpoint using the Bind method
				listener.Bind(localEndPoint);
				// Specify how many requests a Socket can listen before it gives Server busy response.
				listener.Listen(3);

				Debug.WriteLine("Waiting for a connection...");
				Socket handler = listener.Accept();
				Debug.WriteLine("Client successfully connected...");

				// Incoming data from the client.
				string data = null;
				byte[] bytes = null;
				string cleanerData = null;
				
				while (true)
				{
					bytes = new byte[1024];
					int bytesRec = handler.Receive(bytes);
					cleanerData = Encoding.ASCII.GetString(bytes, 0, bytesRec - 5); //removes <EOF> from print to make it a bit cleaner
					data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
					if (data.IndexOf("<EOF>") > -1)
					{
						break;
					}
				}
				Debug.WriteLine($"Text received : {cleanerData}"); 

				byte[] msg = Encoding.ASCII.GetBytes(data);
				handler.Send(msg);

				handler.Shutdown(SocketShutdown.Both);
				handler.Close();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.ToString());
			}

			
			//Console.WriteLine("\n Press any key to continue...");
			//Console.ReadKey();
		}
		public static async void Receive(byte[] data)
		{
			await Task.Run(async () =>
			{
				try
				{
					string buffer = Encoding.ASCII.GetString(data);
					
					//ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
			});
		}
	}
}
