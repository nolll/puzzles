namespace Pzl.Client.Timing;

public interface ISystemTimeProvider
{
    public DateTime Now { get; }
}