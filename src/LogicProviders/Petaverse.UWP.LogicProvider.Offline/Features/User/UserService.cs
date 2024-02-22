namespace Petaverse.UWP.LogicProvider.Offline;

public class UserService : IUserService
{
    #region [ Fields ]


    private readonly IFaunaService faunaService;
    #endregion

    #region [ CTors ]
    public UserService(IFaunaService faunaService)
    {
        this.faunaService = faunaService;
    }
    #endregion

    #region [ Methods ]

    #endregion
    public Task<User> GetById(string id, UserGetByIdSetting? setting)
    {
        throw new NotImplementedException();
    }

    //public async Task<User> GetById(string id, UserGetByIdSetting? setting)
    //{
    //    var breedList = new List<Breed>
    //{
    //    new Breed { SpeciesId = 1, Name = "Siamese", Description = "Siamese Cat", ImageUrl = "https://fake-url.com/siamese.jpg", MinimumSize = 5, MaximumSize = 15, MinimumWeight = 2, MaximumWeight = 8, MinimumLifeSpan = 10, MaximumLifeSpan = 18, Colors = "Brown", Animals = new ObservableCollection<Animal>() },
    //    // Add more breeds as needed
    //};

    //    var animalPhotos = new List<PetaverseMedia>
    //{
    //    new PetaverseMedia { Id = "1", MediaName = "Photo 1", TimeUpload = DateTime.Now.AddMonths(-2), Type = MediaType.Photo, MediaUrl = "https://fake-url.com/photo1.jpg" },
    //    // Add more animal photos as needed
    //};

    //    var userPets = new List<Animal>
    //{
    //    new Animal
    //    {
    //        Name = "FakePet",
    //        Bio = "This is a fake pet for demonstration purposes.",
    //        SixDigitCode = "123456",
    //        PetColors = "#ffc225",
    //        Gender = true,
    //        DateOfBirth = DateTime.Now.AddYears(-3),
    //        Breed = breedList[0],
    //        PetAvatar = new PetaverseMedia { Id = "2", MediaName = "Avatar", TimeUpload = DateTime.Now.AddMonths(-1), Type = MediaType.Photo, MediaUrl = "https://fake-url.com/avatar.jpg" },
    //        PetPhotos = new ObservableCollection<PetaverseMedia>(){}
    //    },
    //    // Add more pets as needed
    //};

    //    var isSettingNull = setting is null;
    //    var isIncludePetInformation = setting is null ? false : setting.IsIncludePetInformation;

    //    var userInfo = new User
    //    {
    //        Id = Guid.NewGuid().ToString(),
    //        UserName = "FakeUser",
    //        FirstName = "John",
    //        MiddleName = "Doe",
    //        LastName = "Smith",
    //        Email = "fakeuser@example.com",
    //        Gender = true,
    //        PhoneNumber = "123-456-7890",
    //        DateOfBirth = DateTime.Now.AddYears(-25),
    //        ProfilePicUrl = "https://fake-url.com/profile-pic.jpg",
    //        Pets = new ObservableCollection<Animal>()
    //    };

    //    return userInfo;
    //}
}
