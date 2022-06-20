using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfExtension;

public class DisplayConverter : IValueConverter
{
    //后台转换到前台
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null)
        {
            string str = value.ToString();
            if (str =="0") return "No";
        }
        return "Yes";
    }
    //前台转换到后台
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
