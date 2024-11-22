namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202307;

public abstract class PokerHandComparer(int jackValue) : IComparer<PokerHand>
{
    private readonly Dictionary<char, int> _charValues = new()
    {
        { 'A', 14 },
        { 'K', 13 },
        { 'Q', 12 },
        { 'J', jackValue },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 },
    };

    protected int Compare(string a, string b)
    {
        var aArray = a.ToCharArray();
        var bArray = b.ToCharArray();

        for (var i = 0; i < a.Length; i++)
        {
            if (aArray[i] != bArray[i])
                return _charValues[aArray[i]].CompareTo(_charValues[bArray[i]]);
        }

        return 0;
    }

    public abstract int Compare(PokerHand? x, PokerHand? y);
}