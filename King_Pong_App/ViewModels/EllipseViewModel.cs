using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace King_Pong_App.ViewModels
{
	public class EllipseViewModel : INotifyPropertyChanged
	{
		private Visibility visibility;
		/// <summary>
		/// Set/Get for the visibility property. 
		/// Implements INotifyPropertyChanged event handler
		/// </summary>
		public Visibility Visibility
		{
			get => visibility;
			set
			{
				visibility = value;
				OnPropertyChanged(nameof(Visibility));
			}
		}
		/// <summary>
		/// Initalizes the instance with the attributes set to the 
		/// values they should have at the start of a game.
		/// </summary>
		public EllipseViewModel()
		{
			visibility = Visibility.Visible;
			color = Brushes.Green;
		}
		/// <summary>
		/// Hides the object
		/// </summary>
		public void HideEllipse()
		{
			Visibility = Visibility.Hidden;
		}
		/// <summary>
		/// Shows the object
		/// </summary>
		public void ShowEllipse()
		{
			Visibility = Visibility.Visible;
		}

		private SolidColorBrush color;
		/// <summary>
		/// Set/Get for the color property. 
		/// Implements INotifyPropertyChanged event handler
		/// </summary>
		public SolidColorBrush Color
		{
			get => color;
			set
			{
				color = value;
				OnPropertyChanged("Color");
			}
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
}
