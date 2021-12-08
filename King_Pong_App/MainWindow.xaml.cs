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
using System.Net.WebSockets;

namespace King_Pong_App
{
	public partial class MainWindow : Window
	{
		public Uri serverUri = new Uri("ws://localhost:9000/wsDemo");
		public ClientWebSocket socket = new();
		public EllipseViewModel backFourCups; // in order to hide the back row if only six cup game mode is chosen
		public static GameSession _gameSession;
		public static Client client;

		public MainWindow()
		{
			InitializeComponent();
			_gameSession = new();
			DataContext = _gameSession;
			client = new(serverUri, socket);
			client.Start();
			_gameSession.CommandReceived += _gameSession_CommandReceived;
		}

		private void _gameSession_CommandReceived(object sender, EventArgs e)
		{
			if (int.TryParse(_gameSession.Command, out int number))  // if the received command is an integer
			{
				if (number is < 0 or > 10) //checking for invalid numbers
				{
					Debug.WriteLine($"Command received was out of bounds. Command was {number}");
					return;
				}

				HitOrMiss(number);

				return;
			}

			if (_gameSession.Command.ToLower() == "ff")
				Forfeit();
			
			// this should never be reached
			Debug.WriteLine($"Command received has unknown value: {_gameSession.Command}");
		}

		private void HitOrMiss(int number)
		{
			if (_gameSession.starterTeamDecided)
			{
				NormalGameLoop(number);
			}
			else
				DecideStarter(number);
		}

		private void NormalGameLoop(int number)
		{
			if (number == 0) 
				NextTurn();
			else 
				HitEvent(number - 1);
		}

		private void DecideStarter(int number)
		{
			if(number > 1) // checking if the number if valid
			{
				Debug.WriteLine($"Only 0 and 1 is accepted commands before the starter team has been decided");
				Debug.WriteLine($"The command received was: {_gameSession.Command}");
				return;
			}

			_gameSession.Current = number == 0 ? _gameSession.Team1 : _gameSession.Team2;
			_gameSession.starterTeamDecided = true;
			UpdateTurnIndicator();
			
		}

		private void Nyt_Spil_Click(object sender, RoutedEventArgs e)
		{
			if (_gameSession.gameInProgress == true)
			{
				MessageBox.Show("Der er et spil i gang. Vent med at starte et nyt spil, til det igangværende spil er afsluttet");
				return;
			}

			CupSelection();
			NumberOfPlayersSelection();

			if (_gameSession.teamSize == 2)
				FourPlayerGame();
			else
				TwoPlayerGame();
			
			//UpdateGameBoard();
		}

		public void TwoPlayerGame()
		{
			TwoPlayerNameWindow nameSelect2 = new();
			nameSelect2.DataContext = _gameSession;
			nameSelect2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			nameSelect2.Owner = this;
			nameSelect2.ShowDialog();

			Player1_2_Hits.Text = "";
			Player2_2_Hits.Text = "";
		}

		public void FourPlayerGame()
		{
			FourPlayerNameWindow nameSelect4 = new();
			nameSelect4.DataContext = _gameSession;
			nameSelect4.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			nameSelect4.Owner = this;
			nameSelect4.ShowDialog();
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

		public void HitEvent(int number)
		{
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
			UpdateTurnText();
			UpdateTurnIndicator();
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
			turnTextBlock.Text = _gameSession.Current.Roster[_gameSession.currentPlayer].PlayerName + "'s tur";
		}

		private void Regler_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Regler kan findes via dette link: https://kingpong-rules.com");
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
		}

		private void HitEvent_Click(object sender, RoutedEventArgs e)
		{
			if (_gameSession.starterTeamDecided == true)
			{
				if (_gameSession.Current == _gameSession.Team1)
					HitEvent(_gameSession.Team2.CupsRemaining - 1);
				else
					HitEvent(_gameSession.Team1.CupsRemaining - 1);
			}
			else
				MessageBox.Show("Det er endnu ikke afgjort, hvem der starter endnu. Tryk AUTO DECIDE STARTER");
		}
		public void GameOver()
		{
			GameWonWindow gameWon = new();
			gameWon.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			gameWon.Owner = this;
			gameWon.ShowDialog();
			_gameSession.gameInProgress = false;
		}
		private void AutomaticWin_Click(object sender, RoutedEventArgs e)
		{
			client.Send("AssHatFace");
			_gameSession.Command= "1";
			_gameSession.starterTeamDecided = true;  // to be able to test
			//_gameSession.Player1.PlayerName = _gameSession.Command;
		}

		public void Forfeit()  // to make sure the teams are shown correctly on GameWonWindow
		{
			_gameSession.TurnOver();
			GameOver();
		}
	}
}
