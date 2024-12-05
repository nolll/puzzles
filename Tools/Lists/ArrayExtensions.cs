namespace Pzl.Tools.Lists;

public static class ArrayExtensions
{
    public static int IndexOf<T>(this T[] a, T item)  where T : struct
    {
        return Array.IndexOf<T>(a, item);
    }
}