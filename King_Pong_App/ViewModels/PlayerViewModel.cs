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
		/// <summary>
		/// Default constructor for the PlayerViewModel
		/// </summary>
		public PlayerViewModel()
		{
			NumberOfHits = 0;
		}
		/// <summary>
		/// Constructor for the PlayerViewModel that is only 
		/// used when the application is opened
		/// </summary>
		public PlayerViewModel(string name, int numberOfHits = 0)
				: base(name, numberOfHits)
		{

		}

		/// <summary>
		/// Increases the number of throws for a player
		/// </summary>
		public void AddThrow()
		{
			NumberOfThrows++;
		}
		/// <summary>
		/// Increases the number of hits for a player
		/// </summary>
		public void AddHit()
		{
			NumberOfHits++;
		}
		/// <summary>
		/// Calculates and returns the hitrate for a player
		/// </summary>
		/// <returns></returns>
		public string Hitrate() => Math.Round((double)NumberOfHits / NumberOfThrows * 100, 2).ToString() + "%";
		
		/// <summary>
		/// Prints info the the player in the desired format 
		/// for the GameWonWindow.
		/// </summary>
		/// <returns></returns>
		public string PrintInfo()
		{
			string name = $"{PlayerName}: \n";
			string hits = $"Antal Ramte: {NumberOfHits}\n";
			string hitrate = $"Præcision: {Hitrate()}\n";

			return name + hits + hitrate + "\n";
		}
	}
}
