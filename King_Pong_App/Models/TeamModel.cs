using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace King_Pong_App.Models;

[JsonObject(MemberSerialization.OptIn)]
public class TeamModel : INotifyPropertyChanged
{

	private int cupsRemaining;
	/// <summary>
	/// Property that tracks how many cups a team has left 
	/// and implements INotifyPropertyChanged
	/// </summary>
	public int CupsRemaining
	{
		get { return cupsRemaining; }
		set 
		{ 
			cupsRemaining = value;
			OnPropertyChanged(nameof(CupsRemaining));
		}
	}
	[JsonProperty]
	private string teamName;
	/// <summary>
	/// Name property that implements INotifyPropertyChanged
	/// </summary>
	public string TeamName
	{
		get { return teamName; }
		set
		{
			teamName = value;
			OnPropertyChanged(nameof(TeamName));
		}

	}


	public TeamModel() { }

	/// <summary>
	/// A list of PlayerModel objects
	/// </summary>
	public List<PlayerModel> Roster = new();
	/// <summary>
	/// Adding any amount of players to the roster.
	/// Done in order to use the same function for 1 or 2 player teams
	/// without needing to overload
	/// </summary>
	/// <param name="players"></param>
	public void AddMembers(params PlayerModel[] players)
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

		List<PlayerModel> sortedList = Roster.OrderByDescending(p => p.NumberOfHits).ToList();
		sortedList.ForEach(p => playerStats += p.PrintInfo());

		return playerStats;
	}

	public event PropertyChangedEventHandler PropertyChanged;
	/// <summary>
	/// The implementation of INotifyPropertyChanged
	/// </summary>
	/// <param name="propertyName"></param>
	public void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}


