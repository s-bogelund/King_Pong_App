using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using King_Pong_App;

namespace King_Pong_App.Models
{
	public class GamePlayModel : INotifyPropertyChanged
	{
		public GamePlayModel()
		{

		}
		public enum Commands
		{
			HIT,
			TURNOVER,
			WIN,
		}

		private string command;

		public string Command
		{
			get { return command; }
			set 
			{ 
				command = value;
				OnPropertyChanged("Command");
				Debug.WriteLine("command updated");			}
		}


		public void CommandHandler(Commands com)
		{
			switch (com)
			{
				case Commands.HIT:
					
					break;
				case Commands.TURNOVER:
					break;
				case Commands.WIN:
					break;
				default:
					break;
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		public virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
