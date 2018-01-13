using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoralesLarios.Development.Configuration;
using System.Dynamic;
using Xunit;

namespace MoralesLarios.Development.Tests.Configuration
{
    public class DynamicPropertiesCreatorTests
    {

        private IDynamicPropertiesCreator instance;


        public DynamicPropertiesCreatorTests()
        {
            instance = new DynamicPropertiesCreator();
        }


        [Fact]
        public void CreateDynamicProperty_AlphanumericsArgument_OK()
        {
            string propertyName = "StringProperty1";
            object propertyValue = "oneValue";

            dynamic configNodes = new ExpandoObject();

            instance.CreateDynamicProperty(configNodes, propertyName, propertyValue);

            Assert.Equal(configNodes.StringProperty1, propertyValue);
        }


        [Fact]
        public void CreateDynamicProperty_NumericsArgument_OK()
        {
            string propertyName = "NumericProperty";
            object propertyValue = 19m;

            dynamic configNodes = new ExpandoObject();

            instance.CreateDynamicProperty(configNodes, propertyName, propertyValue);

            Assert.Equal(configNodes.NumericProperty, propertyValue);
        }

        [Fact]
        public void CreateDynamicProperties_NumericsArgument_OK()
        {
            IDictionary<string, object> properties = new Dictionary<string, object>()
            {
                ["PropertyAlphaNumeric"] = "data",
                ["PropertyNumeric"]      = 9m
            };

            dynamic configNodes = new ExpandoObject();

            instance.CreateDynamicProperties(configNodes, properties);

            Assert.Equal(configNodes.PropertyAlphaNumeric, "data");
            Assert.Equal(configNodes.PropertyNumeric     , 9m);
        }

    }
}
