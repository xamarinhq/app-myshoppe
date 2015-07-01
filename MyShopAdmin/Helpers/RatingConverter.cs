using System;
using Xamarin.Forms;
using System.Globalization;

namespace MyShopAdmin.Helpers
{
	class RatingConverter : IValueConverter
	{
		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{
			double multiplier;

			if (!double.TryParse(value == null ? "0" : value.ToString(), out multiplier))
				multiplier = 0;

			if(multiplier > 5)
			{
				var green = Color.Green;
				return green.MultiplyAlpha(10.0 / multiplier);
			
			}
			var red = Color.Red;
			if (multiplier <= 0)
				return red;

			return red.MultiplyAlpha (5.0 / multiplier);
		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}

