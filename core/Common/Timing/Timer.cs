using System;

namespace App.Common.Timing;

public class Timer
{
    private DateTime _startTime;
    private DateTime _lastRead;

    public Timer()
    {
        _startTime = DateTime.Now;
        _lastRead = _startTime;
    }

    public void Start() => _startTime = DateTime.Now;

    public TimeSpan FromStart => DateTime.Now - _startTime;

    public TimeSpan FromLastRead
    {
        get
        {
            var now = DateTime.Now;
            var diff = now - _lastRead;
            _lastRead = now;
            return diff;
        }
    }
}