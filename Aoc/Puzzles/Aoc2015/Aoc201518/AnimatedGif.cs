using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201518;

public class AnimatedGif
{
    private const char LightOn = '#';
    private const char LightOff = '.';

    private readonly bool _isCornersLit;
    private Matrix<char> _matrix;

    public int LightCount => _matrix.Values.Count(o => o == LightOn);

    public AnimatedGif(in string input, in bool isCornersLit = false)
    {
        _isCornersLit = isCornersLit;
        _matrix = MatrixBuilder.BuildCharMatrix(input);
        if (_isCornersLit)
            TurnOnCornerLights();
    }

    public void RunAnimation(in int steps)
    {
        for (var i = 0; i < steps; i++)
        {
            var newMatrix = new Matrix<char>();

            foreach (var coord in _matrix.Coords)
            {
                var adjacentValues = _matrix.AllAdjacentValuesTo(coord);
                newMatrix.WriteValueAt(coord, GetNewState(_matrix.ReadValueAt(coord), adjacentValues.Count(o => o == LightOn)));
            }
            
            _matrix = newMatrix;
            if (_isCornersLit)
                TurnOnCornerLights();
        }
    }

    private void TurnOnCornerLights()
    {
        TurnOnLight(_matrix.XMin, _matrix.YMin);
        TurnOnLight(_matrix.XMax, _matrix.YMin);
        TurnOnLight(_matrix.XMax, _matrix.YMax);
        TurnOnLight(_matrix.XMin, _matrix.YMax);
    }

    private void TurnOnLight(int x, int y) => _matrix.WriteValueAt(x, y, LightOn);

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