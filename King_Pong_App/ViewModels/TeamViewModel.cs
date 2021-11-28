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

		public List<PlayerViewModel> roster = new();
		public void AddMembers(params PlayerViewModel[] players)
		{
			foreach (var player in players)
			{
				roster.Add(player);
			}
			
		}

		public string PrintInfo()
		{
			string allStats = String.Empty;
			
			roster.OrderBy(p => p.NumberOfHits);
			roster.ForEach(p => allStats += p.PrintInfo());

			return allStats;
		}
	}
}
