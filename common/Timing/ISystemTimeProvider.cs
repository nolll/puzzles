﻿namespace common.Timing;

public interface ISystemTimeProvider
{
    public DateTime Now { get; }
}