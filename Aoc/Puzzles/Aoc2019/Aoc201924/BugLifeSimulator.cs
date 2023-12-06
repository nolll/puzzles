using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201924;

public class BugLifeSimulator
{
    private Matrix<char> _matrix;

    public string String => string.Join("", _matrix.Values);
    private readonly IList<string> _previousStrings;

    public BugLifeSimulator(string input)
    {
        _matrix = BuildMatrix(input);
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
        var newMatrix = new Matrix<char>(1, 1);
        for (var y = 0; y < _matrix.Height; y++)
        {
            for (var x = 0; x < _matrix.Width; x++)
            {
                _matrix.MoveTo(x, y);
                var currentValue = _matrix.ReadValue();
                var adjacentValues = _matrix.PerpendicularAdjacentValues;
                var neighborCount = adjacentValues.Count(o => o == '#');
                var newValue = GetNewValue(currentValue, neighborCount);
                newMatrix.MoveTo(x, y);
                newMatrix.WriteValue(newValue);
            }
        }

        _matrix = newMatrix;
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
            foreach (var c in _matrix.Values)
            {
                if(c == '#')
                    totalScore += currentScore;
                currentScore *= 2;
            }

            return totalScore;
        }
    }

    private Matrix<char> BuildMatrix(string map)
    {
        var matrix = new Matrix<char>(1, 1);
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