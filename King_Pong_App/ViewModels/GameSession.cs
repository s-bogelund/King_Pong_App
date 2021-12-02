using King_Pong_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace King_Pong_App.ViewModels
{
	public class GameSession : INotifyPropertyChanged
	{

		public GameSession()
		{
			Player1 = new();
			Player2 = new();
			Player3 = new();
			Player4 = new();

			Team1 = new();
			Team2 = new();

			Cup1_1 = new();
			Cup1_2 = new();
			Cup1_3 = new();
			Cup1_4 = new();
			Cup1_5 = new();
			Cup1_6 = new();
			Cup1_7 = new();
			Cup1_8 = new();
			Cup1_9 = new();
			Cup1_10 = new();

			Cup2_1 = new();
			Cup2_2 = new();
			Cup2_3 = new();
			Cup2_4 = new();
			Cup2_5 = new();
			Cup2_6 = new();
			Cup2_7 = new();
			Cup2_8 = new();
			Cup2_9 = new();
			Cup2_10 = new();

			current = Team1;

			backFourCups = new() { Cup1_7, Cup1_8, Cup1_9, Cup1_10, 
									Cup2_7, Cup2_8, Cup2_9, Cup2_10 };
		}
		public List<EllipseViewModel> backFourCups;

		public int numberOfCups = 10;
		public int teamSize = 2;
		public int currentPlayer = 0;

		public void TurnOver()
		{
			Current = Current == Team1 ? Team2 : Team1;
			currentPlayer = 0;
		}
		private string command;
		public string Command
		{
			get { return command; }
			set 
			{ 
				command = value;
				OnPropertyChanged("Command");
			}

		}
		
		private TeamViewModel current;

		public TeamViewModel Current
		{
			get { return current; }
			set 
			{ 
				current = value;
				OnPropertyChanged(nameof(Current));
			}
		}

		public TeamViewModel Team1 { get; set; }
		public TeamViewModel Team2 { get; set; }

		public PlayerViewModel Player1 { get; set; }
		public PlayerViewModel Player2 { get; set; }
		public PlayerViewModel Player3 { get; set; }
		public PlayerViewModel Player4 { get; set; }

		public EllipseViewModel Cup1_1 { get; set; }
		public EllipseViewModel Cup1_2 { get; set; }
		public EllipseViewModel Cup1_3 { get; set; }
		public EllipseViewModel Cup1_4 { get; set; }
		public EllipseViewModel Cup1_5 { get; set; }
		public EllipseViewModel Cup1_6 { get; set; }
		public EllipseViewModel Cup1_7 { get; set; }
		public EllipseViewModel Cup1_8 { get; set; }
		public EllipseViewModel Cup1_9 { get; set; }
		public EllipseViewModel Cup1_10 { get; set; }
		public EllipseViewModel Cup2_1 { get; set; }
		public EllipseViewModel Cup2_2 { get; set; }
		public EllipseViewModel Cup2_3 { get; set; }
		public EllipseViewModel Cup2_4 { get; set; }
		public EllipseViewModel Cup2_5 { get; set; }
		public EllipseViewModel Cup2_6 { get; set; }
		public EllipseViewModel Cup2_7 { get; set; }
		public EllipseViewModel Cup2_8 { get; set; }
		public EllipseViewModel Cup2_9 { get; set; }
		public EllipseViewModel Cup2_10 { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
