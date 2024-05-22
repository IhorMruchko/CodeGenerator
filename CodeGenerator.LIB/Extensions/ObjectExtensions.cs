using CodeGenerator.LIB.Utils.Parsing;

namespace CodeGenerator.LIB.Extensions;

public static class ObjectExtensions
{
    public static ParameterParser ToParser(this object[]? source)
    {
        return new ParameterParser(source);
    }

    public static ParameterParser ToParser(this object? source)
    {
        return source is object[] src
            ? new ParameterParser(src)
            : new ParameterParser(source);
    }
}
