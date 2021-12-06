using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King_Pong_App.Models
{
	public class TeamModel : PlayerModel
	{
		public PlayerModel Player1 { get; set; }
		public PlayerModel Player2 { get; set; }
		public bool Turn { get; set; }


		private int cupsRemaining;

		public int CupsRemaining
		{
			get { return cupsRemaining; }
			set 
			{ 
				cupsRemaining = value;
				OnPropertyChanged(nameof(CupsRemaining));
			}
		}


		public TeamModel() { }

		public TeamModel(string name, PlayerModel player1, PlayerModel player2)
		{
			Player1 = player1;
			Player2 = player2;
			Name = name;
		}
	}
}

