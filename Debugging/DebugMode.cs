namespace Pzl.Client.Debugging;

public static class DebugMode
{
    public static bool IsDebugMode
    {
        get
        {
            return true;
#if SINGLE
            return true;
#else
            return false;
#endif
        }
    }
}