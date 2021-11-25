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
			App.player1.Name = NameOfPlayer1.Text;
			App.player3.Name = NameOfPlayer3.Text;

			App.team1.Name = Team1Name.Text;
			App.team2.Name = Team2Name.Text;

			App.team1.AddMembers(App.player1);
			App.team2.AddMembers(App.player3);

			Close();
		}
	}
}
