using Petaverse.Models.DTOs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Petaverse.UserControls
{
    public sealed partial class CommunityPeopleCardUserControl : UserControl
    {
        public User User
        {
            get { return (User)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User", typeof(User), typeof(CommunityPeopleCardUserControl), null);


        public CommunityPeopleCardUserControl()
        {
            this.InitializeComponent();
        }
    }
}
