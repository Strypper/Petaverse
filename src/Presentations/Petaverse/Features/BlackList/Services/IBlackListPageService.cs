namespace Petaverse.BlackList;

public interface IBlackListPageService
{
    Task<IEnumerable<BlackListItemModel>> GetAllAsync();
}
