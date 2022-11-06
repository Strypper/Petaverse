using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using Petaverse.Models.DTOs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Networking.Sockets;

namespace Petaverse.Models.UserControlModels
{
    public partial class BlogCard : BaseEntity
    {
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string thumbnailUrl;
        [ObservableProperty]
        string shortDescription;
    }

    public static class FakeBlogCard
    {
        public static List<BlogCard> GetFakeBlogCard()
        {
            var blogs = new List<BlogCard>();
            for (int i = 0; i < 12; i++)
            {
                var thumbnailUrl = new Faker().Image.LoremFlickrUrl(320, 240, "cat portrait", false, true);
                var shortDescription = new Faker().Lorem.Paragraph();
                var title = $"Title {i}";
                blogs.Add(new BlogCard()
                {
                    Title = title,
                    ShortDescription = shortDescription,
                    ThumbnailUrl = thumbnailUrl,
                });
            }
            return blogs.Take(4).ToList();
        }
    }
}
