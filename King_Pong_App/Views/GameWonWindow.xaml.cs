using King_Pong_App.ViewModels;
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
	/// Interaction logic for GameWonWindow.xaml
	/// </summary>
	public partial class GameWonWindow : Window
	{
		public GameWonWindow()
		{
			InitializeComponent();
			DisplayWinningTeam();
			PlayerStats();
		}

		public void DisplayWinningTeam()
		{
			string losingTeamName = App.currentTeam == App.team1 ? App.team2.Name : App.team1.Name;
			AnnounceWinnerLabel.Content = $"{App.currentTeam.Name.ToUpper()} VINDER!!";
			WinningTeamInfo.Text = $"{App.currentTeam.Name} Stats";
			LosingTeamInfo.Text = $"{losingTeamName} Stats";
			
		}

		public void PlayerStats()
		{
			WinningPlayerStats.Text = App.currentTeam.PrintInfo();
			LosingPlayerStats.Text = App.currentTeam == App.team1 ? App.team2.PrintInfo() : App.team1.PrintInfo();
			
		}

		private void GameOver_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
