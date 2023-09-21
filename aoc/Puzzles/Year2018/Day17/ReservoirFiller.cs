using System.Collections.Generic;
using System.Linq;
using common.CoordinateSystems.CoordinateSystem2D;
using common.Strings;

namespace Aoc.Puzzles.Year2018.Day17;

public class ReservoirFiller
{
    private Matrix<char> _matrix;
    private int _yMin = int.MaxValue;
    private int _yMax = int.MinValue;
    private readonly MatrixAddress _source = new(500, 0);
    private List<MatrixAddress> _openAddresses;

    private const char SourceTile = '+';
    private const char WallTile = '#';
    private const char EmptyTile = '.';
    private const char RunningWaterTile = '|';
    private const char RestingWaterTile = '~';

    public int TotalWaterTileCount => _matrix.Values.Count(o => o == RestingWaterTile || o == RunningWaterTile) - DistanceFromSourceToMinY;
    public int RetainedWaterTileCount => _matrix.Values.Count(o => o == RestingWaterTile);
    private int DistanceFromSourceToMinY => _yMin - _source.Y - 1;

    public ReservoirFiller(string input)
    {
        BuildMatrix(input);
    }

    public void Fill()
    {
        _openAddresses = new List<MatrixAddress> { new(_source.X, _source.Y) };
        while (_openAddresses.Any())
        {
            var current = _openAddresses.First();
            _matrix.MoveTo(current);
            var valueBelow = _matrix.ReadValueAt(_matrix.Address.X, _matrix.Address.Y + 1);
            if (valueBelow == WallTile || valueBelow == RestingWaterTile)
            {
                _openAddresses.RemoveAt(0);
                AddToOpenAddresses(new MatrixAddress(_matrix.Address.X, _matrix.Address.Y - 1));
                continue;
            }

            while (true)
            {
                _matrix.MoveDown();
                if (IsAtBottom)
                {
                    _openAddresses.RemoveAt(0);
                    break;
                }
                    
                var value = _matrix.ReadValue();
                if (value is WallTile or RestingWaterTile)
                {
                    _matrix.MoveUp();
                    var canFlowRight = TryFlowRight();
                    var canFlowLeft = TryFlowLeft();
                    var isBlockedRight = !canFlowRight;
                    var isBlockedLeft = !canFlowLeft;
                        
                    if (isBlockedLeft && isBlockedRight)
                    {
                        while (true)
                        {
                            _matrix.MoveRight();
                            if (_matrix.ReadValue() == WallTile)
                                break;

                            _matrix.WriteValue(RestingWaterTile);
                        }

                        break;
                    }

                    _openAddresses.RemoveAt(0);
                    break;
                }

                if (value is EmptyTile or RunningWaterTile)
                {
                    if(value == EmptyTile)
                        _matrix.WriteValue(RunningWaterTile);
                }
            }
        }
    }

    private void BuildMatrix(string input)
    {
        _matrix = new Matrix<char>(1, 1, EmptyTile);
        _matrix.MoveTo(_source);
        _matrix.WriteValue(SourceTile);

        var rows = PuzzleInputReader.ReadLines(input);

        foreach (var row in rows)
        {
            var parts = row.Split(',');
            var parts2 = parts[0].Split('=');
            if (parts2[0].First() == 'x')
            {
                var x = int.Parse(parts2[1]);
                var yValues = parts[1].Split('=')[1].Split("..").Select(int.Parse).ToList();
                var startY = yValues[0];
                var endY = yValues[1];
                for (var y = startY; y <= endY; y++)
                {
                    WriteWall(x, y);
                }
            }
            else
            {
                var y = int.Parse(parts2[1]);
                var xValues = parts[1].Split('=')[1].Split("..").Select(int.Parse).ToList();
                var startX = xValues[0];
                var endX = xValues[1];
                for (var x = startX; x <= endX; x++)
                {
                    WriteWall(x, y);
                }
            }
        }
    }

    private void WriteWall(in int x, in int y)
    {
        _matrix.MoveTo(x, y);
        _matrix.WriteValue(WallTile);
        SetMinAndMax(y);
    }

    private void SetMinAndMax(in int y)
    {
        if (y < _yMin)
            _yMin = y;
        if (y > _yMax)
            _yMax = y;
    }

    private void AddToOpenAddresses(MatrixAddress address)
    {
        if(!_openAddresses.Contains(address))
            _openAddresses.Add(address);
    }

    private bool TryFlowRight()
    {
        while (true)
        {
            _matrix.MoveRight();
            var value = _matrix.ReadValue();
            if (value == EmptyTile || value == RunningWaterTile)
            {
                if (value == EmptyTile)
                    _matrix.WriteValue(RunningWaterTile);
                var valueBelow = _matrix.ReadValueAt(_matrix.Address.X, _matrix.Address.Y + 1);
                if (valueBelow == EmptyTile || valueBelow == RunningWaterTile)
                {
                    AddToOpenAddresses(_matrix.Address);
                    return true;
                }
            }
            else if (value == WallTile)
            {
                return false;
            }
        }
    }

    private bool TryFlowLeft()
    {
        while (true)
        {
            _matrix.MoveLeft();
            var value = _matrix.ReadValue();
            if (value == EmptyTile || value == RunningWaterTile)
            {
                if (value == EmptyTile)
                    _matrix.WriteValue(RunningWaterTile);
                var valueBelow = _matrix.ReadValueAt(_matrix.Address.X, _matrix.Address.Y + 1);
                if (valueBelow == EmptyTile || valueBelow == RunningWaterTile)
                {
                    AddToOpenAddresses(_matrix.Address);
                    return true;
                }
            }
            else if (value == WallTile)
            {
                return false;
            }
        }
    }

    private bool IsAtBottom => _matrix.Address.Y > _yMax;
}