namespace common.Runners;

public static class DebugMode
{
    public static bool IsDebugMode
    {
        get
        {
#if SINGLE
            return true;
#else
            return false;
#endif
        }
    }
}