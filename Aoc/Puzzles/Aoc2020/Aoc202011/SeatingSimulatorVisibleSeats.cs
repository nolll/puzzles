using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202011;

public class SeatingSimulatorVisibleSeats : SeatingSimulator
{
    public SeatingSimulatorVisibleSeats(string input) : base(input)
    {
    }

    protected override IList<char> GetAdjacentSeats()
    {
        var pos = Grid.Address;
        var values = new List<char?>
        {
            GetVisible(Grid.TryMoveUp, pos),
            GetVisible(TryMoveUpRight, pos),
            GetVisible(Grid.TryMoveRight, pos),
            GetVisible(TryMoveRightDown, pos),
            GetVisible(Grid.TryMoveDown, pos),
            GetVisible(TryMoveDownLeft, pos),
            GetVisible(Grid.TryMoveLeft, pos),
            GetVisible(TryMoveLeftUp, pos),
        };

        Grid.MoveTo(pos);

        return values.Where(o => o != null).Cast<char>().ToList();
    }

    protected override char GetSeatStatus(char currentValue, int neighborCount)
    {
        if (currentValue == EmptyChair && neighborCount == 0)
            return OccupiedChair;

        if (currentValue == OccupiedChair && neighborCount >= 5)
            return EmptyChair;

        return currentValue;
    }

    private char? GetVisible(Func<int, bool> func, Coord pos)
    {
        Grid.MoveTo(pos);
        while (func(1))
        {
            var v = Grid.ReadValue();
            if (v != Floor)
                return v;
        }

        return null;
    }

    private bool TryMoveUpRight(int steps) => Grid.TryMoveUp(steps) && Grid.TryMoveRight(steps);
    private bool TryMoveRightDown(int steps) => Grid.TryMoveRight(steps) && Grid.TryMoveDown(steps);
    private bool TryMoveDownLeft(int steps) => Grid.TryMoveDown(steps) && Grid.TryMoveLeft(steps);
    private bool TryMoveLeftUp(int steps) => Grid.TryMoveLeft(steps) && Grid.TryMoveUp(steps);
}