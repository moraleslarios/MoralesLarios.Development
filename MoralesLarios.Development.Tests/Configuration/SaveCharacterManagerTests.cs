using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MoralesLarios.Development.Configuration;
using MoralesLarios.Generics;

namespace MoralesLarios.Development.Tests.Configuration
{
    public class SaveCharacterManagerTests
    {

        private ISaveCharacterManager instance;


        public SaveCharacterManagerTests()
        {
            instance = new SaveCharacterManager();
        }


        [Fact]
        public void SaveComas_withComasSaves_OK()
        {
            string textToSaveCharacter            = @"hello\; I am ml";
            string textSaved                      = @"hello; I am ml";
            string textSavedWithoutCharacterSaver = @"hello I am ml";

            SaveCharacterResult expected = new SaveCharacterResult
            {
                HasCharSaver                   = true,
                OriginalText                   = textToSaveCharacter,
                TextSaved                      = textSaved,
                TextSavedWithoutCharacterSaver = textSavedWithoutCharacterSaver
            };

            SaveCharacterResult result = instance.SaveComas(textToSaveCharacter);

            GenericEqualityComparer<SaveCharacterResult> comparer
                = new GenericEqualityComparer<SaveCharacterResult>(a => new { a.HasCharSaver, a.OriginalText, a.TextSaved });

            Assert.Equal(expected, result, comparer);
        }

        [Fact]
        public void SaveComas_withOutComasSaves_OK()
        {
            string textToSaveCharacter            = @"hello; I am ml";
            string textSaved                      = textToSaveCharacter;
            string textSavedWithoutCharacterSaver = textToSaveCharacter;

            SaveCharacterResult expected = new SaveCharacterResult
            {
                HasCharSaver                   = false,
                OriginalText                   = textToSaveCharacter,
                TextSaved                      = textSaved,
                TextSavedWithoutCharacterSaver = textSavedWithoutCharacterSaver
            };

            SaveCharacterResult result = instance.SaveComas(textToSaveCharacter);

            GenericEqualityComparer<SaveCharacterResult> comparer
                = new GenericEqualityComparer<SaveCharacterResult>(a => new { a.HasCharSaver, a.OriginalText, a.TextSaved, a.TextSavedWithoutCharacterSaver });

            Assert.Equal(expected, result, comparer);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void SaveComas_NullEmptyWhite_ThrowException(string parameter)
        {
            Assert.Throws<ArgumentNullException>(() => instance.SaveComas(parameter));
        }


    }
}
