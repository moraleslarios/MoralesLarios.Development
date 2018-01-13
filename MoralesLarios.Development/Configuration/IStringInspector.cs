using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoralesLarios.Development.Configuration
{
    public interface IStringInspector
    {
        bool IsAlphanumericForce(string data);
        bool IsNumeric(string data);
        bool IsArray(string data);
        bool IsDateTime(string data);
        bool IsBool(string data);
    }
}
