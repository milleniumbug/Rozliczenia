using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using RozliczeniaXamarin.Models;
using Xamarin.Forms;

namespace RozliczeniaXamarin.Converters
{
    class TransferToStringConverter : IValueConverter
    {
		public static TransferToStringConverter Default = new TransferToStringConverter();

	    /// <inheritdoc />
	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	    {
		    if(value == null)
			    return null;
		    var o = ((TransferViewModel)value).Transfer;
		    return $"{o.From} should pay {o.MoneyAmount} to {o.To}";
	    }

	    /// <inheritdoc />
	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	    {
		    throw new NotImplementedException();
	    }
    }
}
