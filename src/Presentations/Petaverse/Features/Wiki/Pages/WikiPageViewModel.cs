using Petaverse.ViewModels;

namespace Petaverse.Wiki;

public partial class WikiPageViewModel : ViewModelBase
{
    #region [ Fields ]

    private readonly IWikiPageService wikiPageService;
    #endregion

    #region [ CTors ]

    public WikiPageViewModel(IWikiPageService wikiPageService)
    {
        this.wikiPageService = wikiPageService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    ObservableCollection<Species> species;
    #endregion

    #region [ Methods ]

    public async Task LoadDataAsync()
    {
        if (IsBusy)
            return;

        if (Species is not null)
            return;

        IsBusy = true;
        var data = await wikiPageService.GetAllSpecies();
        Species = new(data);
        IsBusy = false;
    }
    #endregion
}
