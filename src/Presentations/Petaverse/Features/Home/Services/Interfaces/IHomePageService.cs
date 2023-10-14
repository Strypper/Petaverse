namespace Petaverse.Home;

public interface IHomePageService
{
    Task<IEnumerable<Home_FirstSectionItemModel>> GetFirstItemsAsync();
    Task<IEnumerable<Home_SecondSectionItemModel>> GetSecondItemsAsync();
    Task<IEnumerable<Home_ThirdSectionItemModel>> GetThirdItemsAsync();
    Task<IEnumerable<Home_FourthSectionItemModel>> GetFourthItemsAsync();
}
