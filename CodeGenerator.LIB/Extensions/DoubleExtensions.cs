namespace CodeGenerator.LIB.Extensions;

public static class DoubleExtensions
{
    public static double Map(this double value, 
                             double startFrom,
                             double endFrom, 
                             double startTo,
                             double endTo)
    {
        return startTo + (endTo - startTo) * ((value - startFrom) / (endFrom - startFrom));
    }
}
