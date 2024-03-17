namespace Petaverse.UWP.LogicProvider.Offline;

public class FaunaService : IFaunaService
{
    #region [ CTor ]

    public FaunaService()
    {

    }
    #endregion

    #region [ Methods ]

    public Task<IEnumerable<Species>> GetSpeciesListAsync()
    {
        var catBreed = GetBreedsList();
        var species = new List<Species> {
            new() {
                Id = "1",
                Name = "Cats",
                Icon = "CatIcon",
                Color = "#ffb900",
                Breeds = new(catBreed),
                Description = new Faker().Lorem.Paragraph(),
                CreatedOn = new Faker().Date.Past(),
                LastUpdatedOn = new Faker().Date.Past(),
            },
            new() {
                Id = "2",
                Name = "Dogs",
                Icon = "DogIcon",
                Color = "#ffd679",
                Description = new Faker().Lorem.Paragraph(),
                CreatedOn = new Faker().Date.Past(),
                LastUpdatedOn = new Faker().Date.Past(),
                //Breeds = DemoBreedData.GetBreedsList()
            },
            new() {
                Id = "3",
                Name = "Fishes",
                Icon = "FishIcon",
                Color = "#00bcf2",
                Description = new Faker().Lorem.Paragraph(),
                CreatedOn = new Faker().Date.Past(),
                LastUpdatedOn = new Faker().Date.Past(),
                //Breeds = DemoBreedData.GetBreedsList()
            },
            new() {
                Id = "4",
                Name = "Birds",
                Icon = "BirdIcon",
                Color = "#ca0b4a",
                Description = new Faker().Lorem.Paragraph(),
                CreatedOn = new Faker().Date.Past(),
                LastUpdatedOn = new Faker().Date.Past(),
                //Breeds = DemoBreedData.GetBreedsList()
            }
        };
        return Task.FromResult(species.AsEnumerable());
    }
    #endregion

    #region [ Private Methods ]

    public static IEnumerable<Breed> GetBreedsList()
    {
        var breeds = new List<Breed>();
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "Abyssinian Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/AbyssinianCat.png",
            Coat = Coat.Medium,
            Energy = Energy.Energetic,
            Shedding = Shedding.Medium,
            Size = BreedSize.Medium,
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "American Short Hair Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/AmericanShortHairCat.png",
            Coat = Coat.Short,
            Energy = Energy.Energetic,
            Shedding = Shedding.Minimal,
            Size = BreedSize.Medium,
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "American Bobtail Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/AmericanBobtailCatBreed.png",
            Coat = Coat.Long,
            Energy = Energy.Medium,
            Shedding = Shedding.Heavy,
            Size = BreedSize.Medium,
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "Birman Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/BirmanCatBreed.png",
            Coat = Coat.Long,
            Energy = Energy.Medium,
            Shedding = Shedding.Heavy,
            Size = BreedSize.Medium,
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "Bombay Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/BombayCat.png",
            Coat = Coat.Medium,
            Energy = Energy.Hunter,
            Shedding = Shedding.Minimal,
            Size = BreedSize.Medium,
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "British Shorthair Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/BritishShorthairCatBreed.png",
            Coat = Coat.Short,
            Energy = Energy.Hunter,
            Shedding = Shedding.Minimal,
            Size = BreedSize.Large,
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "Chartreux Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/ChartreuxCatBreed.png",
            Coat = Coat.Long,
            Energy = Energy.Medium,
            Shedding = Shedding.Heavy,
            Size = BreedSize.Large,
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "Himalayan Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/HimalayanCat.png",
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "Selkirk Rex Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/SelkirkRexCatBreed.png",
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "Persian Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/PersianCatBreed.png",
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "Norwegian Forest Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/NorwegianForestCatBreed.png",
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "LaPerm Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/ChartreuxCatBreed.png",
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        breeds.Add(new()
        {
            Id = new Guid().ToString(),
            SpeciesId = 1,
            Name = "Turkish Angora Cat",
            ImageUrl = "ms-appx:///Assets/Breeds/LaPermCat.png",
            MinimumSize = new Random().Next(1, 4),
            MaximumSize = new Random().Next(5, 9),
            MinimumWeight = new Random().Next(10, 12),
            MaximumWeight = new Random().Next(20, 25),
            MinimumLifeSpan = new Random().Next(5, 6),
            MaximumLifeSpan = new Random().Next(15, 20),
            CreatedOn = new Faker().Date.Past(),
            LastUpdatedOn = new Faker().Date.Past(),
        });
        return breeds;
    }
    #endregion
}
