namespace Pzl.Client.Debugging;

public class RunMode
{
    public bool IsDebug
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