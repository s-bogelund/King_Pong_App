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


namespace King_Pong_GUI
{
	/// <summary>
	/// Interaction logic for NewGameWindow.xaml
	/// </summary>
	public partial class NewGameWindow : Window
	{
		public NewGameWindow()
		{
			InitializeComponent();
		}

		private void ConfirmCups_Click(object sender, RoutedEventArgs e)
		{
			if(!(bool)TenCupButton.IsChecked && !(bool)SixCupButton.IsChecked)
				MessageBox.Show("Du skal vælge, hvor mange kopper der skal bruges i spillet");
			
			if ((bool)SixCupButton.IsChecked) NewGameModel.NumberOfCups = 6;
			if ((bool)TenCupButton.IsChecked) NewGameModel.NumberOfCups = 10;

			TeamPlayerNameWindow teamPlayerNameWindow = new TeamPlayerNameWindow();
			teamPlayerNameWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen; // centers the new window
			//teamPlayerNameWindow.Owner = MainWindow.BeginNewGame;
			Close();
			teamPlayerNameWindow.ShowDialog();
			
			

		}

		public static void BeginNewGame(int numberOfCups, List<Ellipse> circleList)
		{
			if (numberOfCups == 6)
				circleList.ForEach(i => i.Visibility = Visibility.Hidden);  //hides the last four cups if only six cups are chosen
		}
	}


}


