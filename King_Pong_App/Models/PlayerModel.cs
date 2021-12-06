﻿using System;
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
		
		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged("Name");
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
			Name = name;
			numberOfHits = _numberOfHits;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
