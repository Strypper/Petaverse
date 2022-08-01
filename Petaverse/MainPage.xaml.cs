using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Petaverse.ContentDialogs;
using Petaverse.Interfaces;
using Petaverse.Views;
using PetaVerse.Models.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Petaverse
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<NavigationViewItem> PetaverseNavigateViewItems { get; set; } = new ObservableCollection<NavigationViewItem>();
        private ICurrentUserService currentUserService;

        public MainPage()
        {
            this.InitializeComponent();
            currentUserService = Ioc.Default.GetRequiredService<ICurrentUserService>();
            PetaverseNavigateViewItems = PetaverseNavigationItem.InitPetaverseNavigationItems();
        }

        private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var currentUserGuid = currentUserService.GetLocalUserGuidFromAppSettings();
            if (!string.IsNullOrEmpty(currentUserGuid))
            {
                var currentUser = await currentUserService.GetLocalUserAsync(currentUserGuid);
                this.ProccessLogin(currentUser);
            }
        }

        private void NavigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            var item = args.SelectedItem as NavigationViewItem;
            if(item != null)
                TheMainFrame.Navigate(item.DestinationPage);
        }

        private async void AddPet_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var addPetContentDialog = new AddPetContentDialog();
            await addPetContentDialog.ShowAsync();
        }

        private void Profile_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            TheMainFrame.Navigate(typeof(ProfilePage));
            MainNavView.SelectedItem = null;
        }

        private void LoginUserControl_LoginSuccessEventHandler(User petaverseUser)
        {
            this.ProccessLogin(petaverseUser);
        }

        private void ProccessLogin(User petaverseUser)
        {
            if(petaverseUser != null)
            {
                MainNavView.SelectedItem = PetaverseNavigateViewItems.FirstOrDefault(item => item.Id == 2);
                CurrentUserPersonPicture.ProfilePicture = new BitmapImage(new Uri(petaverseUser.ProfilePicUrl));
                CurrentUserFullNameText.Text = petaverseUser.FullName;
                foreach (var item in PetaverseNavigateViewItems) { item.IsEnable = true; }
                NavigationViewPaneFooter.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }
    }

    public partial class NavigationViewItem : ObservableRecipient
    {
        public int    Id              { get; set; }
        public string Glyph           { get; set; }
        public string Content         { get; set; }
        public Type   DestinationPage { get; set; }

        [ObservableProperty]
        private bool isEnable;

        public NavigationViewItem(int id, string glyph, string content, bool isEnable, Type destinationPage)
        {
            Id = id;
            Glyph = glyph;
            Content = content;
            IsEnable = isEnable;
            DestinationPage = destinationPage;
        }
    }

    public class PetaverseNavigationItem
    {
        public static ObservableCollection<NavigationViewItem> InitPetaverseNavigationItems()
        {
            var itemsList = new ObservableCollection<NavigationViewItem>();
            itemsList.Add(new NavigationViewItem(1, "\uE946", "Wiki"     , false, typeof(WikiPage)));
            itemsList.Add(new NavigationViewItem(2, "\uEF3B", "PetShorts", false, typeof(PetShortsPage)));
            return itemsList;
        }
    }
}
