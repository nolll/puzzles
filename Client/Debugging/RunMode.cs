using System.Diagnostics;

namespace Pzl.Client.Debugging;

public class RunMode
{
    public bool IsDebug => Debugger.IsAttached;
}