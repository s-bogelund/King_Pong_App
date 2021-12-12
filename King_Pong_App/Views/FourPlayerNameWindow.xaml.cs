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
		/// <summary>
		/// When a user pushes the 'Bekræft' button, names are 
		/// assigned and relevant information is sent to the server
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
			MainWindow._gameSession.playersCreated = true;

			Close();
		}
		/// <summary>
		/// Updates the names of the relevant GameSession properties 
		/// based on what is written in testboxes
		/// </summary>
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
		/// <summary>
		/// Sends relevant GameSession info to the server in Json format
		/// </summary>
		public void SendInfoToServer()
		{
			var serialized = JsonConvert.SerializeObject(MainWindow._gameSession, Formatting.Indented);

			MainWindow.client.Send((serialized));
			Debug.WriteLine(serialized);
		}

		
	}
}
