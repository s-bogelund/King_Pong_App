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
		public IntroRoundWindow()
		{
			InitializeComponent();
			RoundDescription();
			MainWindow._gameSession.StarterTeamFound += _gameSession_StarterTeamFound;
		}

		private void _gameSession_StarterTeamFound(object sender, EventArgs e)
		{
			Close();
		}

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
			MainWindow._gameSession.StarterTeamDecided = true;
		}
	}
}
