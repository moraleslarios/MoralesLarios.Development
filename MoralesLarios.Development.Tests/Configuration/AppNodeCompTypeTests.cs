using MoralesLarios.Development.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoralesLarios.Development.Tests.Configuration
{
    public class AppNodeCompTypeTests
    {
        private IAppNodeCompType instance;

        

        public AppNodeCompTypeTests()
        {
            ISaveCharacterManager saveCharacterManager = new SaveCharacterManager();

            IStringInspector stringInspector = new StringInspector(saveCharacterManager);

            instance = new AppNodeCompType(stringInspector);
        }

        [Theory]
        [InlineData("'DataString'"           , DataType.Alphanumeric)]
        //[InlineData(22                       , DataType.Numeric)]
        [InlineData("25/12/2000"             , DataType.DateTime)]
        [InlineData("true"                   , DataType.Bool)]
        [InlineData("str1;str2"            , DataType.ArrayAlphanumeric)]
        [InlineData("1;2"                  , DataType.ArrayNumeric)]
        [InlineData("25/10/2003;15/01/2014", DataType.ArrayDateTime)]
        [InlineData("true;false"           , DataType.ArrayBool)]

        public void DecodeType_GoodParameter_OK(string data, DataType expected)
        {
            DataType result = instance.DecodeType(data);

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void DecodeType_NullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.DecodeType(data));
        }



        [Theory]
        [InlineData("'DataString'", DataType.Alphanumeric)]
        //[InlineData(22            , DataType.Numeric)]
        [InlineData("25/12/2000"  , DataType.DateTime)]
        [InlineData("true"        , DataType.Bool)]
        [InlineData("25"          , DataType.Numeric)]
        [InlineData("algo"        , DataType.Alphanumeric)]
        public void DecodeTypeSimple_GoodParameter_OK(string data, DataType expected)
        {
            DataType result = instance.DecodeTypeSimple(data);

            Assert.Equal(result, expected);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void DecodeTypeSimple_NullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.DecodeTypeSimple(data));
        }

        [Theory]
        [InlineData("str1;str2"            , DataType.ArrayAlphanumeric)]
        [InlineData("1;2"                  , DataType.ArrayNumeric)]
        [InlineData("25/10/2003;15/01/2014", DataType.ArrayDateTime)]
        [InlineData("true;false"           , DataType.ArrayBool)]
        public void DecodeTypeArray_GoodParameter_OK(string data, DataType expected)
        {
            DataType result = instance.DecodeTypeArray(data);

            Assert.Equal(result, expected);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void DecodeTypeArray_NullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.DecodeTypeArray(data));
        }

    }
}
