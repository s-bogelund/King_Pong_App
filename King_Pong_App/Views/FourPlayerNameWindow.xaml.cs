using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace King_Pong_App.Views
{
	/// <summary>
	/// Interaction logic for NameSelectionWindow.xaml
	/// </summary>
	public partial class FourPlayerNameWindow : Window
	{
		public FourPlayerNameWindow()
		{
			InitializeComponent();
		}

		private void ConfirmNames_Click(object sender, RoutedEventArgs e)
		{
			#region Control statements
			if (Team1Name.Text.Length > 10 || Team2Name.Text.Length > 10 || Player1Name.Text.Length > 10 ||
				Player2Name.Text.Length > 10 || Player3Name.Text.Length > 10 || Player4Name.Text.Length > 10)
			{
				MessageBox.Show("Navnene må ikke overstige 10 karakterer 🤔");
				return;
			}
			if (Team1Name.Text.Length == 0 || Team2Name.Text.Length == 0 || Player1Name.Text.Length == 0 ||
				Player2Name.Text.Length == 0 || Player3Name.Text.Length == 0 || Player4Name.Text.Length == 0)
			{
				MessageBox.Show("Husk at udfylde alle felter 😅");
				return;
			}
			#endregion
			
			FourPlayerNameAssignment();
			SendInfoToServer();
			MainWindow._gameSession.gameInProgress = true;

			Close();
		}

		public void FourPlayerNameAssignment()
		{
			MainWindow._gameSession.Player1.PlayerName = Player1Name.Text;
			MainWindow._gameSession.Player2.PlayerName = Player2Name.Text;
			MainWindow._gameSession.Player3.PlayerName = Player3Name.Text;
			MainWindow._gameSession.Player4.PlayerName = Player4Name.Text;

			MainWindow._gameSession.Team1.TeamName = Team1Name.Text;
			MainWindow._gameSession.Team2.TeamName = Team2Name.Text;

			MainWindow._gameSession.Team1.AddMembers(MainWindow._gameSession.Player1, MainWindow._gameSession.Player2);
			MainWindow._gameSession.Team2.AddMembers(MainWindow._gameSession.Player3, MainWindow._gameSession.Player4);
		}

		public void SendInfoToServer()
		{
			var serialized = JsonConvert.SerializeObject(MainWindow._gameSession, Formatting.Indented);


			//Debug.WriteLine(serialized);
			//ugly quick json fix
			serialized = ReplaceFirst(serialized, "playerName", "player1");
			serialized = ReplaceFirst(serialized, "playerName", "player2");
			serialized = ReplaceFirst(serialized, "playerName", "player3");
			serialized = ReplaceFirst(serialized, "playerName", "player4");
			
			MainWindow.client.Send(JsonFixer());
			Debug.WriteLine(JsonFixer());
		}

		// quick fix to issues with decoding json on server
		public string ReplaceFirst(string text, string search, string replace)
		{
			int pos = text.IndexOf(search);
			if (pos < 0)
			{
				return text;
			}
			return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
		}

		public string JsonFixer()
		{
			string team1 = @$"""team1"": ""{MainWindow._gameSession.Team1.TeamName}""," + "\n";
			string team2 = @$"""team2"": ""{MainWindow._gameSession.Team2.TeamName}""," + "\n";
			string player1 = @$"""player1"": ""{MainWindow._gameSession.Player1.PlayerName}""," + "\n";
			string player2 = @$"""player2"": ""{MainWindow._gameSession.Player2.PlayerName}""," + "\n";
			string player3 = @$"""player3"": ""{MainWindow._gameSession.Player3.PlayerName}""," + "\n";
			string player4 = @$"""player4"": ""{MainWindow._gameSession.Player4.PlayerName}""" + "\n";

			return "[\n" + team1 + team2 + player1 + player2 + player3 + player4 + "]";


		}
	}
}
