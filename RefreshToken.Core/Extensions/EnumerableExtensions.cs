namespace RefreshToken.Core.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<TType> Order<TType>(this IEnumerable<TType> enumerable, bool ascending, Func<TType, object> orderProperty)
    {
        return ascending ? enumerable.OrderBy(orderProperty) : enumerable.OrderByDescending(orderProperty);
    }
}
