using Petaverse.ViewModels;

namespace Petaverse.FosterCenter;

public partial class FosterCenterPageViewModel : ViewModelBase
{
    #region [ Fields ]

    private readonly IFosterCenterPageService pageService;
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string fosterCenterLogo;

    [ObservableProperty]
    string fosterCenterName;

    [ObservableProperty]
    bool isFollowed;

    [ObservableProperty]
    ObservableCollection<TagUIModel> firstTagsCollection;

    [ObservableProperty]
    ObservableCollection<CarouselItemModel> carouselItems;

    [ObservableProperty]
    ObservableCollection<MemberProfilePreviewModel> members;

    [ObservableProperty]
    ObservableCollection<AnimalProfilePreviewModel> animals;
    #endregion

    #region [ CTor ]

    public FosterCenterPageViewModel()
    {
        this.pageService = Ioc.Default.GetRequiredService<IFosterCenterPageService>();
    }
    #endregion

    #region [ Methods ]

    public async Task LoadDataAsync()
    {
        FirstTagsCollection = new();
        CarouselItems = new();
        Members = new();
        Animals = new();

        var fosterCenter = await pageService.GetByIdAsync("random");
        foreach (var tag in fosterCenter.Tags)
        {
            FirstTagsCollection.Add(new()
            {
                TagName = tag.TagName,
                ColorHex = tag.TagColorHex
            });
        }

        foreach (var image in fosterCenter.CoverImages)
        {
            CarouselItems.Add(new()
            {
                ImageUrl = image.MediaUrl,
            });
        }

        foreach (var member in fosterCenter.Members)
        {
            Members.Add(new()
            {
                Id = member.Id,
                UserName = member.UserName,
                UserAvatarUrl = member.ProfilePicUrl,
                RoleName = member.RoleName
            });
        }

        foreach (var animal in fosterCenter.Animals)
        {
            Animals.Add(new()
            {
                Id = animal.Id,
                Name = animal.Name,
                AvatarUrl = animal.PetAvatar.MediaUrl,
            });
        }
    }
    #endregion
}
