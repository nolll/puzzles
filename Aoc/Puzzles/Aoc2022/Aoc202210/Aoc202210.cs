using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202210;

[Name("Cathode-Ray Tube")]
public class Aoc202210(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var tube = new CathodeRayTube();
        var (result, _, _) = tube.Run(input);

        return new PuzzleResult(result, "cbd8f00e296a6ea077faf3fd0363b201");
    }

    protected override PuzzleResult RunPart2()
    {
        var tube = new CathodeRayTube();
        var (_, result, _) = tube.Run(input);

        return new PuzzleResult(result, "0b3ccbb8211fc474bd2156e662bf15fd");
    }
}