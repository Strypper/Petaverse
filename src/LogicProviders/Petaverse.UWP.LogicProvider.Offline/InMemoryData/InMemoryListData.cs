using System;

namespace Petaverse.UWP.LogicProvider.Offline.InMemoryData;

public static class InMemoryListData
{
    #region [ Fields ]
    private readonly static string _loremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
    #endregion

    #region [ Public Static Properties - In Memory List ]
    public static List<Species> AllSpecies { get; private set; } = new();

    public static List<Breed> AllCatBreeds { get; private set; } = new();

    public static List<Breed> AllDogBreeds { get; private set; } = new();

    public static List<Animal> AllCats { get; private set; } = new();

    public static List<Animal> AllDogs { get; private set; } = new();

    public static List<User> AllUsers { get; private set; } = new();

    public static List<FosterCenterTag> AllFosterCenterTags { get; private set; } = new();

    public static List<FosterCenterMember> AllFosterMembers { get; private set; } = new();

    public static List<FosterCenter> AllFosterCenters { get; private set; } = new();
    #endregion

    #region [ Private Methods - Initialize Data ]
    private static void InitializeData() {
        AllSpecies = InitializeSpecies();

        var catSpecies = AllSpecies.FirstOrDefault(x => x.Name.Contains("Cats", StringComparison.InvariantCultureIgnoreCase));
        AllCatBreeds = InitializeCatBreeds(catSpecies);
        catSpecies.Breeds = AllCatBreeds;
        AllCatBreeds.ForEach(x => {
            var cats = InitializeCats(x);
            x.Animals = new(cats);
            AllCats.AddRange(cats);
        });

        var dogSpecies = AllSpecies.FirstOrDefault(x => x.Name.Contains("Dogs", StringComparison.InvariantCultureIgnoreCase));
        AllDogBreeds = InitializeDogBreeds(dogSpecies);
        dogSpecies.Breeds = AllDogBreeds;
        AllDogBreeds.ForEach(x => {
            var cats = InitializeDogs(x);
            x.Animals = new(cats);
            AllCats.AddRange(cats);
        });

        AllUsers = InitializeUsers();
        AllUsers.ForEach(x => {
            x.Pets.Add(AllCats.ElementAt(new Random().Next(0, AllCats.Count)));
            x.Pets.Add(AllDogs.ElementAt(new Random().Next(0, AllCats.Count)));
        });

        AllFosterCenterTags = InitializeFosterTags();

        AllFosterMembers = InitializeFosterMembers();

        AllFosterCenters = InistializeFosterCenters();
        AllFosterCenters.ForEach(x => {
            x.Tags = new List<FosterCenterTag>(AllFosterCenterTags);

            var randomMemberIndexes = GetRandomUniqueIndices(AllFosterMembers, 3);

            x.Members = new List<FosterCenterMember>(randomMemberIndexes.Select(x => AllFosterMembers.ElementAt(x)));

            x.Animals = new List<Animal>(randomMemberIndexes.Select(x => AllCats.ElementAt(x)).Concat(randomMemberIndexes.Select(x => AllDogs.ElementAt(x))));
        });


    }
    #endregion

    #region [ Public Methods - Reset ]
    public static void CleanAll() {
        AllSpecies = new();
        AllCatBreeds = new();
        AllDogBreeds = new();
        AllCats = new();
        AllDogs = new();
        AllUsers = new();
        AllFosterCenterTags = new();
        AllFosterMembers = new();
        AllFosterCenters = new();
    }

