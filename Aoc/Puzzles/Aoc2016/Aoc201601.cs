using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("No Time for a Taxicab")]
public class Aoc201601 : AocPuzzle
{
    [Puzzle("1dd73ae9ac359d399e07fb888b022f7a")]
    public int Part1(string input)
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(input);
        return calc.DistanceToTarget;
    }

    [Puzzle("4648ca473c884f7676991b343c2db8e0")]
    public int Part2(string input)
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(input);
        return calc.DistanceToFirstRepeat;
    }
    
    public class EasterbunnyDistanceCalculator
    {
        private readonly Grid<int> _grid = new();
        private int? _distanceToFirstRepeatedAddress;

        public void Go(string input)
        {
            var instructions = input.Split(',').Select(o => o.Trim());
            _grid.TurnTo(GridDirection.Up);
            _grid.WriteValue(1);
            foreach (var instruction in instructions)
            {
                var direction = instruction.Substring(0, 1);
                var distance = int.Parse(instruction.Substring(1));
                if (direction == "R")
                    _grid.TurnRight();
                else
                    _grid.TurnLeft();
            
                for (var i = 0; i < distance; i++)
                {
                    _grid.MoveForward();
                    if (_grid.ReadValue() == 1 && _distanceToFirstRepeatedAddress == null)
                    {
                        _distanceToFirstRepeatedAddress = _grid.StartCoord.ManhattanDistanceTo(_grid.Coord);
                    }
                    _grid.WriteValue(1);
                }
            }
        }

        public int DistanceToTarget => _grid.StartCoord.ManhattanDistanceTo(_grid.Coord);
        public int DistanceToFirstRepeat => _distanceToFirstRepeatedAddress ?? 0;
    }
}