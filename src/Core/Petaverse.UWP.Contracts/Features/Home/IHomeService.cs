using System.Collections.Generic;

namespace Petaverse.UWP.Contracts;

public interface IHomeService
{
    Task<IEnumerable<Event>> GetTopEventsAsync();

    Task<IEnumerable<FosterCenter>> GetFosterCentersAsync();

    Task<IEnumerable<NewAdoption>> GetNewAdoptionsAsync();
}
