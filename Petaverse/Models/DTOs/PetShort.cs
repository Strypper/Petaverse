using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PetaVerse.Models.DTOs
{
    public partial class PetShort : BaseEntity
    {
        
        public string           Title     { get; set; }
        public bool             IsSpam    { get; set; }
        public bool             IsLoved   { get; set; }
        public PetaverseMedia?  Media     { get; set; }
        public Animal?          Pet       { get; set; }
        public User?            Publisher { get; set; }

        [ObservableProperty]
        public int love;
        [ObservableProperty]
        private string mediaUrl;
    }

    public class DemoPetShortData
    {
        public static ObservableCollection<PetShort> GetPetShortsList()
        {

            var petShorts = new ObservableCollection<PetShort>();
            var random = new Random();
            var breeds = DemoBreedData.GetBreedsList();

            petShorts.Add(new PetShort()
            {
                Id = 1,
                Title = "Playing with his brother",
                Love = random.Next(0, 10000),
                Media = new PetaverseMedia()
                {
                    MediaUrl = "https://intranetblobstorages.blob.core.windows.net/backgroundvideo/BravoShortVideo.mp4",
                    TimeUpload = new DateTime().Date,
                    Type = MediaType.Video
                },
                Pet = new Animal()
                {
                    Name = "Bravo",
                    Breed = breeds.FirstOrDefault(breed => breed.Id == 2),
                    Gender = true,
                    Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                Publisher = new Faker<User>()
                               .RuleFor(x => x.firstName, fake => fake.Person.FirstName)
                               .RuleFor(x => x.lastName, fake => fake.Person.LastName)
                               .RuleFor(x => x.email, fake => fake.Person.Email)
                               .RuleFor(x => x.phoneNumber, fake => fake.Person.Phone)
                               .RuleFor(x => x.dateOfBirth, fake => fake.Person.DateOfBirth)
                               .RuleFor(x => x.profilePicUrl, fake => fake.Person.Avatar)
            });

            petShorts.Add(new PetShort()
            {
                Id = 2,
                Title = "Curious cat",
                Love = random.Next(0, 10000),
                Media = new PetaverseMedia()
                {
                    MediaUrl = "https://intranetblobstorages.blob.core.windows.net/backgroundvideo/SnowShortVideo.mp4",
                    TimeUpload = new DateTime().Date,
                    Type = MediaType.Video
                },
                Pet = new Animal()
                {
                    Name = "Snow",
                    Breed = breeds.FirstOrDefault(breed => breed.Id == 2),
                    Gender = true,
                    Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                Publisher = new Faker<User>()
                               .RuleFor(x => x.firstName, fake => fake.Person.FirstName)
                               .RuleFor(x => x.lastName, fake => fake.Person.LastName)
                               .RuleFor(x => x.email, fake => fake.Person.Email)
                               .RuleFor(x => x.phoneNumber, fake => fake.Person.Phone)
                               .RuleFor(x => x.dateOfBirth, fake => fake.Person.DateOfBirth)
                               .RuleFor(x => x.profilePicUrl, fake => fake.Person.Avatar)
            });
            return petShorts;
        }
    }
}
