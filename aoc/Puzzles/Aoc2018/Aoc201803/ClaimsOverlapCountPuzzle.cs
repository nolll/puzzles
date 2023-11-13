namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201803;

public class ClaimsOverlapCountPuzzle
{
    public int OverlapCount { get; }

    public ClaimsOverlapCountPuzzle(string input)
    {
        var claims = ClaimListReader.Read(input);
        var matrix = FabricMatrixFactory.Create(claims);
        OverlapCount = GetOverlapCount(matrix);
    }

    private int GetOverlapCount(int[,] matrix)
    {
        var overlapCount = 0;
        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[col, row] > 1)
                    overlapCount++;
            }
        }

        return overlapCount;
    }
}