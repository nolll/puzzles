namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201803;

public class FabricMatrixFactory
{
    public static int[,] Create(List<Claim> claims)
    {
        var matrix = GetEmptyMatrix(claims);
        foreach (var claim in claims)
        {
            for (var row = claim.Top; row < claim.Top + claim.Height; row++)
            {
                for (var col = claim.Left; col < claim.Left + claim.Width; col++)
                {
                    matrix[col, row] += 1;
                }
            }
        }
        return matrix;
    }

    private static int[,] GetEmptyMatrix(List<Claim> claims)
    {
        var size = GetMatrixSize(claims);
        return new int[size.width, size.height];
    }

    private static (int width, int height) GetMatrixSize(List<Claim> claims)
    {
        var width = 0;
        var height = 0;
        foreach (var claim in claims)
        {
            var requiredClaimWidth = claim.Left + claim.Width;
            if (requiredClaimWidth > width)
                width = requiredClaimWidth;

            var requiredClaimHeight = claim.Top + claim.Height;
            if (requiredClaimHeight > height)
                height = requiredClaimHeight;
        }

        return (width, height);
    }
}