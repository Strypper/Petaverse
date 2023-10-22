using CommunityToolkit.Mvvm.Input;
using Windows.UI.Xaml.Controls;

namespace Petaverse.UWP.Core;

public sealed partial class StatusInfoBarUserControl : UserControl
{
    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(StatusInfoBarUserControl), new PropertyMetadata(string.Empty));

    public string Message
    {
        get { return (string)GetValue(MessageProperty); }
        set { SetValue(MessageProperty, value); }
    }
    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register("Message", typeof(string), typeof(StatusInfoBarUserControl), new PropertyMetadata(string.Empty));

    public string Icon
    {
        get { return (string)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(string), typeof(StatusInfoBarUserControl), new PropertyMetadata(string.Empty));

    public string BarColor
    {
        get { return (string)GetValue(BarColorProperty); }
        set { SetValue(BarColorProperty, value); }
    }

    public static readonly DependencyProperty BarColorProperty =
        DependencyProperty.Register("BarColor", typeof(string), typeof(StatusInfoBarUserControl), new PropertyMetadata(string.Empty));


    public IRelayCommand DismissInfoBarCommand
    {
        get { return (IRelayCommand)GetValue(DismissInfoBarCommandProperty); }
        set { SetValue(DismissInfoBarCommandProperty, value); }
    }
    public static readonly DependencyProperty DismissInfoBarCommandProperty =
        DependencyProperty.Register("DismissInfoBarCommand", typeof(IRelayCommand), typeof(StatusInfoBarUserControl), null);



    public StatusInfoBarUserControl()
    {
        this.InitializeComponent();
    }

    private void StatusTimeOutBar_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        => this.Visibility = e.NewValue == 100 ? Visibility.Collapsed : Visibility.Visible;

    private void DismissInfoBar_Click(object sender, RoutedEventArgs e)
    {
        DismissInfoBarCommand.Execute(this);
    }
}
