using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using TableTopWorld.Core;
using TableTopWorld.Core.EntityFramework;

namespace TableTopWorld.UI.WPF.ValueConverters
{
    public class VC_NamespaceValueConverter : IValueConverter
    {
        public object Convert(object value , Type targetType , object parameter , CultureInfo culture)
        {
            return (value as Namespace)?.ToString();
        }
        public object ConvertBack(object value , Type targetType , object parameter , CultureInfo culture)
        {
            return Namespace.Parse(value as string);
        }
    }
}
