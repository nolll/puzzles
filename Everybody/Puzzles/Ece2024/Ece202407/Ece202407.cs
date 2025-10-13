using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202407;

[Name("Not Fast but Furious")]
public class Ece202407 : EverybodyEventPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var knights = new List<Knight>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var score = RunRace([0], BuildActions(parts[1]), 10);
            
            knights.Add(new Knight(parts[0], score));
        }

        var result = string.Join("", knights.OrderByDescending(o => o.Score).Select(o => o.Name));
        
        return new PuzzleResult(result, "05a999b2ab72fff505423f40ee4af56b");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = Part2(Part2Track, input);
        return new PuzzleResult(result, "f315ce3865ed329f4eee3ec0d64bb032");
    }

    public PuzzleResult RunPart3(string input)
    {
        var result = Part3(Part3Track, input);
        return new PuzzleResult(result, "2945d46a4a840d740dfe233d50659d0c");
    }

    public string Part2(string trackString, string input)
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
        var track = BuildTerrain(trackString);
        var rivalActions = BuildActions(input.Split(':').Last());
        var loopsNeeded = rivalActions.Length;
        var rivalScore = RunRace(track, rivalActions, loopsNeeded);
        return GenerateActionCombinations()
            .Select(action => RunRace(track, action, loopsNeeded))
            .Count(o => o > rivalScore);
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
        var visited = new HashSet<Coord>();
        var terrain = new List<int>();
        var trackGrid = GridBuilder.BuildCharGrid(trackLoop, ' ');
        trackGrid.MoveTo(trackGrid.XMin, trackGrid.YMin);
        trackGrid.MoveRight();
        
        while (true)
        {
            terrain.Add(ConvertToInt(trackGrid.ReadValue()));
            visited.Add(trackGrid.Coord);
            
            var next = trackGrid.OrthogonalAdjacentCoords.FirstOrDefault(o =>
                !visited.Contains(o) && trackGrid.ReadValueAt(o) != trackGrid.DefaultValue);

            if (next is null)
                break;
            
            trackGrid.MoveTo(next);
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