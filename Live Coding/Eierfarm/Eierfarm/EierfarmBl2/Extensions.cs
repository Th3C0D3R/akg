using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public static class Extensions
    {
        public static bool IsNumeric(this string text)
        {
            return double.TryParse(text, out double _);
        }

        /// <summary>
        /// Fügt das Element an die Liste an, wenn das Element noch nicht auf der Liste vorhanden ist.
        /// </summary>
        /// <typeparam name="T">Typ des Elements</typeparam>
        /// <param name="liste">Die Liste</param>
        /// <param name="element">Das Element, das nur dann auf die Liste soll, wenn es nicht schon vorhanden ist.</param>
        public static void AddIfNew<T>(this List<T> liste, T element)
        {
            if (!liste.Contains(element))
            {
                liste.Add(element);
            }
        }
    }
}
