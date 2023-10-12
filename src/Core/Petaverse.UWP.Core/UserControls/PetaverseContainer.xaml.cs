using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Petaverse.UWP.Core;

public sealed partial class PetaverseContainer : UserControl, INotifyPropertyChanged
{
    #region [ CTors ]

    public PetaverseContainer()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Properties ]

    public new UIElement Content
    {
        get => (UIElement)GetValue(ContentProperty);
        set
        {
            SetValue(ContentProperty, value);
            PropertyChanged?.Invoke(value, new PropertyChangedEventArgs(nameof(Content)));
        }
    }

    public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(UIElement), typeof(PetaverseContainer), new PropertyMetadata(null));
    #endregion

    #region [ Event Handlers ]

    public event PropertyChangedEventHandler PropertyChanged;

    private void SetPointerNormalState(object sender, PointerRoutedEventArgs e)
    {
        VisualStateManager.GoToState(this, "Normal", true);
    }

    private void SetPointerOverState(object sender, PointerRoutedEventArgs e)
    {
        VisualStateManager.GoToState(this, "PointerOver", true);
    }

    private void SetPointerPressedState(object sender, PointerRoutedEventArgs e)
    {
        VisualStateManager.GoToState(this, "Pressed", true);
    }
    #endregion
}
