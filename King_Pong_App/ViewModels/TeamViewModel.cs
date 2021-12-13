using King_Pong_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace King_Pong_App.ViewModels
{
	public class TeamViewModel : TeamModel
	{
		public TeamViewModel()
		{
		}

		/// <summary>
		/// A list of PlayerViewModel objects
		/// </summary>
		public List<PlayerViewModel> Roster = new();
		/// <summary>
		/// Adding any amount of players to the roster.
		/// Done in order to use the same function for 1 or 2 player teams
		/// without needing to overload
		/// </summary>
		/// <param name="players"></param>
		public void AddMembers(params PlayerViewModel[] players)
		{
			foreach (var player in players)
			{
				Roster.Add(player);
			}
		}

		/// <summary>
		/// Used to print info in the desired format on the
		/// GameWonWindow at the end of the game
		/// </summary>
		/// <returns></returns>
		public string PrintInfo()
		{
			string playerStats = string.Empty;

			List<PlayerViewModel> sortedList = Roster.OrderByDescending(p => p.NumberOfHits).ToList();
			sortedList.ForEach(p => playerStats += p.PrintInfo());

			return playerStats;
		}


	}
}
