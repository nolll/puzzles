using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201817;

public class ReservoirFiller
{
    private Grid<char> _grid = new();
    private int _yMin = int.MaxValue;
    private int _yMax = int.MinValue;
    private readonly Coord _source = new(500, 0);
    private List<Coord> _openAddresses = new();

    private const char SourceTile = '+';
    private const char WallTile = '#';
    private const char EmptyTile = '.';
    private const char RunningWaterTile = '|';
    private const char RestingWaterTile = '~';

    public int TotalWaterTileCount => _grid.Values.Count(o => o == RestingWaterTile || o == RunningWaterTile) - DistanceFromSourceToMinY;
    public int RetainedWaterTileCount => _grid.Values.Count(o => o == RestingWaterTile);
    private int DistanceFromSourceToMinY => _yMin - _source.Y - 1;

    public ReservoirFiller(string input)
    {
        BuildMatrix(input);
    }

    public void Fill()
    {
        _openAddresses = new List<Coord> { new(_source.X, _source.Y) };
        while (_openAddresses.Any())
        {
            var current = _openAddresses.First();
            _grid.MoveTo(current);
            var valueBelow = _grid.ReadValueAt(_grid.Address.X, _grid.Address.Y + 1);
            if (valueBelow == WallTile || valueBelow == RestingWaterTile)
            {
                _openAddresses.RemoveAt(0);
                AddToOpenAddresses(new Coord(_grid.Address.X, _grid.Address.Y - 1));
                continue;
            }

            while (true)
            {
                _grid.MoveDown();
                if (IsAtBottom)
                {
                    _openAddresses.RemoveAt(0);
                    break;
                }
                    
                var value = _grid.ReadValue();
                if (value is WallTile or RestingWaterTile)
                {
                    _grid.MoveUp();
                    var canFlowRight = TryFlowRight();
                    var canFlowLeft = TryFlowLeft();
                    var isBlockedRight = !canFlowRight;
                    var isBlockedLeft = !canFlowLeft;
                        
                    if (isBlockedLeft && isBlockedRight)
                    {
                        while (true)
                        {
                            _grid.MoveRight();
                            if (_grid.ReadValue() == WallTile)
                                break;

                            _grid.WriteValue(RestingWaterTile);
                        }

                        break;
                    }

                    _openAddresses.RemoveAt(0);
                    break;
                }

                if (value is EmptyTile or RunningWaterTile)
                {
                    if(value == EmptyTile)
                        _grid.WriteValue(RunningWaterTile);
                }
            }
        }
    }

    private void BuildMatrix(string input)
    {
        _grid = new Grid<char>(1, 1, EmptyTile);
        _grid.MoveTo(_source);
        _grid.WriteValue(SourceTile);

        var rows = StringReader.ReadLines(input);

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
        _grid.MoveTo(x, y);
        _grid.WriteValue(WallTile);
        SetMinAndMax(y);
    }

    private void SetMinAndMax(in int y)
    {
        if (y < _yMin)
            _yMin = y;
        if (y > _yMax)
            _yMax = y;
    }

    private void AddToOpenAddresses(Coord address)
    {
        if(!_openAddresses.Contains(address))
            _openAddresses.Add(address);
    }

    private bool TryFlowRight()
    {
        while (true)
        {
            _grid.MoveRight();
            var value = _grid.ReadValue();
            if (value == EmptyTile || value == RunningWaterTile)
            {
                if (value == EmptyTile)
                    _grid.WriteValue(RunningWaterTile);
                var valueBelow = _grid.ReadValueAt(_grid.Address.X, _grid.Address.Y + 1);
                if (valueBelow == EmptyTile || valueBelow == RunningWaterTile)
                {
                    AddToOpenAddresses(_grid.Address);
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
            _grid.MoveLeft();
            var value = _grid.ReadValue();
            if (value == EmptyTile || value == RunningWaterTile)
            {
                if (value == EmptyTile)
                    _grid.WriteValue(RunningWaterTile);
                var valueBelow = _grid.ReadValueAt(_grid.Address.X, _grid.Address.Y + 1);
                if (valueBelow == EmptyTile || valueBelow == RunningWaterTile)
                {
                    AddToOpenAddresses(_grid.Address);
                    return true;
                }
            }
            else if (value == WallTile)
            {
                return false;
            }
        }
    }

    private bool IsAtBottom => _grid.Address.Y > _yMax;
}