namespace Euler.Common.Timing;

public interface ISystemTimeProvider
{
    public DateTime Now { get; }
}