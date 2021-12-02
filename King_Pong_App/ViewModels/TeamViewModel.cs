using King_Pong_App.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		public List<PlayerViewModel> Roster = new();
		public void AddMembers(params PlayerViewModel[] players)
		{
			foreach (var player in players)
			{
				Roster.Add(player);
			}
		}

		public string PrintInfo()
		{
			string playerStats = string.Empty;

			List<PlayerViewModel> sortedList = Roster.OrderByDescending(p => p.NumberOfHits).ToList();
			sortedList.ForEach(p => playerStats += p.PrintInfo());

			return playerStats;
		}
	}
}
