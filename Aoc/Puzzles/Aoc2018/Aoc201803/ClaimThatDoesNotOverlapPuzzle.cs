namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201803;

public class ClaimThatDoesNotOverlapPuzzle
{
    public int ClaimId { get; }

    public ClaimThatDoesNotOverlapPuzzle(string input)
    {
        var claims = ClaimListReader.Read(input);
        var grid = FabricGridFactory.Create(claims);
        var claim = FindNonOverlappingClaim(grid, claims);
        ClaimId = claim.Id;
    }

    private Claim FindNonOverlappingClaim(int[,] grid, List<Claim> claims)
    {
        foreach (var claim in claims)
        {
            var overlaps = 0;
            for (var row = claim.Top; row < claim.Top + claim.Height; row++)
            {
                for (var col = claim.Left; col < claim.Left + claim.Width; col++)
                {
                    if (grid[col, row] > 1)
                        overlaps++;
                }
            }

            if (overlaps == 0)
            {
                return claim;
            }
        }

        throw new OverlappingClaimNotFoundException();
    }
}