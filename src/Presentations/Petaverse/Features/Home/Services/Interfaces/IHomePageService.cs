namespace Petaverse;

public interface IHomePageService
{
    Task<IEnumerable<HomeCarouselItemUserControlModel>> GetCarouselItemsAsync();
    Task<IEnumerable<TopFosterCenterModel>> GetTopFosterCentersAsync();
}
