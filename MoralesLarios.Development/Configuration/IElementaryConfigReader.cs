using System.Collections.Generic;

namespace MoralesLarios.Development.Configuration
{
    internal interface IElementaryConfigReader
    {
        IDictionary<string, string> ReadAppConfiguration();
    }
}