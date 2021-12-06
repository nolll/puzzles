using System.Collections.Generic;

namespace Core.Puzzles.Year2018.Day03
{
    public class ClaimThatDoesNotOverlapPuzzle
    {
        public int ClaimId { get; }

        public ClaimThatDoesNotOverlapPuzzle(string input)
        {
            var claims = ClaimListReader.Read(input);
            var matrix = FabricMatrixFactory.Create(claims);
            var claim = FindNonOverlappingClaim(matrix, claims);
            ClaimId = claim.Id;
        }

        private Claim FindNonOverlappingClaim(int[,] matrix, List<Claim> claims)
        {
            foreach (var claim in claims)
            {
                var overlaps = 0;
                for (var row = claim.Top; row < claim.Top + claim.Height; row++)
                {
                    for (var col = claim.Left; col < claim.Left + claim.Width; col++)
                    {
                        if (matrix[col, row] > 1)
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
}