using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoralesLarios.Development.Helper
{
    public static class Extensions
    {
        public static bool IsNumeric(this object obj)
        {
            bool result = decimal.TryParse(obj.ToString(), out var newNumberOut);

            return result;
        }

        public static bool IsDateTime(this object obj)
        {
            bool result = DateTime.TryParse(obj.ToString(), out var newNumberOut);

            return result;
        }

        public static bool IsBool(this object obj)
        {
            bool result = bool.TryParse(obj.ToString(), out var newNumberOut);

            return result;
        }
    }
}
