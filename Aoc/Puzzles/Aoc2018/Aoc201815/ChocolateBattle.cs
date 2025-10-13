using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201815;

public class ChocolateBattle(string input)
{
    private Matrix<char> _matrix = new();
    private IList<BattleFigure> _figures = new List<BattleFigure>();

    private IDictionary<MatrixAddress, IList<MatrixAddress>> _neighborCache =
        new Dictionary<MatrixAddress, IList<MatrixAddress>>();

    public int Outcome { get; private set; }
    private string _winners = "";

    public void RunUntilElvesWins(int initalAttackPower)
    {
        var elfAttackPower = initalAttackPower;
        while (true)
        {
            Init(elfAttackPower);
            var initialElfCount = _figures.Count(o => o.Type == BattleFigureType.Elf);
            Run(true);
            if (_winners == "Elves" && _figures.Count(o => o.Type == BattleFigureType.Elf) == initialElfCount)
                break;

            elfAttackPower++;
        }
    }

    public void RunOnce()
    {
        const int elfAttackPower = 3;
        Init(elfAttackPower);
        Run(false);
    }

    private void Run(bool breakOnElfDeath)
    {
        var round = 0;
        while (IsBothTypesStillAlive)
        {
            var incrementRound = true;
            foreach (var figure in _figures)
            {
                if (figure.IsDead)
                    continue;

                var enemyType = figure.Type == BattleFigureType.Elf ? BattleFigureType.Goblin : BattleFigureType.Elf;
                var enemies = _figures.Where(o => o.Type == enemyType).ToList();
                if (enemies.All(o => o.IsDead))
                {
                    incrementRound = false;
                    break;
                }

                var adjacentEnemyAddresses = NeighborCache(figure.Address).Where(o => _matrix.ReadValueAt(o) == enemyType).ToList();

                if (!adjacentEnemyAddresses.Any())
                {
                    var targets = new List<MatrixAddress>();
                    foreach (var enemy in enemies)
                    {
                        var adjacentAddresses = NeighborCache(enemy.Address);
                        foreach (var adjacentAddress in adjacentAddresses)
                        {
                            if (_matrix.ReadValueAt(adjacentAddress) == '.')
                            {
                                targets.Add(adjacentAddress);
                            }
                        }
                    }

                    targets = targets.Distinct().ToList();
                    var paths = targets.Select(o => PathFinder.ShortestPathTo(_matrix, figure.Address, o)).ToList();
                    var possibleMoves = paths
                        .Where(o => o.Any())
                        .OrderBy(o => o.Count)
                        .ThenBy(o => o.First().Y)
                        .ThenBy(o => o.First().X)
                        .Select(o => o.First());
                    var bestMove = possibleMoves.FirstOrDefault();
                    if (bestMove != null)
                    {
                        _matrix.WriteValueAt(figure.Address, '.');
                        var newAddress = new MatrixAddress(bestMove.X, bestMove.Y);
                        figure.MoveTo(newAddress);
                        _matrix.WriteValueAt(newAddress, figure.Type);
                    }
                }

                adjacentEnemyAddresses = NeighborCache(figure.Address).Where(o => _matrix.ReadValueAt(o) == enemyType).ToList();

                if (adjacentEnemyAddresses.Any())
                {
                    var bestEnemyAddress = adjacentEnemyAddresses
                        .OrderBy(ea => enemies.Single(f => !f.IsDead && f.Address.Equals(ea)).HitPoints)
                        .ThenBy(o => o.Y)
                        .ThenBy(o => o.X)
                        .First();
                    var enemy = enemies.First(o => o.Address.Equals(bestEnemyAddress));
                    enemy.Hit(figure.AttackPower);
                    if (!enemy.IsDead)
                        continue;
                    
                    if (breakOnElfDeath && enemy.Type == BattleFigureType.Elf)
                        return;
                    
                    _matrix.WriteValueAt(enemy.Address, '.');
                }
            }

            _figures = _figures.Where(o => !o.IsDead).OrderBy(o => o.Address.Y).ThenBy(o => o.Address.X).ToList();
            if (incrementRound)
            {
                round++;
            }
        }

        Outcome = _figures.Sum(o => o.HitPoints) * round;
        _winners = _figures.First().Type == BattleFigureType.Elf ? "Elves" : "Goblin";
    }

    private IList<MatrixAddress> NeighborCache(MatrixAddress coord) => _neighborCache[coord];

    private bool IsBothTypesStillAlive =>
        _figures.Any(o => o.Type == BattleFigureType.Elf) &&
        _figures.Any(o => o.Type == BattleFigureType.Goblin);

    private void Init(int elfAttackPower)
    {
        _figures = new List<BattleFigure>();
        var rows = input.Trim().Split('\n');
        var y = 0;

        var width = rows.First().Length;
        var height = rows.Length;
        _matrix = new Matrix<char>(width, height);

        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                var address = new MatrixAddress(x, y);
                _matrix.WriteValueAt(address, c);
                if (c is BattleFigureType.Elf or BattleFigureType.Goblin)
                {
                    var attackPower = c == BattleFigureType.Elf ? elfAttackPower : 3;
                    _figures.Add(new BattleFigure(c, attackPower, address));
                }

                x += 1;
            }

            y += 1;
        }

        _neighborCache = new Dictionary<MatrixAddress, IList<MatrixAddress>>();
        foreach (var coord in _matrix.Coords)
        {
            if (_matrix.ReadValueAt(coord) == '#') 
                continue;
            
            var neighbors = _matrix.OrthogonalAdjacentCoordsTo(coord)
                .Where(o => _matrix.ReadValueAt(o) != '#')
                .ToList();
            
            _neighborCache.Add(coord, neighbors);
        }
    }
}