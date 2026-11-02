using Pzl.Client.Timing;
using Timer = Pzl.Client.Timing.Timer;

namespace Tests.Client;

public class TimerTests
{
    [Fact]
    public void Timer() => new Timer(
        DateTime.Parse("2020-02-02 20:20:20"),
        new TimeProvider(DateTime.Parse("2020-02-02 20:20:21"))
    ).FromStart.TotalMilliseconds.Should().Be(1_000);

    private record TimeProvider(DateTime Now) : ISystemTimeProvider;
}