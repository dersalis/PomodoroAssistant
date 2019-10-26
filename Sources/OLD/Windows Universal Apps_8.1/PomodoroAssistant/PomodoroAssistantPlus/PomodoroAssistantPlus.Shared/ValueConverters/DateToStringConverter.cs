using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Data;
using System.Threading;

namespace PomodoroAssistantPlus.ValueConverters
{
    public class DateToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Jeśli data to dzień dzisiejszy to wyświetl tylko godzinę
            if ((DateTime)value >= DateTime.Today)
                //return string.Format("{0:HH:mm}", (DateTime)value);
                //return string.Format("{0:g}", (DateTime)value);
                return ((DateTime)value).ToString("hh:mm", System.Globalization.CultureInfo.InvariantCulture);

            return string.Format("{0:ddd, dd MMM yyyy}", (DateTime)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value.GetType() == typeof(string) && targetType == typeof(DateTime))
            {
                DateTime newDate;
                if (DateTime.TryParse((string)value, out newDate))
                    return newDate;
            }
            //jeśli nie wprowadzamy zmian to zwróć wartość
            return value;
        }
    }
}
