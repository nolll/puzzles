﻿using System.Collections.Generic;
using System.Linq;
using Aoc.Platform;

namespace Aoc.ConsoleTools;

public class DayFilter
{
    private readonly Parameters _parameters;

    public DayFilter(Parameters parameters)
    {
        _parameters = parameters;
    }

    public List<PuzzleDay> Filter(List<PuzzleDay> days)
    {
        if (_parameters.RunSlowOnly)
            return days.Where(o => o.Puzzle.IsSlow).ToList();

        if (_parameters.RunCommentedOnly)
            return days.Where(o => !string.IsNullOrEmpty(o.Puzzle.Comment)).ToList();

        if (_parameters.RunFunOnly)
            return days.Where(o => o.Puzzle.IsFunToOptimize).ToList();

        return days;
    }
}