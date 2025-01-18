using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody19;

[Name("Encrypted Duck")]
public class Everybody19 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = Run(input, 1);
        return new PuzzleResult(result, "d9c02c79770322919192525a442c576d");
    }

    public PuzzleResult Part2(string input)
    {
        var result = Run(input, 100);
        return new PuzzleResult(result, "81f686ab8d66b6fc14b37f46ec85d6f2");
    }
    
    public PuzzleResult Part3(string input)
    {
        var result = Run(input, 1048576000);
        return new PuzzleResult(result);
    }

    private string Run(string input, int repetitionCount)
    {
        var (directions, encryptedMessage) = input.Split(LineBreaks.Double);
        var lines = encryptedMessage.Split(LineBreaks.Single);
        var width = lines[0].Length;
        var height = lines.Length;
        var allchars = string.Join("", lines).ToCharArray();
        (int dx, int dy)[] coordDeltas = [(0, -1), (1, -1), (1, 0), (1, 1), (0, 1), (-1, 1), (-1, 0), (-1, -1)];
        // var seen = new HashSet<string>();
        
        for (var r = 0; r < repetitionCount; r++)
        {
            var directionIndex = 0;
            for (var y = 1; y < height - 1; y++)
            {
                for (var x = 1; x < width - 1; x++)
                {
                    var charPositions = coordDeltas
                        .Select(o => (y + o.dy) * width + x + o.dx).ToArray();
                    var movechars = string.Join("", charPositions.Select(o => allchars[o]));
                    var direction = directions[directionIndex % directions.Length];
                    var delta = direction == 'L' ? -1 : 1;
            
                    for (var i = 0; i < charPositions.Length; i++)
                    {
                        var index = (i + delta + charPositions.Length) % charPositions.Length;
                        allchars[charPositions[index]] = movechars[i];
                    }

                    directionIndex++;
                }
            }

            // var key = string.Join("", allchars);
            // if (seen.Contains(key))
            // {
                // Console.WriteLine(r);
            //}
            //seen.Add(key);

            var sc = allchars.IndexOf('>');
            var ec = allchars.IndexOf('<');
            if (ec < sc)
                continue;
            
            var s = sc + 1;
            var l = ec - s;
            var ss = string.Join("", allchars).Substring(s, l);
            
            if(!ss.Contains('.'))
                Console.WriteLine($"-- {ss} --");
        }
        
        var print = string.Join("", allchars);
        var start = print.IndexOf('>') + 1;
        var length = print.IndexOf('<') - start;
        
        for (int i = 0; i < print.Length; i += width)
        {
            Console.WriteLine(print.Substring(i, width));
        }
        
        return print.Substring(start, length);
    }
}