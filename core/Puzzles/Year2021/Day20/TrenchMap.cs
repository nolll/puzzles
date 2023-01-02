using System;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2021.Day20;

public class TrenchMap
{
    public int GetLitPixelCount(string input, int steps)
    {
        var groups = input.Split("\r\n\r\n");
        var algorithm = groups[0].Trim();
        var inputImage = (IDynamicMatrix<char>)MatrixBuilder.BuildQuickCharMatrix(groups[1].Trim(), '.');
        inputImage.ExtendAllDirections(5);
        IDynamicMatrix<char> outputImage = new QuickMatrix<char>('.');
        
        for (var i = 0; i < steps; i++)
        {
            var defaultValue = inputImage.ReadValueAt(0, 0);
            var newInputImage = new QuickMatrix<char>(inputImage.Width, inputImage.Height, defaultValue);
            for (var y = inputImage.YMin; y <= inputImage.YMax; y++)
            {
                for (var x = inputImage.XMin; x <= inputImage.XMax; x++)
                {
                    newInputImage.MoveTo(x, y);
                    newInputImage.WriteValue(inputImage.ReadValueAt(x, y));
                }
            }

            inputImage = newInputImage;
            inputImage.ExtendAllDirections(3);
            outputImage = new QuickMatrix<char>(1, 1, defaultValue);
            
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

            var sliceFrom = new MatrixAddress(outputImage.XMin + 1, outputImage.YMin + 1);
            var sliceTo = new MatrixAddress(outputImage.XMax - 1, outputImage.YMax - 1);
            outputImage = (IDynamicMatrix<char>)outputImage.Slice(sliceFrom, sliceTo);
            inputImage = outputImage;
        }

        var sliced = outputImage;

        return sliced.Values.Count(o => o == '#');
    }
}