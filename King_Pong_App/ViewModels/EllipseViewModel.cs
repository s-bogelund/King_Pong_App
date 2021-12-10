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
		public Visibility Visibility
		{
			get => visibility;
			set
			{
				visibility = value;
				OnPropertyChanged(nameof(Visibility));
			}
		}

		public EllipseViewModel()
		{
			visibility = Visibility.Visible;
			color = Brushes.Green;
		}

		public void HideEllipse()
		{
			Visibility = Visibility.Hidden;
		}

		public void ShowEllipse()
		{
			Visibility = Visibility.Visible;
		}
		private SolidColorBrush color;

		public SolidColorBrush Color
		{
			get => color;
			set
			{
				color = value;
				OnPropertyChanged("Color");
			}
		}

		//public SolidColorBrush EllipseColorChanger(Ellipse ellipse)
		//{
		//	OnPropertyChanged("EllipseColorChanged");

		//	if (ellipse.Fill == Brushes.Green)
		//		return Brushes.Red;
		//	else
		//		return Brushes.Green;
		//}


		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
