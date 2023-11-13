using Puzzles.common.Puzzles;

namespace Puzzles.aoc;

public abstract class AocPuzzle : TwoPartsPuzzle
{
    private readonly string _year;
    private readonly string _day;

    public override string Id { get; }
    public override string SortId { get; }
    public override string Title { get; }
    public override string ListTitle { get; }
    protected override string CollectionTag => PuzzleTag.Aoc;

    protected AocPuzzle()
    {
        var (year, day) = AocPuzzleParser.GetYearAndDay(GetType());
        var paddedDay = day.ToString().PadLeft(2, '0');
        var id = $"{year}{paddedDay}";
        Id = id;
        SortId = id;
        Title = $"Advent of Code {year}-{paddedDay}";
        ListTitle = $"{PuzzleTag.Aoc} {year}-{paddedDay}";
        _year = year.ToString();
        _day = day.ToString();
    }

    protected override IEnumerable<string> CustomTags
    {
        get
        {
            yield return _year;
            yield return _day;
        }
    }
}