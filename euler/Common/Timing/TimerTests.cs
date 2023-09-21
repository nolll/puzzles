using NUnit.Framework;

namespace Euler.Common.Timing;

public class TimerTests
{
    [Test]
    public void Timer()
    {
        var startTime = DateTime.Parse("2020-02-02 20:20:20");
        var endTime = DateTime.Parse("2020-02-02 20:20:21");

        var systemTime = new SystemTimeProviderForTest(endTime);
        var timer = new Timer(startTime, systemTime);

        Assert.That(timer.FromStart.TotalMilliseconds, Is.EqualTo(1_000));
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