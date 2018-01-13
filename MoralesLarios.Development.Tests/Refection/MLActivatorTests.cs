using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MoralesLarios.Development.Reflection;
using MoralesLarios.Development.Configuration;

namespace MoralesLarios.Development.Tests.Refection
{
    public class MLActivatorTests
    {
        private IMLActivator instance;

        public MLActivatorTests()
        {
            instance = new MLActivator();
        }


        #region CreateInstanceSimple

        [Theory]
        [InlineData("data", DataType.Alphanumeric, "data")]
        [InlineData("true", DataType.Bool, true)]
        public void CreateInstanceSimple_DataTypeSimple_OK(string value, DataType dateType, object expected)
        {
            object result = instance.CreateInstanceSimple(value, dateType);

            Assert.Equal(result, expected);
        }


        [Fact]
        public void CreateInstanceSimple_NumericDataType_OK()
        {
            string data = "25";

            decimal expected = 25m;

            var result = instance.CreateInstanceSimple(data, DataType.Numeric);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void CreateInstanceSimple_DateTimeDataType_OK()
        {
            string data = "25/12/2015";

            DateTime expected = new DateTime(2015, 12, 25);

            var result = instance.CreateInstanceSimple(data, DataType.DateTime);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void CreateInstanceSimple_ArrayDataType_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => instance.CreateInstanceSimple("..", DataType.ArrayAlphanumeric));
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateInstanceSimple_NullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.CreateInstanceSimple(data, DataType.DateTime));
        }

        #endregion

        #region CreateInstanceArray

        [Fact]
        public void CreateInstanceArray_ArrayAlphanumerics_OK()
        {
            string data = "data1;data2";

            DataType dataType = DataType.ArrayAlphanumeric;

            object expected = new string[] { "data1", "data2" };

            object result = instance.CreateInstanceArray(data, dataType);

            Assert.Equal(result, expected);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateInstanceArray_AlphanumericsNullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.CreateInstanceArray(data, DataType.ArrayAlphanumeric));
        }



        [Fact]
        public void CreateInstanceArray_ArrayNumerics_OK()
        {
            string data = "7;8";

            DataType dataType = DataType.ArrayNumeric;

            object expected = new decimal[] { 7, 8 };

            object result = instance.CreateInstanceArray(data, dataType);

            Assert.Equal(result, expected);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateInstanceArray_NumericsNullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.CreateInstanceArray(data, DataType.Numeric));
        }


        [Fact]
        public void CreateInstanceArray_ArrayDateTime_OK()
        {
            string data = "1/1/2015;2/1/2015";

            DataType dataType = DataType.ArrayDateTime;

            object expected = new DateTime[] { new DateTime(2015, 1, 1), new DateTime(2015, 1, 2) };

            object result = instance.CreateInstanceArray(data, dataType);

            Assert.Equal(result, expected);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateInstanceArray_DateTimeNullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.CreateInstanceArray(data, DataType.ArrayDateTime));
        }


        [Fact]
        public void CreateInstanceArray_ArrayBool_OK()
        {
            string data = "true;false";

            DataType dataType = DataType.ArrayBool;

            object expected = new bool[] { true, false };

            object result = instance.CreateInstanceArray(data, dataType);

            Assert.Equal(result, expected);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateInstanceArray_BoolNullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.CreateInstanceArray(data, DataType.Bool));
        }

        #endregion

        #region CreateInstance

        [Fact]
        public void CreateInstance_SimpleAlphanumeric_OK()
        {
            string data = "data";

            object expected = "data";

            object result = instance.CreateInstance(data, DataType.Alphanumeric);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void CreateInstance_ArrayAlphanumeric_OK()
        {
            string data = "data;otherData";

            object expected = new string[] { "data", "otherData" };

            object result = instance.CreateInstance(data, DataType.ArrayAlphanumeric);

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateInstance_SimpleInstanceNullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.CreateInstance(data, DataType.ArrayAlphanumeric));
        }

        #endregion

    }
}
