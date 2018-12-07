using System;
using System.Globalization;
using System.Windows.Data;

namespace TableTopWorld.UI.WPF.ValueConverters
{
    public class VC_ValueOperation : IValueConverter
    {
        public object Convert(object value , Type targetType , object parameter , CultureInfo culture)
        {
            return this.getValue(value) + this.getValue(parameter);
        }

        public object ConvertBack(object value , Type targetType , object parameter , CultureInfo culture)
        {
            return this.getValue(value) - this.getValue(parameter);
        }

        private double getValue(object value)
        {
            switch ( value )
            {
                case string svalue:
                    return double.Parse(svalue);
                case double dValue:
                    return dValue;
                default:
                    throw new NotImplementedException($"the value {value} with type {value.GetType()}");
            }
        }
    }
}
