using King_Pong_App.ViewModels;
using King_Pong_App.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using King_Pong_App.WebSocket;
using System.Net.WebSockets;
using System.Windows.Input;
using King_Pong_App.Models;

namespace King_Pong_App;

public partial class MainWindow : Window
{
	private readonly Uri _serverUri = new Uri("ws://10.9.8.2:9000/");
	private readonly ClientWebSocket _socket = new();
	public CupModel backFourCups; // in order to hide the back row if only six cup game mode is chosen
	public static GameViewModel game;
	public static Client client;
	private List<bool> Team1Demo = new();
	private List<bool> Team2Demo = new();

	/// <summary>
	/// When the application is launched this is where the Datacontext is defined.
	/// It also initializes a websocket client and starts it.
	/// </summary>
	public MainWindow()
	{
		InitializeComponent();
		game = new();
		DataContext = game;
		client = new(_serverUri, _socket);
		client.Start();
		game.CommandReceived += game_CommandReceived;
	}

	/// <summary>
	/// Event handler for when a command is received from the server. 
	/// This is where everything is put together and the game is controlled.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void game_CommandReceived(object sender, EventArgs e)
	{
		// if the received command is an integer
		if (int.TryParse(game.Command, out int number))  
		{
			HitOrMiss(number);
			return;
		}

		if (game.Command.ToLower() == "ff")
		{
			Forfeit();
			return;
		}

		// this should never be reached
		Debug.WriteLine($"Command received has unknown value: {game.Command}");
	}

	/// <summary>
	/// The number received corresponds to a certain cup and the actions taken depends on 
	/// whether it is the pregame or primary game mode
	/// </summary>
	/// <param name="number"></param>
	public void HitOrMiss(int number)
	{
		if (number < 0 || number > game.numberOfCups * 2) //checking for invalid numbers
		{
			Debug.WriteLine($"Command received was out of bounds. Command was {number}");
			return;
		}

		if (game.StarterTeamDecided)
			NormalGameLoop(number);
		else
			DecideStarter(number);
	}
	/// <summary>
	/// The numbers 1-20 corresponds to a cup, and if number = 0, it is a miss and the next turn begins
	/// </summary>
	/// <param name="number"></param>
	private void NormalGameLoop(int number)
	{
		// number is 0, it was a miss, otherwise a cup corresponding to the number received will be marked hit
		if (number == 0) 
			NextTurn();
		else 
			HitEvent(number - 1);
	}

	/// <summary>
	/// Decides which team won the start. Number corresponds to the cup what was hit
	/// </summary>
	/// <param name="number"></param>
	private void DecideStarter(int number)
	{
		// checking if the number if valid for deciding starter team
		if (number < 1 || number > game.numberOfCups * 2)
		{
			Debug.WriteLine($"Only command values between 1 and {game.numberOfCups * 2} accepted");
			Debug.WriteLine($"The command received was: {game.Command}");
			return;
		}

		game.Current = number < game.numberOfCups ? game.Team1 : game.Team2;
		HitWindow();
		game.StarterTeamDecided = true;
		UpdateGameBoard();
	}

	/// <summary>
	/// Event handler that handles the entire process of beginning 
	/// a new game through to the end of the intro round.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Nyt_Spil_Click(object sender, RoutedEventArgs e)
	{
		#region Control Statements
		if (game.gameOver)
		{
			MessageBox.Show("For at starte et nyt spil, skal appen genstartes!");
			return;
		}
		if (game.gameInProgress)
		{
			MessageBox.Show("Der er et spil i gang. Vent med at starte et nyt spil, til det igangværende spil er afsluttet");
			return;
		}
		#endregion
		game.ResetGameInfo();
		CupSelection();
		NumberOfPlayersSelection();

		if (game.teamSize == 2)
			FourPlayerGame();
		else
			TwoPlayerGame();

		for (int i = 0; i < game.numberOfCups; i++)
		{
			bool hit = false;
			Team1Demo.Add(hit);
			Team2Demo.Add(hit);
		}
		IntroRound();
	}

