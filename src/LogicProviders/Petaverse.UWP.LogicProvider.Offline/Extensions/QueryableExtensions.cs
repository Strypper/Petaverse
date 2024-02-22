using System.Linq.Expressions;

namespace Petaverse.UWP.LogicProvider.Offline;

public static class QueryableExtensions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicateIfTrue)
    {
        return condition ? query.Where(predicateIfTrue) : query;
    }
}
