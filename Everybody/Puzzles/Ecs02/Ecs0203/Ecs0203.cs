using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs02.Ecs0203;

[Name("The Dice that Never Lie (Unless I Tell Them To)")]
public class Ecs0203 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var dice = new List<Die>();
        foreach (var line in lines)
        {
            var raw = Numbers.IntsFromString(line);
            var id = raw.First();
            var seed = raw.Last();
            var faces = raw.Skip(1).SkipLast(1).ToArray();
            dice.Add(new Die(id, seed, faces));
        }

        var score = 0;
        var rollCount = 0;
        while (score < 10_000)
        {
            foreach (var die in dice)
            {
                score += die.Roll(rollCount + 1);
            }

            rollCount++;
        }
        
        return new PuzzleResult(rollCount, "afba3780df3e7caae7832176dc41303e");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }

    private class Die(int id, int seed, int[] faces)
    {
        private readonly int _seed = seed;
        private int _pulse = seed;
        private int _face;
        
        public int Roll(int rollNumber)
        {
            var spin = rollNumber * _pulse;
            _face = (_face + spin) % faces.Length;
            _pulse += spin;
            _pulse %= _seed;
            _pulse = _pulse + 1 + rollNumber + _seed;
            return faces[_face];
        }
    }
}