	/// <summary>
	/// Method is called if the chosen team size is 1.
	/// It opens the TwoPlayerNameWindow
	/// </summary>
	public void TwoPlayerGame()
	{
		if (game.teamSize == 0)
			return;

		TwoPlayerNameWindow nameSelect2 = new();
		nameSelect2.DataContext = game;
		nameSelect2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		nameSelect2.Owner = this;
		nameSelect2.ShowDialog();

		Player1_2_Hits.Text = "";
		Player2_2_Hits.Text = "";
	}

	/// <summary>
	/// Method is called if the chosen team size is 2.
	/// It opens the FourPlayerNameWindow
	/// </summary>
	private void FourPlayerGame()
	{
		if (game.teamSize == 0)
			return;

		FourPlayerNameWindow nameSelect4 = new();
		nameSelect4.DataContext = game;
		nameSelect4.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		nameSelect4.Owner = this;
		nameSelect4.ShowDialog();
	}

	/// <summary>
	/// Opens the IntroRoundWindow
	/// </summary>
	private void IntroRound()
	{
		if (!game.playersCreated)
			return;

		IntroRoundWindow intro = new();
		intro.DataContext = game;
		intro.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		intro.Owner = this;
		intro.ShowDialog();
	}

	/// <summary>
	/// Opens the HitAnnounceWindow
	/// </summary>
	private void HitWindow()
	{
		HitAnnounceWindow hit = new();
		hit.DataContext = game;
		hit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		hit.Owner = this;
		hit.ShowDialog();
	}
	/// <summary>
	/// Opens the PlayerNumberSelectWindow
	/// </summary>
	private void NumberOfPlayersSelection()
	{
		if (!game.cupsChosen)
			return;

		PlayerNumberSelectWindow playerNumberSelectWindow = new();
		playerNumberSelectWindow.DataContext = this.DataContext;
		playerNumberSelectWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		playerNumberSelectWindow.Owner = this;
		playerNumberSelectWindow.ShowDialog();
	}
	/// <summary>
	/// Opens the CupSelectWindow
	/// </summary>
	private void CupSelection()
	{
		CupSelectWindow cupSelect = new();
		cupSelect.DataContext = DataContext;
		cupSelect.WindowStartupLocation = WindowStartupLocation.CenterOwner; // centers the new window
		cupSelect.Owner = this;   // sets MainWindow as owner so that if it closes, GameStartWindow also closes
		cupSelect.ShowDialog();

		if (game.numberOfCups == 6)
			game.backFourCups.ForEach(c => c.HideCup());
		else
			game.backFourCups.ForEach(c => c.ShowCup());
	}

	/// <summary>
	/// This method is called whenever a hit event occurs. 
	/// The number received corresponds to the cup that was hit.
	/// </summary>
	/// <param name="number"></param>
	private void HitEvent(int number)
	{
		// to avoid crashes
		if (game.Team1.CupsRemaining <= 0 || game.Team2.CupsRemaining <= 0)
			return;

		List<CupModel> allTeam1Cups = new()
		{
			game.Cup1_1,
			game.Cup1_2,
			game.Cup1_3,
			game.Cup1_4,
			game.Cup1_5,
			game.Cup1_6,
			game.Cup1_7,
			game.Cup1_8,
			game.Cup1_9,
			game.Cup1_10
		};
		List<CupModel> allTeam2Cups = new()
		{
			game.Cup2_1,
			game.Cup2_2,
			game.Cup2_3,
			game.Cup2_4,
			game.Cup2_5,
			game.Cup2_6,
			game.Cup2_7,
			game.Cup2_8,
			game.Cup2_9,
			game.Cup2_10
		};

		List<CupModel> team1ActualCups = new() { };
		List<CupModel> team2ActualCups = new() { };

		//ensures that we can't hit cups that aren't used if using only 6 cups
		for (int i = 0; i < game.numberOfCups; i++)  
		{
			team1ActualCups.Add(allTeam1Cups[i]);
			team2ActualCups.Add(allTeam2Cups[i]);
		}

		// if the current team is team 1, it is assumed that the cup hit belongs to team 2
		if (game.Current == game.Team1)
		{
			// the number passed is in the range of numberOfCups*2 due to how it's structured on Rpi.
			// so to get the actual cup from team 2 we need to subtract numberOfCups
			team2ActualCups[number - game.numberOfCups].Color = Brushes.Red;
			game.Team2.CupsRemaining--;
		}
		else 
		{
			team1ActualCups[number].Color = Brushes.Red;
			game.Team1.CupsRemaining--;
		}
		game.Current.Roster[game.currentPlayer].AddHit();
		if (game.Team1.CupsRemaining > 0 && game.Team2.CupsRemaining > 0)
			HitWindow();
		NextTurn();
	}

