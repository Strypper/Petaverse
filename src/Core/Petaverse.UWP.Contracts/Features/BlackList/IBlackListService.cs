using System.Collections.Generic;

namespace Petaverse.UWP.Contracts;

public interface IBlackListService
{
    Task<IEnumerable<BlackCase>> GetAllBlackCases();
    Task<BlackCaseDetail> GetBlackCaseDetailById(string id);
}
