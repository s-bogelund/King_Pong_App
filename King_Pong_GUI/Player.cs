using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King_Pong_GUI
{
	public class Player
	{
		public int TeamNumber { get; set; }
		public int PlayerNumber { get; set; }
		public string Name { get; set; }
		public int NumberOfHits { get; set; }
		public int NumberOfThrows { get; set; }
		public double HitRate { get; }

		public Player() { }
		public Player(string name, int numberOfHits, int playerNumber, int teamNumber)
		{
			Name = name;
			NumberOfHits = numberOfHits;
			PlayerNumber = playerNumber;
			TeamNumber = teamNumber;
			HitRate = (double)numberOfHits / NumberOfThrows;
		}

		public string PrintHits()
		{
			return $"{Name}      -      {NumberOfHits} krus ramt";
		}

		public void AddThrow()
		{
			NumberOfThrows++;
		}
		public void AddHit()
		{
			NumberOfHits++;
		}
	}
}
