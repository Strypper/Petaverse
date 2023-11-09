namespace Petaverse.FosterCenter;

public interface IFosterCenterPageService
{
    Task<UWP.Core.FosterCenter> GetByIdAsync(string id);
}
