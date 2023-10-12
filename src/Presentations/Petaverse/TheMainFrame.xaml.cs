using Microsoft.UI.Xaml.Controls;
using Windows.UI.Core;

namespace Petaverse;

public sealed partial class TheMainFrame : Page
{
    #region [ CTor ]

    public TheMainFrame()
    {
        this.InitializeComponent();

        if (Environment.OSVersion.Version.Build >= 22000)
        {
            SetValue(BackdropMaterial.ApplyToRootOrPageBackgroundProperty, true);
        }

        Window.Current.SetTitleBar(TitleBarGrid);

        Window.Current.Activated += (s, e) =>
        {
            TitleBarGrid.Opacity = e.WindowActivationState != CoreWindowActivationState.Deactivated ? 1 : 0.5;
        };
    }
    #endregion

    #region [ Event Handlers ]

    private void Navigate(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
    {
        var index = sender.MenuItems.IndexOf(args.InvokedItemContainer);

        if (index == -1)
        {
            //ContentFrame.Navigate(typeof(Settings));

            return;
        }

        ContentFrame.Navigate(index % 2 == 0 ? typeof(HomePage) : typeof(IronShieldPage));
    }
    #endregion
}
