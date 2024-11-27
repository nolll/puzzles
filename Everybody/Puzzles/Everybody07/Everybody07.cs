using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody07;

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
        return PuzzleResult.Empty;
    }

    public static string Part1(string input)
    {
        const int initialPower = 10;
        const int trackLength = 10;
        
        var lines = input.Split(LineBreaks.Single);
        var knights = new List<Knight>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var knight = new Knight
            {
                Name = parts[0]
            };
            var actions = parts[1].Split(',').ToArray();
            var actionCount = actions.Length;
            var power = initialPower;
            for (var i = 0; i < trackLength; i++)
            {
                var action = actions[i % actionCount];
                if (action == "+")
                    power++;
                else if (action == "-")
                    power = Math.Max(0, power - 1);
                
                knight.Score += power;
            }
            
            knights.Add(knight);
        }

        return string.Join("", knights.OrderByDescending(o => o.Score).Select(o => o.Name));
    }
    
    public static string Part2(string trackLoop, string input)
    {
        const int initialPower = 10;
        const int loopCount = 10;

        var flatTrack = BuildFlatTrack(trackLoop);
        var trackLength = flatTrack.Length;
        
        var lines = input.Split(LineBreaks.Single);
        var knights = new List<Knight>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var knight = new Knight
            {
                Name = parts[0]
            };
            var actions = parts[1].Split(',').ToArray();
            var actionCount = actions.Length;
            var power = initialPower;
            for (var i = 0; i < trackLength * loopCount; i++)
            {
                var action = actions[i % actionCount];
                var terrain = flatTrack[i % trackLength];

                if (terrain is '=' or 'S')
                {
                    if (action == "+")
                        power++;
                    else if (action == "-")
                        power = Math.Max(0, power - 1);
                }
                else
                {
                    if (terrain == '+')
                        power++;
                    else if (terrain == '-')
                        power = Math.Max(0, power - 1);
                }
                
                knight.Score += power;
            }
            
            knights.Add(knight);
        }

        return string.Join("", knights.OrderByDescending(o => o.Score).Select(o => o.Name));
    }

    private static string BuildFlatTrack(string trackLoop)
    {
        var trackMatrix = MatrixBuilder.BuildCharMatrix(trackLoop);
        trackMatrix.MoveTo(trackMatrix.XMin, trackMatrix.YMin);
        var currentChar = ' ';
        var s = "";
        trackMatrix.TurnRight();
        while (currentChar != 'S')
        {
            if (!trackMatrix.TryMoveForward())
            {
                trackMatrix.TurnRight();
                trackMatrix.MoveForward();
            }

            currentChar = trackMatrix.ReadValue();
            s += currentChar;
        }

        return s;
    }

    private class Knight
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    
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
}