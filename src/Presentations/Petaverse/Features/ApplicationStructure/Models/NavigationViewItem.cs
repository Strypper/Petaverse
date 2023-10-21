namespace Petaverse.ApplicationStructure;


public partial class NavigationViewItem : ObservableRecipient
{
    public int Id { get; set; }
    public string Glyph { get; set; }
    public string Content { get; set; }
    public Type DestinationPage { get; set; }

    public List<NavigationViewItem> SubMenuItems { get; set; }

    [ObservableProperty]
    private bool isEnable;

    public NavigationViewItem(int id, string glyph, string content, bool isEnable, Type destinationPage)
    {
        Id = id;
        Glyph = glyph;
        Content = content;
        IsEnable = isEnable;
        DestinationPage = destinationPage;
        SubMenuItems = new List<NavigationViewItem>();
    }
}