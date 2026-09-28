using System.Text.RegularExpressions;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("No Matter How You Slice It")]
public class Aoc201803 : AocPuzzle
{
    [Puzzle("06a186fe1ad0ea2861a42fd9809e491e")]
    public int Part1(string input) => new ClaimsOverlapCountPuzzle(input).OverlapCount;

    [Puzzle("442af765a98dc2465a7db5a4e92167a4")]
    public int Part2(string input) => new ClaimThatDoesNotOverlapPuzzle(input).ClaimId;
    
    public class Claim
    {
        public int Id { get; }
        public int Left { get; }
        public int Top { get; }
        public int Width { get; }
        public int Height { get; }

        public Claim(int id, int left, int top, int width, int height)
        {
            Id = id;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }
    }
    
    public static class ClaimListReader
    {
        private static readonly Regex ClaimRegex = new(@"^#(\d+) @ (\d+),(\d+): (\d+)x(\d+)$");
        public static List<Claim> Read(string str) => str.Split(LineBreaks.Single).Select(ConvertToClaim).ToList();

        private static Claim ConvertToClaim(string str)
        {
            var match = ClaimRegex.Match(str);
            var id = GetGroupValue(match.Groups[1]);
            var left = GetGroupValue(match.Groups[2]);
            var top = GetGroupValue(match.Groups[3]);
            var width = GetGroupValue(match.Groups[4]);
            var height = GetGroupValue(match.Groups[5]);
            return new Claim(id, left, top, width, height);
        }

        private static int GetGroupValue(Group matchGroup) => int.Parse(matchGroup.Value);
    }
    
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
    
    public class OverlappingClaimNotFoundException : Exception
    {
        public OverlappingClaimNotFoundException()
            : base("No overlapping claim was found")
        {
        }
    }
}