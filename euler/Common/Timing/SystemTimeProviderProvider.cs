namespace Euler.Common.Timing;

public class SystemTimeProviderProvider : ISystemTimeProvider
{
    public DateTime Now => DateTime.Now;
}