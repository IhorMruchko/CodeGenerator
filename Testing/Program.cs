
Console.WriteLine(Map(22, 0, 85, 0, 60));

static double Map(double value,
                             double startFrom,
                             double endFrom,
                             double startTo,
                             double endTo)
{
    return startTo + (endTo - startTo) * ((value - startFrom) / (endFrom - startFrom));
}