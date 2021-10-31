using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace King_Pong_GUI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class NewGameModel : Application
	{
		public static string Team1Name;
		public static string Team2Name;

		//public static int NumberOfCups { get; set; }

		public static bool Team1Turn { get; set; }
		Rectangle TurnIndicator1;
	}
}
