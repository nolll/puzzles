using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Puzzles;

namespace Aoc;

public abstract class AocPuzzle : TwoPartsPuzzle
{
    private readonly string _year;
    private readonly string _paddedDay;

    public override string Id { get; }
    public override string Title { get; }
    public override string ListTitle { get; }

    protected AocPuzzle()
    {
        var (year, day) = AocPuzzleParser.GetYearAndDay(GetType());
        var paddedDay = day.ToString().PadLeft(2, '0');
        Id = $"{year}{paddedDay}";
        Title = $"Day {day} {year}";
        ListTitle = $"Day {paddedDay} {year}";
        _year = year.ToString();
        _paddedDay = paddedDay;
    }

    public override IEnumerable<string> GetTags()
    {
        var tags = base.GetTags().ToList();
        tags.Add(_year);
        return tags;
    }

    protected override string InputFilePath =>
        Path.Combine(
            "Puzzles",
            $"Year{_year}",
            $"Day{_paddedDay}",
            $"Year{_year}Day{_paddedDay}.txt");
}