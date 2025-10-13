using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.HashSets;
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
            score += dice.Sum(die => die.Roll());
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
        
        while (players.Any(o => o.Position < goal))
        {
            for (var i = 0; i < players.Count; i++)
            {
                var player = players[i];
                if (player.Position == goal)
                    continue;

                var score = player.Die.Roll();

                if (racetrack[player.Position] == score)
                    player.Position++;
                
                if(player.Position == goal)
                    done.Add(player);
            }
        }

        var result = string.Join(",", done.Select(o => o.Id));
        return new PuzzleResult(result, "7171b572bda6f1b6df3618de04406256");
    }

    public PuzzleResult Part3(string input)
    {
        var (diceInput, gridInput) = input.Split(LineBreaks.Double);
        var dice = ParseDice(diceInput);
        var grid = GridBuilder.BuildIntGridFromNonSeparated(gridInput);
        var totalSet = new HashSet<Coord>();
        
        foreach (var die in dice)
        {
            var spaces = grid.FindAddresses(die.Roll());
            var set = new HashSet<Coord>();
            set.AddRange(spaces);

            while (spaces.Any())
            {
                var score = die.Roll();
                var newSpaces = new HashSet<Coord>();
                foreach (var space in spaces)
                {
                    if(grid.ReadValueAt(space) == score)
                        newSpaces.Add(space);
                    
                    newSpaces.AddRange(grid.OrthogonalAdjacentCoordsTo(space)
                        .Where(o => grid.ReadValueAt(o) == score));
                }

                set.UnionWith(newSpaces);
                spaces = newSpaces.Distinct().ToList();
            }
            
            totalSet.UnionWith(set);
        }
        
        return new PuzzleResult(totalSet.Count, "0573f4383c024a477b878cfe7f4997a7");
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
        private long _pulse = seed;
        private int _face;
        private int _rollNumber = 1;
        
        public int Roll()
        {
            var spin = _rollNumber * _pulse;
            _face = (int)((_face + spin) % faces.Length);
            _pulse += spin;
            _pulse %= seed;
            _pulse += 1 + _rollNumber + seed;
            var result = faces[_face];
            _rollNumber++;
            return result;
        }
    }

    private class Player(int id, Die die)
    {
        public int Id { get; } = id;
        public Die Die { get; } = die;
        public int Position { get; set; }
    }
}