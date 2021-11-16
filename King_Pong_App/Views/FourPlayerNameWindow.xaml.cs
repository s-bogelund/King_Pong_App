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

namespace King_Pong_App.Views
{
	/// <summary>
	/// Interaction logic for NameSelectionWindow.xaml
	/// </summary>
	public partial class FourPlayerNameWindow : Window
	{
		public FourPlayerNameWindow()
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
				App.player1.Name = Player1Name.Text;
				App.player2.Name = Player2Name.Text;
				App.player3.Name = Player3Name.Text;
				App.player4.Name = Player4Name.Text;
				App.team1.Name = Team1Name.Text;
				App.team2.Name = Team2Name.Text;

				App.team1.AddMembers(App.player1, App.player2);
				App.team2.AddMembers(App.player3, App.player4);
				Close();
			}
		}
	}
}
