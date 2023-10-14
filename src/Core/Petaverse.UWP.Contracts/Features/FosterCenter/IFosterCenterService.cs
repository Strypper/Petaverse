namespace Petaverse.UWP.Contracts;

public interface IFosterCenterService
{
    Task<FosterCenter> GetFosterCenterByIdAsync(string Id);
}
