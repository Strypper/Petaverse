namespace Petaverse.UWP.LogicProvider.Offline.InMemoryData;

public static class InMemoryListData
{
    #region [ Fields ]
    private readonly static string _loremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
    #endregion

    #region [ Public Static Properties - In Memory List ]
    public static List<Species> AllSpecies { get; private set; } = new List<Species>();

    public static List<Breed> AllCatBreeds { get; private set; } = new List<Breed>();

    public static List<Breed> AllDogBreeds { get; private set; } = new List<Breed>();

    public static List<Animal> AllCats { get; private set; } = new List<Animal>();

    public static List<Animal> AllDogs { get; private set; } = new List<Animal>();
    #endregion

    #region [ Public Methods - Initialize Data ]
    public static void InitializeData() {
        AllSpecies = InitializeSpecies();
        var catSpecies = AllSpecies.FirstOrDefault(x => x.Name.Contains("Cats", StringComparison.InvariantCultureIgnoreCase));

        AllCatBreeds = InitializeCatBreeds(catSpecies);
        catSpecies.Breeds = AllCatBreeds;
        var catBreed = AllCatBreeds.First();
        AllCats.AddRange(InitializeCats(catBreed));
        AllCats.AddRange(InitializeCats(AllCatBreeds.Last()));

        var dogSpecies = AllSpecies.FirstOrDefault(x => x.Name.Contains("Dogs", StringComparison.InvariantCultureIgnoreCase));
        AllDogBreeds = InitializeDogBreeds(dogSpecies);
        dogSpecies.Breeds = AllDogBreeds;
        AllDogs.AddRange(InitializeDogs(AllDogBreeds.First()));
        AllDogs.AddRange(InitializeDogs(AllDogBreeds.Last()));
    }
    #endregion

    #region [ Private Methods - Initialize Data ]
    private static List<Species> InitializeSpecies() {
        var species = new List<Species> {
            new() {
                Id = "1",
                Name = "Cats",
                Icon = "CatIcon",
                Color = "#ffb900",
                Description = _loremIpsum,
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = "2",
                Name = "Dogs",
                Icon = "DogIcon",
                Color = "#ffd679",
                Description = _loremIpsum,
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
                //Breeds = DemoBreedData.GetBreedsList()
            },
            new() {
                Id = "3",
                Name = "Fishes",
                Icon = "FishIcon",
                Color = "#00bcf2",
                Description = _loremIpsum,
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
                //Breeds = DemoBreedData.GetBreedsList()
            },
            new() {
                Id = "4",
                Name = "Birds",
                Icon = "BirdIcon",
                Color = "#ca0b4a",
                Description = _loremIpsum,
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
                //Breeds = DemoBreedData.GetBreedsList()
            }
        };
        return species;
    }

    private static List<Breed> InitializeCatBreeds(Species catSpecies) {
        var catBreds = new List<Breed> {
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
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
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
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
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
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
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
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
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
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
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
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
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
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
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
                Name = "Himalayan Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/HimalayanCat.png",
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                MinimumWeight = new Random().Next(10, 12),
                MaximumWeight = new Random().Next(20, 25),
                MinimumLifeSpan = new Random().Next(5, 6),
                MaximumLifeSpan = new Random().Next(15, 20),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
                Name = "Selkirk Rex Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/SelkirkRexCatBreed.png",
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                MinimumWeight = new Random().Next(10, 12),
                MaximumWeight = new Random().Next(20, 25),
                MinimumLifeSpan = new Random().Next(5, 6),
                MaximumLifeSpan = new Random().Next(15, 20),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
                Name = "Persian Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/PersianCatBreed.png",
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                MinimumWeight = new Random().Next(10, 12),
                MaximumWeight = new Random().Next(20, 25),
                MinimumLifeSpan = new Random().Next(5, 6),
                MaximumLifeSpan = new Random().Next(15, 20),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
                Name = "Norwegian Forest Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/NorwegianForestCatBreed.png",
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                MinimumWeight = new Random().Next(10, 12),
                MaximumWeight = new Random().Next(20, 25),
                MinimumLifeSpan = new Random().Next(5, 6),
                MaximumLifeSpan = new Random().Next(15, 20),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
                Name = "LaPerm Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/ChartreuxCatBreed.png",
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                MinimumWeight = new Random().Next(10, 12),
                MaximumWeight = new Random().Next(20, 25),
                MinimumLifeSpan = new Random().Next(5, 6),
                MaximumLifeSpan = new Random().Next(15, 20),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = new Guid().ToString(),
                SpeciesId = int.Parse(catSpecies.Id),
                Name = "Turkish Angora Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/LaPermCat.png",
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                MinimumWeight = new Random().Next(10, 12),
                MaximumWeight = new Random().Next(20, 25),
                MinimumLifeSpan = new Random().Next(5, 6),
                MaximumLifeSpan = new Random().Next(15, 20),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            }
        };

