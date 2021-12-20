using System;
using System.Linq;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2021.Day20;

public class TrenchMap
{
    public int GetLitPixelCount(string input, int steps)
    {
        var groups = input.Split("\r\n\r\n");
        var algorithm = groups[0].Trim();
        var inputImage = MatrixBuilder.BuildCharMatrix(groups[1].Trim(), '.');
        inputImage.ExtendAllDirections(3);
        var outputImage = new Matrix<char>('.');

        Console.WriteLine($"--- Original --- {inputImage.Width},{inputImage.Height}");
        Console.WriteLine(inputImage.Print());
        Console.WriteLine();
        
        for (var i = 0; i < steps; i++)
        {
            var defaultValue = inputImage.ReadValueAt(0, 0);
            inputImage.ExtendAllDirections(2);
            outputImage = new Matrix<char>(inputImage.Width, inputImage.Height, defaultValue);

            var height = inputImage.Height;
            var width = inputImage.Width;

            Console.WriteLine($"--- Extend {i + 1} --- {inputImage.Width},{inputImage.Height}");
            Console.WriteLine(inputImage.Print());
            Console.WriteLine();

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

            
            inputImage = outputImage.Slice(new MatrixAddress(1, 1), width - 2, height - 2);
            //inputImage = outputImage;

            Console.WriteLine($"--- Output {i + 1} --- {outputImage.Width},{outputImage.Height}");
            Console.WriteLine(outputImage.Print());
            Console.WriteLine();
        }

        var sliced = outputImage.Slice(new MatrixAddress(steps, steps), outputImage.Width - steps * 2, outputImage.Height - steps * 2);

        Console.WriteLine($"--- Sliced --- {sliced.Width},{sliced.Height}");
        Console.WriteLine(sliced.Print());
        Console.WriteLine();

        return sliced.Values.Count(o => o == '#');
    }
}