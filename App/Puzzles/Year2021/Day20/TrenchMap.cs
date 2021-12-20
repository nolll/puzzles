using System;
using System.Linq;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2021.Day20;

public class TrenchMap
{
    public int GetLitPixelCount(string input)
    {
        var groups = input.Split("\r\n\r\n");
        var algorithm = groups[0].Trim();
        var inputImage = MatrixBuilder.BuildCharMatrix(groups[1].Trim(), '.');
        var outputImage = new Matrix<char>();

        for (var i = 0; i < 2; i++)
        {
            inputImage.ExtendAllDirections(2);
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

                    outputImage.MoveTo(x - 1, y - 1);
                    var c = algorithm[index];
                    outputImage.WriteValue(c);
                }
            }

            inputImage = outputImage;
        }

        return outputImage.Values.Count(o => o == '#');
    }
}