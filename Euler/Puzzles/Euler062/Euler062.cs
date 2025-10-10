using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler062;

[Name("Cubic Permutations")]
public class Euler062 : EulerPuzzle
{
    private const int SearchFor = 5;
    
    public PuzzleResult Run()
    {
        var n = 1;
        var cubes = new Dictionary<string, List<long>>();

        while (true)
        {
            var cube = (long)Math.Pow(n, 3);
            var key = string.Join("", cube.ToString().Order());
            if (!cubes.TryAdd(key, [cube]))
                cubes[key].Add(cube);

            if (cubes.Values.Max(o => o.Count) == SearchFor)
                break;
            
            n++;
        }

        var result = cubes.Values.MaxBy(o => o.Count)!.Min();
        
        return new PuzzleResult(result, "9ec99ac7e0cd756c60d4e894d6be9371");
    }

}