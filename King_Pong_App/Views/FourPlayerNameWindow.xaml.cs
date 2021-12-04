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
				FourPlayerNameAssignment();

				Close();
			}
		}

		public void FourPlayerNameAssignment()
		{
			MainWindow._gameSession.Player1.Name = Player1Name.Text;
			MainWindow._gameSession.Player2.Name = Player2Name.Text;
			MainWindow._gameSession.Player3.Name = Player3Name.Text;
			MainWindow._gameSession.Player4.Name = Player4Name.Text;

			MainWindow._gameSession.Team1.Name = Team1Name.Text;
			MainWindow._gameSession.Team2.Name = Team2Name.Text;

			MainWindow._gameSession.Team1.AddMembers(MainWindow._gameSession.Player1, MainWindow._gameSession.Player2);
			MainWindow._gameSession.Team2.AddMembers(MainWindow._gameSession.Player3, MainWindow._gameSession.Player4);
		}
	}
}
