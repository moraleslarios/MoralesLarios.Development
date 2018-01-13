using System.Collections.Generic;

namespace MoralesLarios.Development.Configuration
{
    public interface IDynamicPropertiesCreator
    {
        void CreateDynamicProperty(dynamic configNodes, string propertyName, object propertyValue);
        void CreateDynamicProperties(dynamic configNodes, IDictionary<string, object> properties);
    }
}