namespace Pzl.Tools.Timing;

public class SystemTimeProviderProvider : ISystemTimeProvider
{
    public DateTime Now => DateTime.Now;
}