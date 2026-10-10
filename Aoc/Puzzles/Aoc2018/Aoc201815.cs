using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.HashSets;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Beverage Bandits")]
public class Aoc201815 : AocPuzzle
{
    private static class Chars
    {
        public const char Wall = '#';
        public const char Space = '.';
        public const char Goblin = 'G';
        public const char Elf = 'E';
    }

    private const int ElfAttackPowerPart1 = 3;
    private const int ElfAttackPowerPart2 = 4;
    
    [Puzzle("78d65601c1d852a1cb1c731ef5403795")]
    public int Part1(string input)
    {
        var (grid, figures) = Init(input, ElfAttackPowerPart1);
        var cache = BuildNeighborCache(grid);
        var round = Fight(cache, grid, figures);
        return Result(figures, round);
    }

    [Puzzle("69659adc98aaf6e1d1febd9dabddca6f")]
    public int Part2(string input)
    {
        var attackPower = ElfAttackPowerPart2;
        var (grid, figures) = Init(input, attackPower);
        var cache = BuildNeighborCache(grid);
        var initialElfCount = ElfCount(figures);
        while (true)
        {
            var round = Fight(cache, grid, figures, true);
            if (round > 0 && GoblinCount(figures) == 0 && ElfCount(figures) == initialElfCount)
                return Result(figures, round);

            attackPower++;
            (grid, figures) = Init(input, attackPower);
        }
    }

    private static int Result(List<BattleFigure> figures, int round) => figures.Sum(o => o.HitPoints) * round;
    private static int ElfCount(List<BattleFigure> figures) => FigureCount(figures, Chars.Elf);
    private static int GoblinCount(List<BattleFigure> figures) => FigureCount(figures, Chars.Goblin);
    private static int FigureCount(List<BattleFigure> figures, char c) => 
        figures.Where(o => !o.IsDead).Count(o => o.Type == c);

    private static int Fight(
        Dictionary<Coord, IList<Coord>> cache,
        Grid<char> grid, 
        List<BattleFigure> figures, 
        bool breakOnElfDeath = false)
    {
        var round = 0;
        while (IsBothTypesStillAlive(figures))
        {
            var gameOver = false;
            foreach (var figure in figures)
            {
                if (figure.IsDead)
                    continue;

                var enemyType = figure.Type == Chars.Elf ? Chars.Goblin : Chars.Elf;
                var enemies = figures.Where(o => o.Type == enemyType && !o.IsDead).ToList();
                if (!enemies.Any())
                {
                    gameOver = true;
                    break;
                }

                var enemy = GetEnemyToFight(cache, grid, enemies, figure, enemyType);

                if (enemy is null)
                {
                    MoveCloser(cache, grid, enemies, figure);
                    enemy = GetEnemyToFight(cache, grid, enemies, figure, enemyType);
                }

                if (enemy is null)
                    continue;

                enemy.Hit(figure.AttackPower);
                if (!enemy.IsDead)
                    continue;

                grid.WriteValueAt(enemy.Coord, Chars.Space);

                if (breakOnElfDeath && enemy.Type == Chars.Elf)
                    return 0;
            }

            var newFigures = figures.Where(o => !o.IsDead).OrderBy(o => o.Coord.Y).ThenBy(o => o.Coord.X).ToList();
            figures.Clear();
            figures.AddRange(newFigures);

            if (!gameOver)
                round++;
        }

        return round;
    }

    private static BattleFigure? GetEnemyToFight(
        Dictionary<Coord, IList<Coord>> cache, 
        Grid<char> grid, 
        List<BattleFigure> enemies, 
        BattleFigure figure,
        char enemyType)
    {
        var adjacentEnemyCoords = cache[figure.Coord].Where(o => grid.ReadValueAt(o) == enemyType).ToList();
        if (!adjacentEnemyCoords.Any())
            return null;

        var bestEnemyCoord = adjacentEnemyCoords
            .OrderBy(ea => enemies.Single(f => f.Coord.Equals(ea)).HitPoints)
            .ThenBy(o => o.Y)
            .ThenBy(o => o.X)
            .FirstOrDefault();

        return enemies.First(o => o.Coord.Equals(bestEnemyCoord));
    }

