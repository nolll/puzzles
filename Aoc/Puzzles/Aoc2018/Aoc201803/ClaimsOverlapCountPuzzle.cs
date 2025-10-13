namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201803;

public class ClaimsOverlapCountPuzzle
{
    public int OverlapCount { get; }

    public ClaimsOverlapCountPuzzle(string input)
    {
        var claims = ClaimListReader.Read(input);
        var grid = FabricGridFactory.Create(claims);
        OverlapCount = GetOverlapCount(grid);
    }

    private int GetOverlapCount(int[,] grid)
    {
        var overlapCount = 0;
        for (var row = 0; row < grid.GetLength(0); row++)
        {
            for (var col = 0; col < grid.GetLength(1); col++)
            {
                if (grid[col, row] > 1)
                    overlapCount++;
            }
        }

        return overlapCount;
    }
}