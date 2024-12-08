using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202408;

[Name("Resonant Collinearity")]
public class Aoc202408 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input, '.');
        var count = FindAntinodes1(matrix).Count;
        
        return new PuzzleResult(count, "af57e33340c00c6ce0f53d7c2f21f201");
    }
    
    public PuzzleResult Part2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input, '.');
        var count = FindAntinodes2(matrix).Count;
        
        return new PuzzleResult(count, "e01777da998c6b596501f3853bd26a8d");
    }

    private static List<MatrixAddress> FindAntinodes1(Matrix<char> matrix)
    {
        var antinodes = new HashSet<MatrixAddress>();
        var types = matrix.Values.Distinct().Where(o => o != matrix.DefaultValue);
        foreach (var type in types)
        {
            var antennas = matrix.FindAddresses(type);
            var pairs = GetPairs(antennas);
            foreach (var pair in pairs)
            {
                var absDiff = new MatrixAddress(Math.Abs(pair.b.X - pair.a.X), Math.Abs(pair.b.Y - pair.a.Y));
                
                var adx = pair.a.X > pair.b.X ? absDiff.X : -absDiff.X;
                var ady = pair.a.Y > pair.b.Y ? absDiff.Y : -absDiff.Y;
                var bdx = pair.b.X > pair.a.X ? absDiff.X : -absDiff.X;
                var bdy = pair.b.Y > pair.a.Y ? absDiff.Y : -absDiff.Y;
                
                MatrixAddress[] nodes =
                [
                    new(pair.a.X + adx, pair.a.Y + ady),
                    new(pair.b.X + bdx, pair.b.Y + bdy)
                ];
                
                antinodes.AddRange(nodes.Where(o => !matrix.IsOutOfRange(o)));
            }
        }
        
        return antinodes.ToList();
    }
    
    private static List<MatrixAddress> FindAntinodes2(Matrix<char> matrix)
    {
        var antinodes = new HashSet<MatrixAddress>();
        var types = matrix.Values.Distinct().Where(o => o != matrix.DefaultValue);
        foreach (var type in types)
        {
            var antennas = matrix.FindAddresses(type);
            var pairs = GetPairs(antennas);
            foreach (var pair in pairs)
            {
                var absDiff = new MatrixAddress(Math.Abs(pair.b.X - pair.a.X), Math.Abs(pair.b.Y - pair.a.Y));
                
                var adx = pair.a.X > pair.b.X ? absDiff.X : -absDiff.X;
                var ady = pair.a.Y > pair.b.Y ? absDiff.Y : -absDiff.Y;
                var bdx = pair.b.X > pair.a.X ? absDiff.X : -absDiff.X;
                var bdy = pair.b.Y > pair.a.Y ? absDiff.Y : -absDiff.Y;

                var dir0 = pair.a;
                while (!matrix.IsOutOfRange(dir0))
                {
                    antinodes.Add(dir0);
                    dir0 = new MatrixAddress(dir0.X + adx, dir0.Y + ady);
                }
                    
                var dir1 = pair.b;
                while (!matrix.IsOutOfRange(dir1))
                {
                    antinodes.Add(dir1);
                    dir1 = new MatrixAddress(dir1.X + bdx, dir1.Y + bdy);
                }
            }
        }
        
        return antinodes.ToList();
    }

    private static IEnumerable<(MatrixAddress a, MatrixAddress b)> GetPairs(IList<MatrixAddress> antennas)
    {
        for (var i = 0; i < antennas.Count; i++)
        {
            for (var j = 0; j < antennas.Count; j++)
            {
                if (i == j) 
                    continue;
                
                MatrixAddress[] pair = [antennas[i], antennas[j]];
                pair = pair.OrderBy(o => o.Y).ThenBy(o => o.X).ToArray();
                yield return (pair[0], pair[1]);
            }
        }
    }
}