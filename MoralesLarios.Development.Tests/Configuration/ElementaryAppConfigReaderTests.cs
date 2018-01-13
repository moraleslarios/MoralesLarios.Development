using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoralesLarios.Development.Configuration;
using System.Collections.Generic;
using Xunit;

namespace MoralesLarios.Development.Tests.Configuration
{
    public class ElementaryAppConfigReaderTests
    {

        private IElementaryConfigReader instance;


        public ElementaryAppConfigReaderTests()
        {
            instance = new ElementaryConfigReader();
        }


        [Fact]
        public void ReadAppConfiguration()
        {
            IDictionary<string, string> expected = new Dictionary<string, string>()
            {
                ["PropertyForceString1"] = "'property1Value'",
                ["Propertytring1"]       = "property1Value",
                ["PropertyNumeric1"]     = "99999,99",
                ["PropertyArrayString1"] = "one;two;three",
                ["PropertyArrayNumeric"] = "1;2;3",
                ["PropertyDate"]         = "25/12/2017",
                ["PropertyDateTime"]     = "25/12/2017 12:12:15",
                ["PropertyArrayDate"]    = "25/12/2017;15/12/2015",
                ["PropertyBool"]         = "true",
                ["PropertyArrayBool"]    = "true;false",
                ["PropSaveChararcter"]   = "one\\;two\\;three"
            };

            IDictionary<string, string> result = instance.ReadAppConfiguration();

            Assert.Equal(expected.Count, result.Count);

            Assert.Equal(expected["PropertyForceString1"], result["PropertyForceString1"]);
            Assert.Equal(expected["Propertytring1"]      , result["Propertytring1"]      );
            Assert.Equal(expected["PropertyNumeric1"]    , result["PropertyNumeric1"]    );
            Assert.Equal(expected["PropertyArrayString1"], result["PropertyArrayString1"]);
            Assert.Equal(expected["PropertyArrayNumeric"], result["PropertyArrayNumeric"]);
            Assert.Equal(expected["PropertyDate"]        , result["PropertyDate"]        );
            Assert.Equal(expected["PropertyDateTime"]    , result["PropertyDateTime"]    );
            Assert.Equal(expected["PropertyArrayDate"]   , result["PropertyArrayDate"]   );
            Assert.Equal(expected["PropertyBool"]        , result["PropertyBool"]        );
            Assert.Equal(expected["PropertyArrayBool"]   , result["PropertyArrayBool"]);
            Assert.Equal(expected["PropSaveChararcter"]  , result["PropSaveChararcter"]);
        }

    }
}
