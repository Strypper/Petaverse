namespace Petaverse.UWP.LogicProvider.Offline;

public class FosterCenterService : IFosterCenterService
{
    #region [ Fields ]

    private readonly IFaunaService faunaService;
    #endregion

    #region [ CTor ]

    public FosterCenterService(IFaunaService faunaService)
    {
        this.faunaService = faunaService;
    }
    #endregion


    #region [ Methods ]

    public Task<FosterCenter> GetFosterCenterByIdAsync(string Id)
    {
        throw new NotImplementedException();
    }
    //public Task<FosterCenter> GetFosterCenterByIdAsync(string Id)
    //{
    //    var fosterCenter = new FosterCenter
    //    {
    //        Id = Guid.NewGuid().ToString(),
    //        Name = "Fake Foster Center",
    //        Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo1.jpg",
    //        IsUserFollowing = true, // You can set this based on your requirement
    //        Address = "123 Fake Street, Faketown",
    //        Rating = 4.2, // Set your desired rating
    //        Description = "This is a fake foster center for demonstration purposes.",
    //        CoverImages = new List<PetaverseMedia>
    //    {
    //        new PetaverseMedia
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            MediaName = "Cover Image 1",
    //            MediaUrl = "ms-appx:///Assets/Mocks/HomePage/TitleDemo1.jpg",
    //            TimeUpload = DateTime.Now.AddDays(-10),
    //            Type = MediaType.Photo,
    //            LocalImage = null
    //        },
    //        // Add more cover images as needed
    //    },
    //        Members = new List<FosterCenterMember>
    //    {
    //        new FosterCenterMember
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            UserName = "FakeAdmin",
    //            ProfilePicUrl = "ms-appx:///Assets/Logos/Petaverse.png",
    //            RoleName = "Admin"
    //        },
    //        // Add more members as needed
    //    },
    //        Animals = new List<Animal>
    //    {
    //        new Animal
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            Name = "FakeCat",
    //            PetAvatar = new PetaverseMedia
    //            {
    //                Id = Guid.NewGuid().ToString(),
    //                MediaUrl = "ms-appx:///Assets/Logos/Petaverse.png"
    //            }
    //        },
    //        // Add more animals as needed
    //    },
    //        Tags = new List<FosterCenterTag>
    //    {
    //        new FosterCenterTag
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            TagName = "FakeTag1",
    //            TagColorHex = "#FF5733"
    //        },
    //        new FosterCenterTag
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            TagName = "FakeTag2",
    //            TagColorHex = "#0088FF"
    //        },
    //        // Add more tags as needed
    //    },
    //    };

    //    return Task.FromResult(fosterCenter);
    //}
    #endregion
}
