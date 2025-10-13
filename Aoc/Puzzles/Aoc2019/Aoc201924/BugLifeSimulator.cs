using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201924;

public class BugLifeSimulator
{
    private Grid<char> _grid;

    public string String => string.Join("", _grid.Values);
    private readonly IList<string> _previousStrings;

    public BugLifeSimulator(string input)
    {
        _grid = BuildMatrix(input);
        _previousStrings = new List<string>();
    }

    public void Run(int iterations)
    {
        for (var i = 0; i < iterations; i++)
        {
            NextIteration();
        }
    }

    public void RunUntilRepeat()
    {
        while (true)
        {
            NextIteration();
            if (_previousStrings.Contains(String))
            {
                break;
            }
            _previousStrings.Add(String);
        }
    }

    private void NextIteration()
    {
        var newMatrix = new Grid<char>(1, 1);
        for (var y = 0; y < _grid.Height; y++)
        {
            for (var x = 0; x < _grid.Width; x++)
            {
                _grid.MoveTo(x, y);
                var currentValue = _grid.ReadValue();
                var adjacentValues = _grid.OrthogonalAdjacentValues;
                var neighborCount = adjacentValues.Count(o => o == '#');
                var newValue = GetNewValue(currentValue, neighborCount);
                newMatrix.MoveTo(x, y);
                newMatrix.WriteValue(newValue);
            }
        }

        _grid = newMatrix;
    }

    private char GetNewValue(char currentValue, int neighborCount)
    {
        if (currentValue == '#' && neighborCount != 1)
            return '.';

        if (currentValue == '.' && (neighborCount == 1 || neighborCount == 2))
            return '#';

        return currentValue;
    }

    public long BiodiversityRating
    {
        get
        {
            long totalScore = 0;
            var currentScore = 1;
            foreach (var c in _grid.Values)
            {
                if(c == '#')
                    totalScore += currentScore;
                currentScore *= 2;
            }

            return totalScore;
        }
    }

    private Grid<char> BuildMatrix(string map)
    {
        var matrix = new Grid<char>(1, 1);
        var rows = map.Trim().Split('\n');
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return matrix;
    }
}