namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201803;

public class FabricGridFactory
{
    public static int[,] Create(List<Claim> claims)
    {
        var grid = GetEmptyGrid(claims);
        foreach (var claim in claims)
        {
            for (var row = claim.Top; row < claim.Top + claim.Height; row++)
            {
                for (var col = claim.Left; col < claim.Left + claim.Width; col++)
                {
                    grid[col, row] += 1;
                }
            }
        }
        return grid;
    }

    private static int[,] GetEmptyGrid(List<Claim> claims)
    {
        var size = GetGridSize(claims);
        return new int[size.width, size.height];
    }

    private static (int width, int height) GetGridSize(List<Claim> claims)
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