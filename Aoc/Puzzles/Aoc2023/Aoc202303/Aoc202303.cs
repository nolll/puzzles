using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202303;

[Name("Gear Ratios")]
public class Aoc202303 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = Run(input);

        return new PuzzleResult(result.EngineParts, "9f5f9a7fa049bd552fc05c71b10aab1c");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = Run(input);

        return new PuzzleResult(result.GearRatios, "0ec5347a4e1a8f41769180000882ae7d");
    }

    public static Result Run(string input)
    {
        var lines = StringReader.ReadLines(input); ;
        var width = lines.First().Length;
        var height = lines.Count;
        var numberCoordList = FindNumberCoords(lines);
        var symbolMatrix = BuildSymbolMatrix(lines, width, height);
        var numberMatrix = BuildNumberMatrix(numberCoordList, width, height);
        var engineParts = FindEngineParts(numberCoordList, symbolMatrix);
        var gearRatios = FindGearRatios(numberMatrix, symbolMatrix);

        return new Result(engineParts.Sum(), gearRatios.Sum());
    }

    private static List<NumberCoord> FindNumberCoords(IEnumerable<string> lines)
    {
        var numberCoordList = new List<NumberCoord>();

        var row = 0;
        foreach (var line in lines)
        {
            var items = RemoveSymbols(line).Split('.');

            var index = 0;
            foreach (var item in items)
            {
                var numberLength = item.Length;

                if (int.TryParse(item, out var number))
                {
                    var coords = new List<Coord>();
                    for (var i = 0; i < numberLength; i++)
                    {
                        var x = index + i;
                        coords.Add(new Coord(x, row));
                    }

                    numberCoordList.Add(new NumberCoord(number, coords));
                    index += numberLength;
                }
                index++;
            }

            row++;
        }

        return numberCoordList;
    }

    private static string RemoveSymbols(string line)
    {
        var cleanedLine = line.ToCharArray();
        for (var i = 0; i < cleanedLine.Length; i++)
        {
            var c = cleanedLine[i];
            if (!char.IsDigit(c))
                cleanedLine[i] = '.';
        }

        return string.Join("", cleanedLine);
    }

    private static Matrix<char> BuildSymbolMatrix(IEnumerable<string> lines, int width, int height)
    {
        var symbolMatrix = new Matrix<char>(width, height);
        var row = 0;
        foreach (var line in lines)
        {
            var chars = line.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                var c = chars[i];
                var isDigit = char.IsDigit(c);
                var isSymbol = !isDigit && c != '.';
                var symbol = isSymbol ? c : '.';
                symbolMatrix.WriteValueAt(i, row, symbol);
            }

            row++;
        }

        return symbolMatrix;
    }

    private static Matrix<int> BuildNumberMatrix(List<NumberCoord> numberCoordList, int width, int height)
    {
        var numberMatrix = new Matrix<int>(width, height);

        foreach (var numberCoord in numberCoordList)
        {
            foreach (var coord in numberCoord.Coords)
            {
                numberMatrix.WriteValueAt(coord, numberCoord.Number);
            }
        }

        return numberMatrix;
    }

    private static List<int> FindEngineParts(List<NumberCoord> numberCoordList, Matrix<char> symbolMatrix)
    {
        var engineParts = new List<int>();
        foreach (var numberCoord in numberCoordList)
        {
            var hasAdjacentSymbol = false;
            foreach (var coord in numberCoord.Coords)
            {
                var adjacent = symbolMatrix.AllAdjacentValuesTo(coord);
                if (adjacent.Any(o => o != '.'))
                    hasAdjacentSymbol = true;
            }

            if (hasAdjacentSymbol)
                engineParts.Add(numberCoord.Number);
        }

        return engineParts;
    }

    private static List<int> FindGearRatios(Matrix<int> numberMatrix, Matrix<char> symbolMatrix)
    {
        var symbolCoords = symbolMatrix.Coords;
        var gearRatios = new List<int>();
        foreach (var symbolCoord in symbolCoords)
        {
            if (symbolMatrix.ReadValueAt(symbolCoord) != '*')
                continue;

            var adjacentValues = numberMatrix.AllAdjacentValuesTo(symbolCoord)
                .Where(o => o > 0)
                .Distinct()
                .ToList();

            if (adjacentValues.Count == 2)
            {
                gearRatios.Add(adjacentValues.First() * adjacentValues.Last());
            }
        }

        return gearRatios;
    }

    private record NumberCoord(int Number, List<Coord> Coords);
    public record Result(int EngineParts, int GearRatios);
}