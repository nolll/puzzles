namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201814;

public class RecipeGenerator
{
    private readonly List<int> _scores;
    private int _elf1Pos;
    private int _elf2Pos;

    public RecipeGenerator()
    {
        _scores = new List<int> {3, 7};
        _elf1Pos = 0;
        _elf2Pos = 1;
    }

    public string ScoresAfter(in int input)
    {
        var i = 0;
        var target = input + 10;
        while (i < target)
        {
            var val1 = _scores.ElementAt(_elf1Pos);
            var val2 = _scores.ElementAt(_elf2Pos);
            var score = val1 + val2;
            var hasTwoDigits = score >= 10;
            _scores.Add(hasTwoDigits ? 1 : score);
            if (hasTwoDigits)
                _scores.Add(score - 10);
            _elf1Pos = GetElfPos(_elf1Pos, val1);
            _elf2Pos = GetElfPos(_elf2Pos, val2);
            i++;
        }

        var result = _scores.Skip(input).Take(10);
        return string.Concat(result.Select(o => o.ToString()));
    }

    public int RecipeCountBefore(in string input)
    {
        var lastEleven = "";
        while (!lastEleven.Contains(input))
        {
            var val1 = _scores.ElementAt(_elf1Pos);
            var val2 = _scores.ElementAt(_elf2Pos);
            var score = val1 + val2;
            var hasTwoDigits = score >= 10;
            _scores.Add(hasTwoDigits ? 1 : score);
            if (hasTwoDigits)
            {
                _scores.Add(score - 10);
            }

            lastEleven = string.Concat(_scores.TakeLast(11));
            _elf1Pos = GetElfPos(_elf1Pos, val1);
            _elf2Pos = GetElfPos(_elf2Pos, val2);
        }


        return string.Concat(_scores).IndexOf(input, StringComparison.InvariantCulture);
    }

    private int GetElfPos(in int currentPos, in int steps)
    {
        var newPos = currentPos + steps + 1;
        var maxPos = _scores.Count - 1;
        while (newPos > maxPos)
        {
            newPos -= _scores.Count;
        }

        return newPos;
    }
}