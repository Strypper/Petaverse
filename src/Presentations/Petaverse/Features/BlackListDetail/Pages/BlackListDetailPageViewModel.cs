using Petaverse.ViewModels;

namespace Petaverse.BlackListDetail;

public partial class BlackListDetailPageViewModel : ViewModelBase
{
    #region [ Fields ]

    private readonly IBlackListDetailPageService blackListDetailPageService;
    #endregion

    #region [ CTor ]

    //public BlackListDetailPageViewModel(IBlackListDetailPageService blackListDetailPageService)
    //{
    //    this.blackListDetailPageService = blackListDetailPageService;
    //}

    public BlackListDetailPageViewModel()
    {
            
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    BlackListDetailModel blackListDetail;
    #endregion

    #region [ Methods ]

    public async Task LoadBlackListDetail(string id)
    {
        //BlackListDetail = await blackListDetailPageService.GetBlackListDetailAsync(id);
    }
    #endregion
}
