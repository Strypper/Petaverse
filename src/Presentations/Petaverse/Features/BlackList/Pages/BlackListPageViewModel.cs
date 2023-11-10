using Petaverse.ViewModels;
using WinRTXamlToolkit.Tools;

namespace Petaverse.BlackList;

public partial class BlackListPageViewModel : ViewModelBase
{
    #region [ Fields ]

    private readonly IBlackListPageService blackListPageService;
    #endregion

    #region [ CTor ]

    public BlackListPageViewModel(IBlackListPageService blackListPageService)
    {
        this.blackListPageService = blackListPageService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    ObservableCollection<BlackListItemModel> items;
    #endregion

    #region [ Methods ]

    public async Task LoadDataAsync()
    {
        if (Items is not null)
            return;

        Items = new();
        var data = await blackListPageService.GetAllAsync();
        data.ForEach(x => Items.Add(x));
    }
    #endregion
}
