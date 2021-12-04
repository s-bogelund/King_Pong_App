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
				TwoPlayerNameAssignment();
				
				Close();
			}
			
		}

		public void TwoPlayerNameAssignment()
		{
			MainWindow._gameSession.Player1.Name = NameOfPlayer1.Text;
			MainWindow._gameSession.Player3.Name = NameOfPlayer3.Text;

			MainWindow._gameSession.Team1.Name = Team1Name.Text;
			MainWindow._gameSession.Team2.Name = Team2Name.Text;

			MainWindow._gameSession.Team1.AddMembers(MainWindow._gameSession.Player1);
			MainWindow._gameSession.Team2.AddMembers(MainWindow._gameSession.Player3);
		}
	}
}
