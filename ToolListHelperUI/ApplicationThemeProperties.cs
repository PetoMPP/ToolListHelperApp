using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperUI
{
    internal class ApplicationThemeProperties
    {
        public static Color DarkPrimaryFore { get; } = Color.FromArgb(30, 165, 235);
        public static Color DarkSecondaryFore { get; } = Color.White;
        public static Color DarkPrimaryBack { get; } = Color.FromArgb(66, 66, 66);
        public static Color DarkSecondaryBack { get; } = Color.FromArgb(20, 100, 135);
        public static Color DarkPrimaryBorderColor { get; } = Color.Black;
        public static Color DarkSecondaryBorderColor { get; } = Color.FromArgb(30, 165, 235);
        public static Color LightPrimaryFore { get; } = Color.FromArgb(1, 112, 184);
        public static Color LightSecondaryFore { get; } = Color.Black;
        public static Color LightPrimaryBack { get; } = Color.White;
        public static Color LightSecondaryBack { get; } = Color.FromArgb(30, 165, 235);
        public static Color LightPrimaryBorderColor { get; } = Color.White;
        public static Color LightSecondaryBorderColor { get; } = Color.FromArgb(1, 60, 111);
    }
}
