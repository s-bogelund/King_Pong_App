using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace King_Pong_GUI
{
	public partial class NewGameModel
	{
		private static int numberOfCups;

		public static int NumberOfCups
		{
			get { return numberOfCups; }
			set { numberOfCups = value; }
		}

		private int opacity;

		public int Opacity
		{
			get { return opacity; }
			set { opacity = value; }
		}

		public static bool Visibility { get; set; }

		

		public NewGameModel()
		{
			//Task.Run(() =>
			//{
			//	while (true)
			//	{
			//		Debug.WriteLine($"Number of cups: {NumberOfCups}");
			//		Thread.Sleep(500);
			//		Thread.SpinWait(1);
			//	}
			//});
		}

	}
}
