﻿using King_Pong_App.ViewModels;
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
			string losingTeamName = MainWindow._gameSession.Current == MainWindow._gameSession.Team1 ? MainWindow._gameSession.Team2.Name : MainWindow._gameSession.Team1.Name;
			AnnounceWinnerLabel.Content = $"{MainWindow._gameSession.Current.Name.ToUpper()} VINDER!!";
			WinningTeamInfo.Text = $"{MainWindow._gameSession.Current.Name} Stats";
			LosingTeamInfo.Text = $"{losingTeamName} Stats";
			
		}

		public void PlayerStats()
		{
			WinningPlayerStats.Text = MainWindow._gameSession.Current.PrintInfo();
			LosingPlayerStats.Text = MainWindow._gameSession.Current == MainWindow._gameSession.Team1 ? MainWindow._gameSession.Team2.PrintInfo() : MainWindow._gameSession.Team1.PrintInfo();
			
		}

		private void GameOver_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
