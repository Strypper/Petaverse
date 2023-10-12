using Petaverse.Models.DTOs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Petaverse.UserControls
{
    public sealed partial class CommunityPeopleCardUserControl : UserControl
    {
        public Models.DTOs.User User
        {
            get { return (Models.DTOs.User)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User", typeof(Models.DTOs.User), typeof(CommunityPeopleCardUserControl), null);


        public CommunityPeopleCardUserControl()
        {
            this.InitializeComponent();
        }
    }
}