        return catBreds;
    }

    private static List<Breed> InitializeDogBreeds(Species dogSpecies) {
        var dogBreeds = new List<Breed>() {
            new() {
                Name = "Labrador Retriever",
                Description = "Friendly, outgoing, and devoted. Labrador Retrievers are great family pets.",
                ImageUrl = "labrador.jpg",
                MinimumWeight = 55,
                MaximumWeight = 80,
                MinimumLifeSpan = 10,
                MaximumLifeSpan = 12,
                Colors = "Yellow, Black, Chocolate",
                SpeciesId = int.Parse(dogSpecies.Id),
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Name = "German Shepherd",
                Description = "Confident, courageous, and smart. German Shepherds are versatile and well-suited for various tasks.",
                ImageUrl = "german_shepherd.jpg",
                MinimumWeight = 50,
                MaximumWeight = 90,
                MinimumLifeSpan = 9,
                MaximumLifeSpan = 13,
                Colors = "Sable, Black and Tan",
                SpeciesId = int.Parse(dogSpecies.Id),
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Name = "Golden Retriever",
                Description = "Friendly, intelligent, and tolerant. Golden Retrievers are great companions and love to please.",
                ImageUrl = "golden_retriever.jpg",
                MinimumWeight = 55,
                MaximumWeight = 75,
                MinimumLifeSpan = 10,
                MaximumLifeSpan = 12,
                Colors = "Golden",
                SpeciesId = int.Parse(dogSpecies.Id),
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Name = "Siberian Husky",
                Description = "Loyal, mischievous, and outgoing. Siberian Huskies are known for their striking appearance and endurance.",
                ImageUrl = "husky.jpg",
                MinimumWeight = 35,
                MaximumWeight = 60,
                MinimumLifeSpan = 12,
                MaximumLifeSpan = 14,
                Colors = "Black, White, Gray",
                SpeciesId = int.Parse(dogSpecies.Id),
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Name = "Chó Cỏ",
                Description = "Chó Cỏ, also known as the Vietnamese Hound or Vietnamese Feral Dog, is a breed native to Vietnam. It is known for its resilience, adaptability, and loyalty.",
                ImageUrl = "cho_co.jpg",
                MinimumWeight = 15,
                MaximumWeight = 25,
                MinimumLifeSpan = 12,
                MaximumLifeSpan = 15,
                Colors = "Various, often brown or black with white markings",
                SpeciesId = int.Parse(dogSpecies.Id),
                MinimumSize = new Random().Next(1, 4),
                MaximumSize = new Random().Next(5, 9),
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
        };

        return dogBreeds;
    }

    private static List<Animal> InitializeCats(Breed catBreed) {
        var list = new List<Animal>() {
            new() {
                Breed = catBreed,
                Name = "Max",
                Bio = "A playful cat",
                SixDigitCode = "654321",
                PetColors = "Brown",
                Gender = false,
                DateOfBirth = new DateTime(2018, 8, 20),
                Age = new Random().NextDouble() * 4
            },
            new() {
                Breed = catBreed,
                Name = "Bella",
                Bio = "A cuddly cat",
                SixDigitCode = "987654",
                PetColors = "Gray",
                Gender = null,
                DateOfBirth = null,
                Age = new Random().NextDouble() * 4,
            },
            new() {
                Breed = catBreed,
                Name = "Rocky",
                Bio = "A loyal cat",
                SixDigitCode = "789012",
                PetColors = "Black and White",
                Gender = true,
                DateOfBirth = new DateTime(2017, 11, 30),
                Age = new Random().NextDouble() * 4,
            },
        };



        return list;
    }

    private static List<Animal> InitializeDogs(Breed dogBreed) {
        var dogs = new List<Animal> {
            new() {
                Breed = dogBreed,
                Name = "Max",
                Bio = "A playful dog",
                SixDigitCode = "654321",
                PetColors = "Brown",
                Gender = false,
                DateOfBirth = new DateTime(2018, 8, 20),
                Age = new Random().NextDouble() * 4
            },
            new() {
                Breed = dogBreed,
                Name = "Bella",
                Bio = "A cuddly dog",
                SixDigitCode = "987654",
                PetColors = "Gray",
                Gender = null,
                DateOfBirth = null,
                Age = new Random().NextDouble() * 4,
            },
            new() {
                Breed = dogBreed,
                Name = "Rocky",
                Bio = "A loyal dog",
                SixDigitCode = "789012",
                PetColors = "Black and White",
                Gender = true,
                DateOfBirth = new DateTime(2017, 11, 30),
                Age = new Random().NextDouble() * 4,
            },
            new() {
                Breed = dogBreed,
                Name = "Snowball",
                Bio = "An adventurous dog",
                SixDigitCode = "345678",
                PetColors = "White",
                Gender = false,
                DateOfBirth = new DateTime(2019, 3, 5),
                Age = new Random().NextDouble() * 4,
            },
            new() {
                Breed = dogBreed,
                Name = "Daisy",
                Bio = "A gentle dog",
                SixDigitCode = "234567",
                PetColors = "Brown and White",
                Gender = true,
                DateOfBirth = new DateTime(2017, 11, 30),
                Age = new Random().NextDouble() * 4,
            },
            new() {
                Breed = dogBreed,
                Name = "Buddy",
                Bio = "A friendly dog",
                SixDigitCode = "901234",
                PetColors = "Golden",
                Gender = true,
                DateOfBirth = new DateTime(2019, 7, 8),
                Age = 3.1,
            }
        };

        return dogs;
    }
    #endregion
}
