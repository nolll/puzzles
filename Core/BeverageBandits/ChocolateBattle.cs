using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Core.Tools;

namespace Core.BeverageBandits
{
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

        public void Run(bool isPrinterEnabled)
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
                    var adjacentEnemyAddresses = _matrix.Adjacent4Coords.Where(o => _matrix.ReadValueAt(o) == enemyType).ToList();

                    if (!adjacentEnemyAddresses.Any())
                    {
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
                            figure.MoveTo(new MatrixAddress(bestMove.X, bestMove.Y));
                            _matrix.MoveTo(figure.Address);
                            _matrix.WriteValue(figure.Type);
                        }
                    }

                    _matrix.MoveTo(figure.Address);
                    adjacentEnemyAddresses = _matrix.Adjacent4Coords.Where(o => _matrix.ReadValueAt(o) == enemyType).ToList();

                    if (adjacentEnemyAddresses.Any())
                    {
                        var bestEnemyAddress = adjacentEnemyAddresses
                            .OrderBy(ea => _figures.Single(f => f.Address.Equals(ea)).HitPoints)
                            .ThenBy(o => o.Y)
                            .ThenBy(o => o.X)
                            .First();
                        var enemy = _figures.First(o => o.Address.Equals(bestEnemyAddress));
                        enemy.Hit();
                        if (enemy.IsDead)
                        {
                            _matrix.MoveTo(enemy.Address);
                            _matrix.WriteValue('.');
                        }
                    }
                }

                _figures = _figures.Where(o => o.HitPoints > 0).OrderBy(o => o.Address.Y).ThenBy(o => o.Address.X).ToList();
                if(incrementRound)
                    round++;

                if (isPrinterEnabled)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(_matrix.Print());
                }
            }
            Outcome = _figures.Sum(o => o.HitPoints) * round;
        }

        private bool IsBothTypesStillAlive =>
            _figures.Any(o => o.Type == BattleFigureType.Elf) &&
            _figures.Any(o => o.Type == BattleFigureType.Goblin);

        private void BuildMatrix(string input)
        {
            _matrix = new Matrix<char>();
            var rows = input.Trim().Split('\n');
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
                        _figures.Add(new BattleFigure(figureId, c, address));
                        figureId++;
                    }

                    x += 1;
                }

                y += 1;
            }
        }
    }
}