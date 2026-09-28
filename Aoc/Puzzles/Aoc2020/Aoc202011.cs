using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Seating System")]
public class Aoc202011 : AocPuzzle
{
    [Puzzle("808ef3d15c0093a702b0f3d80b8108fe")]
    public int Part1(string input)
    {
        var simulator = new SeatingSimulatorAdjacentSeats(input);
        simulator.Run();
        return simulator.OccupiedSeatCount;
    }

    [Puzzle("7f305c2d3f92fba8601b1e43706ebc6c")]
    public int Part2(string input)
    {
        var simulator = new SeatingSimulatorVisibleSeats(input);
        simulator.Run();
        return simulator.OccupiedSeatCount;
    }
    
    public abstract class SeatingSimulator
    {
        protected const char Floor = '.';
        protected const char OccupiedChair = '#';
        protected const char EmptyChair = 'L';

        protected Grid<char> Grid;
        public int OccupiedSeatCount { get; private set; }

        protected SeatingSimulator(string input)
        {
            Grid = GridBuilder.BuildCharGrid(input);
        }

        public void Run()
        {
            var prevCount = 0;
            var currentCount = -1;
            while (prevCount != currentCount)
            {
                prevCount = currentCount;
                RunOnce();
                currentCount = Grid.Values.Count(o => o == OccupiedChair);
            }

            OccupiedSeatCount = currentCount;
        }

        private void RunOnce()
        {
            var newGrid = Grid.Clone();

            foreach (var coord in Grid.Coords)
            {
                Grid.MoveTo(coord);
                var currentValue = Grid.ReadValue();
                var adjacentValues = GetAdjacentSeats();
                var neighborCount = adjacentValues.Count(o => o == OccupiedChair);
                var newValue = GetSeatStatus(currentValue, neighborCount);

                newGrid.MoveTo(coord);
                newGrid.WriteValue(newValue);
            }
        
            Grid = newGrid;
        }

        protected abstract IList<char> GetAdjacentSeats();
        protected abstract char GetSeatStatus(char currentValue, int neighborCount);
    }
    
    public class SeatingSimulatorAdjacentSeats : SeatingSimulator
    {
        public SeatingSimulatorAdjacentSeats(string input) : base(input)
        {

        }

        protected override IList<char> GetAdjacentSeats()
        {
            return Grid.AllAdjacentValues;
        }

        protected override char GetSeatStatus(char currentValue, int neighborCount)
        {
            if (currentValue == EmptyChair && neighborCount == 0)
                return OccupiedChair;

            if (currentValue == OccupiedChair && neighborCount >= 4)
                return EmptyChair;

            return currentValue;
        }
    }
    
    public class SeatingSimulatorVisibleSeats : SeatingSimulator
    {
        public SeatingSimulatorVisibleSeats(string input) : base(input)
        {
        }

        protected override IList<char> GetAdjacentSeats()
        {
            var pos = Grid.Coord;
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
}