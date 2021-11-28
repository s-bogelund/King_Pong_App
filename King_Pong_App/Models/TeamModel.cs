using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King_Pong_App.Models
{
	public class TeamModel : PlayerModel
	{
		public List<PlayerModel> TeamMembers = new();
		public PlayerModel Player1 { get; set; }
		public PlayerModel Player2 { get; set; }
		public bool Turn { get; set; }

		public int CupsRemaining { get; set; }

		public TeamModel() { }

		public TeamModel(string name, PlayerModel player1, PlayerModel player2)
		{
			Player1 = player1;
			Player2 = player2;
			Name = name;
			TeamMembers.Add(player1);
			TeamMembers.Add(player2);
		}
	}
}

