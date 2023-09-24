using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Aoc2019.Day08;

public class SpaceImageLayer
{
    private readonly string _data;
    private readonly int _width;
    private readonly IList<IList<char>> _matrix;
        
    public int NumberOfZeros => GetCharCount(_data, '0');
    public int NumberOfOnes => GetCharCount(_data, '1');
    public int NumberOfTwos => GetCharCount(_data, '2');
        
    public SpaceImageLayer(string data, int width = SpaceImageDimensions.Width)
    {
        _data = data;
        _width = width;
        _matrix = CreateMatrix(data);
    }

    private IList<IList<char>> CreateMatrix(string data)
    {
        var rows = GetRows(data).ToList();
        return new List<IList<char>>(rows);
    }

    private IEnumerable<IList<char>> GetRows(string imageData)
    {
        for (var i = 0; i < imageData.Length; i += _width)
        {
            yield return new List<char>(imageData.Substring(i, _width).ToCharArray());
        }
    }

    public char GetChar(int x, int y)
    {
        return _matrix[y][x];
    }

    public string Print()
    {
        var printer = new SpaceImagePrinter();
        return printer.Print(_matrix);
    }

    private int GetCharCount(string data, char character)
    {
        var count = 0;
        foreach (var c in data)
        {
            if (c == character)
                count++;
        }
        return count;
    }
}