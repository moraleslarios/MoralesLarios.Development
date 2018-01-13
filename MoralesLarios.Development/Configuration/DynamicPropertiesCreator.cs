using System;
using MoralesLarios.CodeComun;
using System.Collections.Generic;

namespace MoralesLarios.Development.Configuration
{
    public class DynamicPropertiesCreator : IDynamicPropertiesCreator
    {
        public void CreateDynamicProperties(dynamic configNodes, IDictionary<string, object> properties)
        {
            ParameterValidator.ValidateObject(configNodes, nameof(configNodes));
            ParameterValidator.ValidateObject(properties, nameof(properties));

            var dictionary = (IDictionary<string, object>)configNodes;

            foreach (var property in properties)
            {
                dictionary.Add(property.Key, property.Value);
            }
        }

        public void CreateDynamicProperty(dynamic configNodes, string propertyName, object propertyValue)
        {
            ParameterValidator.ValidateObject(configNodes  , nameof(configNodes));
            ParameterValidator.ValidateString(propertyName , nameof(propertyName));
            ParameterValidator.ValidateObject(propertyValue, nameof(propertyValue));

            var dictionary = (IDictionary<string, object>)configNodes;

            dictionary.Add(propertyName, propertyValue);

        }
    }
}