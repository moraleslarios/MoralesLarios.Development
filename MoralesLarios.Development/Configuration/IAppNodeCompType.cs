namespace MoralesLarios.Development.Configuration
{
    public interface IAppNodeCompType
    {
        DataType DecodeType(string data);
        DataType DecodeTypeSimple(string data);
        DataType DecodeTypeArray(string data);
    }
}