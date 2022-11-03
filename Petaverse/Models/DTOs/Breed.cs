using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Petaverse.Models.DTOs
{
    public partial class Breed : BaseEntity
    {
        [ObservableProperty]
        int speciesId;
        [ObservableProperty]
        string breedName;
        [ObservableProperty]
        string breedDescription;
        [ObservableProperty]
        string imageUrl;
        [ObservableProperty]
        double minimunSize;
        [ObservableProperty]
        double maximumSize;
        [ObservableProperty]
        double minimumWeight;
        [ObservableProperty]
        double maximumWeight;
        [ObservableProperty]
        int minimumLifeSpan;
        [ObservableProperty]
        int maximumLifeSpan;
        [ObservableProperty]
        string color;
        [ObservableProperty]
        Species species;

        [ObservableProperty]
        ObservableCollection<Animal> animals;

        [ObservableProperty]
        public Coat coat;
    }

    public enum Coat
    {
        None = 0, Short = 1, Medium = 2, Long = 3
    }

    public enum AnimalSize
    {
        Tiny, Small, Medium, MediumLarge, Large
    }

    public enum Shedding
    {
        None, Minimal, Medium, Heavy
    }

    public enum Energy
    {
        Low, Medium, Energetic
    }

    public class DemoBreedData
    {
        public static ObservableCollection<Breed> GetBreedsList()
        {
            var breeds = new ObservableCollection<Breed>();
            breeds.Add(new Breed() 
            { 
                Id = 1,
                BreedName = "Abyssinian Cat",
                ImageUrl  = "ms-appx:///Assets/Breeds/AbyssinianCat.png",
            });
            breeds.Add(new Breed()
            {
                Id = 2,
                BreedName = "American Short Hair Cat",
                ImageUrl  = "ms-appx:///Assets/Breeds/AmericanShortHairCat.png",
            });
            breeds.Add(new Breed()
            {
                Id = 3,
                BreedName = "American Bobtail Cat",
                ImageUrl  = "ms-appx:///Assets/Breeds/AmericanBobtailCatBreed.png",
            });
            breeds.Add(new Breed()
            {
                Id = 4,
                BreedName = "Birman Cat",
                ImageUrl  = "ms-appx:///Assets/Breeds/BirmanCatBreed.png",
            });
            breeds.Add(new Breed()
            {
                Id = 5,
                BreedName = "Bombay Cat",
                ImageUrl  = "ms-appx:///Assets/Breeds/BombayCat.png",
            });
            breeds.Add(new Breed()
            {
                Id = 6,
                BreedName = "British Shorthair Cat",
                ImageUrl  = "ms-appx:///Assets/Breeds/BritishShorthairCatBreed.png",
            });
            breeds.Add(new Breed()
            {
                Id = 7,
                BreedName = "Chartreux Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/ChartreuxCatBreed.png",
            });
            breeds.Add(new Breed()
            {
                Id = 8,
                BreedName = "Himalayan Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/HimalayanCat.png",
            });
            breeds.Add(new Breed()
            {
                Id = 9,
                BreedName = "Selkirk Rex Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/SelkirkRexCatBreed.png",
            });
            breeds.Add(new Breed()
            {
                Id = 10,
                BreedName = "Persian Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/PersianCatBreed.png",
            });
            breeds.Add(new Breed()
            {
                Id = 11,
                BreedName = "Norwegian Forest Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/NorwegianForestCatBreed.png",
            });
            breeds.Add(new Breed()
            {
                Id = 12,
                BreedName = "LaPerm Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/ChartreuxCatBreed.png",
            });
            breeds.Add(new Breed()
            {
                Id = 13,
                BreedName = "Turkish Angora Cat",
                ImageUrl = "ms-appx:///Assets/Breeds/LaPermCat.png",
            });
            return breeds;
        }
    }
}
