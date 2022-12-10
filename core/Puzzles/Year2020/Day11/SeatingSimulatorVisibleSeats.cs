using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2020.Day11;

public class SeatingSimulatorVisibleSeats : SeatingSimulator
{
    public SeatingSimulatorVisibleSeats(string input) : base(input)
    {
    }

    protected override IList<char> GetAdjacentSeats()
    {
        var pos = Matrix.Address;
        var values = new List<char?>
        {
            GetVisible(Matrix.TryMoveUp, pos),
            GetVisible(TryMoveUpRight, pos),
            GetVisible(Matrix.TryMoveRight, pos),
            GetVisible(TryMoveRightDown, pos),
            GetVisible(Matrix.TryMoveDown, pos),
            GetVisible(TryMoveDownLeft, pos),
            GetVisible(Matrix.TryMoveLeft, pos),
            GetVisible(TryMoveLeftUp, pos),
        };

        Matrix.MoveTo(pos);

        return values.Where(o => o != null).Select(o => o.Value).ToList();
    }

    protected override char GetSeatStatus(char currentValue, int neighborCount)
    {
        if (currentValue == EmptyChair && neighborCount == 0)
            return OccupiedChair;

        if (currentValue == OccupiedChair && neighborCount >= 5)
            return EmptyChair;

        return currentValue;
    }

    private char? GetVisible(Func<int, bool> func, MatrixAddress pos)
    {
        Matrix.MoveTo(pos);
        while (func(1))
        {
            var v = Matrix.ReadValue();
            if (v != Floor)
                return v;
        }

        return null;
    }

    private bool TryMoveUpRight(int steps) => Matrix.TryMoveUp(steps) && Matrix.TryMoveRight(steps);
    private bool TryMoveRightDown(int steps) => Matrix.TryMoveRight(steps) && Matrix.TryMoveDown(steps);
    private bool TryMoveDownLeft(int steps) => Matrix.TryMoveDown(steps) && Matrix.TryMoveLeft(steps);
    private bool TryMoveLeftUp(int steps) => Matrix.TryMoveLeft(steps) && Matrix.TryMoveUp(steps);
}