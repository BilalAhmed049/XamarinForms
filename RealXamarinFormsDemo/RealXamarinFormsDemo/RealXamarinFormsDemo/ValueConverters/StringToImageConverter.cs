using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealXamarinFormsDemo.ValueConverters
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filename = (string)value;
            return Device.OnPlatform(
                      iOS: ImageSource.FromFile("Images/" + filename),
                      Android: ImageSource.FromFile(filename),
                      WinPhone: ImageSource.FromFile("Images/" + filename));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
