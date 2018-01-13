using MoralesLarios.Development.Reflection;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoralesLarios.CodeComun;

namespace MoralesLarios.Development.Configuration
{
    public class Config
    {
        private static dynamic _configNodes;

        public static dynamic ConfigNodes
        {
            get
            {
                if (_configNodes == null)
                {
                    _configNodes = new ExpandoObject();
                    LoadAppFile();
                }

                return _configNodes;
            }

            private set { _configNodes = value; }
        }


        internal static IAppNodeCompType AppNodeCompType { private get; set; } 
            = new AppNodeCompType(
                                    new StringInspector(new SaveCharacterManager())
                                 );

        internal static IElementaryConfigReader elementaryConfigReader { private get; set; }
            = new ElementaryConfigReader();

        internal static IMLActivator mlActivator { private get; set; }
            = new MLActivator();

        internal static IDynamicPropertiesCreator dynamicPropertyCreator { private get; set; }
            = new DynamicPropertiesCreator();


        internal static void LoadAppFile()
        {
            var configValues = elementaryConfigReader.ReadAppConfiguration();
            var values       = CreateFinalDictionary(configValues);

            dynamicPropertyCreator.CreateDynamicProperties(ConfigNodes, values);
        }


        internal static IDictionary<string, object> CreateFinalDictionary(IDictionary<string, string> values)
        {
            ParameterValidator.ValidateObject(values, nameof(values));

            Dictionary<string, object> result = new Dictionary<string, object>();

            foreach (var value in values)
            {
                var dataType = AppNodeCompType.DecodeType(value.Value);

                var valueStr = RemoveSpecialCharacters(value.Value.ToString());

                var valueObj = mlActivator.CreateInstance(valueStr, dataType);

                result.Add(value.Key, valueObj);
            }

            return result;
        }


        private static string RemoveSpecialCharacters(string value)
        {
            string result = value;

            if(result?.FirstOrDefault() != null && result.FirstOrDefault().ToString() == "'")
            {
                result = result.Substring(1);
            }

            if (result?.LastOrDefault() != null && result.LastOrDefault().ToString() == "'" 
                && result.Substring(result.Count() -2) != "\\'")
            {
                result = result.Substring(0, result.Count() -1);
            }

            result = result.ToString().Replace("\\'", "'");
            result = result.ToString().Replace("\\;", ";");

            return result;
        }

    }
}
        