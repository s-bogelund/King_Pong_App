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
	/// Interaction logic for PlayerNumberSelectWindow.xaml
	/// </summary>
	public partial class PlayerNumberSelectWindow : Window
	{
		public PlayerNumberSelectWindow()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Sets the value of the teamSize property depending on which radiobutton is checked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ConfirmPlayers_Click(object sender, RoutedEventArgs e)
		{
			if (!(bool)_1v1_radiobutton.IsChecked && !(bool)_2v2_radioButton.IsChecked)
			{
				MessageBox.Show("Du skal lige vælge, hvor mange spillere hvert hold skal have 😘");
				return;
			}

			MainWindow._gameSession.teamSize = (bool)_1v1_radiobutton.IsChecked ? 1 : 2;
				
			Close();
		}
	}
}
