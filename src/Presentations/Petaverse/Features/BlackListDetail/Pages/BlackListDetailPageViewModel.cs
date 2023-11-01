using Petaverse.ViewModels;

namespace Petaverse.BlackListDetail;

public partial class BlackListDetailPageViewModel : ViewModelBase
{
    #region [ Fields ]

    private readonly IBlackListPageService blackListPageService;
    #endregion

    #region [ CTor ]

    public BlackListDetailPageViewModel(IBlackListPageService blackListPageService)
    {
        this.blackListPageService = blackListPageService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    BlackListDetailModel blackListDetail;
    #endregion

    #region [ Methods ]

    public async Task LoadBlackListDetail(string id)
    {
        BlackListDetail = await blackListPageService.GetBlackListDetailAsync(id);
    }
    #endregion
}
