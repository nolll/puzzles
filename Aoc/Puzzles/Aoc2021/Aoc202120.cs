using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Trench Map")]
public class Aoc202120 : AocPuzzle
{
    [Puzzle("45662f27fb9cbf099b4d5453539159a2")]
    public int Part1(string input) => Solve(input, 2);

    [Puzzle("0225d04616fb918456e876afd4831afd")]
    public int Part2(string input) => Solve(input, 50);

    private int Solve(string input, int steps)
    {
        var groups = input.Split(LineBreaks.Double);
        var algorithm = groups[0].Trim();
        var inputImage = GridBuilder.BuildCharGrid(groups[1].Trim(), '.');
        inputImage.ExtendAllDirections(5);
        var outputImage = new Grid<char>('.');
        
        for (var i = 0; i < steps; i++)
        {
            var defaultValue = inputImage.ReadValueAt(inputImage.XMin, inputImage.YMin);
            var newInputImage = new Grid<char>(inputImage.Width, inputImage.Height, defaultValue);

            foreach (var coord in inputImage.Coords) 
                newInputImage.WriteValueAt(coord, inputImage.ReadValueAt(coord));

            inputImage = newInputImage;
            inputImage.ExtendAllDirections(3);
            outputImage = new Grid<char>(1, 1, defaultValue);
            
            for (var y = inputImage.YMin + 1; y <= inputImage.YMax - 1; y++)
            {
                for (var x = inputImage.XMin + 1; x <= inputImage.XMax - 1; x++)
                {
                    var binary = "";
                    binary += inputImage.ReadValueAt(x - 1, y - 1) == '#' ? '1' : '0';
                    binary += inputImage.ReadValueAt(x, y - 1) == '#' ? '1' : '0';
                    binary += inputImage.ReadValueAt(x + 1, y - 1) == '#' ? '1' : '0';
                    binary += inputImage.ReadValueAt(x - 1, y) == '#' ? '1' : '0';
                    binary += inputImage.ReadValueAt(x, y) == '#' ? '1' : '0';
                    binary += inputImage.ReadValueAt(x + 1, y) == '#' ? '1' : '0';
                    binary += inputImage.ReadValueAt(x - 1, y + 1) == '#' ? '1' : '0';
                    binary += inputImage.ReadValueAt(x, y + 1) == '#' ? '1' : '0';
                    binary += inputImage.ReadValueAt(x + 1, y + 1) == '#' ? '1' : '0';
                    
                    var index = Convert.ToInt32(binary, 2);

                    outputImage.MoveTo(x, y);
                    var c = algorithm[index];
                    outputImage.WriteValue(c);
                }
            }

            var sliceFrom = new Coord(outputImage.XMin + 1, outputImage.YMin + 1);
            var sliceTo = new Coord(outputImage.XMax - 1, outputImage.YMax - 1);
            outputImage = outputImage.Slice(sliceFrom, sliceTo);
            inputImage = outputImage;
        }

        return outputImage.Values.Count(o => o == '#');
    }
}