﻿
namespace Petaverse.PersonalProfile;

public class ProfilePageParameter
{
    public string ProfileId { get; set; }
    public string? AvatarUrl { get; set; }
    public string? OrgPicUrl { get; set; }
    public bool IsIncludePetInformation { get; set; }
}
