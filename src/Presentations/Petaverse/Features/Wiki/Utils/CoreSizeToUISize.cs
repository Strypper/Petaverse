namespace Petaverse.Wiki;

public static class CoreSizeToUISize
{
    public static Size Convert(BreedSize size)
    {
        return size switch
        {
            BreedSize.Tiny => Size.Tiny,
            BreedSize.Small => Size.Small,
            BreedSize.Medium => Size.Medium,
            BreedSize.MediumLarge => Size.MediumLarge,
            BreedSize.Large => Size.Large,
            _ => throw new NotImplementedException()
        };
    }
}
