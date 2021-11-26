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
	/// Interaction logic for TwoPlayerNameWindow.xaml
	/// </summary>
	public partial class TwoPlayerNameWindow : Window
	{
		public TwoPlayerNameWindow()
		{
			InitializeComponent();
		}

		private void ConfirmNames_Click(object sender, RoutedEventArgs e)
		{
			if (Team1Name.Text.Length > 10 || Team2Name.Text.Length > 10 || NameOfPlayer1.Text.Length > 10 || NameOfPlayer3.Text.Length > 10)
				MessageBox.Show("Navnene må ikke overstige 10 karakterer 🤔");
			else if (Team1Name.Text.Length == 0 || Team2Name.Text.Length == 0 || NameOfPlayer1.Text.Length == 0 || NameOfPlayer3.Text.Length == 0)
				MessageBox.Show("Husk at udfylde alle felter 😅");
			else
			{
				App.player1.Name = NameOfPlayer1.Text;
				App.player2.Name = "";
				App.player3.Name = NameOfPlayer3.Text;
				App.player4.Name = "";

				App.team1.Name = Team1Name.Text;
				App.team2.Name = Team2Name.Text;

				App.team1.AddMembers(App.player1);
				App.team2.AddMembers(App.player3);

				Close();
			}
			
		}
	}
}
