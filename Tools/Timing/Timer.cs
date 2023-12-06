namespace Pzl.Tools.Timing;

public class Timer
{
    private readonly ISystemTimeProvider _systemTimeProvider;
    private readonly DateTime _startTime;
    
    public Timer() : this(DateTime.Now, new SystemTimeProviderProvider())
    {
    }

    public Timer(DateTime startTime, ISystemTimeProvider systemTimeProvider)
    {
        _systemTimeProvider = systemTimeProvider;
        _startTime = startTime;
    }

    public TimeSpan FromStart => _systemTimeProvider.Now - _startTime;
}