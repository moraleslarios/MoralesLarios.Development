using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MoralesLarios.CodeComun.Helper;

namespace MoralesLarios.CodeComun.Tests.Helper
{
    public class ExtensionsTests
    {
        
        [Theory]
        [InlineData(8, true)]
        [InlineData("aa", false)]
        [InlineData(true, false)]
        public void IsNumber_GeneralCases_OK(object obj, bool expected)
        {
            bool result = Extensions.IsNumeric(obj);

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData("25/12/2017", true)]
        [InlineData("14/14/2018", false)]
        [InlineData(true, false)]
        public void IsDateTime_GeneralCases_OK(object obj, bool expected)
        {
            bool result = Extensions.IsDateTime(obj);

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData("25/12/2017", false)]
        [InlineData(false , true)]
        [InlineData(true, true)]
        public void IsBool_GeneralCases_OK(object obj, bool expected)
        {
            bool result = Extensions.IsBool(obj);

            Assert.Equal(result, expected);
        }

    }
}
