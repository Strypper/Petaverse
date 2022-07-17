using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PetaVerse.Models.DTOs
{
    public class Breed : BaseEntity
    {
        public int          SpeciesId           { get; set; }
        public string       BreedName           { get; set; } = string.Empty;
        public string       BreedDescription    { get; set; } = string.Empty;
        public string       ImageUrl            { get; set; } = string.Empty;
        public double       MinimunSize         { get; set; }
        public double       MaximumSize         { get; set; }
        public double       MinimumWeight       { get; set; }
        public double       MaximumWeight       { get; set; }
        public int          MinimumLifeSpan     { get; set; }
        public int          MaximumLifeSpan     { get; set; }
        public CoatType     Coat                { get; set; }
        public string       Color               { get; set; } = string.Empty;

        public Species     Species              { get; set; }

        public virtual ICollection<Animal>  Animals     { get; set; } = new HashSet<Animal>();
    }

    public enum CoatType
    {
        Medium, 
        Heavy, 
        Light
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
