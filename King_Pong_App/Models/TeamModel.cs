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
}

