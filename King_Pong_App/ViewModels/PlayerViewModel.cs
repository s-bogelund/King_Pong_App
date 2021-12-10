using King_Pong_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King_Pong_App.ViewModels
{
	[JsonObject(MemberSerialization.OptIn)]
	public class PlayerViewModel : PlayerModel
	{
		public PlayerViewModel()
		{

		}
		public PlayerViewModel(string name, int numberOfHits = 0)
				: base(name, numberOfHits)
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
			string name = $"{PlayerName}:";
			string hits = $"Antal Ramte: {NumberOfHits}\n";
			string hitrate = $"Præcision: {Hitrate()}\n";

			return name + "\n" + hits + hitrate + "\n";
		}
	}
}
