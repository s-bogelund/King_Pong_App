using King_Pong_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King_Pong_App.ViewModels
{
	public class TeamViewModel : TeamModel
	{
		public TeamViewModel()
		{

		}

		public string CurrentScore()
		{
			return $"{App.team1.CupsRemaining} - {App.team2.CupsRemaining}";
		}

		public void AddMembers(params PlayerModel[] players)
		{
			foreach (var player in players)
			{
				TeamMembers.Add(player);
			}
			
		}
	}
}
