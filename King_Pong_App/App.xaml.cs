using King_Pong_App.Models;
using King_Pong_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace King_Pong_App
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static PlayerViewModel player1 = new("1", 1, 1);
		public static PlayerViewModel player2 = new("2", 2, 1);
		public static PlayerViewModel player3 = new("3", 3, 2);
		public static PlayerViewModel player4 = new("4", 4, 2);

		public static TeamViewModel team1 = new();
		public static TeamViewModel team2 = new();

		public static string CurrentScore()
		{
			return $"{App.team1.CupsRemaining} : {App.team2.CupsRemaining}";
		}

		public static int numberOfCups = 10;

	}
}
