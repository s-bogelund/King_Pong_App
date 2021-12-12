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
	/// Interaction logic for IntroRoundWindow.xaml
	/// </summary>
	public partial class IntroRoundWindow : Window
	{
		/// <summary>
		/// Prints relevant info when the window opens 
		/// and subscribes to the StarterTeamFound event handler
		/// </summary>
		public IntroRoundWindow()
		{
			InitializeComponent();
			RoundDescription();
			MainWindow._gameSession.StarterTeamFound += _gameSession_StarterTeamFound;
		}
		/// <summary>
		/// Event handler that closes the window when a starter team has been found
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _gameSession_StarterTeamFound(object sender, EventArgs e)
		{
			Close();
		}
		/// <summary>
		/// Prints info about how the intro round is played
		/// </summary>
		private void RoundDescription()
		{
			IntroRoundDescription.Text =
				$"I denne runde spilles der om, hvilket hold der skal starte\n" +
				$"For at vinde starten skal en spiller fra hvert hold kaste samtidig, mens de holder deres holdknap nede.\n" +
				$"Det første hold der rammer vinder starten.\n" +
				$"Hvis begge kastere rammer, så skal der kastes igen.";
		}

		private void IntroRoundOver_Button_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
