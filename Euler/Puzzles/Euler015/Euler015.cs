using Puzzles.Common.Puzzles;

namespace Pzl.Euler.Puzzles.Euler015;

public class Euler015 : EulerPuzzle
{
    public override string Name => "Lattice paths";

    protected override PuzzleResult Run()
    {
        var result = Run(20);
        return new PuzzleResult(result, "24564b04f61254168e07eb4d1c9df79f");
    }

    public long Run(int gridSize)
    {
        return PascalTriangle(gridSize).Max();
    }

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