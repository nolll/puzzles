using System.Reflection.Metadata;
using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.CoordinateSystems.CoordinateSystem3D;
using Pzl.Tools.Graphs;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody14;

[Name("")]
public class Everybody14 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var y = 0;
        var miny = 0;
        var maxy = 0;

        foreach (var instr in input.Split(','))
        {
            var v = int.Parse(instr[1..]);
            if (instr.StartsWith("U"))
                y -= v;
            else if (instr.StartsWith("D")) 
                y += v;

            miny = Math.Min(y, miny);
            maxy = Math.Max(y, maxy);
        }

        var result = maxy - miny;
        
        return new PuzzleResult(result, "4d7ad96354959558ed0b95fa70be777c");
    }

    public PuzzleResult Part2(string input)
    {
        var seen = new HashSet<(int x, int y, int z)>();

        var lines = input.Split(LineBreaks.Single);
        foreach (var line in lines)
        {
            var x = 0;
            var y = 0;
            var z = 0;
            
            foreach (var instr in line.Split(','))
            {
                var v = int.Parse(instr[1..]);
                if (instr.StartsWith("R"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        x++;
                        seen.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("L"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        x--;
                        seen.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("U"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        y--;
                        seen.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("D"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        y++;
                        seen.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("F"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        z++;
                        seen.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("B"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        z--;
                        seen.Add((x, y, z));
                    }
                }
            }   
        }

        var result = seen.Count;
        
        return new PuzzleResult(result, "1ceb1e594b0f47c1b64f940bb505f9ce");
    }

    public PuzzleResult Part3(string input)
    {
        var leaves = new HashSet<(int x, int y, int z)>();
        var trunk = new HashSet<(int x, int y, int z)>();
        var coords = new HashSet<(int x, int y, int z)>();
        
        var lines = input.Split(LineBreaks.Single);
        foreach (var line in lines)
        {
            var x = 0;
            var y = 0;
            var z = 0;

            foreach (var instr in line.Split(','))
            {
                var v = int.Parse(instr[1..]);
                if (instr.StartsWith("R"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        x++;
                        coords.Add((x, y, z));
                        if (x == 0 && z == 0)
                            trunk.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("L"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        x--;
                        coords.Add((x, y, z));
                        if (x == 0 && z == 0)
                            trunk.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("U"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        y--;
                        coords.Add((x, y, z));
                        if (x == 0 && z == 0)
                            trunk.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("D"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        y++;
                        coords.Add((x, y, z));
                        if (x == 0 && z == 0)
                            trunk.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("F"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        z++;
                        coords.Add((x, y, z));
                        if (x == 0 && z == 0)
                            trunk.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("B"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        z--;
                        coords.Add((x, y, z));
                        if (x == 0 && z == 0)
                            trunk.Add((x, y, z));
                    }
                }
            }

            leaves.Add((x, y, z));
        }
        
        var inputs = new List<Graph.Input>();
        foreach (var coord in coords)
        {
            var nbrs = OrthogonalAdjacentCoords(coord);
            foreach (var nbr in nbrs)
            {
                if(coords.Contains(nbr)) 
                    inputs.Add(new Graph.Input(Id(coord), Id(nbr)));
            }
        }

        var best = int.MaxValue;
        foreach (var t in trunk)
        {
            var sum = leaves.Sum(leaf => Graph.GetLowestCost(inputs, Id(leaf), Id(t)));

            best = Math.Min(best, sum);
        }
        
        return new PuzzleResult(best, "55d3e09b26d9f60ed08c206a7505561f");
    }

    private static List<(int x, int y, int z)> OrthogonalAdjacentCoords((int x, int y, int z) coord)
    {
        var (x, y, z) = coord;
        return
        [
            (x + 1, y, z),
            (x - 1, y, z),
            (x, y + 1, z),
            (x, y - 1, z),
            (x, y, z + 1),
            (x, y, z - 1)
        ];
    }

    private static string Id((int x, int y, int z) coord) => $"{coord.x},{coord.y},{coord.z}";
}