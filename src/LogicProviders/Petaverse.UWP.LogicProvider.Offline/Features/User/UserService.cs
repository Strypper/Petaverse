namespace Petaverse.UWP.LogicProvider.Offline;

public class UserService : IUserService
{

    #region [ CTor ]
    public UserService()
    {
        
    }
    #endregion

    #region [ Methods ]

    #endregion
    public Task<User> GetById(string id, UserGetByIdSetting? setting)
    {
        var breedFaker = new Faker<Breed>()
                .RuleFor(b => b.SpeciesId, f => f.Random.Number(1, 10))
                .RuleFor(b => b.Name, f => f.PickRandom("Siamese", "Persian", "Maine Coon", "Ragdoll", "Bengal"))
                .RuleFor(b => b.Description, f => f.Lorem.Sentence())
                .RuleFor(b => b.ImageUrl, f => f.Image.LoremFlickrUrl(200, 200, "Tabby Cat")) 
                .RuleFor(b => b.MinimumSize, f => f.Random.Double(0, 10))
                .RuleFor(b => b.MaximumSize, f => f.Random.Double(10, 100))
                .RuleFor(b => b.MinimumWeight, f => f.Random.Double(0, 10))
                .RuleFor(b => b.MaximumWeight, f => f.Random.Double(10, 100))
                .RuleFor(b => b.MinimumLifeSpan, f => f.Random.Number(1, 10))
                .RuleFor(b => b.MaximumLifeSpan, f => f.Random.Number(10, 20))
                .RuleFor(b => b.Colors, f => f.Commerce.Color())
                .RuleFor(b => b.Animals, new ObservableCollection<Animal>());

        var breedList = breedFaker.Generate(10);

        var animalPhotosFaker = new Faker<PetaverseMedia>()
            .RuleFor(x => x.Id, f => f.UniqueIndex.ToString())
            .RuleFor(x => x.MediaName, f => f.Lorem.Text())
            .RuleFor(x => x.TimeUpload, f => f.Date.Past(18, DateTime.Now.AddYears(-65)))
            .RuleFor(x => x.Type, f => MediaType.Photo)
            .RuleFor(x => x.MediaUrl, f => f.Image.LoremFlickrUrl(350, 400, "Tabby Cat"));

        var animalPhotos = animalPhotosFaker.Generate(200).AsEnumerable();

        var userPetsFaker = new Faker<Animal>()
            .RuleFor(x => x.Name, f => f.Name.FirstName())
            .RuleFor(x => x.Bio, f => f.Lorem.Paragraph())
            .RuleFor(x => x.SixDigitCode, f => f.Random.Number(100000, 999999).ToString())
            .RuleFor(x => x.PetColors, f => f.PickRandom(new List<string>{ "#ffc225", "#404040", "#ffffff" }))
            .RuleFor(x => x.Gender, f => f.PickRandom(new List<bool> { true, false }))
            .RuleFor(x => x.DateOfBirth, f => f.Date.Past(18, DateTime.Now.AddYears(-65)))
            .RuleFor(x => x.Breed, f => f.PickRandom(breedList))
            .RuleFor(x => x.PetAvatar, f => new()
            {
                Id = f.UniqueIndex.ToString(),
                MediaName = f.Lorem.Text(),
                TimeUpload = f.Date.Past(18, DateTime.Now.AddYears(-65)),
                Type = MediaType.Photo,
                MediaUrl = f.Image.LoremFlickrUrl(200, 200, "Tabby Cat")
            })
            .RuleFor(x => x.PetPhotos, f => new(animalPhotos));

        var userPets = userPetsFaker.Generate(5).AsEnumerable();

        var isSettingNull = setting is null;
        var isIncludePetInformation = setting is null ? false : setting.IsIncludePetInformation;

        var userInfo = new Faker<User>()
            .RuleFor(x => x.Id, f => f.UniqueIndex.ToString())
            .RuleFor(x => x.UserName, f => f.Internet.UserName())
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.MiddleName, f => f.Person.LastName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.Email, f => f.Person.Email)
            .RuleFor(x => x.Gender, f => f.PickRandom(new List<bool> { true, false }))
            .RuleFor(x => x.PhoneNumber, f => f.Person.Phone)
            .RuleFor(x => x.DateOfBirth, f => f.Date.Past(18, DateTime.Now.AddYears(-65)))
            .RuleFor(x => x.ProfilePicUrl, f => f.Internet.Avatar())
            .RuleFor(x => x.Pets, f => (isSettingNull || isIncludePetInformation) ? new(userPets) : null);

        return Task.FromResult(userInfo.Generate());
    }
}