	/// <summary>
	/// Handles the switching of turns and calls all methods relevant to that.
	/// Also updates the game board.
	/// </summary>
	private void NextTurn()
	{
		game.Current.Roster[game.currentPlayer].AddThrow();

		if (game.Team1.CupsRemaining > 0 && game.Team2.CupsRemaining > 0)
		{
			if (game.teamSize <= game.currentPlayer + 1)
				game.TurnOver();
			else
				game.currentPlayer++;
		}
		else
			GameOver();
			
		UpdateGameBoard();
	}
	/// <summary>
	/// Is called when a team has won.
	/// Opens the GameWonWindow and sets the value of 
	/// relevant GameViewModel attributes.
	/// </summary>
	private void GameOver()
	{
		GameWonWindow gameWon = new();
		gameWon.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		gameWon.Owner = this;
		gameWon.ShowDialog();
		game.gameInProgress = false;
		game.gameOver = true;
	}
	/// <summary>
	/// Is called when a team has forfeited the match
	/// </summary>
	private void Forfeit()  // to make sure the teams are shown correctly on GameWonWindow
	{
		game.TurnOver();
		GameOver();
	}
	/// <summary>
	/// Updates the elements that aren't updated automatically by event handlers
	/// </summary>
	private void UpdateGameBoard()
	{
		UpdateTurnText();
		UpdateTurnIndicator();
	}
	/// <summary>
	/// Changes the side that the turn indicator is shown
	/// </summary>
	private void UpdateTurnIndicator()
	{
		if (game.Current == game.Team1)
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
	/// <summary>
	/// Updates the text block showing which player's turn it is.
	/// </summary>
	private void UpdateTurnText()
	{
		turnTextBlock.Text = game.Current.Roster[game.currentPlayer].PlayerName + "'s tur";
	}
	/// <summary>
	/// Event handler for when a user click the 'Regler' button
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Regler_Click(object sender, RoutedEventArgs e)
	{
		MessageBox.Show("Regler kan findes via dette link: https://kingpong-rules.com");
	}
	/// <summary>
	/// Event handler for when a user click the 'Giv Op' button.
	/// Shows instructions as to how the users forfeit the game.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Giv_Op_Click(object sender, RoutedEventArgs e)
	{
		MessageBox.Show(@"For at give op, skal begge holdknapper holdes inde i mindst 5 sekunder. 
							Bemærk at det er holdet som der har turen, som giver op");
	}
	private void DemoCommandSimulator(object sender, RoutedEventArgs e)
	{
		Random rand = new();
		int number = rand.Next(0, 2);
		Debug.WriteLine($"The random number generated is: {number} <----");

		if (!game.gameInProgress)
		{
			//MessageBox.Show("Det er endnu ikke afgjort, hvem der starter endnu. Tryk AUTO DECIDE STARTER");
			return;
		}

		if (game.gameOver)
		{
			GameOver();
			return;
		}

		if (number == 1)
		{
			DemoCupHit();
			return;
		}
		
		if (number == 0)
		{
			game.Command = "0";
			return;
		}
		Debug.WriteLine("Something went wrong :)");
	}
	private void DemoCupHit()
	{
		Random rand = new();
		int number = 0;
		bool found = false;
		if (game.Current == game.Team1)
		{
			while (!found)
			{
				number = rand.Next(0, Team2Demo.Count);
				Debug.WriteLine($"Random number was : {number}");
				if(!Team2Demo[number])
				{
					Team2Demo[number] = true;
					found = true;
					number++;
					game.Command = (number + game.numberOfCups).ToString();
				}
			}
		}

		if (game.Current == game.Team2)
		{
			while (!found)
			{
				number = rand.Next(0, Team1Demo.Count);
				
				Debug.WriteLine($"Random number was : {number}");
				if(!Team1Demo[number])
				{
					Team1Demo[number] = true;
					found = true;
					number++;
					game.Command = (number).ToString();
				}
			}
		}
	}
}

