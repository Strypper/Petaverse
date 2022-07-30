using CommunityToolkit.Mvvm.DependencyInjection;
using Petaverse.Interfaces;
using PetaVerse.Models.DTOs;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Petaverse.UserControls.ProfilePageUserControls
{
    public sealed partial class UserInfoPanelUserControl : UserControl
    {
        public delegate void LogoutDelegate();
        public event LogoutDelegate LogoutEventHandler;

        public List<string> Tags { get; set; } = new List<string>() { "Dog Lover", "Cat Lover", "Pet Hero", "Explorer", "Petaverse Core Creator" };
        public User CurrentUser
        {
            get { return (User)GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }

        public static readonly DependencyProperty CurrentUserProperty =
            DependencyProperty.Register("CurrentUser", typeof(User), typeof(UserInfoPanelUserControl), null);

        private readonly ICurrentUserService currentUserService;

        public UserInfoPanelUserControl()
        {
            this.InitializeComponent();
            currentUserService = Ioc.Default.GetRequiredService<ICurrentUserService>();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            currentUserService.RemoveAllLocalData();
            LogoutEventHandler.Invoke();
        }
    }
}
