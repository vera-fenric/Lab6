using System;
using System.Windows.Data;
using System.Numerics;
using Lab3;

namespace ViewModel
{
    //---------------------Подумать над конвертерами!
    public class MinMaxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            if (!(value is V2DataOnGrid))
                return null;
            V2DataOnGrid g = (V2DataOnGrid)value;
            return "Max: " + g.Max + "; Min: " + g.Min;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    //---------------------Подумать над конвертерами! Эти конвёртеры используют внутреннее представление DataItem
    public class PointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            if (!(value is DataItem))
                return null;
            DataItem d = (DataItem)value;
            return "Point: (" + d.Point.X + ", " + d.Point.Y + ");";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
    //---------------------Подумать над конвертерами! Эти конвёртеры используют внутреннее представление DataItem
    public class SavedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            if (!(value is bool))
                return null;
            bool b = (bool)value;
            if (b)
                return "Все изменения были сохранены. ";
            return "Присутствуют несохранённые изменения. ";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
    public class ComplexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            if (!(value is DataItem))
                return null;
            DataItem d = (DataItem)value;
            return "Value: " + d.Val.Real + "+" + d.Val.Imaginary + "i;";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class FloatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            return value.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            string s = value as string;
            return float.Parse(s, culture);
        }
    }
    public class AvgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            AvgViewModel.CorrectResultViewModel avg = value as AvgViewModel.CorrectResultViewModel;
            if (avg == null)
                return null;
            if (avg.Value == -1)
                return null;
            return $"Avg: {avg.Value}; ";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
