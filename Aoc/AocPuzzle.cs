using Pzl.Common;

namespace Pzl.Aoc;

public abstract class AocPuzzle : TwoPartsPuzzle
{
    private readonly string _year;
    private readonly string _day;

    public override string SortId { get; }
    public override string Title { get; }
    public override string ListTitle { get; }

    protected AocPuzzle()
    {
        var (year, day) = AocPuzzleParser.GetYearAndDay(GetType());
        var paddedDay = day.ToString().PadLeft(2, '0');
        var id = $"{year}{paddedDay}";
        SortId = id;
        Title = $"Advent of Code {year}-{paddedDay}";
        ListTitle = $"Aoc {year}-{paddedDay}";
        _year = year.ToString();
        _day = day.ToString();
    }

    protected override IEnumerable<string> CustomTags
    {
        get
        {
            yield return "aoc";
            yield return _year;
            yield return _day;
        }
    }
}