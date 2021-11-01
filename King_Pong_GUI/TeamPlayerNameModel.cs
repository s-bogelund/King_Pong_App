using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace King_Pong_GUI
{
	public class TeamPlayerNameModel : INotifyProperChanged
	{
		private string namePlayer1;

		public string NamePlayer1
		{
			get
			{
				return namePlayer1;
			}
			set
			{
				namePlayer1 = value;
				onPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void onPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public string NamePlayer2 { get; set; }
		public string NamePlayer3 { get; set; }
		public string NamePlayer4 { get; set; }

		public string NameTeam1 { get; set; }
		public string NameTeam2 { get; set; }

		public TeamPlayerNameModel()
		{
			//Task.Run(() =>
			//{
			//	while (true)
			//	{
			//		Debug.WriteLine($"Name Team 1: {NameTeam1}");
			//		Debug.WriteLine($"Name Player 1: {NamePlayer1}");
			//		Debug.WriteLine($"Name Player 2: {NamePlayer2}");
			//		Debug.WriteLine("");
			//		Debug.WriteLine($"Name Team 2: {NameTeam2}");
			//		Debug.WriteLine($"Name Player 3: {NamePlayer3}");
			//		Debug.WriteLine($"Name Player 4: {NamePlayer4}");
			//		Thread.Sleep(100);
			//	}
			//});
		}
	}
}
