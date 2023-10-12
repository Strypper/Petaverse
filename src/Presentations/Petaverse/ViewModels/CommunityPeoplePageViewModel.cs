using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using Petaverse.Models.DTOs;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Petaverse.ViewModels
{
    public partial class CommunityPeoplePageViewModel : ViewModelBase
    {
        [ObservableProperty]
        public ObservableCollection<Models.DTOs.User> communityPeople;
        public CommunityPeoplePageViewModel()
        {
        }

        public async Task InitFakeData()
        {
            CommunityPeople = new ObservableCollection<Models.DTOs.User>();
            for (int i = 0; i < 30; i++)
            {
                CommunityPeople.Add(new Faker<Models.DTOs.User>()
                    .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                    .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                    .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                    .RuleFor(u => u.PhoneNumber, (f, u) => f.Person.Phone)
                    .RuleFor(u => u.NumberOfCats, (f, u) => f.Random.Number(40))
                    .RuleFor(u => u.NumberOfDogs, (f, u) => f.Random.Number(10))
                    .RuleFor(u => u.Foster, (f, u) => f.Random.Number(40))
                    .RuleFor(u => u.Hero, (f, u) => f.Random.Number(10))
                    .RuleFor(u => u.DummyWord, (f, u) => f.Company.Bs())
                    .RuleFor(u => u.City, (f, u) => f.Person.Address.City)
                    .RuleFor(u => u.TeamLogo, f => f.Image.LoremFlickrUrl(30, 30, "Logo"))
                    .RuleFor(u => u.PetaverseProfileImageUrl, f => f.Internet.Avatar()));
            }
        }
    }
}
