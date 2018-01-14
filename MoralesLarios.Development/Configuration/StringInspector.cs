using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoralesLarios.Development.Helper;

namespace MoralesLarios.Development.Configuration
{
    internal class StringInspector : IStringInspector
    {
        private ISaveCharacterManager saveCharacterManager;

        public const char splitCharacter = ';';

        public StringInspector(ISaveCharacterManager saveCharacterManager)
        {
            this.saveCharacterManager = saveCharacterManager;
        }

        public bool IsAlphanumericForce(string data)
        {
            ParameterValidator.ValidateString(data, nameof(data));

            if (data.Length <= 2) return false;

            bool result = data.First().ToString() == "'" && data.Last().ToString() == "'";

            return result;
        }

        public bool IsArray(string data)
        {
            ParameterValidator.ValidateString(data, nameof(data));

            string textToValidate = saveCharacterManager.SaveComas(data).TextSavedWithoutCharacterSaver;

            bool result = textToValidate.Contains(splitCharacter.ToString());

            return result;
        }

        public bool IsNumeric(string data)
        {
            ParameterValidator.ValidateString(data, nameof(data));

            var result = data.IsNumeric();

            return result;
        }

        public bool IsDateTime(string data)
        {
            ParameterValidator.ValidateString(data, nameof(data));

            var result = data.IsDateTime();

            return result;
        }

        public bool IsBool(string data)
        {
            ParameterValidator.ValidateString(data, nameof(data));

            var result = data.IsBool();

            return result;
        }
    }
}
