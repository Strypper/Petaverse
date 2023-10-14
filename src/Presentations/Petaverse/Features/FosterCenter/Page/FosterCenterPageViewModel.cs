using Petaverse.ViewModels;

namespace Petaverse.FosterCenter;

public partial class FosterCenterPageViewModel : ViewModelBase
{
    #region [ Fields ]

    private readonly IFosterCenterService fosterCenterService;
    #endregion

    #region [ Properties ]

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
        this.fosterCenterService = Ioc.Default.GetRequiredService<IFosterCenterService>();

        FirstTagsCollection = new();
        CarouselItems = new();
        Members = new();
        Animals = new();

        LoadDataAsync();
    }
    #endregion

    #region [ Methods ]

    private async Task LoadDataAsync()
    {
        var fosterCenter = await fosterCenterService.GetFosterCenterByIdAsync("random");
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
                UserName = member.UserName,
                UserAvatarUrl = member.ProfilePicUrl,
                RoleName = member.RoleName
            });
        }

        foreach (var animal in fosterCenter.Animals)
        {
            Animals.Add(new()
            {
                Name = animal.Name,
                AvatarUrl = animal.PetAvatar.MediaUrl,
            });
        }
    }
    #endregion
}
