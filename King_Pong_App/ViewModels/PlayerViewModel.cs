using King_Pong_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King_Pong_App.ViewModels
{
	public class PlayerViewModel : PlayerModel
	{
		public PlayerViewModel()
		{

		}
		public PlayerViewModel(string name, int playerNumber, int teamNumber, int numberOfHits = 0)
				: base(name, playerNumber, teamNumber, numberOfHits)
		{

		}
		public string PrintHits()
		{
			return @$"{Name}		{NumberOfHits}";
		}


		public void AddThrow()
		{
			NumberOfThrows++;
		}
		public void AddHit()
		{
			NumberOfHits++;
			//Task.Run(() =>
			//{
			//	while (true)
			//	{
			//		Debug.WriteLine($"Name Player 1: {Player1.Name}");
			//		Thread.Sleep(1000);
			//	}
			//});
		}
	}
}
