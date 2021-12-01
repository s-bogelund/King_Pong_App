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
		public PlayerViewModel Player1 { get; set; }

		public EllipseViewModel Cup1_1 { get; set; }
		public GameSession() 
		{
			Player1 = new();
			Player1.Name = "Scott";
			Player1.NumberOfHits = 0;
			Player1.NumberOfThrows = 0;

			Cup1_1 = new();
			Cup1_1.EllipseColor = Brushes.Green;
			Cup1_1.EllipseVisibility = Visibility.Visible;
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
		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
