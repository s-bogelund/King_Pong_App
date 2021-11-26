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
<<<<<<< HEAD

		}
=======
		}
		public string PrintHits() => $"{Name}	{NumberOfHits}";
>>>>>>> master

		public void AddThrow() => NumberOfThrows++;

		public void AddHit() => NumberOfHits++;

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
