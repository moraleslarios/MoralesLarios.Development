using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoralesLarios.Development.Configuration;
using MoralesLarios.CodeComun;

namespace MoralesLarios.Development.Reflection
{
    public class MLActivator : IMLActivator
    {
        public object CreateInstance(string value, DataType dataType)
        {
            ParameterValidator.ValidateString(value, nameof(value));

            var result = (int)dataType < 4 ? CreateInstanceSimple(value, dataType) : CreateInstanceArray(value, dataType);

            return result;
        }

        public object CreateInstanceArray(string value, DataType dataType)
        {
            ParameterValidator.ValidateString(value, nameof(value));

            if ((int)dataType < 4) throw new ArgumentException($"The parameter {nameof(dataType)} isn't a array type", nameof(dataType));

            switch (dataType)
            {
                case DataType.ArrayAlphanumeric  : return CreateArray(value, dataType).OfType<string>  ().ToArray();
                case DataType.ArrayNumeric       : return CreateArray(value, dataType).OfType<decimal> ().ToArray();
                case DataType.ArrayDateTime      : return CreateArray(value, dataType).OfType<DateTime>().ToArray();
                case DataType.ArrayBool          : return CreateArray(value, dataType).OfType<bool>    ().ToArray();
                default                          : return value;
            }
        }

        public object CreateInstanceSimple(string value, DataType dataType)
        {
            ParameterValidator.ValidateString(value, nameof(value));

            if ((int)dataType > 3) throw new ArgumentException($"The parameter {nameof(dataType)} isn't a simple type", nameof(dataType));

            switch (dataType)
            {
                case DataType.Alphanumeric : return value;
                case DataType.Numeric      : return decimal.Parse(value);
                case DataType.DateTime     : return DateTime.Parse(value);
                case DataType.Bool         : return bool.Parse(value);
                default                    : return value;
            }
        }


        private IEnumerable<object> CreateArray(string value, DataType dataType)
        {
            ParameterValidator.ValidateString(value, nameof(value));

            var items = value.Split(';');

            var dataTypeItem = dataType - 4;

            foreach (var item in items)
            {
                var itemValue = CreateInstanceSimple(item, dataTypeItem);

                yield return itemValue;
            }
        }

    }
}
