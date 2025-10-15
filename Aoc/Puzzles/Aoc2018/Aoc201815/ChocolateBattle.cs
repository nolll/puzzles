using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201815;

public class ChocolateBattle(string input)
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
    
    private Grid<char> _grid = new();
    private List<BattleFigure> _figures = [];
    private Dictionary<Coord, IList<Coord>> _neighborCache = new();

    public int FightOneRound()
    {
        Reset(ElfAttackPowerPart1);
        BuildNeighborCache();
        var round = Fight();
        return Result(round);
    }
    
    public int FightUntilElvesWins()
    {
        var attackPower = ElfAttackPowerPart2;
        Reset(attackPower);
        BuildNeighborCache();
        var initialElfCount = ElfCount;
        while (true)
        {
            var round = Fight(true);
            if (round > 0 && GoblinCount == 0 && ElfCount == initialElfCount)
                return Result(round);

            attackPower++;
            Reset(attackPower);
        }
    }

    private int Result(int round) => _figures.Sum(o => o.HitPoints) * round;
    private int ElfCount => FigureCount(Chars.Elf);
    private int GoblinCount => FigureCount(Chars.Goblin);
    private int FigureCount(char c) => _figures.Where(o => !o.IsDead).Count(o => o.Type == c);

    private int Fight(bool breakOnElfDeath = false)
    {
        var round = 0;
        while (IsBothTypesStillAlive)
        {
            var gameOver = false;
            foreach (var figure in _figures)
            {
                if (figure.IsDead)
                    continue;

                var enemyType = figure.Type == Chars.Elf ? Chars.Goblin : Chars.Elf;
                var enemies = _figures.Where(o => o.Type == enemyType && !o.IsDead).ToList();
                if (!enemies.Any())
                {
                    gameOver = true;
                    break;
                }

                var enemy = GetEnemyToFight(enemies, figure, enemyType);

                if (enemy is null)
                {
                    MoveCloser(enemies, figure);
                    enemy = GetEnemyToFight(enemies, figure, enemyType);
                }

                if (enemy is null)
                    continue;
                
                enemy.Hit(figure.AttackPower);
                if (!enemy.IsDead)
                    continue;
                    
                _grid.WriteValueAt(enemy.Coord, Chars.Space);
                    
                if (breakOnElfDeath && enemy.Type == Chars.Elf)
                    return 0;
            }

            _figures = _figures.Where(o => !o.IsDead).OrderBy(o => o.Coord.Y).ThenBy(o => o.Coord.X).ToList();
            
            if (!gameOver) 
                round++;
        }

        return round;
    }

    private BattleFigure? GetEnemyToFight(List<BattleFigure> enemies, BattleFigure figure, char enemyType)
    {
        var adjacentEnemyCoords = NeighborCache(figure.Coord).Where(o => _grid.ReadValueAt(o) == enemyType).ToList();
        if (!adjacentEnemyCoords.Any())
            return null;
        
        var bestEnemyCoord = adjacentEnemyCoords
            .OrderBy(ea => enemies.Single(f => f.Coord.Equals(ea)).HitPoints)
            .ThenBy(o => o.Y)
            .ThenBy(o => o.X)
            .FirstOrDefault();
                    
        return enemies.First(o => o.Coord.Equals(bestEnemyCoord));
    }

    private void MoveCloser(List<BattleFigure> enemies, BattleFigure figure)
    {
        var bestMove = GetBestMove(enemies, figure);

        if (bestMove == null)
            return;
        
        _grid.WriteValueAt(figure.Coord, Chars.Space);
        figure.MoveTo(bestMove);
        _grid.WriteValueAt(bestMove, figure.Type);
    }

    private Coord? GetBestMove(List<BattleFigure> enemies, BattleFigure figure) => GetTargetCoords(enemies)
        .Distinct()
        .Select(o => PathFinder.ShortestPathTo(_grid, figure.Coord, o))
        .Where(o => o.Any())
        .OrderBy(o => o.Count())
        .ThenBy(o => o.First().Y)
        .ThenBy(o => o.First().X)
        .Select(o => o.First())
        .FirstOrDefault();

    private IEnumerable<Coord> GetTargetCoords(List<BattleFigure> enemies) => 
        enemies.SelectMany(o => NeighborCache(o.Coord).Where(p => _grid.ReadValueAt(p) == Chars.Space));

    private IList<Coord> NeighborCache(Coord coord) => _neighborCache[coord];

    private bool IsBothTypesStillAlive => _figures.Select(o => o.Type).Distinct().Count() == 2;

    private void Reset(int elfAttackPower)
    {
        _figures = [];
        _grid = GridBuilder.BuildCharGrid(input);
        
        foreach (var coord in _grid.Coords)
        {
            var c = _grid.ReadValueAt(coord);
            if (c is Chars.Elf or Chars.Goblin)
            {
                var attackPower = c == Chars.Elf ? elfAttackPower : 3;
                _figures.Add(new BattleFigure(c, attackPower, coord));
            }
        }
    }

    private void BuildNeighborCache()
    {
        _neighborCache = new Dictionary<Coord, IList<Coord>>();
        foreach (var coord in _grid.Coords)
        {
            if (_grid.ReadValueAt(coord) == Chars.Wall) 
                continue;
            
            var neighbors = _grid.OrthogonalAdjacentCoordsTo(coord)
                .Where(o => _grid.ReadValueAt(o) != Chars.Wall)
                .ToList();
            
            _neighborCache.Add(coord, neighbors);
        }
    }
}