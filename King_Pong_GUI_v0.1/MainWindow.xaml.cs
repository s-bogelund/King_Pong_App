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

namespace King_Pong_GUI_v0._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Player Player1_1 = new Player ("Luyen", 1, 1, 2);
            DataContext = Player1_1;

            Player Player1_2 = new Player("Simon", 0, 2, 1);
            DataContext = Player1_2;

            Team Team1 = new Team("Team1", Player1_1, Player1_2);

            Player Player2_1 = new Player("Magnex", 0, 1, 2); 

            Player Player2_2 = new Player("Lukas", 0, 2, 2);

            Team Team2 = new Team("Team2", Player2_1, Player2_2);

            Text1_1.Text = Player1_1.PrintHits();
            Text1_2.Text = Player1_2.PrintHits();
            Text2_1.Text = Player2_1.PrintHits();
            Text2_2.Text = Player2_2.PrintHits();

			CupHitEvent(Ellipse06);
			CupHitEvent(Ellipse1);

		}

		private void Nyt_Spil_Click(object sender, RoutedEventArgs e)
        {
            bool gameInProgress = true;

            if (gameInProgress)
                MessageBox.Show("Der er et spil i gang. Vent med at starte et nyt spil, til det igangværende spil er afsluttet");
            else
            {
                //MessageBoxButton OkButton;
                MessageBox.Show("Forestil dig, at et spil går i gang. Brug din fantasi");
                
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

        public void BeginNewGame()
        {
           
        }
    }
}
