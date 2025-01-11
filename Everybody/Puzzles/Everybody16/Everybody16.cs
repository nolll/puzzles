using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody16;

[Name("Cat Grin of Fortune")]
public class Everybody16 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var increments = parts[0].Split(',').Select(int.Parse).ToArray();
        var wheels = new List<List<string>>();
        
        for (var i = 0; i < increments.Length; i++)
        {
            var s = i * 4;
            var wheel = new List<string>();
                
            foreach (var line in parts[1].Split(LineBreaks.Single))
            {
                if (line.Length <= s)
                    break;

                var cat = line.Substring(s, 3);
                if (cat == "   ")
                    break;
                
                wheel.Add(cat);
            }
            
            wheels.Add(wheel);
        }

        var cats = new List<string>();
        for (var i = 0; i < wheels.Count; i++)
        {
            var wheel = wheels[i];
            var cat = wheel[100 * increments[i] % wheel.Count];
            cats.Add(cat);
        }

        var result = string.Join(" ", cats);
        
        return new PuzzleResult(result, "1a56d927da3da48fad02fb78b95a91cb");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}