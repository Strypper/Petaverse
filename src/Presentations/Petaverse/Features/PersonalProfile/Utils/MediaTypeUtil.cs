namespace Petaverse.PersonalProfile;

public static class MediaTypeUtil
{
    public static MediaType MapCoreToPersonalProfile(UWP.Core.MediaType coreMediaType)
    {
        switch (coreMediaType)
        {
            case UWP.Core.MediaType.Video:
                return MediaType.Video;
            case UWP.Core.MediaType.Photo:
                return MediaType.Photo;
            case UWP.Core.MediaType.Avatar:
                return MediaType.Avatar;
            default:
                throw new ArgumentException("Unsupported core media type.");
        }
    }
}
