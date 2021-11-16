using King_Pong_App.ViewModels;
using King_Pong_App.Views;
using System;
using System.Collections.Generic;
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
		public PlayerViewModel playerInfo;
		public TeamViewModel teams;

		public MainWindow()
		{
			InitializeComponent();
			backFourCups = Resources["backFourCups"] as EllipseViewModel;

			//List<Ellipse> backFourCups = new() { ellipse1_7, ellipse1_8, ellipse1_9, ellipse1_10, ellipse2_7, ellipse2_8, ellipse2_9, ellipse2_10 };


		}

		private void Nyt_Spil_Click(object sender, RoutedEventArgs e)
		{
			bool gameInProgress = false;

			if (gameInProgress)
				MessageBox.Show("Der er et spil i gang. Vent med at starte et nyt spil, til det igangværende spil er afsluttet");
			else
			{
				CupSelectWindow cupSelect = new();
				cupSelect.WindowStartupLocation = WindowStartupLocation.CenterOwner; // centers the new window
				cupSelect.Owner = this;   // sets MainWindow as owner so that if it closes, GameStartWindow also closes
				cupSelect.ShowDialog();
				if (App.numberOfCups == 6)
					backFourCups.HideEllipse(backFourCups.EllipseVisibility);
				FourPlayerNameWindow nameSelect = new();
				nameSelect.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				nameSelect.Owner = this;
				nameSelect.ShowDialog();
				Team1Name.Text = App.team1.Name;
				Team2Name.Text = App.team2.Name;
				ScoreCount.Text = App.CurrentScore();

				Player1_1.Text = App.player1.PrintHits();
				Player1_2.Text = App.player2.PrintHits();
				Player2_1.Text = App.player3.PrintHits();
				Player2_2.Text = App.player4.PrintHits();

				//TeamPlayerNameWindow teamPlayerNameWindow = new TeamPlayerNameWindow();
				//teamPlayerNameWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
				//teamPlayerNameWindow.ShowDialog();
			}
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
			MessageBox.Show("Det får du fandme ikke lov til. Kæmp til det sidste din taber!");
		}
	}
}
