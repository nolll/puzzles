using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Like a GIF For Your Yard")]
public class Aoc201518 : AocPuzzle
{
    [Puzzle("cf54372c819da8af501619293a164f4f")]
    public int Part1(string input)
    {
        var gif = new AnimatedGif(input);
        gif.RunAnimation(100);
        return gif.LightCount;
    }

    [Puzzle("91a84e73c4b0d0185f19367fdc75f4a7")]
    public int Part2(string input)
    {
        var gif = new AnimatedGif(input, true);
        gif.RunAnimation(100);
        return gif.LightCount;
    }
    
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
                var newGrid = new Grid<char>();

                foreach (var coord in _grid.Coords)
                {
                    var adjacentValues = _grid.AllAdjacentValuesTo(coord);
                    newGrid.WriteValueAt(coord, GetNewState(_grid.ReadValueAt(coord), adjacentValues.Count(o => o == LightOn)));
                }
            
                _grid = newGrid;
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
}