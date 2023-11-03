namespace Petaverse.BlackList;

public sealed partial class BlackListItemUserControl : UserControl
{
    #region [ Delegates ]

    public delegate void SelectItemEventHandler(BlackListItemModel item);
    #endregion

    #region [ CTor ]

    public BlackListItemUserControl()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Properties ]

    public BlackListItemModel ComponentData
    {
        get { return (BlackListItemModel)GetValue(ComponentDataProperty); }
        set { SetValue(ComponentDataProperty, value); }
    }

    public static readonly DependencyProperty ComponentDataProperty =
        DependencyProperty.Register("ComponentData", typeof(BlackListItemModel), typeof(BlackListItemUserControl), new PropertyMetadata(null));


    #endregion
    #region [ Event Handlers ]

    public event SelectItemEventHandler SelectItem;

    private void Grid_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        => SelectItem?.Invoke(ComponentData);
    #endregion


    #region [ Local Functions ]

    public string GetItemTimeGap(DateTime dateTime)
    {
        DateTimeToTimeGapConverter converter = new();
        object convertedResult = converter.Convert(dateTime, null, null, null);
        if (convertedResult is null)
            return string.Empty;

        TimeGap timeGap = convertedResult as TimeGap;

        Dictionary<TimeGapType, string> vnGapLang = new()
        {
            {TimeGapType.Year, "năm" },
            {TimeGapType.Month, "tháng" },
            {TimeGapType.Week, "tuần" },
            {TimeGapType.Day, "ngày" },
            {TimeGapType.Hour, "giờ" },
            {TimeGapType.Minute, "phút" },
            {TimeGapType.Second, "giây" }
        };

        return $"vào {timeGap.TimeAmount} {vnGapLang.GetValueOrDefault(timeGap.Type)} trước";

    }
    #endregion

}
