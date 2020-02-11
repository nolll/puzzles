using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class ChocolateBattleTests
    {
        [Test]
        public void BattleResultsInCorrectOutcome()
        {
            const string input = @"
#######
#.G...#
#...EG#
#.#.#G#
#..G#E#
#.....#
#######";

            var battle = new ChocolateBattle(input);
            battle.Run();

            Assert.That(battle.Outcome, Is.EqualTo(27730));
        }
    }

    public class ChocolateBattle
    {
        private Matrix<char> _matrix;
        private IList<BattleFigure> _figures;
        public int Outcome { get; private set; }

        public ChocolateBattle(string input)
        {
            _figures = new List<BattleFigure>();
            BuildMatrix(input);
        }

        public void Run()
        {
            var round = 0;
            while (_figures.Any(o => o.Type == BattleFigureType.Elf) && _figures.Any(o => o.Type == BattleFigureType.Goblin))
            {
                foreach (var figure in _figures)
                {
                    _matrix.MoveTo(figure.Address);
                    var enemyType = figure.Type == BattleFigureType.Elf ? BattleFigureType.Goblin : BattleFigureType.Elf;
                    var adjacentEnemies = _matrix.Adjacent4Coords.Where(o => _matrix.ReadValueAt(o) == enemyType).ToList();
                    if (adjacentEnemies.Any())
                    {
                        var bestEnemyAddress = adjacentEnemies.OrderBy(o => o.Y).ThenBy(o => o.X).ToList().First();
                        var enemy = _figures.First(o => o.Address.Equals(bestEnemyAddress));
                        enemy.Hit();
                        if (enemy.HitPoints <= 0)
                        {
                            _matrix.MoveTo(enemy.Address);
                            _matrix.WriteValue('.');
                        }
                    }
                    else
                    {
                        var enemies = _figures.Where(o => o.Type != figure.Type).ToList();
                        var targets = new List<MatrixAddress>();
                        foreach (var enemy in enemies)
                        {
                            _matrix.MoveTo(enemy.Address);
                            var adjacentAddresses = _matrix.Adjacent4Coords;
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
                        var possibleMoves = paths.Select(o => o.First());
                        var bestMove = possibleMoves.OrderBy(o => o.Y).ThenBy(o => o.X).ToList().First();
                        _matrix.MoveTo(figure.Address);
                        _matrix.WriteValue('.');
                        figure.MoveTo(new MatrixAddress(bestMove.X, bestMove.Y));
                        _matrix.MoveTo(figure.Address);
                        _matrix.WriteValue(figure.Type);
                    }
                }

                _figures = _figures.Where(o => o.HitPoints > 0).OrderBy(o => o.Address.Y).ThenBy(o => o.Address.X).ToList();
                round++;
            }
            Outcome = _figures.Sum(o => o.HitPoints) * round;
        }

        private void BuildMatrix(string input)
        {
            _matrix = new Matrix<char>();
            var rows = input.Trim().Split('\n');
            var y = 0;
            foreach (var row in rows)
            {
                var x = 0;
                var chars = row.Trim().ToCharArray();
                foreach (var c in chars)
                {
                    var address = new MatrixAddress(x, y);
                    _matrix.MoveTo(address);
                    _matrix.WriteValue(c);
                    if (c == BattleFigureType.Elf || c == BattleFigureType.Goblin)
                    {
                        _figures.Add(new BattleFigure(c, address));
                    }

                    x += 1;
                }

                y += 1;
            }
        }
    }

    public class BattleFigure
    {
        public int HitPoints { get; private set; }
        public char Type { get; }
        public MatrixAddress Address { get; private set; }

        public BattleFigure(char type, MatrixAddress address)
        {
            HitPoints = 200;
            Type = type;
            Address = address;
        }

        public void Hit()
        {
            HitPoints -= 3;
        }

        public void MoveTo(MatrixAddress address)
        {
            Address = address;
        }
    }

    public static class BattleFigureType
    {
        public const char Elf = 'E';
        public const char Goblin = 'G';
    }
}