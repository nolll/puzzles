using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody07;

[IsSlow] // 55s for part 3
[Name("Not Fast but Furious")]
public class Everybody07(string[] inputs) : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = Part1(inputs[0]);
        return new PuzzleResult(result, "05a999b2ab72fff505423f40ee4af56b");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = Part2(Part2Track, inputs[1]);
        return new PuzzleResult(result, "f315ce3865ed329f4eee3ec0d64bb032");
    }

    protected override PuzzleResult RunPart3()
    {
        var result = Part3(Part3Track, inputs[2]);
        return new PuzzleResult(result, "2945d46a4a840d740dfe233d50659d0c");
    }

    public static string Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var knights = new List<Knight>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var score = RunRace([0], BuildActions(parts[1]), 10);
            
            knights.Add(new Knight(parts[0], score));
        }

        return string.Join("", knights.OrderByDescending(o => o.Score).Select(o => o.Name));
    }
    
    public static string Part2(string trackString, string input)
    {
        const int loopCount = 10;
        
        var track = BuildTerrain(trackString);
        
        var lines = input.Split(LineBreaks.Single);
        var knights = new List<Knight>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var actions = BuildActions(parts[1]);
            var score = RunRace(track, actions, loopCount);
            
            knights.Add(new Knight(parts[0], score));
        }

        return string.Join("", knights.OrderByDescending(o => o.Score).Select(o => o.Name));
    }

    private static int Part3(string trackString, string input)
    {
        var loopCount = 2024;
        var track = BuildTerrain(trackString);
        var rivalActions = BuildActions(input.Split(':').Last());
        var rivalScore = RunRace(track, rivalActions, loopCount);
        var actionCombinations = GenerateActionCombinations();

        return actionCombinations.Select(action => RunRace(track, action, loopCount)).Count(o => o > rivalScore);
    }

    private static IEnumerable<int[]> GenerateActionCombinations()
    {
        return GenerateActionCombinations("", 11, ['+', '-', '='])
            .Select(BuildActions)
            .Where(o => o.Count(x => x == 0) == 3 && o.Count(x => x == -1) == 3 && o.Count(x => x == 1) == 5);
    }
    
    private static IEnumerable<string> GenerateActionCombinations(string s, int depth, char[] chars)
    {
        if (depth == 0)
            return [s];

        var a = new List<string>();
        foreach (var c in chars)
        {
            a.AddRange(GenerateActionCombinations(s + c, depth - 1, chars));
        }

        return a;
    }

    private static long RunRace(int[] track, int[] actions, int loopCount)
    {
        var actionCount = actions.Length;
        var power = InitialPower;
        var score = 0L;
        for (var i = 0; i < track.Length * loopCount; i++)
        {
            var actionIndex = i % actionCount;
            var trackIndex = i % track.Length;
            var action = actions[actionIndex];
            var trackAction = track[trackIndex];
            var actionToUse = trackAction is 0 ? action : trackAction; 
            power = Math.Max(0, power + actionToUse);
            
            score += power;
        }

        return score;
    }

    private static int[] BuildTerrain(string trackLoop)
    {
        var visited = new HashSet<MatrixAddress>();
        var terrain = new List<int>();
        var trackMatrix = MatrixBuilder.BuildCharMatrix(trackLoop, ' ');
        trackMatrix.MoveTo(trackMatrix.XMin, trackMatrix.YMin);
        trackMatrix.MoveRight();
        
        while (true)
        {
            terrain.Add(ConvertToInt(trackMatrix.ReadValue()));
            visited.Add(trackMatrix.Address);
            
            var next = trackMatrix.OrthogonalAdjacentCoords.FirstOrDefault(o =>
                !visited.Contains(o) && trackMatrix.ReadValueAt(o) != trackMatrix.DefaultValue);

            if (next is null)
                break;
            
            trackMatrix.MoveTo(next);
        }

        return terrain.ToArray();
    }

    private static int[] BuildActions(string actions) => BuildActions(actions.Replace(",", "").ToCharArray());
    private static int[] BuildActions(IEnumerable<char> actions) => actions.Select(ConvertToInt).ToArray();
    
    private static int ConvertToInt(char c) =>
        c switch
        {
            '+' => 1,
            '-' => -1,
            _ => 0
        };

    private record Knight(string Name, long Score);
    
    private const string Part2Track = """
                                      S-=++=-==++=++=-=+=-=+=+=--=-=++=-==++=-+=-=+=-=+=+=++=-+==++=++=-=-=--
                                      -                                                                     -
                                      =                                                                     =
                                      +                                                                     +
                                      =                                                                     +
                                      +                                                                     =
                                      =                                                                     =
                                      -                                                                     -
                                      --==++++==+=+++-=+=-=+=-+-=+-=+-=+=-=+=--=+++=++=+++==++==--=+=++==+++-
                                      """;
    
    private const string Part3Track = """
                                      S+= +=-== +=++=     =+=+=--=    =-= ++=     +=-  =+=++=-+==+ =++=-=-=--
                                      - + +   + =   =     =      =   == = - -     - =  =         =-=        -
                                      = + + +-- =-= ==-==-= --++ +  == == = +     - =  =    ==++=    =++=-=++
                                      + + + =     +         =  + + == == ++ =     = =  ==   =   = =++=       
                                      = = + + +== +==     =++ == =+=  =  +  +==-=++ =   =++ --= + =          
                                      + ==- = + =   = =+= =   =       ++--          +     =   = = =--= ==++==
                                      =     ==- ==+-- = = = ++= +=--      ==+ ==--= +--+=-= ==- ==   =+=    =
                                      -               = = = =   +  +  ==+ = = +   =        ++    =          -
                                      -               = + + =   +  -  = + = = +   =        +     =          -
                                      --==++++==+=+++-= =-= =-+-=  =+-= =-= =--   +=++=+++==     -=+=++==+++-
                                      """;

    private const int InitialPower = 10;
}