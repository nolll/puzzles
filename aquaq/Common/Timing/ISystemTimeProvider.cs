namespace AquaQ.Common.Timing;

public interface ISystemTimeProvider
{
    public DateTime Now { get; }
}