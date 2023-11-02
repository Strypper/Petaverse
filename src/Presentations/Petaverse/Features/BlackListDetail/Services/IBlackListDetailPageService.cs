namespace Petaverse.BlackListDetail;

public interface IBlackListDetailPageService
{
    Task<BlackListDetailModel> GetBlackListDetailAsync(string id);
}
