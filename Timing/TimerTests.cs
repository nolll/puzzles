namespace Pzl.Client.Timing;

public class TimerTests
{
    [Fact]
    public void Timer()
    {
        var startTime = DateTime.Parse("2020-02-02 20:20:20");
        var endTime = DateTime.Parse("2020-02-02 20:20:21");

        var systemTime = new SystemTimeProviderForTest(endTime);
        var timer = new Timer(startTime, systemTime);

        timer.FromStart.TotalMilliseconds.Should().Be(1_000);
    }

    private class SystemTimeProviderForTest : ISystemTimeProvider
    {
        public DateTime Now { get; }

        public SystemTimeProviderForTest(DateTime now)
        {
            Now = now;
        }
    }
}