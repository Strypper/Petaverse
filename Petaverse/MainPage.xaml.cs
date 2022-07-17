using Petaverse.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace Petaverse
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<NavigationViewItem> PetaverseNavigateViewItems { get; set; } = new ObservableCollection<NavigationViewItem>();
        public MainPage()
        {
            this.InitializeComponent();
            PetaverseNavigateViewItems = PetaverseNavigationItem.InitPetaverseNavigationItems();
        }

        private void NavigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            var item = args.SelectedItem as NavigationViewItem;
            if(item != null)
                TheMainFrame.Navigate(item.DestinationPage);
        }
    }

    public class NavigationViewItem
    {
        public string Glyph           { get; set; }
        public string Content         { get; set; }
        public Type   DestinationPage { get; set; }
        public NavigationViewItem(string glyph, string content, Type destinationPage)
        {
            Glyph = glyph;
            Content = content;
            DestinationPage = destinationPage;
        }
    }

    public class PetaverseNavigationItem
    {
        public static ObservableCollection<NavigationViewItem> InitPetaverseNavigationItems()
        {
            var itemsList = new ObservableCollection<NavigationViewItem>();
            itemsList.Add(new NavigationViewItem("\uE946", "Wiki",      typeof(WikiPage)));
            itemsList.Add(new NavigationViewItem("\uEF3B", "PetShorts", typeof(PetShortsPage)));
            return itemsList;
        }
    }
}
