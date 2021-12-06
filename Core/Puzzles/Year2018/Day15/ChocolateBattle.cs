using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;

namespace Core.Puzzles.Year2018.Day15
{
    public class ChocolateBattle
    {
        private readonly string _input;
        private Matrix<char> _matrix;
        private IList<BattleFigure> _figures;
        public int Outcome { get; private set; }
        public string Winners = "";
        public int ElfAttackPower { get; private set; }

        public ChocolateBattle(string input)
        {
            _input = input;
        }

        public void RunUntilElvesWins(bool isPrinterEnabled)
        {
            var elfAttackPower = 4;
            while (true)
            {
                Init(elfAttackPower);
                var initialElfCount = _figures.Count(o => o.Type == BattleFigureType.Elf);
                Run(isPrinterEnabled, true);
                if (Winners == "Elves" && _figures.Count(o => o.Type == BattleFigureType.Elf) == initialElfCount)
                    break;

                elfAttackPower++;
            }

            ElfAttackPower = elfAttackPower;
        }

        public void RunOnce(bool isPrinterEnabled)
        {
            const int elfAttackPower = 3;
            Init(elfAttackPower);
            Run(isPrinterEnabled, false);
            ElfAttackPower = elfAttackPower;
        }

        private bool Run(bool isPrinterEnabled, bool breakOnElfDeath)
        {
            var round = 0;
            while (IsBothTypesStillAlive)
            {
                var incrementRound = true;
                foreach (var figure in _figures)
                {
                    if (figure.IsDead)
                        continue;

                    _matrix.MoveTo(figure.Address);
                    var enemies = _figures.Where(o => o.Type != figure.Type).ToList();
                    if (enemies.All(o => o.IsDead))
                    {
                        incrementRound = false;
                        break;
                    }

                    var enemyType = figure.Type == BattleFigureType.Elf ? BattleFigureType.Goblin : BattleFigureType.Elf;
                    var adjacentEnemyAddresses = _matrix.PerpendicularAdjacentCoords.Where(o => _matrix.ReadValueAt(o) == enemyType).ToList();

                    if (!adjacentEnemyAddresses.Any())
                    {
                        var targets = new List<MatrixAddress>();
                        foreach (var enemy in enemies)
                        {
                            _matrix.MoveTo(enemy.Address);
                            var adjacentAddresses = _matrix.PerpendicularAdjacentCoords;
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
                            _matrix.MoveTo(figure.Address);
                            _matrix.WriteValue('.');
                            var newAddress = new MatrixAddress(bestMove.X, bestMove.Y);
                            figure.MoveTo(newAddress);
                            _matrix.MoveTo(newAddress);
                            _matrix.WriteValue(figure.Type);
                        }
                    }

                    _matrix.MoveTo(figure.Address);
                    adjacentEnemyAddresses = _matrix.PerpendicularAdjacentCoords.Where(o => _matrix.ReadValueAt(o) == enemyType).ToList();

                    if (adjacentEnemyAddresses.Any())
                    {
                        var bestEnemyAddress = adjacentEnemyAddresses
                            .OrderBy(ea => _figures.Single(f => !f.IsDead && f.Address.Equals(ea)).HitPoints)
                            .ThenBy(o => o.Y)
                            .ThenBy(o => o.X)
                            .First();
                        var enemy = _figures.First(o => o.Address.Equals(bestEnemyAddress));
                        enemy.Hit(figure.AttackPower);
                        if (enemy.IsDead)
                        {
                            if (breakOnElfDeath && enemy.Type == BattleFigureType.Elf)
                                return false;
                            _matrix.MoveTo(enemy.Address);
                            _matrix.WriteValue('.');
                        }
                    }
                }

                _figures = _figures.Where(o => o.HitPoints > 0).OrderBy(o => o.Address.Y).ThenBy(o => o.Address.X).ToList();
                if (incrementRound)
                {
                    round++;
                }

                if (isPrinterEnabled)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(_matrix.Print());
                }
            }

            Outcome = _figures.Sum(o => o.HitPoints) * round;
            Winners = _figures.First().Type == BattleFigureType.Elf ? "Elves" : "Goblin";

            return true;
        }

        private bool IsBothTypesStillAlive =>
            _figures.Any(o => o.Type == BattleFigureType.Elf) &&
            _figures.Any(o => o.Type == BattleFigureType.Goblin);

        private void Init(int elfAttackPower)
        {
            _figures = new List<BattleFigure>();
            _matrix = new Matrix<char>();
            var rows = _input.Trim().Split('\n');
            var y = 0;
            var figureId = 0;
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
                        var attackPower = c == BattleFigureType.Elf ? elfAttackPower : 3;
                        _figures.Add(new BattleFigure(figureId, c, attackPower, address));
                        figureId++;
                    }

                    x += 1;
                }

                y += 1;
            }
        }
    }
}