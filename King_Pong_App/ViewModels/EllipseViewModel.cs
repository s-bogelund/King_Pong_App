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


		private Visibility ellipseVisibility;
		public Visibility EllipseVisibility
		{
			get => ellipseVisibility;
			set
			{
				ellipseVisibility = Visibility.Visible;
				OnPropertyChanged("EllipseVisibility");
			}
		}

		public EllipseViewModel()
		{
			ellipseVisibility = Visibility.Visible;
			ellipseColor = Brushes.Green;
		}

		public void HideEllipse(EllipseViewModel ellipse)
		{
			ellipse.ellipseVisibility = Visibility.Hidden;
			OnPropertyChanged("EllipseVisibility");
			//return ellipseVisibility;
		}

		public void ShowEllipse(EllipseViewModel ellipse)
		{
			ellipse.ellipseVisibility = Visibility.Visible;
			OnPropertyChanged("EllipseVisibility");
			//return ellipseVisibility;
		}
		private SolidColorBrush ellipseColor;

		public SolidColorBrush EllipseColor
		{
			get => ellipseColor;
			set
			{
				ellipseColor = value;
				OnPropertyChanged("EllipseColorChanged");
			}
		}

		public SolidColorBrush EllipseColorChanger(Ellipse ellipse)
		{
			OnPropertyChanged("EllipseColorChanged");

			if (ellipse.Fill == Brushes.Green)
				return Brushes.Red;
			else
				return Brushes.Green;
		}


		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
