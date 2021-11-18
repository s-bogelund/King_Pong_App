using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace King_Pong_App.Models
{
	public class PlayerModel : INotifyPropertyChanged
	{
		public int TeamNumber { get; set; }
		public int PlayerNumber { get; set; }
		public int NumberOfThrows { get; set; }
		public double HitRate { get; set; }
		
		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				OnPropertyChanged("NameChanged");
				name = value;

			}
		}

		private int numberOfHits;

		public int NumberOfHits
		{
			get { return numberOfHits; }
			set
			{
				numberOfHits = value;
				OnPropertyChanged("NumberOfHits");
			}
		}
		public PlayerModel() { }
		public PlayerModel(string name, int playerNumber, int teamNumber, int numberOfHits = 0)
		{
			Name = name;
			NumberOfHits = numberOfHits;
			PlayerNumber = playerNumber;
			TeamNumber = teamNumber;
			HitRate = numberOfHits == 0 ? 0 : (double)numberOfHits / NumberOfThrows;
		}

		public bool Turn { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
