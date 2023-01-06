using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalyProject
{
    public static class DateTimeExtension
    {
        public static DateTime Tomorrow(this DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }
    }
    public static class IntExtensions 
    {
        public static bool IsInRange(this int range, int length)
        {
            if (range >= 0 && range < length) return true;
            return false;
        }

    }
}
