using System;
using System.Globalization;
using System.Windows.Data;

namespace CodeGenerator.WPF.Resources.Converters;

[ValueConversion(typeof(double), typeof(double))]
public class SizeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
        => value is double typed && parameter is double param ? typed + param : value;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        => value is double typed && parameter is double param ? typed - param : value;
}
