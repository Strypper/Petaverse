using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Petaverse.Models.DTOs
{
    public partial class Post : BaseEntity
    {
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string location;
        [ObservableProperty]
        string dateTime;
        [ObservableProperty]
        string description;

        [ObservableProperty]
        int like;
        [ObservableProperty]
        int seen;

        [ObservableProperty]
        User user;

        //[ObservableProperty]
        //ObservableCollection<PetaverseMedia> imageUrl;

        [ObservableProperty]
        string imageUrl;
    }

    public static class LoadFakePostData
    {
        public static ObservableCollection<Post> FakePosts()
        {
            var posts = new ObservableCollection<Post>();
            posts.Add(new Post() { Title = "GIÚP BE MÈO QUẬN 10", 
                                   Location = "Quận 10",
                                   ImageUrl = "ms-appx:///Assets/Mocks/AbandonedAnimals/MockAdoptPet1.jpg"
            });
            posts.Add(new Post()
            {
                Title = "GIÚP BÉ MÈO QUẬN 12",
                Location = "Quận 12",
                ImageUrl = "ms-appx:///Assets/Mocks/AbandonedAnimals/MockAdoptPet2.jpg"
            });
            posts.Add(new Post()
            {
                Title = "GIÚP BÉ MÈO QUẬN 3",
                Location = "Quận 3",
                ImageUrl = "ms-appx:///Assets/Mocks/AbandonedAnimals/MockAdoptPet3.jpg"
            });
            posts.Add(new Post()
            {
                Title = "GIÚP BÉ MÈO QUẬN 4",
                Location = "Quận 4",
                ImageUrl = "ms-appx:///Assets/Mocks/AbandonedAnimals/MockAdoptPet4.jpg"
            });
            return posts;
        }
    }
}
