namespace Petaverse.Wiki;

public static class CoreEnergyToUIEnergy
{
    public static Energy Convert(this UWP.Core.Energy energy)
    {
        return energy switch
        {
            UWP.Core.Energy.Low => Energy.Low,
            UWP.Core.Energy.Medium => Energy.Medium,
            UWP.Core.Energy.Energetic => Energy.Energetic,
            UWP.Core.Energy.Hunter => Energy.Hunter,
            _ => throw new NotImplementedException()
        };
    }
}
