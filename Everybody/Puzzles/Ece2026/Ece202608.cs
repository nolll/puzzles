using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Entgineering")]
public class Ece202608 : EverybodyEventPuzzle
{
    [Puzzle("2214c66a6958621009f2c79881b805c9")]
    public int Part1(string input)
    {
        var trees = GetTrees(input);
        var startTrees = GetStartTrees(CheckUpLeft, trees);
        var (energy, _) = RunRound(trees, startTrees, MoveDownRight, false);

        return energy;
    }

    private static Grid<char> BuildGrid(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input, '.');
        grid.ExtendAllDirections();
        return grid;
    }

    [Puzzle("4cd1a143d561f3af2b09ac0be3847c3f")]
    public int Part2(string input)
    {
        var trees = GetTrees(input);
        var directions = GetDirections(trees);
        var totalEnergy = 0;
        foreach (var (move2, startTrees) in directions)
        {
            var (energy, _) = RunRound(trees, startTrees, move2, false);
            totalEnergy += energy;
        }

        return totalEnergy;
    }

    private static List<(Func<Coord, Coord>, IEnumerable<Coord>)> GetDirections(
        Dictionary<Coord, int> trees)
    {
        List<(Func<Coord, Coord>, IEnumerable<Coord>)> directions = [
            (MoveDownRight, GetStartTrees(CheckUpLeft, trees)),
            (MoveDownLeft, GetStartTrees(CheckUpRight, trees)),
            (MoveLeft, GetStartTrees(CheckRight, trees)),
            (MoveUpLeft, GetStartTrees(CheckDownRight, trees)),
            (MoveUpRight, GetStartTrees(CheckDownLeft, trees)),
            (MoveRight, GetStartTrees(CheckLeft, trees))
        ];
        return directions;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }
    
    private (int, int) RunRound(
        Dictionary<Coord, int> trees,
        IEnumerable<Coord> startTrees,
        Func<Coord, Coord> move2,
        bool modify)
    {
        var visible = new HashSet<Coord>();

        foreach (var tree in startTrees)
        {
            visible.Add(tree);
            var nextTree = tree;
            var shadowHeight = trees[tree];
            while (true)
            {
                shadowHeight--;
                nextTree = move2(nextTree);
                
                if (!trees.TryGetValue(nextTree, out var treeHeight))
                {
                    break;
                }
                
                var isVisible = treeHeight > shadowHeight;
                if (isVisible) 
                    visible.Add(nextTree);

                shadowHeight = Math.Max(shadowHeight, treeHeight);
            }
        }

        return (visible.Count, 0);
    }

    private static IEnumerable<Coord> GetStartTrees(Func<Dictionary<Coord, int>, Coord, bool> check, Dictionary<Coord, int> trees) => 
        trees.Keys.Where(o => check(trees, o));

    private static Dictionary<Coord, int> GetTrees(string input)
    {
        var grid = BuildGrid(input);
        return grid.Coords.Select(o => (o, grid.ReadValueAt(o)))
            .Where(o => o.Item2 != '.')
            .ToDictionary(k => k.Item1, v => int.Parse(v.Item2.ToString()));
    }

    private static bool CheckUpRight(Dictionary<Coord, int> trees, Coord coord) => !trees.ContainsKey(UpRight(coord));
    private static bool CheckRight(Dictionary<Coord, int> trees, Coord coord) => !trees.ContainsKey(Right(coord));
    private static bool CheckDownRight(Dictionary<Coord, int> trees, Coord coord) => !trees.ContainsKey(DownRight(coord));
    private static bool CheckDownLeft(Dictionary<Coord, int> trees, Coord coord) => !trees.ContainsKey(DownLeft(coord));
    private static bool CheckLeft(Dictionary<Coord, int> trees, Coord coord) => !trees.ContainsKey(Left(coord));
    private static bool CheckUpLeft(Dictionary<Coord, int> trees, Coord coord) => !trees.ContainsKey(UpLeft(coord));
    
    private static Coord MoveUpRight(Coord coord) => UpRight(coord);
    private static Coord MoveRight(Coord coord) => Right(coord);
    private static Coord MoveDownRight(Coord coord) => DownRight(coord);
    private static Coord MoveDownLeft(Coord coord) => DownLeft(coord);
    private static Coord MoveLeft(Coord coord) => Left(coord);
    private static Coord MoveUpLeft(Coord coord) => UpLeft(coord);
    
    private static Coord UpLeft(Coord coord) => coord.Add(-1, -1);
    private static Coord UpRight(Coord coord) => coord.Add(1, -1);
    private static Coord Right(Coord coord) => coord.Add(2, 0);
    private static Coord DownRight(Coord coord) => coord.Add(1, 1);
    private static Coord DownLeft(Coord coord) => coord.Add(-1, 1);
    private static Coord Left(Coord coord) => coord.Add(-2, 0);
}