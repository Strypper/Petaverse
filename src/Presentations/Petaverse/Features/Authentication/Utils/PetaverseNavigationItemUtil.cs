namespace Petaverse;

public class PetaverseNavigationItemUtil
{
    public static ObservableCollection<NavigationViewItem> InitPetaverseNavigationItems()
    {
        var communityItem = new NavigationViewItem(3, "\uE125", "Community", false, typeof(CommunityPage));
        communityItem.SubMenuItems.Add(new NavigationViewItem(4, "\uE125", "People", true, typeof(CommunityPeoplePage)));
        communityItem.SubMenuItems.Add(new NavigationViewItem(5, "\uE902", "Group", true, typeof(CommunityPeoplePage)));


        var itemsList = new ObservableCollection<NavigationViewItem>();
        itemsList.Add(new NavigationViewItem(1, "\uE946", "Wiki", false, typeof(WikiPage)));
        itemsList.Add(new NavigationViewItem(2, "\uEF3B", "PetShorts (Beta)", false, typeof(PetShortsPage)));
        itemsList.Add(communityItem);


        return itemsList;
    }
}
