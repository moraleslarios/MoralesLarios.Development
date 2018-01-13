using MoralesLarios.Development.Configuration;

namespace MoralesLarios.Development.Reflection
{
    public interface IMLActivator
    {
        object CreateInstance(string value, DataType dataType);
        object CreateInstanceSimple(string value, DataType dataType);
        object CreateInstanceArray(string value, DataType dataType);
    }
}