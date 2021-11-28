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


		public void AddThrow()
		{
			NumberOfThrows++;
		}
		public void AddHit()
		{
			NumberOfHits++;
		}

		public string Hitrate() => Math.Round((double)NumberOfHits / NumberOfThrows * 100, 2).ToString() + "%";
		
		public string PrintInfo()
		{
			string name = $"{Name}:";
			string hits = $"Antal Ramte: {NumberOfHits}\n";
			string hitrate = $"Præcision: {Hitrate()}\n";

			return name + "\n" + hits + hitrate + "\n";
		}
	}
}
