namespace MoralesLarios.Development
{
    using System;
    using MoralesLarios.CodeComun;




    public class SaveCharacterManager : ISaveCharacterManager
    {
        private readonly char _characterSaver;

        private const char splitChar = ';';

        public SaveCharacterManager(Char characterSaver = '\\')
        {
            _characterSaver = characterSaver;
        }

        public SaveCharacterResult SaveComas(string textToSaveCharacter)
        {
            ParameterValidator.ValidateString(textToSaveCharacter, nameof(textToSaveCharacter));

            var characterSaveWithSplit = $"{_characterSaver.ToString()}{splitChar.ToString()}";

            var result = new SaveCharacterResult
            {
                OriginalText = textToSaveCharacter
            };

            if (textToSaveCharacter.Contains(characterSaveWithSplit))
            {
                result.HasCharSaver                   = true;
                result.TextSaved                      = textToSaveCharacter.Replace(characterSaveWithSplit, splitChar.ToString());
                result.TextSavedWithoutCharacterSaver = textToSaveCharacter.Replace(characterSaveWithSplit, string.Empty);
            }
            else
            {
                result.HasCharSaver                   = false;
                result.TextSaved                      = textToSaveCharacter;
                result.TextSavedWithoutCharacterSaver = textToSaveCharacter;
            }

            return result;
        }
    }
}