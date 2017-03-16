using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormsListViewDemo.ValueConverters
{
	public class StringToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var filename = (string)value;
			return Device.OnPlatform(
					  iOS: ImageSource.FromFile("Images/" + filename),
					  Android: ImageSource.FromFile(filename),
					  WinPhone: ImageSource.FromFile("Assets/" + filename));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
