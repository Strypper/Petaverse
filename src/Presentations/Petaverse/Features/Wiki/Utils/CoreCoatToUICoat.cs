namespace Petaverse.Wiki;

public static class CoreCoatToUICoat
{
    public static Coat Convert(this UWP.Core.Coat coat)
    {
        return coat switch
        {
            UWP.Core.Coat.None => Coat.None,
            UWP.Core.Coat.Short => Coat.Short,
            UWP.Core.Coat.Medium => Coat.Medium,
            UWP.Core.Coat.Long => Coat.Long,
            _ => throw new NotImplementedException()
        };
    }
}
