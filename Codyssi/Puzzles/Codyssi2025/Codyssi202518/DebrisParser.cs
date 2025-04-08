using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202518;

public static class DebrisParser
{
    public static DebrisSystem Parse(string input, int sizex, int sizey, int sizez)
    {
        var rules = input.Split(LineBreaks.Single);
        var coords = GetCoords(sizex, sizey, sizez).ToArray();
        var debris = GetDebris(rules, coords).ToArray();
        return new DebrisSystem(sizex, sizey, sizez, debris);
    }

    private static IEnumerable<Debris> GetDebris(IEnumerable<string> rules, (int x, int y, int z, int w)[] coords)
    {
        foreach (var (_, x, y, z, w, divide, remainder, vx, vy, vz, vw) in rules.Select(Numbers.IntsFromString))
        {
            foreach (var c in coords)
            {
                var sum = c.x * x + c.y * y + c.z * z + c.w * w;
                var res = (sum % divide + divide) % divide; 
                if (res == remainder) 
                    yield return new Debris(c.x, c.y, c.z, c.w, vx, vy, vz, vw);
            }
        }
    }

    private static IEnumerable<(int x, int y, int z, int w)> GetCoords(int sizex, int sizey, int sizez)
    {
        for (var x = 0; x < sizex; x++)
        {
            for (var y = 0; y < sizey; y++)
            {
                for (var z = 0; z < sizez; z++)
                {
                    for (var w = -1; w < 2; w++)
                    {
                        yield return (x, y, z, w);
                    }
                }
            }
        }
    }
}