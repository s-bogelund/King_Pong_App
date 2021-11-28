using King_Pong_App.ViewModels;
using King_Pong_App.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace King_Pong_App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public EllipseViewModel backFourCups;
		public EllipseViewModel allCups;
		//public PlayerViewModel playerInfo;
		//public TeamViewModel teams;


		public MainWindow()
		{
			InitializeComponent();
			backFourCups = Resources["backFourCups"] as EllipseViewModel;
			
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

		public void HitEvent()
		{
			List<Ellipse> team1Cups = new() { ellipse1_1, ellipse1_2, ellipse1_3, ellipse1_4, ellipse1_5, ellipse1_6, ellipse1_7, ellipse1_8, ellipse1_9, ellipse1_10 };
			List<int> hits = new();
			Random hit = new();
			int num = 0;
			
			num = hit.Next(0,9)
			while (true)
			{
				num = hit.Next(0, 9);
				Debug.WriteLine(num);
				if (hits.Contains(num))
				{

				}
				else
				{
					team1Cups[num].Fill = Brushes.Red;
					hits.Add(num);
					return;
				}
				Debug.WriteLine(num);
			}
			
			
			//ellipse.Fill = Brushes.Red;
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

		public void NextTurn()
		{
			if(App.teamSize <= App.playerTurn)
			{
				App.TurnOver();
			}
			else
			{
				App.playerTurn++;
			}

			UpdateGameBoard();
		}

		public void UpdateTurnText()
		{
			turnTextBlock.Text = App.currentTeam.roster[App.playerTurn - 1].Name + "'s tur";
		}

		public void UpdateGameBoard()
		{
			UpdateTurnText();
			UpdateTurnIndicator();
			UpdateHits();
			UpdateCupsRemaining();
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
		}

		private void NextTurn_Click(object sender, RoutedEventArgs e)
		{
			NextTurn();
		}

		private void HitEvent_Click(object sender, RoutedEventArgs e)
		{
			HitEvent();
		}
	}
}
