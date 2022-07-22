using PetaVerse.Models.DTOs;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Petaverse.UserControls.ProfilePageUserControls
{
    public sealed partial class UserInfoPanelUserControl : UserControl
    {
        public List<string> Tags { get; set; } = new List<string>() { "Dog Lover", "Cat Lover", "Pet Hero", "Explorer", "Petaverse Core Creator" };
        public User CurrentUser
        {
            get { return (User)GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }

        public static readonly DependencyProperty CurrentUserProperty =
            DependencyProperty.Register("CurrentUser", typeof(User), typeof(UserInfoPanelUserControl), null);


        public UserInfoPanelUserControl()
        {
            this.InitializeComponent();
        }
    }
}
