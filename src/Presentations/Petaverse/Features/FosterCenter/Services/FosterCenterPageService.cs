
namespace Petaverse.FosterCenter;

public class FosterCenterPageService : IFosterCenterPageService
{
    #region [ Fields ]

    private readonly IFosterCenterService service;
    #endregion

    #region [ CTors ]

    public FosterCenterPageService(IFosterCenterService service)
    {
        this.service = service;
    }
    #endregion

    #region [ Methods ]

    public Task<UWP.Core.FosterCenter> GetByIdAsync(string id)
        => service.GetFosterCenterByIdAsync(id);
    #endregion
}