    public static void InitializeAll() {
        CleanAll();
        InitializeData();
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
                Description = "House cats, or domestic cats (Felis catus), are small carnivorous mammals that have been domesticated for thousands of years. They come in various breeds, colors, and coat patterns. Known for their independent yet affectionate nature, they make popular pets worldwide, valued for their companionship and hunting abilities. House cats are characterized by their slender bodies, soft fur, sharp retractable claws, and keen senses. They are adept at controlling pests and form strong bonds with their human caregivers through playful interactions and affectionate behavior.",
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1),
            },
            new() {
                Id = "2",
                Name = "Dogs",
                Icon = "DogIcon",
                Color = "#ffd679",
                Description = "Dogs are domesticated mammals known for their loyalty and companionship with humans. They come in various breeds, sizes, and coat types, each with unique characteristics and temperaments. Dogs are highly social animals, forming strong bonds with their owners and families. They are often trained for various roles, including companionship, working, and service tasks. Dogs are known for their intelligence, trainability, and ability to understand human emotions. They provide comfort, security, and joy to millions of households worldwide.",
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1)
            },
            new() {
                Id = "3",
                Name = "Fishes",
                Icon = "FishIcon",
                Color = "#00bcf2",
                Description = "Pet fishes are aquatic animals commonly kept in home aquariums for their beauty and tranquility. They come in a wide range of species, colors, and sizes, offering diversity in appearance and behavior. Fishes are admired for their graceful movements and vibrant colors, adding aesthetic appeal to any space. They require a suitable habitat with proper water conditions, filtration, and nutrition to thrive. Pet fishes can provide relaxation and stress relief to their owners, creating a peaceful and soothing atmosphere in the home.",
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1)
            },
            new() {
                Id = "4",
                Name = "Birds",
                Icon = "BirdIcon",
                Color = "#ca0b4a",
                Description = "Pet birds are colorful, social companions valued for their intelligence and vocal abilities. They require proper care, including a spacious cage, balanced diet, and interaction for mental stimulation. With their charming personalities and ability to mimic sounds, they bring joy and companionship to their owners.",
                CreatedOn = DateTime.Now.AddYears(-1),
                LastUpdatedOn = DateTime.Now.AddYears(-1)
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
                Id = "1",
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
                Id = "2",
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
                Id = "3",
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
                Id = "4",
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
                Id = "5",
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
        var random = new Random();

        var list = new List<Animal>() {
            new() {
                Breed = catBreed,
                Name = "Max",
                Bio = "A playful cat",
                SixDigitCode = $"{random.Next(100000, 1000000)}",
                PetColors = "Undefined",
                Gender = false,
                DateOfBirth = new DateTime(2018, 8, 20),
                Age = new Random().NextDouble() * 4
            },
            new() {
                Breed = catBreed,
                Name = "Bella",
                Bio = "A cuddly cat",
                SixDigitCode = $"{random.Next(100000, 1000000)}",
                PetColors = "Undefined",
                Gender = null,
                DateOfBirth = null,
                Age = new Random().NextDouble() * 4,
            },
            new() {
                Breed = catBreed,
                Name = "Rocky",
                Bio = "A loyal cat",
                SixDigitCode = $"{random.Next(100000, 1000000)}",
                PetColors = "Undefined",
                Gender = true,
                DateOfBirth = new DateTime(2017, 11, 30),
                Age = new Random().NextDouble() * 4,
            },
        };

        return list;
    }

    private static List<Animal> InitializeDogs(Breed dogBreed) {
        var random = new Random();

        var list = new List<Animal> {
            new() {
                Breed = dogBreed,
                Name = "Max",
                Bio = "A playful dog",
                SixDigitCode = $"{random.Next(100000, 1000000)}",
                PetColors = "Brown",
                Gender = false,
                DateOfBirth = new DateTime(2018, 8, 20),
                Age = new Random().NextDouble() * 4
            },
            new() {
                Breed = dogBreed,
                Name = "Bella",
                Bio = "A cuddly dog",
                SixDigitCode = $"{random.Next(100000, 1000000)}",
                PetColors = "Gray",
                Gender = null,
                DateOfBirth = null,
                Age = new Random().NextDouble() * 4,
            },
            new() {
                Breed = dogBreed,
                Name = "Rocky",
                Bio = "A loyal dog",
                SixDigitCode = $"{random.Next(100000, 1000000)}",
                PetColors = "Black and White",
                Gender = true,
                DateOfBirth = new DateTime(2017, 11, 30),
                Age = new Random().NextDouble() * 4,
            },
            new() {
                Breed = dogBreed,
                Name = "Snowball",
                Bio = "An adventurous dog",
                SixDigitCode = $"{random.Next(100000, 1000000)}",
                PetColors = "White",
                Gender = false,
                DateOfBirth = new DateTime(2019, 3, 5),
                Age = new Random().NextDouble() * 4,
            },
            new() {
                Breed = dogBreed,
                Name = "Daisy",
                Bio = "A gentle dog",
                SixDigitCode = $"{random.Next(100000, 1000000)}",
                PetColors = "Brown and White",
                Gender = true,
                DateOfBirth = new DateTime(2017, 11, 30),
                Age = new Random().NextDouble() * 4,
            },
            new() {
                Breed = dogBreed,
                Name = "Buddy",
                Bio = "A friendly dog",
                SixDigitCode = $"{random.Next(100000, 1000000)}",
                PetColors = "Golden",
                Gender = true,
                DateOfBirth = new DateTime(2019, 7, 8),
                Age = 3.1,
            }
        };

        dogBreed.Animals = new(list);

        return list;
    }

    private static List<User> InitializeUsers() {
        var users = new List<User>
        {
            new() {
                UserName = "john_doe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "+1234567890",
                Gender = true,
                DateOfBirth = new DateTime(1990, 5, 15),
                ProfilePicUrl = "john_doe.jpg"
            },
            new() {
                UserName = "jane_smith",
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "+1987654321",
                Gender = false,
                DateOfBirth = new DateTime(1985, 10, 20),
                ProfilePicUrl = "jane_smith.jpg"
            },
            new() {
                UserName = "alex_jones",
                FirstName = "Alex",
                LastName = "Jones",
                Email = "alex.jones@example.com",
                PhoneNumber = "+1122334455",
                Gender = true,
                DateOfBirth = new DateTime(1988, 8, 8),
                ProfilePicUrl = "alex_jones.jpg"
            },
            new() {
                UserName = "emily_wilson",
                FirstName = "Emily",
                LastName = "Wilson",
                Email = "emily.wilson@example.com",
                PhoneNumber = "+1567890123",
                Gender = false,
                DateOfBirth = new DateTime(1995, 3, 25),
                ProfilePicUrl = "emily_wilson.jpg"
            },
            new() {
                UserName = "sam_brown",
                FirstName = "Sam",
                LastName = "Brown",
                Email = "sam.brown@example.com",
                PhoneNumber = "+1654321876",
                Gender = true,
                DateOfBirth = new DateTime(1983, 12, 10),
                ProfilePicUrl = "sam_brown.jpg"
            },
            new() {
                UserName = "lisa_taylor",
                FirstName = "Lisa",
                LastName = "Taylor",
                Email = "lisa.taylor@example.com",
                PhoneNumber = "+1447890123",
                Gender = false,
                DateOfBirth = new DateTime(1979, 7, 5),
                ProfilePicUrl = "lisa_taylor.jpg"
            },
            new() {
                UserName = "michael_clark",
                FirstName = "Michael",
                LastName = "Clark",
                Email = "michael.clark@example.com",
                PhoneNumber = "+1987654321",
                Gender = true,
                DateOfBirth = new DateTime(1992, 9, 18),
                ProfilePicUrl = "michael_clark.jpg"
            },
            new() {
                UserName = "sophia_evans",
                FirstName = "Sophia",
                LastName = "Evans",
                Email = "sophia.evans@example.com",
                PhoneNumber = "+1876543210",
                Gender = false,
                DateOfBirth = new DateTime(1997, 11, 30),
                ProfilePicUrl = "sophia_evans.jpg"
            },
            new() {
                UserName = "david_thompson",
                FirstName = "David",
                LastName = "Thompson",
                Email = "david.thompson@example.com",
                PhoneNumber = "+1765432987",
                Gender = true,
                DateOfBirth = new DateTime(1980, 4, 12),
                ProfilePicUrl = "david_thompson.jpg"
            },
            new() {
                UserName = "olivia_jackson",
                FirstName = "Olivia",
                LastName = "Jackson",
                Email = "olivia.jackson@example.com",
                PhoneNumber = "+1543219876",
                Gender = false,
                DateOfBirth = new DateTime(1987, 6, 28),
                ProfilePicUrl = "olivia_jackson.jpg"
            }
        };



        return users;
    }

    private static List<FosterCenterTag> InitializeFosterTags() {
        List<FosterCenterTag> fosterCenterTags = new()
        {
            new FosterCenterTag
            {
                Id = "1",
                TagName = "Tag1",
                TagColorHex = "#ff0000"
            },
            new FosterCenterTag
            {
                Id = "2",
                TagName = "Tag2",
                TagColorHex = "#00ff00"
            },
            new FosterCenterTag
            {
                Id = "3",
                TagName = "Tag3",
                TagColorHex = "#0000ff"
            },
            new FosterCenterTag
            {
                Id = "4",
                TagName = "Tag4",
                TagColorHex = "#ffff00"
            },
            new FosterCenterTag
            {
                Id = "5",
                TagName = "Tag5",
                TagColorHex = "#ff00ff"
            },
            new FosterCenterTag
            {
                Id = "6",
                TagName = "Tag6",
                TagColorHex = "#00ffff"
            },
            new FosterCenterTag
            {
                Id = "7",
                TagName = "Tag7",
                TagColorHex = "#808080"
            },
            new FosterCenterTag
            {
                Id = "8",
                TagName = "Tag8",
                TagColorHex = "#800000"
            },
            new FosterCenterTag
            {
                Id = "9",
                TagName = "Tag9",
                TagColorHex = "#008000"
            },
            new FosterCenterTag
            {
                Id = "10",
                TagName = "Tag10",
                TagColorHex = "#000080"
            }
        };

        return fosterCenterTags;
    }

    private static List<FosterCenterMember> InitializeFosterMembers() {
        var fosterCenterMembers = new List<FosterCenterMember>
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user1",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                Gender = true,
                DateOfBirth = new DateTime(1990, 5, 15),
                ProfilePicUrl = "profile1.jpg",
                RoleName = "Role1"
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user2",
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "0987654321",
                Gender = false,
                DateOfBirth = new DateTime(1985, 8, 25),
                ProfilePicUrl = "profile2.jpg",
                RoleName = "Role2"
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user3",
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                PhoneNumber = "1112223333",
                Gender = true,
                DateOfBirth = new DateTime(1995, 10, 5),
                ProfilePicUrl = "profile3.jpg",
                RoleName = "Role3"
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user4",
                FirstName = "David",
                LastName = "Brown",
                Email = "david.brown@example.com",
                PhoneNumber = "4445556666",
                Gender = true,
                DateOfBirth = new DateTime(1980, 4, 12),
                ProfilePicUrl = "profile4.jpg",
                RoleName = "Role4"
            },
            new()
            {Id = Guid.NewGuid().ToString(),
                UserName = "user5",
                FirstName = "Emily",
                LastName = "Anderson",
                Email = "emily.anderson@example.com",
                PhoneNumber = "7778889999",
                Gender = false,
                DateOfBirth = new DateTime(1992, 6, 30),
                ProfilePicUrl = "profile5.jpg",
                RoleName = "Role5"
            },
            new()
            {Id = Guid.NewGuid().ToString(),
                UserName = "user6",
                FirstName = "Michael",
                LastName = "Wilson",
                Email = "michael.wilson@example.com",
                PhoneNumber = "5554443333",
                Gender = true,
                DateOfBirth = new DateTime(1988, 9, 18),
                ProfilePicUrl = "profile6.jpg",
                RoleName = "Role6"
            },
            new()
            {Id = Guid.NewGuid().ToString(),
                UserName = "user7",
                FirstName = "Sophia",
                LastName = "Lee",
                Email = "sophia.lee@example.com",
                PhoneNumber = "2223334444",
                Gender = false,
                DateOfBirth = new DateTime(1975, 11, 8),
                ProfilePicUrl = "profile7.jpg",
                RoleName = "Role7"
            },
            new()
            {Id = Guid.NewGuid().ToString(),
                UserName = "user8",
                FirstName = "Matthew",
                LastName = "Martinez",
                Email = "matthew.martinez@example.com",
                PhoneNumber = "6667778888",
                Gender = true,
                DateOfBirth = new DateTime(1983, 3, 22),
                ProfilePicUrl = "profile8.jpg",
                RoleName = "Role8"
            },
            new()
            {Id = Guid.NewGuid().ToString(),
                UserName = "user9",
                FirstName = "Olivia",
                LastName = "Garcia",
                Email = "olivia.garcia@example.com",
                PhoneNumber = "9998887777",
                Gender = false,
                DateOfBirth = new DateTime(1998, 12, 14),
                ProfilePicUrl = "profile9.jpg",
                RoleName = "Role9"
            },
            new()
            {   
                Id = Guid.NewGuid().ToString(),
                UserName = "user10",
                FirstName = "James",
                LastName = "Rodriguez",
                Email = "james.rodriguez@example.com",
                PhoneNumber = "3332221111",
                Gender = true,
                DateOfBirth = new DateTime(1970, 7, 3),
                ProfilePicUrl = "profile10.jpg",
                RoleName = "Role10"
            }
        };

        return fosterCenterMembers;
    }

    private static List<FosterCenter> InistializeFosterCenters() {
        var fosterCenters = new List<FosterCenter>
        {
            new()
            {
                Name = "Paws and Harmony Shelter",
                Logo = "paws_and_harmony.jpg",
                IsUserFollowing = false,
                Address = "123 Oak Street, Cityville, USA",
                Rating = 4.7,
                Description = "A peaceful shelter dedicated to providing homes for all animals in need."
            },
            new()
            {
                Name = "Fur-Ever Friends Refuge",
                Logo = "fur_ever_friends.jpg",
                IsUserFollowing = true,
                Address = "456 Maple Avenue, Townsville, USA",
                Rating = 4.9,
                Description = "A refuge where animals find companionship and loving homes forever."
            },
            new()
            {
                Name = "Whiskers Haven",
                Logo = "whiskers_haven.jpg",
                IsUserFollowing = true,
                Address = "789 Pine Street, Villagetown, USA",
                Rating = 4.5,
                Description = "A haven where cats and other furry friends receive love and care until they find forever families."
            },
            new()
            {
                Name = "Pawsitive Pals Center",
                Logo = "pawsitive_pals.jpg",
                IsUserFollowing = false,
                Address = "101 Cedar Avenue, Hamletville, USA",
                Rating = 4.6,
                Description = "Bringing positivity to the lives of animals by providing shelter and care."
            },
            new()
            {
                Name = "Safe Haven Animal Sanctuary",
                Logo = "safe_haven.jpg",
                IsUserFollowing = true,
                Address = "321 Elm Street, Suburbia, USA",
                Rating = 4.8,
                Description = "A sanctuary where animals are protected, loved, and given a second chance at happiness."
            },
            new()
            {
                Name = "Furry Tail Retreat",
                Logo = "furry_tail_retreat.jpg",
                IsUserFollowing = true,
                Address = "567 Birch Avenue, Countryside, USA",
                Rating = 4.7,
                Description = "A peaceful retreat where animals can heal, play, and find loving homes."
            },
            new()
            {
                Name = "Happy Hearts Animal Haven",
                Logo = "happy_hearts.jpg",
                IsUserFollowing = false,
                Address = "888 Willow Street, Riverside, USA",
                Rating = 4.6,
                Description = "A haven filled with happiness and love, where animals are cherished and cared for."
            },
            new()
            {
                Name = "Hopeful Paws Refuge",
                Logo = "hopeful_paws.jpg",
                IsUserFollowing = true,
                Address = "999 Cedar Avenue, Mountainview, USA",
                Rating = 4.9,
                Description = "Offering hope and care to animals in need, with the belief that every paw deserves a chance."
            },
            new()
            {
                Name = "Kindred Spirits Animal Sanctuary",
                Logo = "kindred_spirits.jpg",
                IsUserFollowing = false,
                Address = "777 Pine Street, Lakeside, USA",
                Rating = 4.8,
                Description = "A sanctuary where kindred spirits, both human and animal, come together in love and compassion."
            },
            new()
            {
                Name = "Loyal Hearts Animal Rescue",
                Logo = "loyal_hearts.jpg",
                IsUserFollowing = true,
                Address = "234 Oak Street, Meadowville, USA",
                Rating = 4.7,
                Description = "Rescuing animals with loyal hearts and providing them with care and forever homes."
            }
        };

        return fosterCenters;
    }
    #endregion

    #region [ Private Methods - Helper ]
    static List<int> GetRandomUniqueIndices<T>(List<T> originalList, int numberOfItemsToSelect) {
        if (numberOfItemsToSelect >= originalList.Count) {
            return Enumerable.Range(0, originalList.Count).ToList(); // Return all indices if the number of items to select is greater than or equal to the list size
        }

        var random = new Random();
        var shuffledIndices = Enumerable.Range(0, originalList.Count).ToList();

        // Fisher-Yates shuffle algorithm
        int n = shuffledIndices.Count;
        while (n > 1) {
            n--;
            var k = random.Next(n + 1);
            (shuffledIndices[n], shuffledIndices[k]) = (shuffledIndices[k], shuffledIndices[n]);
        }

        // Select the first N shuffled indices
        return shuffledIndices.Take(numberOfItemsToSelect).ToList();
    }
    #endregion
}
