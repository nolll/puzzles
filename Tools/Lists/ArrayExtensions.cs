namespace Pzl.Tools.Lists;

public static class ArrayExtensions
{
    public static int IndexOf<T>(this T[] a, T item) where T : struct => Array.IndexOf(a, item);
    
    public static void Deconstruct<T>(this T[] srcArray, out T a0) {
        if (srcArray == null || srcArray.Length < 1)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1) {
        if (srcArray == null || srcArray.Length < 2)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
        a1 = srcArray[1];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2) {
        if (srcArray == null || srcArray.Length < 3)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
        a1 = srcArray[1];
        a2 = srcArray[2];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3) {
        if (srcArray == null || srcArray.Length < 4)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
        a1 = srcArray[1];
        a2 = srcArray[2];
        a3 = srcArray[3];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4) {
        if (srcArray == null || srcArray.Length < 5)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
        a1 = srcArray[1];
        a2 = srcArray[2];
        a3 = srcArray[3];
        a4 = srcArray[4];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5) {
        if (srcArray == null || srcArray.Length < 6)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
        a1 = srcArray[1];
        a2 = srcArray[2];
        a3 = srcArray[3];
        a4 = srcArray[4];
        a5 = srcArray[5];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5, out T a6) {
        if (srcArray == null || srcArray.Length < 7)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
        a1 = srcArray[1];
        a2 = srcArray[2];
        a3 = srcArray[3];
        a4 = srcArray[4];
        a5 = srcArray[5];
        a6 = srcArray[6];
    }

    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5, out T a6, out T a7) {
        if (srcArray == null || srcArray.Length < 8)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
        a1 = srcArray[1];
        a2 = srcArray[2];
        a3 = srcArray[3];
        a4 = srcArray[4];
        a5 = srcArray[5];
        a6 = srcArray[6];
        a7 = srcArray[7];
    }
    
    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5, out T a6, out T a7, out T a8) {
        if (srcArray == null || srcArray.Length < 9)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
        a1 = srcArray[1];
        a2 = srcArray[2];
        a3 = srcArray[3];
        a4 = srcArray[4];
        a5 = srcArray[5];
        a6 = srcArray[6];
        a7 = srcArray[7];
        a8 = srcArray[8];
    }
    
    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5, out T a6, out T a7, out T a8, out T a9) {
        if (srcArray == null || srcArray.Length < 10)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
        a1 = srcArray[1];
        a2 = srcArray[2];
        a3 = srcArray[3];
        a4 = srcArray[4];
        a5 = srcArray[5];
        a6 = srcArray[6];
        a7 = srcArray[7];
        a8 = srcArray[8];
        a9 = srcArray[9];
    }
    
    public static void Deconstruct<T>(this T[] srcArray, out T a0, out T a1, out T a2, out T a3, out T a4, out T a5, out T a6, out T a7, out T a8, out T a9, out T a10) {
        if (srcArray == null || srcArray.Length < 11)
            throw new ArgumentException(nameof(srcArray));

        a0 = srcArray[0];
        a1 = srcArray[1];
        a2 = srcArray[2];
        a3 = srcArray[3];
        a4 = srcArray[4];
        a5 = srcArray[5];
        a6 = srcArray[6];
        a7 = srcArray[7];
        a8 = srcArray[8];
        a9 = srcArray[9];
        a10 = srcArray[10];
    }
}