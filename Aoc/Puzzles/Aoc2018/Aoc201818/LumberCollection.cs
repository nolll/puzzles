using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201818;

public class LumberCollection
{
    private const char Open = '.';
    private const char Wood = '|';
    private const char Lumber = '#';

    private Grid<char> _grid;
    private int LumberCount => _grid.Values.Count(o => o == Lumber);
    private int WoodCount => _grid.Values.Count(o => o == Wood);
    public int ResourceValue => LumberCount * WoodCount;

    public LumberCollection(string input)
    {
        _grid = GridBuilder.BuildCharGrid(input);
    }

    public void Run(int minutes)
    {
        var foundPeriod = false;
        var earlierLayouts = new List<string> {_grid.Print()};
        for (var i = 0; i < minutes; i++)
        {
            _grid = GetNextIteration();

            if (!foundPeriod)
            {
                var print = _grid.Print();
                var earlierIndex = earlierLayouts.IndexOf(print);
                if (earlierIndex != -1)
                {
                    foundPeriod = true;
                    var period = i - earlierIndex + 1;
                    while (i < minutes)
                    {
                        i += period;
                    }

                    i -= period;
                }

                earlierLayouts.Add(print);
            }
        }
    }

    private Grid<char> GetNextIteration()
    {
        var newMatrix = new Grid<char>();
        for (var y = 0; y < _grid.Height; y++)
        {
            for (var x = 0; x < _grid.Width; x++)
            {
                _grid.MoveTo(x, y);
                newMatrix.MoveTo(x, y);
                newMatrix.WriteValue(GetNewValue());
            }
        }
        return newMatrix;
    }

    private char GetNewValue()
    {
        var adjacent = _grid.AllAdjacentValues;
        var currentValue = _grid.ReadValue();
        if (currentValue == Open)
            return adjacent.Count(o => o == Wood) >= 3 ? Wood : currentValue;
        if (currentValue == Wood)
            return adjacent.Count(o => o == Lumber) >= 3 ? Lumber : currentValue;
        if (currentValue == Lumber)
            return adjacent.Count(o => o == Lumber) >= 1 && adjacent.Count(o => o == Wood) >= 1 ? Lumber : Open;

        return Open;
    }
}