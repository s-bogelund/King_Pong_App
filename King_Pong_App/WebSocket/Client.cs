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
	public class Client
	{
		public Uri _uri;

		public ClientWebSocket _client = new ClientWebSocket();
		private int messageSentCounter = 0;

		public Client(Uri uri, ClientWebSocket client)
		{
			_uri = uri;
			_client = client;
		}
		/// <summary>
		/// Connects to the server and has the ability to send and receive asynchronously
		/// </summary>
		/// <returns></returns>
		public async Task Start()
		{
			try
			{
				await _client.ConnectAsync(_uri, CancellationToken.None);
				while (_client.State == WebSocketState.Open)
				{
					while (messageSentCounter == 0) // should ensure that it only sends once, otherwise it sends 5-8 times
					{
						await Send("");
					}
					await Receive();
				}

				await _client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Message was sent successfully", CancellationToken.None);
			}
			catch (WebSocketException e)
			{
				Console.WriteLine("You've reached the general websocket exception :(");
				Console.WriteLine(e.Message);

				if (_client.State == WebSocketState.Open)
					await _client.CloseAsync(WebSocketCloseStatus.Empty, null, CancellationToken.None);  // attemps to close the connection properly
			}
		}

		/// <summary>
		/// Sends a message to a server asynchronously
		/// </summary>
		/// <returns></returns>
		public async Task Send(string sendMessage)
		{
			int numberOfTimesRun = 0;
			if (_client.State == WebSocketState.Open)
			{
				byte[] messageInBytes = Encoding.UTF8.GetBytes(sendMessage);
				Debug.WriteLine($"Trying to send message: {sendMessage}");
				ArraySegment<byte> bytesToSend = messageInBytes;
				await _client.SendAsync(bytesToSend, WebSocketMessageType.Binary, true, CancellationToken.None);

				// trying to ensure that it only sends once:
				await Task.Delay(400);
				messageSentCounter++;

				//debug
				numberOfTimesRun++;
				Debug.WriteLine($"Send has run {numberOfTimesRun} times");
			}

		}
		/// <summary>
		/// Listens for messages and sets the GameSession property 'Command' 
		/// to be equal to the message received
		/// </summary>
		/// <returns></returns>
		public async Task Receive()
		{
			var offset = 0;
			var packet = 1024;
			var receiveBuffer = new byte[1024];
			int numberOfTimesRun = 0;

			Debug.WriteLine("Ready to receive");
			ArraySegment<byte> byteReceived = new(receiveBuffer, offset, packet); ;

			WebSocketReceiveResult receiveMessage = await _client.ReceiveAsync(byteReceived, CancellationToken.None);
			Debug.WriteLine("Message received");

			var serverMessage = Encoding.UTF8.GetString(receiveBuffer, 0, receiveMessage.Count);
			Debug.WriteLine(serverMessage + " <-- Received from server");

			if (int.TryParse(serverMessage, out int message) || serverMessage == "ff")
				MainWindow._gameSession.Command = serverMessage;
			else
				Debug.WriteLine($"Unknown message received from server: {serverMessage}");
			//}
			numberOfTimesRun++;
			Debug.WriteLine($"Receive has run {numberOfTimesRun} times");
			Task.Delay(100);

		}
	}
}
