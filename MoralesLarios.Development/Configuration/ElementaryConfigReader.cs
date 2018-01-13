namespace MoralesLarios.Development.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    internal class ElementaryConfigReader : IElementaryConfigReader
    {
        public IDictionary<string, string> ReadAppConfiguration()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (var key in ConfigurationManager.AppSettings.Keys)
            {
                string value = ConfigurationManager.AppSettings.GetValues(key.ToString()).FirstOrDefault();

                result.Add(key.ToString(), value?.ToString() ?? "without value");
            }

            return result;
        }
    }
}