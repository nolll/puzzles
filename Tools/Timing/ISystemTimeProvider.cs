namespace Pzl.Tools.Timing;

public interface ISystemTimeProvider
{
    public DateTime Now { get; }
}