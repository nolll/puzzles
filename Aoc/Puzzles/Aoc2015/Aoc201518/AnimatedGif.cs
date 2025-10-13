using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201518;

public class AnimatedGif
{
    private const char LightOn = '#';
    private const char LightOff = '.';

    private readonly bool _isCornersLit;
    private Grid<char> _grid;

    public int LightCount => _grid.Values.Count(o => o == LightOn);

    public AnimatedGif(in string input, in bool isCornersLit = false)
    {
        _isCornersLit = isCornersLit;
        _grid = GridBuilder.BuildCharGrid(input);
        if (_isCornersLit)
            TurnOnCornerLights();
    }

    public void RunAnimation(in int steps)
    {
        for (var i = 0; i < steps; i++)
        {
            var newMatrix = new Grid<char>();

            foreach (var coord in _grid.Coords)
            {
                var adjacentValues = _grid.AllAdjacentValuesTo(coord);
                newMatrix.WriteValueAt(coord, GetNewState(_grid.ReadValueAt(coord), adjacentValues.Count(o => o == LightOn)));
            }
            
            _grid = newMatrix;
            if (_isCornersLit)
                TurnOnCornerLights();
        }
    }

    private void TurnOnCornerLights()
    {
        TurnOnLight(_grid.XMin, _grid.YMin);
        TurnOnLight(_grid.XMax, _grid.YMin);
        TurnOnLight(_grid.XMax, _grid.YMax);
        TurnOnLight(_grid.XMin, _grid.YMax);
    }

    private void TurnOnLight(int x, int y) => _grid.WriteValueAt(x, y, LightOn);

    private static char GetNewState(in char value, in int adjacentOnCount)
    {
        if (value == LightOn)
        {
            return adjacentOnCount is 2 or 3 
                ? LightOn 
                : LightOff;
        }

        return adjacentOnCount == 3 
            ? LightOn 
            : LightOff;
    }
}