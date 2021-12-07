using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace King_Pong_App.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class PlayerModel : INotifyPropertyChanged
	{
		public int NumberOfThrows { get; set; }

		[JsonProperty]
		private string playerName;
		public string PlayerName
		{
			get { return playerName; }
			set
			{
				playerName = value;
				OnPropertyChanged(nameof(PlayerName));
			}
		}

		private int numberOfHits;

		public int NumberOfHits
		{
			get { return numberOfHits; }
			set
			{
				numberOfHits = value;
				OnPropertyChanged(nameof(NumberOfHits));
			}
		}
		public PlayerModel() { }
		public PlayerModel(string name, int _numberOfHits = 0)
		{
			PlayerName = name;
			numberOfHits = _numberOfHits;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
