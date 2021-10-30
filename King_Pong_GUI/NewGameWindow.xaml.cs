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
			
			if ((bool)SixCupButton.IsChecked) App.NumberOfCups = 6;
			if ((bool)TenCupButton.IsChecked) App.NumberOfCups = 10;
			Close();
		}

		public static void BeginNewGame(int numberOfCups, List<Ellipse> circleList)
		{
			if (numberOfCups == 6)
				circleList.ForEach(i => i.Visibility = Visibility.Hidden);  //hides the last four cups if only six cups are chosen
		}
	}


}


