using MoralesLarios.Development.Configuration;
using System;
using Xunit;

namespace MoralesLarios.Development.Tests.Configuration
{
    public class StringInspectorTests
    {
        private IStringInspector instance;


        public StringInspectorTests()
        {
            ISaveCharacterManager saveCharacterManager = new SaveCharacterManager();

            instance = new StringInspector(saveCharacterManager);
        }


        #region IsAlphanumeric

        [Fact]
        public void IsAlphanumericForce_true_OK()
        {
            string data = "'data'";

            bool result = instance.IsAlphanumericForce(data);

            Assert.True(result);
        }

        [Fact]
        public void IsAlphanumericForce_numericValue_true_OK()
        {
            string data = "'123'";

            bool result = instance.IsAlphanumericForce(data);

            Assert.True(result);
        }

        [Fact]
        public void IsAlphanumeric_LessTwoCharacters_OK()
        {
            string data = "'";

            bool result = instance.IsAlphanumericForce(data);

            Assert.False(result);
        }

        [Fact]
        public void IsAlphanumeric_WithoutSimpleComilla_OK()
        {
            string data = "hola";

            bool result = instance.IsAlphanumericForce(data);

            Assert.False(result);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void IsAlphanumeric_NullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.IsAlphanumericForce(data));
        }

        #endregion

        #region IsNumeric

        [Fact]
        public void IsNumeric_DecimalValue_OK()
        {
            var data = "99.5";

            bool result = instance.IsNumeric(data);

            Assert.True(result);
        }

        [Fact]
        public void IsNumeric_NotDecimalValue_OK()
        {
            var data = "99";

            bool result = instance.IsNumeric(data);

            Assert.True(result);
        }


        [Fact]
        public void IsNumeric_NotNumericParameter_OK()
        {
            var data = "no date";

            bool result = instance.IsNumeric(data);

            Assert.False(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void IsNumeric_NullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.IsNumeric(data));
        }

        #endregion

        #region IsArray

        [Fact]
        public void IsArray_ParameterWithComasAndWithoutCharacterSaver_OK()
        {
            var data = "one;two;three";

            bool result = instance.IsArray(data);

            Assert.True(result);
        }

        [Fact]
        public void IsArray_ParameterWithComasAndWithCharacterSaver_OK()
        {
            var data = @"one\;two\;three";

            bool result = instance.IsArray(data);

            Assert.False(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void IsArray_NullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.IsArray(data));
        }

        #endregion

        #region IsDateTime

        [Fact]
        public void IsDateTime_DateTimeParameter_OK()
        {
            var data = "25/12/2015";

            bool result = instance.IsDateTime(data);

            Assert.True(result);
        }

        [Fact]
        public void IsDateTime_NotDateTimeParameter_OK()
        {
            var data = "no date";

            bool result = instance.IsDateTime(data);

            Assert.False(result);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void IsDateTime_NullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.IsDateTime(data));
        }

        #endregion

        #region IsBool

        [Fact]
        public void IsBool_BoolParameter_OK()
        {
            var data = "false";

            bool result = instance.IsBool(data);

            Assert.True(result);
        }

        [Fact]
        public void IsBool_NotDateTimeParameter_OK()
        {
            var data = "no bool";

            bool result = instance.IsBool(data);

            Assert.False(result);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void IsBool_NullEmptyWhite_ThrowException(string data)
        {
            Assert.Throws<ArgumentNullException>(() => instance.IsBool(data));
        }

        #endregion


    }
}
