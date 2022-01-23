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
public class PlayerModel : INotifyPropertyChanged
{
	public int NumberOfThrows { get; set; }

	[JsonProperty]
	private string playerName;
	/// <summary>
	/// Name property that implements INotifyPropertyChanged
	/// </summary>
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
	/// <summary>
	/// Property that tracks number of cups hit and implements INotifyPropertyChanged
	/// </summary>
	public int NumberOfHits
	{
		get { return numberOfHits; }
		set
		{
			numberOfHits = value;
			OnPropertyChanged(nameof(NumberOfHits));
		}
	}
	public PlayerModel() 
	{
		numberOfHits = 0;
	}
	public PlayerModel(string name, int _numberOfHits = 0)
	{
		PlayerName = name;
		numberOfHits = _numberOfHits;
	}
	/// <summary>
	/// Increases the number of throws for a player
	/// </summary>
	public void AddThrow()
	{
		NumberOfThrows++;
	}
	/// <summary>
	/// Increases the number of hits for a player
	/// </summary>
	public void AddHit()
	{
		NumberOfHits++;
	}
	/// <summary>
	/// Calculates and returns the hitrate for a player
	/// </summary>
	/// <returns></returns>
	public string Hitrate() => Math.Round((double)NumberOfHits / NumberOfThrows * 100, 2).ToString() + "%";

	/// <summary>
	/// Prints info the the player in the desired format 
	/// for the GameWonWindow.
	/// </summary>
	/// <returns></returns>
	public string PrintInfo()
	{
		string name = $"{PlayerName}: \n";
		string hits = $"Antal Ramte: {NumberOfHits}\n";
		string hitrate = $"Præcision: {Hitrate()}\n";

		return name + hits + hitrate + "\n";
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
