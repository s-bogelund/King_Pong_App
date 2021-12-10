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
using System.Windows.Threading;

namespace King_Pong_App.Views
{
	/// <summary>
	/// Interaction logic for HitAnnounceWindow.xaml
	/// </summary>
	public partial class HitAnnounceWindow : Window
	{
		public HitAnnounceWindow()
		{
			InitializeComponent();
			HitPrint();
			StartCloseTimer(4);
		}

		public void HitPrint()
		{
			if (MainWindow._gameSession.StarterTeamDecided)
			{
				AnnounceHitLabel.Content = $"{MainWindow._gameSession.Current.Roster[MainWindow._gameSession.currentPlayer].PlayerName.ToUpper()} \nRAMTE!";
				return;
			}

			AnnounceHitLabel.Content = $"DER ER RAMT!! \n{MainWindow._gameSession.Current.TeamName.ToUpper()} \nSTARTER!";
		}
		private void StartCloseTimer(int seconds)
		{
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(seconds);
			timer.Tick += TimerTick;
			timer.Start();
		}

		private void TimerTick(object sender, EventArgs e)
		{
			DispatcherTimer timer = (DispatcherTimer)sender;
			timer.Stop();
			timer.Tick -= TimerTick;
			Close();
		}

		private void Luk_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
