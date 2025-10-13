using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202011;

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
        var newMatrix = Grid.Clone();

        foreach (var coord in Grid.Coords)
        {
            Grid.MoveTo(coord);
            var currentValue = Grid.ReadValue();
            var adjacentValues = GetAdjacentSeats();
            var neighborCount = adjacentValues.Count(o => o == OccupiedChair);
            var newValue = GetSeatStatus(currentValue, neighborCount);

            newMatrix.MoveTo(coord);
            newMatrix.WriteValue(newValue);
        }
        
        Grid = newMatrix;
    }

    protected abstract IList<char> GetAdjacentSeats();
    protected abstract char GetSeatStatus(char currentValue, int neighborCount);
}