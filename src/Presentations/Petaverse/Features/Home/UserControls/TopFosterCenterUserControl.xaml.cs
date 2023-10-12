namespace Petaverse;

public sealed partial class TopFosterCenterUserControl : UserControl
{
    #region [ CTors ]

    public TopFosterCenterUserControl()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Properties ]

    public TopFosterCenterModel ComponentData
    {
        get { return (TopFosterCenterModel)GetValue(ComponentDataProperty); }
        set { SetValue(ComponentDataProperty, value); }
    }

    public static readonly DependencyProperty ComponentDataProperty =
        DependencyProperty.Register("ComponentData", typeof(TopFosterCenterModel), typeof(TopFosterCenterUserControl), null);


    #endregion
}
