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
		public Player(string name, int playerNumber, int teamNumber, int numberOfHits = 0)
		{
			Name = name;
			NumberOfHits = numberOfHits;
			PlayerNumber = playerNumber;
			TeamNumber = teamNumber;
			HitRate = numberOfHits == 0 ? 0 : (double)numberOfHits / NumberOfThrows;
		}

		public string PrintHits()
		{
			return $"{Name}    -    {NumberOfHits}";
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

	public interface INotifyProperChanged
	{
	}
}
