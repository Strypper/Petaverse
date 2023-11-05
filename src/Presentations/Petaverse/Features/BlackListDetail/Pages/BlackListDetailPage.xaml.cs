﻿using Petaverse.BlackList;

namespace Petaverse.BlackListDetail;

public sealed partial class BlackListDetailPage : Page
{
    #region [ Fields ]

    private readonly BlackListDetailPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public BlackListDetailPage()
    {
        this.InitializeComponent();
        viewModel = Ioc.Default.GetRequiredService<BlackListDetailPageViewModel>();
    }
    #endregion   

    #region [ Overrides ]

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        var item = e.Parameter as BlackListItemModel;
        if (item is null)
            return;

        BlackCaseTitle.Text = item.Title;
    }
    #endregion

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await viewModel.LoadBlackListDetail("1");
    }

    private void GoBack(Microsoft.UI.Xaml.Controls.SwipeItem sender, Microsoft.UI.Xaml.Controls.SwipeItemInvokedEventArgs args)
    {
        Frame.GoBack();
    }
}
