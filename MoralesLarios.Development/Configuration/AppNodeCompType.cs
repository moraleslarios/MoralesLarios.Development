using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoralesLarios.CodeComun;

namespace MoralesLarios.Development.Configuration
{
    internal class AppNodeCompType : IAppNodeCompType
    {
        private IStringInspector stringInspector;

        public AppNodeCompType(IStringInspector stringInspector)
        {
            this.stringInspector = stringInspector;
        }

        public DataType DecodeType(string data)
        {
            ParameterValidator.ValidateString(data, nameof(data));

            var isArray = stringInspector.IsArray(data);

            var result = isArray ? DecodeTypeArray(data) : DecodeTypeSimple(data);

            return result;
        }

        public DataType DecodeTypeArray(string data)
        {
            ParameterValidator.ValidateString(data, nameof(data));

            var newData = data.Replace("[", string.Empty).Replace("]", string.Empty);

            var array = newData.Split(';');

            var simpleResult = DecodeTypeSimple(array.First());

            var result = simpleResult + 4;

            return result;
        }

        public DataType DecodeTypeSimple(string data)
        {
            ParameterValidator.ValidateString(data, nameof(data));

            if (stringInspector.IsAlphanumericForce(data)) return DataType.Alphanumeric;

            if (stringInspector.IsNumeric(data)) return DataType.Numeric;

            if (stringInspector.IsDateTime(data)) return DataType.DateTime;

            if (stringInspector.IsBool(data)) return DataType.Bool;

            return DataType.Alphanumeric;
        }


        //private void CompTypeDataItemsArray(string[] items, DataType dataType)
        //{
        //    ParameterValidator.ValidateEnumerableString(items, nameof(items));

        //    foreach (var item in items)
        //    {
        //        var dataTypeItem = DecodeTypeSimple(item);

        //        if(dataTypeItem != DataType) throw new InvalidOperationException($"")
        //    }
        //}




    }
}
