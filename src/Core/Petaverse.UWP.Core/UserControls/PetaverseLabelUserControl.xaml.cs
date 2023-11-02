using Windows.UI.Xaml.Controls;

namespace Petaverse.UWP.Core;

public sealed partial class PetaverseLabelUserControl : UserControl
{

    #region [ CTor ]

    public PetaverseLabelUserControl()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Properties ]


    public Brush Background
    {
        get { return (Brush)GetValue(BackgroundProperty); }
        set { SetValue(BackgroundProperty, value); }
    }

    public static readonly DependencyProperty BackgroundProperty =
        DependencyProperty.Register("Background", typeof(Brush), typeof(PetaverseLabelUserControl), null);



    public string LabelContent
    {
        get { return (string)GetValue(LabelContentProperty); }
        set { SetValue(LabelContentProperty, value); }
    }

    public static readonly DependencyProperty LabelContentProperty =
        DependencyProperty.Register("LabelContent", typeof(string), typeof(PetaverseLabelUserControl), new("LabelContent"));



    public Brush BorderBrush
    {
        get { return (Brush)GetValue(BorderBrushProperty); }
        set { SetValue(BorderBrushProperty, value); }
    }

    public static readonly DependencyProperty BorderBrushProperty =
        DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(PetaverseLabelUserControl), null);



    public Brush TextColor
    {
        get { return (Brush)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }

    public static readonly DependencyProperty TextColorProperty =
        DependencyProperty.Register("TextColor", typeof(Brush), typeof(PetaverseLabelUserControl), null);



    public double TextSize
    {
        get { return (double)GetValue(TextSizeProperty); }
        set { SetValue(TextSizeProperty, value); }
    }

    public static readonly DependencyProperty TextSizeProperty =
        DependencyProperty.Register("TextSize", typeof(double), typeof(PetaverseLabelUserControl), new PropertyMetadata(14.0));


    #endregion
}
