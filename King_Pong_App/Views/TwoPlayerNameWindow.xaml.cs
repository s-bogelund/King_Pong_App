using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace King_Pong_App.Views;

/// <summary>
/// Interaction logic for TwoPlayerNameWindow.xaml
/// </summary>
public partial class TwoPlayerNameWindow : Window
{
	public TwoPlayerNameWindow()
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
		#region
		if (Team1Name.Text.Length > 10 || Team2Name.Text.Length > 10 || NameOfPlayer1.Text.Length > 10 || NameOfPlayer3.Text.Length > 10)
		{
			MessageBox.Show("Navnene må ikke overstige 10 karakterer 🤔");
			return;
		}
		if (Team1Name.Text.Length == 0 || Team2Name.Text.Length == 0 || NameOfPlayer1.Text.Length == 0 || NameOfPlayer3.Text.Length == 0)
		{
			MessageBox.Show("Husk at udfylde alle felter 😅");
			return;
		}
		#endregion

		TwoPlayerNameAssignment();
		SendInfoToServer();
		MainWindow.game.gameInProgress = true;
		MainWindow.game.playersCreated = true;
		Close();
	}

	/// <summary>
	/// Updates the names of the relevant GameViewModel properties 
	/// based on what is written in testboxes
	/// </summary>
	public void TwoPlayerNameAssignment()
	{
		MainWindow.game.Player1.PlayerName = NameOfPlayer1.Text;
		MainWindow.game.Player3.PlayerName = NameOfPlayer3.Text;

		MainWindow.game.Player2.PlayerName = string.Empty;
		MainWindow.game.Player4.PlayerName = string.Empty;


		MainWindow.game.Team1.TeamName = Team1Name.Text;
		MainWindow.game.Team2.TeamName = Team2Name.Text;

		MainWindow.game.Team1.AddMembers(MainWindow.game.Player1);
		MainWindow.game.Team2.AddMembers(MainWindow.game.Player3);
	}
	/// <summary>
	/// Sends relevant game info to the server in JSON format
	/// </summary>
	public void SendInfoToServer()
	{
		var serialized = JsonConvert.SerializeObject(MainWindow.game, Formatting.Indented);
		MainWindow.client.Send(serialized);
	}

}