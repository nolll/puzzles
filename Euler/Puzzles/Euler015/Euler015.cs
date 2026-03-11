using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler015;

[Name("Lattice paths")]
public class Euler015 : EulerPuzzle
{
    [Puzzle("24564b04f61254168e07eb4d1c9df79f")]
    public long Solve() => Solve(20);
    public long Solve(int gridSize) => PascalTriangle(gridSize).Max();

    private static IEnumerable<long> PascalTriangle(int levels)
    {
        var list = new List<long> {1};
        for (var i = 0; i < levels; i++)
        {
            list = ExpandTriangle(list.ToList());
            list = ExpandTriangle(list.ToList());
        }

        return list;
    }

    private static List<long> ExpandTriangle(IReadOnlyList<long> lastList)
    {
        var list = new List<long> {1};
        for (var i = 1; i < lastList.Count; i++)
        {
            var a = lastList[i - 1];
            var b = lastList[i];
            list.Add(a + b);
        }
            
        list.Add(1);

        return list;
    }
}