using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace Petaverse.Models.DTOs
{
    public partial class Adoption : BaseEntity
    {
        [ObservableProperty]
        User owner;
        [ObservableProperty]
        Animal pet;
        [ObservableProperty]
        string activity;
        
    }

    public static class FakeAdoption
    {
        public static ObservableCollection<Adoption> FakeAdoptionData()
        {
            var adoptions = new ObservableCollection<Adoption>();
            for (int i = 0; i < 12; i++)
            {
                var fakeFirstName = new Faker().Person.FirstName;
                var fakeLastName = new Faker().Person.LastName;
                var fakeOwnerImageUrl = new Faker().Person.Avatar;
                var fakePetImageUrl = new Faker().Image.LoremFlickrUrl(480, 480, "cat portrait", false, true);
                var fakeActivity = new Faker().Random.Int(1, 2) == 1 ? "Nhận nuôi" : "Nuôi tạm";
                adoptions.Add(new Adoption()
                {
                    Owner = new User()
                    {
                        FirstName = fakeFirstName,
                        LastName  = fakeLastName,
                        PetaverseProfileImageUrl = fakeOwnerImageUrl,
                    },
                    Pet = new Animal()
                    {
                        PetAvatar = new PetaverseMedia()
                        {
                            MediaUrl = fakePetImageUrl
                        }
                    },
                    Activity = fakeActivity
                });
            }
            return adoptions;
        }
    }
}
