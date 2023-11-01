namespace Petaverse.BlackListDetail;

public interface IBlackListPageService
{
    Task<BlackListDetailModel> GetBlackListDetailAsync(string id);
}
