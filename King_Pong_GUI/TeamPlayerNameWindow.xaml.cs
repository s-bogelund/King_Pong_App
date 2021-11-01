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
using System.Windows.Shapes;

namespace King_Pong_GUI
{
	/// <summary>
	/// Interaction logic for TeamPlayerNameWindow.xaml
	/// </summary>
	public partial class TeamPlayerNameWindow : Window
	{
		public TeamPlayerNameWindow()
		{
			InitializeComponent();
		}

		private void ConfirmNames_Click(object sender, RoutedEventArgs e)
		{
			if (Team1Name.Text.Length > 10 || Team2Name.Text.Length > 10 || Player1Name.Text.Length > 10 ||
				Player2Name.Text.Length > 10 || Player3Name.Text.Length > 10 || Player4Name.Text.Length > 10)
				MessageBox.Show("Navnene må ikke overstige 10 karakterer 🤔");
			else if (Team1Name.Text.Length == 0 || Team2Name.Text.Length == 0 || Player1Name.Text.Length == 0 ||
				Player2Name.Text.Length == 0 || Player3Name.Text.Length == 0 || Player4Name.Text.Length == 0)
				MessageBox.Show("Husk at udfylde alle felter 😅");
			else
			{

				Player player1 = new Player(Player1Name.Text, 1, 1);
				Player player2 = new Player(Player2Name.Text, 2, 1);
				Player player3 = new Player(Player3Name.Text, 3, 2);
				Player player4 = new Player(Player4Name.Text, 4, 2);

				Team team1 = new Team(Team1Name.Text, player1, player2);
				Team team2 = new Team(Team2Name.Text, player3, player4);
				Close();
			}
		}

	}
}

