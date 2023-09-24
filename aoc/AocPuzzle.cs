using System.Collections.Generic;
using System.Linq;
using Common.Puzzles;

namespace Aoc;

public abstract class AocPuzzle : TwoPartsPuzzle
{
    private readonly string _year;

    public override string Id { get; }
    public override string SortId { get; }
    public override string Title { get; }
    public override string ListTitle { get; }

    protected AocPuzzle()
    {
        var (year, day) = AocPuzzleParser.GetYearAndDay(GetType());
        var paddedDay = day.ToString().PadLeft(2, '0');
        var id = $"{year}{paddedDay}";
        Id = id;
        SortId = id;
        Title = $"Day {day} {year}";
        ListTitle = $"Day {paddedDay} {year}";
        _year = year.ToString();
    }

    public override IEnumerable<string> GetTags()
    {
        var tags = base.GetTags().ToList();
        tags.Add(_year);
        return tags;
    }
}