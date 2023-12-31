using System.Globalization;
using System.Windows;
using System.Windows.Data;
using AutoInstallArchSoft.Enums;

namespace AutoInstallArchSoft.Converters;

public class KeyStatusToCollor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((KeyStatus)value == KeyStatus.True)
            return "#008000";

        else if ((KeyStatus)value == KeyStatus.False)
            return "#ff0000";

        else
            return "#ffffff";
    }
 
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }  
}