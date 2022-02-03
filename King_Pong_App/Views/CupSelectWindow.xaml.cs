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

namespace King_Pong_App.Views;

/// <summary>
/// Interaction logic for CupSelectWindow.xaml
/// </summary>
public partial class CupSelectWindow : Window
{
	public CupSelectWindow()
	{
		InitializeComponent();
	}
	/// <summary>
	/// Event handler that sets the number of cups of a game 
	/// depending on which radiobutton is checked
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ConfirmCups_Click(object sender, RoutedEventArgs e)
	{
		if (!(bool)TenCupButton.IsChecked && !(bool)SixCupButton.IsChecked)
		{
			MessageBox.Show("Du skal vælge, hvor mange kopper der skal bruges i spillet");
			return;
		}

		MainWindow.game.numberOfCups = (bool)SixCupButton.IsChecked ? 6 : 10; // default value is 10

		MainWindow.game.Team1.CupsRemaining = MainWindow.game.numberOfCups;
		MainWindow.game.Team2.CupsRemaining = MainWindow.game.numberOfCups;
		MainWindow.game.cupsChosen = true;
		Close();
	}

	
}

