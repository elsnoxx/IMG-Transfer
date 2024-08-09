using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;

namespace Transfer_IMG.General
{
    /// <summary>
    /// A utility class that provides color schema and settings.
    /// </summary>
    public sealed class WT
    {
        // Color schema
        public static Color color = System.Drawing.ColorTranslator.FromHtml("#7a7d84");
        public static Color colorDefault = System.Drawing.ColorTranslator.FromHtml("#212121");

        // language settings
        public static string language = "";
    }
}
