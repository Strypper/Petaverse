using Petaverse.BlackList;
using Petaverse.Home;
using Petaverse.Wiki;

namespace Petaverse.ApplicationStructure;

public static class PetaverseNavigationItemUtil
{

    public static ObservableCollection<NavigationViewItem> InitPetaverseNavigationItems()
    {
        var itemsList = new ObservableCollection<NavigationViewItem>();
        itemsList.Add(new NavigationViewItem(1, "\uE832", "Trang Chủ", true, typeof(HomePage)));
        itemsList.Add(new NavigationViewItem(2, "\uEF16", "Black List", true, typeof(BlackListPage)));
        itemsList.Add(new NavigationViewItem(2, "\uECD6", "Iron Shield", true, typeof(IronShieldPage)));
        itemsList.Add(new NavigationViewItem(2, "\uE04B", "Loài Giống", true, typeof(WikiPage)));

        return itemsList;
    }

    public static ObservableCollection<NavigationViewItem> InitPetaverseFooterNavigationItems()
    {
        var itemsList = new ObservableCollection<NavigationViewItem>();
        itemsList.Add(new NavigationViewItem(1, "\uE283", "Trạm", true, typeof(HomePage)));
        itemsList.Add(new NavigationViewItem(2, "\uEC9F", "Cài Đặt", true, typeof(BlackListPage)));


        return itemsList;
    }
}
