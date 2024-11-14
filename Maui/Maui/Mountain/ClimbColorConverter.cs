using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Mountain
{
    public class ClimbColorConverter : IValueConverter // Szín konverterhez szükséges (ez a 2 metódusa van)
    {                    // átalakítandó értek , mire konvertálni az értéket, (parameter & culture nem használjuk most) 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)  //fix igy
        {
            return (bool)value ? Colors.Green : Colors.Black;   // rövid if ág, ha igaz akkor zöld ha hamis akkor fekete
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) // nem kell most nekünk
        {
            throw new NotImplementedException();
        }
    }

}
