using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using King_Pong_GUI.Properties;

namespace King_Pong_GUI
{
	
	public partial class MainWindow : Window
	{
		
		public MainWindow()
		{
			InitializeComponent();
			List<Ellipse> tenCupsList = new List<Ellipse> { Ellipse1_7, Ellipse1_8, Ellipse1_9, Ellipse1_10, Ellipse2_7, Ellipse2_8, Ellipse2_9, Ellipse2_10 };
			App.Team1Turn = true;
			TurnOver(TurnIndictor1);

			if (App.NumberOfCups == 6)
				tenCupsList.ForEach(i => i.Visibility = Visibility.Hidden);

			Player Player1_1 = new Player("Luyen", 1, 1, 2);

			Player Player1_2 = new Player("Simon", 0, 2, 1);

			Team Team1 = new Team("Team1", Player1_1, Player1_2);

			Player Player2_1 = new Player("Magnex", 0, 1, 2);

			Player Player2_2 = new Player("Lukas", 0, 2, 2);

			Team Team2 = new Team("Team2", Player2_1, Player2_2);

			Text1_1.Text = Player1_1.PrintHits();
			Text1_2.Text = Player1_2.PrintHits();
			Text2_1.Text = Player2_1.PrintHits();
			Text2_2.Text = Player2_2.PrintHits();

			CupHitEvent(Ellipse1_1);
			
		}

		
		private void Nyt_Spil_Click(object sender, RoutedEventArgs e)
		{
			bool gameInProgress = false;

			if (gameInProgress)
				MessageBox.Show("Der er et spil i gang. Vent med at starte et nyt spil, til det igangværende spil er afsluttet");
			else
			{
				NewGameWindow GameStartWindow = new NewGameWindow();
				GameStartWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen; // centers the new window
				GameStartWindow.Owner = this;   // sets MainWindow as owner so that if it closes, GameStartWindow also closes
				GameStartWindow.Show();
				BeginNewGame(App.NumberOfCups);
			}

		}
		public void CupHitEvent(Ellipse ellipse)
		{
			ellipse.Fill = new SolidColorBrush(Colors.Red);
		}
		private void Regler_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Regler kan findes via dette link: https://kingpong_rules.com");
		}

		private void Indstillinger_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Giver det overhovedet mening at have en 'Indstillinger' boks??");

		}

		private void FAQ_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Bare spørg Lucas :)");
		}

		private void Giv_Op_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Det får du fandme ikke lov til. Kæmp til det sidste din taber!");
		}

		public static void BeginNewGame(int numberOfCups)
		{
			  //hides the last four cups if only six cups are chosen
		}

		public static void TurnOver(Rectangle rectangle)
		{
			if (App.Team1Turn)
			{
				App.Team1Turn = false;
				rectangle.Opacity = 0;
			}
			else
			{
				App.Team1Turn = true;
				rectangle.Opacity = 0;
			}
		}
	}
}
