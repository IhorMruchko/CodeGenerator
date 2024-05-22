using System;
using System.Globalization;
using System.Windows.Data;

namespace CodeGenerator.WPF.Resources.Converters;

[ValueConversion(typeof(double), typeof(double))]
public class IconButtonConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
        => value is double typed ? typed / 2 : value;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        => value is double typed ? typed * 2 : value;
}
