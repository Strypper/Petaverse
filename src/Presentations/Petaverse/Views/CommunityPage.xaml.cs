using Petaverse.Models.UserControlModels;

namespace Petaverse.Views;

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
