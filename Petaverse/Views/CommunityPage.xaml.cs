using Petaverse.Models.DTOs;
using Petaverse.Models.UserControlModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Petaverse.Views
{
    public sealed partial class CommunityPage : Page
    {
        public ObservableCollection<Post> Posts { get; set; } = new ObservableCollection<Post>();
        public ObservableCollection<Adoption> Adoptions { get; set; } = new ObservableCollection<Adoption>();
        public List<BlogCard> BlogCards { get; set; } = new List<BlogCard>();
        public CommunityPage()
        {
            this.InitializeComponent();
            Posts = LoadFakePostData.FakePosts();
            Adoptions = FakeAdoption.FakeAdoptionData();
            BlogCards = FakeBlogCard.GetFakeBlogCard();
        }
    }
}
