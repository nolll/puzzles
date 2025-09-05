using System.IO;
using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs02.Ecs0203;

[Name("The Dice that Never Lie (Unless I Tell Them To)")]
public class Ecs0203 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var dice = ParseDice(input);

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
        var (diceInput, racetrackInput) = input.Split(LineBreaks.Double);
        var dice = ParseDice(diceInput);
        var racetrack = racetrackInput.ToCharArray().Select(o => int.Parse(o.ToString())).ToArray();
        var goal = racetrack.Length;
        var players = dice.Select(o => new Player(o.Id, o)).ToList();
        var done = new List<Player>();
        
        var rollCount = 1;
        while (players.Any(o => o.Position < goal))
        {
            for (var i = 0; i < players.Count; i++)
            {
                var player = players[i];
                if (player.Position == goal)
                    continue;

                var score = player.Die.Roll(rollCount);

                if (racetrack[player.Position] == score)
                    player.Position++;
                
                if(player.Position == goal)
                    done.Add(player);
            }
            
            rollCount++;
        }

        var result = string.Join(",", done.Select(o => o.Id));
        return new PuzzleResult(result, "7171b572bda6f1b6df3618de04406256");
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }

    private static Die[] ParseDice(string input)
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

        return dice.ToArray();
    }

    private class Die(int id, int seed, int[] faces)
    {
        public int Id { get; } = id;
        private readonly int _seed = seed;
        private long _pulse = seed;
        private int _face;
        
        public int Roll(int rollNumber)
        {
            var spin = rollNumber * _pulse;
            _face = (int)((_face + spin) % faces.Length);
            _pulse += spin;
            _pulse %= _seed;
            _pulse = _pulse + 1 + rollNumber + _seed;
            var result = faces[_face];
            return result;
        }
    }

    private class Player(int id, Die die)
    {
        public int Id { get; set; } = id;
        public Die Die { get; set; } = die;
        public int Position { get; set; } = 0;
    }
}