namespace Pzl.Tools.Strings;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Reversed<T>(this IEnumerable<T> enumerable)
    {
        var copy = enumerable.ToList();
        copy.Reverse();
        return copy;
    }
    
    public static IEnumerable<T> RemoveItemAt<T>(this IEnumerable<T> enumerable, int index)
    {
        var copy = enumerable.ToList();
        copy.RemoveAt(index);
        return copy;
    }
}