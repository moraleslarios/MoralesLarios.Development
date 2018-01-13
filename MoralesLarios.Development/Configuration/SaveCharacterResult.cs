namespace MoralesLarios.Development
{
    public class SaveCharacterResult
    {
        public bool HasCharSaver { get; internal set; }
        public string OriginalText { get; internal set; }
        public string TextSaved { get; internal set; }
        public string TextSavedWithoutCharacterSaver { get; internal set; }
    }
}