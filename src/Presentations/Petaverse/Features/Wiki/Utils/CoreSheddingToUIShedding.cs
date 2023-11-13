namespace Petaverse.Wiki;

public static class CoreSheddingToUIShedding
{
    public static Shedding Convert(this UWP.Core.Shedding shedding)
    {
        return shedding switch
        {
            UWP.Core.Shedding.None => Shedding.None,
            UWP.Core.Shedding.Minimal => Shedding.Minimal,
            UWP.Core.Shedding.Medium => Shedding.Medium,
            UWP.Core.Shedding.Heavy => Shedding.Heavy,
            _ => throw new NotImplementedException()
        };
    }
}
