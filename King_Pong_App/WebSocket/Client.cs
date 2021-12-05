using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace King_Pong_App.WebSocket
{
	class Client
	{
		private static object consoleLock = new object();
		private const int sendChunkSize = 256;
		private const int receiveChunkSize = 64;
		private const bool verbose = true;
		private static readonly TimeSpan delay = TimeSpan.FromMilliseconds(1000);
		private static string sentToString = "Hello Server!";
		private static string receivedToString = string.Empty;
		public static string connectPath = "ws://localhost:9000/wsDemo/";



		public static async Task StartClient()
		{
			Task.Run(async () =>
			await Connect(connectPath));
		}

		public static async Task Connect(string uri)
		{
			ClientWebSocket webSocket = null;
			try
			{
				webSocket = new();
				await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
				await Task.WhenAll(Receive(webSocket), Send(webSocket));
				Debug.WriteLine("Test1");

			}
			catch (Exception ex)
			{
				Debug.WriteLine("Exception: {0}", ex);
				Debug.WriteLine("Something went wrong with Connect");
			}
			finally
			{
				if (webSocket != null)
					webSocket.Dispose();
				Console.WriteLine();

				lock (consoleLock)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("WebSocket closed.");
					Console.ResetColor();
				}
			}
		}

		public static async Task Send(ClientWebSocket webSocket)
		{
			Debug.WriteLine("Send something");
			while (webSocket.State == WebSocketState.Open)
			{
				byte[] buffer = Encoding.ASCII.GetBytes(sentToString);
				await webSocket.SendAsync(new ArraySegment<byte>(buffer),
					WebSocketMessageType.Binary, true, CancellationToken.None);

				await Task.Delay(delay);
			}

		}

		public static async Task Receive(ClientWebSocket webSocket)
		{

			while (webSocket.State == WebSocketState.Open)
			{
				byte[] receivedBuffer = new byte[receiveChunkSize];
				var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(receivedBuffer), CancellationToken.None);
				if (result.MessageType == WebSocketMessageType.Close)
				{
					await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
				}
				else
				{
					receivedToString = Encoding.ASCII.GetString(receivedBuffer);

					Debug.WriteLine($"Received: {receivedToString}");

				}
			}
		}

		private static void LogStatus(bool receiving, byte[] buffer, int length)
		{
			//lock (consoleLock)
			//{
			//	Console.ForegroundColor = receiving ? ConsoleColor.Green : ConsoleColor.Gray;
			//	Console.WriteLine("{0} {1} bytes... ", receiving ? "Received" : "Sent", length);

			//	if (verbose)
			//		Console.WriteLine(BitConverter.ToString(buffer, 0, length));

			//	Console.ResetColor();
			//}
		}
	}
}
