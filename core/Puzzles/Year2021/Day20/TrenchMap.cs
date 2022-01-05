using System;
using System.Linq;
using Core.Common.CoordinateSystems;

namespace Core.Puzzles.Year2021.Day20;

public class TrenchMap
{
    public int GetLitPixelCount(string input, int steps)
    {
        var groups = input.Split("\r\n\r\n");
        var algorithm = groups[0].Trim();
        var inputImage = MatrixBuilder.BuildCharMatrix(groups[1].Trim(), '.');
        inputImage.ExtendAllDirections(5);
        var outputImage = new Matrix<char>('.');
        
        for (var i = 0; i < steps; i++)
        {
            var defaultValue = inputImage.ReadValueAt(0, 0);
            var newInputImage = new Matrix<char>(inputImage.Width, inputImage.Height, defaultValue);
            for (var y = 0; y < inputImage.Height; y++)
            {
                for (var x = 0; x < inputImage.Width; x++)
                {
                    newInputImage.MoveTo(x, y);
                    newInputImage.WriteValue(inputImage.ReadValueAt(x, y));
                }
            }

            inputImage = newInputImage;
            inputImage.ExtendAllDirections(2);
            outputImage = new Matrix<char>(inputImage.Width, inputImage.Height, defaultValue);

            var height = inputImage.Height;
            var width = inputImage.Width;

            for (var y = 1; y < height - 1; y++)
            {
                for (var x = 1; x < width - 1; x++)
                {
                    inputImage.MoveTo(x, y);
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
            
            outputImage = outputImage.Slice(new MatrixAddress(1, 1), new MatrixAddress(outputImage.Width - 2, outputImage.Height - 2));
            inputImage = outputImage;
        }

        var sliced = outputImage;

        return sliced.Values.Count(o => o == '#');
    }
}