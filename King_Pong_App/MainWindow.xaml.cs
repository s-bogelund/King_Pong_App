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
		public static GameSession _gameSession;
		public MainWindow()
		{
			InitializeComponent();
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
				if (_gameSession.teamSize == 2)
					FourPlayerGame();
				else
					TwoPlayerGame();
			}
			//PrintTeamNames();
			UpdateGameBoard();


			//gameInProgress = true;  <--- implemented when we're done :)
			//"decide starterTeam" game loop
			//normal gameloop
		}

		public void TwoPlayerGame()
		{
			TwoPlayerNameWindow nameSelect2 = new();
			nameSelect2.DataContext = _gameSession;
			nameSelect2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			nameSelect2.Owner = this;
			nameSelect2.ShowDialog();

			//Player1_1.Text = _gameSession.Player1.Name;
			//Player1_2.Text = "";
			//Player2_1.Text = App.player3.Name;
			//Player2_2.Text = "";

			//Player1_1_Hits.Text = App.player1.NumberOfHits.ToString();
			Player1_2_Hits.Text = "";
			//Player2_1_Hits.Text = App.player3.NumberOfHits.ToString();
			Player2_2_Hits.Text = "";
		}

		public void FourPlayerGame()
		{
			FourPlayerNameWindow nameSelect4 = new();
			nameSelect4.DataContext = _gameSession;
			nameSelect4.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			nameSelect4.Owner = this;
			nameSelect4.ShowDialog();

			//Player1_1.Text = App.player1.Name;
			//Player1_2.Text = App.player2.Name;
			//Player2_1.Text = App.player3.Name;
			//Player2_2.Text = App.player4.Name;

			//Player1_1_Hits.Text = App.player1.NumberOfHits.ToString();
			//Player1_2_Hits.Text = App.player2.NumberOfHits.ToString();
			//Player2_1_Hits.Text = App.player3.NumberOfHits.ToString();
			//Player2_2_Hits.Text = App.player4.NumberOfHits.ToString();
		}

		public void NumberOfPlayersSelection()
		{
			PlayerNumberSelectWindow playerNumberSelectWindow = new();
			playerNumberSelectWindow.DataContext = this.DataContext;
			playerNumberSelectWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			playerNumberSelectWindow.Owner = this;
			playerNumberSelectWindow.ShowDialog();
		}
		public void CupSelection()
		{
			CupSelectWindow cupSelect = new();
			cupSelect.DataContext = DataContext;
			cupSelect.WindowStartupLocation = WindowStartupLocation.CenterOwner; // centers the new window
			cupSelect.Owner = this;   // sets MainWindow as owner so that if it closes, GameStartWindow also closes
			cupSelect.ShowDialog();

			if (_gameSession.numberOfCups == 6)
				_gameSession.backFourCups.ForEach(c => c.HideEllipse());
			else
				_gameSession.backFourCups.ForEach(c => c.ShowEllipse());
		}

		//public void PrintTeamNames()
		//{
		//	Team1Name.Text = App.team1.Name;
		//	Team2Name.Text = App.team2.Name;
		//}

		public void HitEvent(int number)
		{
			List<Ellipse> team1TotalCups = new() { ellipse1_1, ellipse1_2, ellipse1_3, ellipse1_4, ellipse1_5, ellipse1_6, ellipse1_7, ellipse1_8, ellipse1_9, ellipse1_10 };
			List<Ellipse> team2TotalCups = new() { ellipse2_1, ellipse2_2, ellipse2_3, ellipse2_4, ellipse2_5, ellipse2_6, ellipse2_7, ellipse2_8, ellipse2_9, ellipse2_10 };

			List<EllipseViewModel> allTeam1Cups = new()
			{
				_gameSession.Cup1_1,
				_gameSession.Cup1_2,
				_gameSession.Cup1_3,
				_gameSession.Cup1_4,
				_gameSession.Cup1_5,
				_gameSession.Cup1_6,
				_gameSession.Cup1_7,
				_gameSession.Cup1_8,
				_gameSession.Cup1_9,
				_gameSession.Cup1_10
			};
			List<EllipseViewModel> allTeam2Cups = new()
			{
				_gameSession.Cup2_1,
				_gameSession.Cup2_2,
				_gameSession.Cup2_3,
				_gameSession.Cup2_4,
				_gameSession.Cup2_5,
				_gameSession.Cup2_6,
				_gameSession.Cup2_7,
				_gameSession.Cup2_8,
				_gameSession.Cup2_9,
				_gameSession.Cup2_10
			};

			List<EllipseViewModel> team1ActualCups = new() { };
			List<EllipseViewModel> team2ActualCups = new() { };

			for (int i = 0; i < _gameSession.numberOfCups; i++)  //ensures that we can't hit cups that aren't used if using only 6 cups
			{
				team1ActualCups.Add(allTeam1Cups[i]);
				team2ActualCups.Add(allTeam2Cups[i]);
			}
			
			//Debug.WriteLine($"Team1ActualCups: {team1ActualCups.Count}");
			//Debug.WriteLine($"Team2ActualCups: {team2ActualCups.Count}");
			//Debug.WriteLine($"number argument = {number}");
			if (_gameSession.Current == _gameSession.Team1)
			{
				team2ActualCups[number].Color = Brushes.Red;
				_gameSession.Team2.CupsRemaining--;
			}
			else 
			{
				team1ActualCups[number].Color = Brushes.Red;
				_gameSession.Team1.CupsRemaining--;
			}
			_gameSession.Current.Roster[_gameSession.currentPlayer].AddHit();

			NextTurn();
		}

		public void NextTurn()
		{
			_gameSession.Current.Roster[_gameSession.currentPlayer].AddThrow();

			if (_gameSession.Team1.CupsRemaining > 0 && _gameSession.Team2.CupsRemaining > 0)
			{
				if (_gameSession.teamSize <= _gameSession.currentPlayer + 1)
					_gameSession.TurnOver();
				else
					_gameSession.currentPlayer++;
			}
			else
				GameOver();
				
			UpdateGameBoard();
		}

		public void UpdateGameBoard()
		{
			//UpdateTurnText();
			UpdateTurnIndicator();
			//UpdateHits();
			//UpdateCupsRemaining();
		}

		public void UpdateTurnIndicator()
		{
			if (_gameSession.Current == _gameSession.Team1)
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
			turnTextBlock.Text = _gameSession.Current.Roster[_gameSession.currentPlayer].Name + "'s tur";
		}

		//public void UpdateHits()
		//{
		//	if (App.teamSize == 2)
		//	{
		//		Player1_1_Hits.Text = App.player1.NumberOfHits.ToString();
		//		Player1_2_Hits.Text = App.player2.NumberOfHits.ToString();
		//		Player2_1_Hits.Text = App.player3.NumberOfHits.ToString();
		//		Player2_2_Hits.Text = App.player4.NumberOfHits.ToString();
		//	}
		//	else
		//	{
		//		Player1_1_Hits.Text = App.player1.NumberOfHits.ToString();
		//		Player1_2_Hits.Text = "";
		//		Player2_1_Hits.Text = App.player3.NumberOfHits.ToString();
		//		Player2_2_Hits.Text = "";
		//	}
		//}

		//public void UpdateCupsRemaining()
		//{
		//	Team1CupsLeft.Text = App.team1.CupsRemaining.ToString();
		//	Team2CupsLeft.Text = App.team2.CupsRemaining.ToString();
		//}

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
		}

		private void NextTurn_Click(object sender, RoutedEventArgs e)
		{
			NextTurn();
			//Debug.WriteLine($"Current team: {App.currentTeam.Name}");
		}

		private void HitEvent_Click(object sender, RoutedEventArgs e)
		{
			if (_gameSession.Current == _gameSession.Team1)
				HitEvent(_gameSession.Team2.CupsRemaining - 1);
			else
				HitEvent(_gameSession.Team1.CupsRemaining - 1);

			//if (App.team1.CupsRemaining <= 0 || App.team2.CupsRemaining <= 0)
			//	MessageBox.Show($"EEEEY, you won {App.currentTeam.Name}!\n\n");

			//Debug.WriteLine($"Current team: {App.currentTeam.Name}");
			//Debug.WriteLine($"Team1 Remaining cups: {App.team1.CupsRemaining}");
			//Debug.WriteLine($"Team2 Remaining cups: {App.team2.CupsRemaining}");

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
