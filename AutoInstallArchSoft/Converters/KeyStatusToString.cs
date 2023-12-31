using System.Globalization;
using System.Windows;
using System.Windows.Data;
using AutoInstallArchSoft.Enums;

namespace AutoInstallArchSoft.Converters;

public class KeyStatusToString: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((KeyStatus)value == KeyStatus.True)
            return "Ключ принят!";

        else if ((KeyStatus)value == KeyStatus.False)
            return "Ключ неверный!";

        else
            return "Unknown";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }  
}
