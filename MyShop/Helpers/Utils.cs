using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyShop.Helpers
{
    public static class Utils
    {
        private static Regex digitsOnly = new Regex(@"[^\d]");

        public static string CleanPhone(this string phone)
        {
            return digitsOnly.Replace(phone, string.Empty);
        }
    }
}
