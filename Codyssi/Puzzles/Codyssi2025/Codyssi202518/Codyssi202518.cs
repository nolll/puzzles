using Pzl.Common;
using Pzl.Tools.Debug;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202518;

[Name("Cataclysmic Escape")]
public class Codyssi202518 : CodyssiPuzzle
{
    private const int SizeX = 10;
    private const int SizeY = 15;
    private const int SizeZ = 60;

    public PuzzleResult Part1(string input)
    {
        var result = RunPart1(input, SizeX, SizeY, SizeZ);
        return new PuzzleResult(result, "a8c76203a26abde805a1a11cbd419b79");
    }
    
    public PuzzleResult Part2(string input)
    {
        const int acceptableDamage = 0;
        var result = RunPart2And3(input, SizeX, SizeY, SizeZ, acceptableDamage);
        return new PuzzleResult(result, "c8dcfc39bf271a441c80feaf46160a32");
    }
    
    public PuzzleResult Part3(string input)
    {
        const int acceptableDamage = 3;
        var result = RunPart2And3(input, SizeX, SizeY, SizeZ, acceptableDamage);
        return new PuzzleResult(result, "f81b4b34e7f317b195c2bfb97a67f3de");
    }

    public int RunPart1(string input, int sizex, int sizey, int sizez) => 
        DebrisParser.Parse(input, sizex, sizey, sizez).Count;
    
    public int RunPart2And3(string input, int sizex, int sizey, int sizez, int acceptableDamage)
    {
        var tx = sizex - 1;
        var ty = sizey - 1;
        var tz = sizez - 1;
        const int tw = 0;

        var debrisSystem = DebrisParser.Parse(input, sizex, sizey, sizez);
        
        var seen = new HashSet<(int x, int y, int z, int w, int damage, int time)>();
        var queue = new Queue<(int x, int y, int z, int w, int damage, int time)>();
        queue.Enqueue((0, 0, 0, 0, 0, 0));
        
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var (x, y, z, w, damage, time) = current;

            var isTarget = x == tx && y == ty && z == tz && w == tw;
            if (isTarget)
                return time;
            
            if (!seen.Add(current))
                continue;

            var newtime = time + 1;
            
            foreach (var adj in debrisSystem.GetAdjacent((x, y, z, w), newtime))
            {
                var (ax, ay, az, aw, ad) = adj;
                var nd = IsStart(adj) ? damage : damage + ad;

                if (nd > acceptableDamage)
                    continue;
                
                var a = (ax, ay, az, aw, nd, newtime);
                if (seen.Contains(a))
                    continue;
                
                queue.Enqueue(a);
            }
        }

        return 0;
    }
    
    private static bool IsStart((int x, int y, int z, int w, int _) coord) => coord is { x: 0, y: 0, z: 0, w: 0 };
}