    private static void MoveCloser(
        Dictionary<Coord, IList<Coord>> cache, 
        Grid<char> grid, 
        List<BattleFigure> enemies, 
        BattleFigure figure)
    {
        var bestMove = GetBestMove(cache, grid, enemies, figure);

        if (bestMove is null)
            return;

        grid.WriteValueAt(figure.Coord, Chars.Space);
        figure.MoveTo(bestMove);
        grid.WriteValueAt(bestMove, figure.Type);
    }

    private static Coord? GetBestMove(
        Dictionary<Coord, IList<Coord>> cache, 
        Grid<char> grid, 
        List<BattleFigure> enemies, 
        BattleFigure figure) =>
        GetPossibleCoords(cache, grid, enemies, figure)
            .Distinct()
            .Select(o => PathFinder.ShortestPathTo(grid, figure.Coord, o))
            .Where(o => o.Any())
            .OrderBy(o => o.Count())
            .ThenBy(o => o.First().Y)
            .ThenBy(o => o.First().X)
            .Select(o => o.First())
            .FirstOrDefault();
    
    private static IEnumerable<Coord> GetPossibleCoords(
        Dictionary<Coord, IList<Coord>> cache, 
        Grid<char> grid, 
        List<BattleFigure> enemies,
        BattleFigure figure)
    {
        var allTargetCoords = GetTargetCoords(cache, grid, enemies).ToHashSet();

        HashSet<Coord> currentCoords = [figure.Coord];
        var seen = currentCoords.ToHashSet();
        while (true)
        {
            var newCoords = new HashSet<Coord>();
            foreach (var a in currentCoords)
            {
                var validAddresses = cache[a].Where(o => !seen.Contains(o) && grid.ReadValueAt(o) == '.').ToList();
                newCoords.AddRange(validAddresses);
            }

            seen.AddRange(newCoords);

            if (newCoords.Count == 0)
                return [];

            var foundCoords = newCoords.Intersect(allTargetCoords).ToList();
            if (foundCoords.Any())
                return foundCoords.ToList();

            currentCoords = newCoords;
        }
    }

    private static IEnumerable<Coord> GetTargetCoords(
        Dictionary<Coord, IList<Coord>> cache, 
        Grid<char> grid, 
        List<BattleFigure> enemies) =>
        enemies.SelectMany(o => cache[o.Coord].Where(p => grid.ReadValueAt(p) == Chars.Space));

    private static bool IsBothTypesStillAlive(List<BattleFigure> figures) => 
        figures.Select(o => o.Type).Distinct().Count() == 2;

    private static (Grid<char>, List<BattleFigure>) Init(string input, int elfAttackPower)
    {
        var figures = new List<BattleFigure>();
        var grid = GridBuilder.BuildCharGrid(input);

        foreach (var coord in grid.Coords)
        {
            var c = grid.ReadValueAt(coord);
            if (c is not (Chars.Elf or Chars.Goblin))
                continue;

            var attackPower = c == Chars.Elf ? elfAttackPower : 3;
            figures.Add(new BattleFigure(c, attackPower, coord));
        }

        return (grid, figures);
    }

    private static Dictionary<Coord, IList<Coord>> BuildNeighborCache(Grid<char> grid)
    {
        var cache = new Dictionary<Coord, IList<Coord>>();
        foreach (var coord in grid.Coords)
        {
            if (grid.ReadValueAt(coord) == Chars.Wall)
                continue;

            cache.Add(coord, GetNeighbors(grid, coord));
        }

        return cache;
    }

    private static List<Coord> GetNeighbors(Grid<char> grid, Coord coord) => grid.OrthogonalAdjacentCoordsTo(coord)
        .Where(o => grid.ReadValueAt(o) != Chars.Wall)
        .ToList();

    private class BattleFigure(char type, int attackPower, Coord coord)
    {
        public int HitPoints { get; private set; } = 200;
        public char Type { get; } = type;
        public int AttackPower { get; } = attackPower;
        public Coord Coord { get; private set; } = coord;
        public bool IsDead => HitPoints <= 0;

        public void Hit(int attackPower) => HitPoints -= attackPower;
        public void MoveTo(Coord address) => Coord = address;
    }
}