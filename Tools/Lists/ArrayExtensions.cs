namespace Pzl.Tools.Lists;

public static class ArrayExtensions
{
    public static int IndexOf<T>(this T[] a, T item) where T : struct => Array.IndexOf(a, item);
    
    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1) {
        AssertSize(srcArray, 2);
        a0 = srcArray[0];
        a1 = srcArray[1];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2) {
        AssertSize(srcArray, 3);
        Deconstruct(srcArray, out a0, out a1);
        a2 = srcArray[2];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3) {
        AssertSize(srcArray, 4);
        Deconstruct(srcArray, out a0, out a1, out a2);
        a3 = srcArray[3];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4) {
        AssertSize(srcArray, 5);
        Deconstruct(srcArray, out a0, out a1, out a2, out a3);
        a4 = srcArray[4];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5) {
        AssertSize(srcArray, 6);
        Deconstruct(srcArray, out a0, out a1, out a2, out a3, out a4);
        a5 = srcArray[5];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5, out T a6) {
        AssertSize(srcArray, 7);
        Deconstruct(srcArray, out a0, out a1, out a2, out a3, out a4, out a5);
        a6 = srcArray[6];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5, out T a6, out T a7) {
        AssertSize(srcArray, 8);
        Deconstruct(srcArray, out a0, out a1, out a2, out a3, out a4, out a5, out a6);
        a7 = srcArray[7];
    }
    
    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5, out T a6, out T a7, out T a8) {
        AssertSize(srcArray, 9);
        Deconstruct(srcArray, out a0, out a1, out a2, out a3, out a4, out a5, out a6, out a7);
        a8 = srcArray[8];
    }
    
    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5, out T a6, out T a7, out T a8, out T a9) {
        AssertSize(srcArray, 10);
        Deconstruct(srcArray, out a0, out a1, out a2, out a3, out a4, out a5, out a6, out a7, out a8);
        a9 = srcArray[9];
    }
    
    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5, out T a6, out T a7, out T a8, out T a9, out T a10) {
        AssertSize(srcArray, 11);
        Deconstruct(srcArray, out a0, out a1, out a2, out a3, out a4, out a5, out a6, out a7, out a8, out a9);
        a10 = srcArray[10];
    }

    private static void AssertSize<T>(T[] srcArray, int size)
    {
        if (srcArray.Length < size)
            throw new ArgumentException(nameof(srcArray));
    }
}