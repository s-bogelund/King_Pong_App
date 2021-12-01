using King_Pong_App.ViewModels;
using King_Pong_App.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using King_Pong_App;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using King_Pong_App.WebSocket;
using King_Pong_App.Models;

namespace King_Pong_App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public EllipseViewModel backFourCups;
		private GameSession _gameSession;

		public MainWindow()
		{
			InitializeComponent();
			backFourCups = Resources["backFourCups"] as EllipseViewModel;
			Server.StartServer();
			//turnTextBlock.Text += gamePlayModel.Command;
			_gameSession = new();
			DataContext = _gameSession;
		}
		
		private void Nyt_Spil_Click(object sender, RoutedEventArgs e)
		{
			bool gameInProgress = false; // remove this when implementation is done

			if (gameInProgress)
				MessageBox.Show("Der er et spil i gang. Vent med at starte et nyt spil, til det igangværende spil er afsluttet");
			else
			{
				CupSelection();
				NumberOfPlayersSelection();
				if (App.teamSize == 2)
					FourPlayerGame();
				else
					TwoPlayerGame();
			}
			PrintTeamNames();
			UpdateGameBoard();
			

			//gameInProgress = true;  <--- implemented when we're done :)
			//"decide starterTeam" game loop
			//normal gameloop
		}

		public void GamePlayLoop()
		{
			while (true)
			{
				string command = App.gamePlayModel.Command;
				
				switch (command)
				{
					case "1":
						HitEvent(int.Parse(command.Substring(1, 1)));
						break;
					default:
						break;
				}
			}
		}

		public void TwoPlayerGame()
		{
			TwoPlayerNameWindow nameSelect2 = new();
			nameSelect2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			nameSelect2.Owner = this;
			nameSelect2.ShowDialog();

			Player1_1.Text = App.player1.Name;
			Player1_2.Text = "";
			Player2_1.Text = App.player3.Name;
			Player2_2.Text = "";

			Player1_1_Hits.Text = App.player1.NumberOfHits.ToString();
			Player1_2_Hits.Text = "";
			Player2_1_Hits.Text = App.player3.NumberOfHits.ToString();
			Player2_2_Hits.Text = "";
		}

		public void FourPlayerGame()
		{
			FourPlayerNameWindow nameSelect4 = new();
			nameSelect4.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			nameSelect4.Owner = this;
			nameSelect4.ShowDialog();

			Player1_1.Text = App.player1.Name;
			Player1_2.Text = App.player2.Name;
			Player2_1.Text = App.player3.Name;
			Player2_2.Text = App.player4.Name;

			Player1_1_Hits.Text = App.player1.NumberOfHits.ToString();
			Player1_2_Hits.Text = App.player2.NumberOfHits.ToString();
			Player2_1_Hits.Text = App.player3.NumberOfHits.ToString();
			Player2_2_Hits.Text = App.player4.NumberOfHits.ToString();
		}

		public void NumberOfPlayersSelection()
		{
			PlayerNumberSelectWindow playerNumberSelectWindow = new();
			playerNumberSelectWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			playerNumberSelectWindow.Owner = this;
			playerNumberSelectWindow.ShowDialog();
		}
		public void CupSelection()
		{
			CupSelectWindow cupSelect = new();
			cupSelect.WindowStartupLocation = WindowStartupLocation.CenterOwner; // centers the new window
			cupSelect.Owner = this;   // sets MainWindow as owner so that if it closes, GameStartWindow also closes
			cupSelect.ShowDialog();

			if (App.numberOfCups == 6)
				backFourCups.HideEllipse(backFourCups);
			else
				backFourCups.ShowEllipse(backFourCups);
		}

		public void PrintTeamNames()
		{
			Team1Name.Text = App.team1.Name;
			Team2Name.Text = App.team2.Name;
		}

		public void HitEvent(int number)
		{
			List<Ellipse> team1TotalCups = new() { ellipse1_1, ellipse1_2, ellipse1_3, ellipse1_4, ellipse1_5, ellipse1_6, ellipse1_7, ellipse1_8, ellipse1_9, ellipse1_10 };
			List<Ellipse> team2TotalCups = new() { ellipse2_1, ellipse2_2, ellipse2_3, ellipse2_4, ellipse2_5, ellipse2_6, ellipse2_7, ellipse2_8, ellipse2_9, ellipse2_10 };

			List<Ellipse> team1ActualCups = new() { };
			List<Ellipse> team2ActualCups = new() { };

			for (int i = 0; i < App.numberOfCups; i++)  //ensures that we can't hit cups that aren't used if using only 6 cups
			{
				team1ActualCups.Add(team1TotalCups[i]);
				team2ActualCups.Add(team2TotalCups[i]);
			}
			
			//Debug.WriteLine($"Team1ActualCups: {team1ActualCups.Count}");
			//Debug.WriteLine($"Team2ActualCups: {team2ActualCups.Count}");
			//Debug.WriteLine($"number argument = {number}");
			if (App.currentTeam == App.team1)
			{
				team2ActualCups[number].Fill = Brushes.Red;
				App.team2.CupsRemaining--;
			}
			else 
			{
				team1ActualCups[number].Fill = Brushes.Red;
				App.team1.CupsRemaining--;
			}
			App.currentTeam.roster[App.playerTurn].AddHit();

			NextTurn();
		}

		public void NextTurn()
		{
			App.currentTeam.roster[App.playerTurn].AddThrow();

			if (App.team1.CupsRemaining > 0 && App.team2.CupsRemaining > 0)
			{
				if (App.teamSize <= App.playerTurn + 1)
					App.TurnOver();
				else
					App.playerTurn++;
			}
			else
				GameOver();
				
			UpdateGameBoard();
		}

		public void UpdateGameBoard()
		{
			UpdateTurnText();
			UpdateTurnIndicator();
			UpdateHits();
			UpdateCupsRemaining();
		}

		public void UpdateTurnIndicator()
		{
			if (App.currentTeam == App.team1)
			{
				TurnIndicator1.Visibility = Visibility.Visible;
				TurnIndicator2.Visibility = Visibility.Hidden;
			}
			else
			{
				TurnIndicator2.Visibility = Visibility.Visible;
				TurnIndicator1.Visibility = Visibility.Hidden;
			}
		}

		public void UpdateTurnText()
		{
			turnTextBlock.Text = App.currentTeam.roster[App.playerTurn].Name + "'s tur";
		}

		public void UpdateHits()
		{
			if (App.teamSize == 2)
			{
				Player1_1_Hits.Text = App.player1.NumberOfHits.ToString();
				Player1_2_Hits.Text = App.player2.NumberOfHits.ToString();
				Player2_1_Hits.Text = App.player3.NumberOfHits.ToString();
				Player2_2_Hits.Text = App.player4.NumberOfHits.ToString();
			}
			else
			{
				Player1_1_Hits.Text = App.player1.NumberOfHits.ToString();
				Player1_2_Hits.Text = "";
				Player2_1_Hits.Text = App.player3.NumberOfHits.ToString();
				Player2_2_Hits.Text = "";
			}
		}

		public void UpdateCupsRemaining()
		{
			Team1CupsLeft.Text = App.team1.CupsRemaining.ToString();
			Team2CupsLeft.Text = App.team2.CupsRemaining.ToString();
		}

		private void Regler_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Regler kan findes via dette link: https://kingpong_rules.com");
		}

		private void FAQ_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Bare spørg Lucas :)");
		}

		private void Giv_Op_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(@"For at give op, skal begge holdknapper holdes inde i mindst 5 sekunder. 
								Bemærk at det er holdet som der har turen, som giver op");

			if (_gameSession.Cup1_1.EllipseVisibility == Visibility.Hidden)
				_gameSession.Cup1_1.EllipseVisibility = Visibility.Visible;
			else
				_gameSession.Cup1_1.EllipseVisibility = Visibility.Hidden;
		}

		private void NextTurn_Click(object sender, RoutedEventArgs e)
		{
			NextTurn();
			Debug.WriteLine($"Current team: {App.currentTeam.Name}");
		}

		private void HitEvent_Click(object sender, RoutedEventArgs e)
		{
			//if (App.currentTeam == App.team1)
			//	HitEvent(App.team2.CupsRemaining-1);
			//else
			//	HitEvent(App.team1.CupsRemaining-1);

			//if (App.team1.CupsRemaining <= 0 || App.team2.CupsRemaining <= 0)
			//	MessageBox.Show($"EEEEY, you won {App.currentTeam.Name}!\n\n");

			//Debug.WriteLine($"Current team: {App.currentTeam.Name}");
			//Debug.WriteLine($"Team1 Remaining cups: {App.team1.CupsRemaining}");
			//Debug.WriteLine($"Team2 Remaining cups: {App.team2.CupsRemaining}");
			App.gamePlayModel.Command = "1";
			_gameSession.Player1.Name = "Ass";
			_gameSession.Cup1_1.EllipseColor = Brushes.Red;

		}
		public void GameOver()
		{
			GameWonWindow gameWon = new();
			gameWon.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			gameWon.Owner = this;
			gameWon.ShowDialog();
		}
		private void AutomaticWin_Click(object sender, RoutedEventArgs e)
		{
			GameOver();
		}
	}
}
