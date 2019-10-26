using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Media;
using Windows.UI;

namespace PomodoroAssistantPlus.Pomodoro
{
    public static class ColorRevert
    {
        public static Color ToColor(this string colorName)
        {
            if (colorName.StartsWith("#"))
                colorName = colorName.Replace("#", string.Empty);
            int v = int.Parse(colorName, System.Globalization.NumberStyles.HexNumber);
            //var color = new SolidColorBrush();
            return new Color()
            {
                A = Convert.ToByte((v >> 24) & 255),
                R = Convert.ToByte((v >> 16) & 255),
                G = Convert.ToByte((v >> 8) & 255),
                B = Convert.ToByte((v >> 0) & 255)
            };
        }

        public static int ToArgb(this Color color)
        {
            int argb = color.A << 24;
            argb += color.R << 16;
            argb += color.G << 8;
            argb += color.B;
            return argb;
        }  
    }
}
