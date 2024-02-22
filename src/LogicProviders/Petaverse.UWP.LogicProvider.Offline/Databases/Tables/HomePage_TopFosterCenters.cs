namespace Petaverse.UWP.LogicProvider.Offline;

public class HomePage_TopFosterCenters : BaseTable
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Logo { get; set; }
    public float Rating { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsUserFollowing { get; set; }
}