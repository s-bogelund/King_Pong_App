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

namespace King_Pong_App.Views;

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
		MainWindow.game.gameInProgress = true;
		MainWindow.game.playersCreated = true;

		Close();
	}
	/// <summary>
	/// Updates the names of the relevant GameViewModel properties 
	/// based on what is written in testboxes
	/// </summary>
	public void FourPlayerNameAssignment()
	{
		MainWindow.game.Player1.PlayerName = Player1Name.Text;
		MainWindow.game.Player2.PlayerName = Player2Name.Text;
		MainWindow.game.Player3.PlayerName = Player3Name.Text;
		MainWindow.game.Player4.PlayerName = Player4Name.Text;

		MainWindow.game.Team1.TeamName = Team1Name.Text;
		MainWindow.game.Team2.TeamName = Team2Name.Text;

		MainWindow.game.Team1.AddMembers(MainWindow.game.Player1, MainWindow.game.Player2);
		MainWindow.game.Team2.AddMembers(MainWindow.game.Player3, MainWindow.game.Player4);
	}
	/// <summary>
	/// Sends relevant game info to the server in JSON format
	/// </summary>
	public void SendInfoToServer()
	{
		var serialized = JsonConvert.SerializeObject(MainWindow.game, Formatting.Indented);

		MainWindow.client.Send((serialized));
		Debug.WriteLine(serialized);
	}

	
}

