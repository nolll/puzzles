using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202512;

[Name("Challenging the Whirlpool")]
public class Codyssi202512 : CodyssiPuzzle
{
    private const long UpperBound = 1073741824;

    public PuzzleResult Part1(string input)
    {
        var (p1, p2, _) = input.Split(LineBreaks.Double);
        var grid = MatrixBuilder.BuildIntMatrixFromSpaceSeparated(p1);
        var instructions = p2.Split(LineBreaks.Single);

        foreach (var instruction in instructions)
        {
            ExecuteInstruction(grid, instruction);
        }

        var best = GetBestSum(grid);
        
        return new PuzzleResult(best, "4e6d5c783aaba03ba76ecc3a36c8ef46");
    }
    
    public PuzzleResult Part2(string input)
    {
        var (p1, p2, p3) = input.Split(LineBreaks.Double);
        var grid = MatrixBuilder.BuildIntMatrixFromSpaceSeparated(p1);
        var instructions = p2.Split(LineBreaks.Single).ToList();
        var moves = p3.Split(LineBreaks.Single);

        var taken = "";
        foreach (var move in moves)
        {
            switch (move)
            {
                case "TAKE":
                    taken = instructions.First();
                    instructions = instructions.Skip(1).ToList();
                    continue;
                case "CYCLE":
                    instructions.Add(taken);
                    taken = "";
                    continue;
                case "ACT":
                    ExecuteInstruction(grid, taken);
                    taken = "";
                    break;
            }
        }

        var best = GetBestSum(grid);
        
        return new PuzzleResult(best, "accb423e9bcc4987fa6994b21c8968da");
    }

    public PuzzleResult Part3(string input)
    {
        var (p1, p2, p3) = input.Split(LineBreaks.Double);
        var grid = MatrixBuilder.BuildIntMatrixFromSpaceSeparated(p1);
        var instructions = p2.Split(LineBreaks.Single).ToList();
        var moves = p3.Split(LineBreaks.Single);

        var taken = "";
        var index = 0;
        while(instructions.Count > 0 || taken.Length > 0)
        {
            if (index >= moves.Length) 
                index = 0;

            var move = moves[index];
            switch (move)
            {
                case "TAKE":
                    taken = instructions.First();
                    instructions = instructions.Skip(1).ToList();
                    break;
                case "CYCLE":
                    instructions.Add(taken);
                    taken = "";
                    break;
                case "ACT":
                    ExecuteInstruction(grid, taken);
                    taken = "";
                    break;
            }

            index++;
        }

        var best = GetBestSum(grid);
        
        return new PuzzleResult(best, "939c50d043eda275028daf308085dcf8");
    }

    private void ExecuteInstruction(Matrix<int> grid, string instruction)
    {
        var parts = instruction.Split(' ');
        switch (parts.Length)
        {
            case 5:
                Shift(grid, parts[1], int.Parse(parts[2]) - 1, int.Parse(parts[4]));
                break;
            case 3:
                ModifyAll(grid, parts[0], int.Parse(parts[1]));
                break;
            default:
                Modify(grid, parts[0], parts[2], int.Parse(parts[3]) - 1, int.Parse(parts[1]));
                break;
        }

        //Print(grid);
    }

    private void Print(Matrix<int> grid)
    {
        for (var y = grid.YMin; y <= grid.YMax; y++)
        {
            for (var x = grid.XMin; x <= grid.XMax; x++)
            {
                Console.Write(grid.ReadValueAt(x, y).ToString().PadLeft(5, ' '));
            }
            
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private long GetBestSum(Matrix<int> grid)
    {
        var best = 0L;
        for (var y = grid.YMin; y <= grid.YMax; y++)
        {
            var sum = 0L;
            for (var x = grid.XMin; x <= grid.XMax; x++)
            {
                sum += grid.ReadValueAt(x, y);
            }

            best = Math.Max(best, sum);
        }
        
        for (var x = grid.XMin; x <= grid.XMax; x++)
        {
            var sum = 0L;
            for (var y = grid.YMin; y <= grid.YMax; y++)    
            {
                sum += grid.ReadValueAt(x, y);
            }

            best = Math.Max(best, sum);
        }

        return best;
    }

    private void Shift(Matrix<int> grid, string what, int which, int steps)
    {
        if (what == "COL")
            ShiftCol(grid, which, steps);
        else
            ShiftRow(grid, which, steps);
    }

    private void ShiftCol(Matrix<int> grid, int col, int steps)
    {
        var values = new List<int>();
        for (var row = 0; row < grid.Height; row++)
        {
            values.Add(grid.ReadValueAt(col, row));
        }

        var origValues = values.ToArray();
        var newValues = new int[origValues.Length];
        for (var i = 0; i < origValues.Length; i++)
        {
            newValues[(i + steps) % origValues.Length] = origValues[i];
        }
        
        for (var row = 0; row < grid.Height; row++)
        {
            grid.WriteValueAt(new MatrixAddress(col, row), newValues[row]);
        }
    }
    
    private void ShiftRow(Matrix<int> grid, int row, int steps)
    {
        var values = new List<int>();
        for (var col = 0; col < grid.Width; col++)
        {
            values.Add(grid.ReadValueAt(col, row));
        }

        var origValues = values.ToArray();
        var newValues = new int[origValues.Length];
        for (var i = 0; i < origValues.Length; i++)
        {
            newValues[(i + steps) % origValues.Length] = origValues[i];
        }
        
        for (var col = 0; col < grid.Width; col++)
        {
            grid.WriteValueAt(new MatrixAddress(col, row), newValues[col]);
        }
    }

    private void ModifyAll(Matrix<int> grid, string modification, int amount)
    {
        var coords = grid.Coords;
        Modify(grid, coords, modification, amount);
    }

    private void Modify(Matrix<int> grid, string modification, string what, int which, int amount)
    {
        var coords = what == "COL"
            ? grid.Coords.Where(o => o.X == which)
            : grid.Coords.Where(o => o.Y == which);
        Modify(grid, coords, modification, amount);
    }
    
    private void Modify(Matrix<int> grid, IEnumerable<MatrixAddress> coords, string modification, int amount)
    {
        switch (modification)
        {
            case "ADD":
                Add(grid, coords, amount);
                break;
            case "SUB":
                Sub(grid, coords, amount);
                break;
            default:
                Multiply(grid, coords, amount);
                break;
        }
    }
    
    private void Add(Matrix<int> grid, IEnumerable<MatrixAddress> coords, int amount)
    {
        foreach (var coord in coords)
        {
            grid.WriteValueAt(coord, AdjustValue(grid.ReadValueAt(coord) + amount));
        }
    }
    
    private void Sub(Matrix<int> grid, IEnumerable<MatrixAddress> coords, int amount)
    {
        foreach (var coord in coords)
        {
            grid.WriteValueAt(coord, AdjustValue(grid.ReadValueAt(coord) - amount));
        }
    }
    
    private void Multiply(Matrix<int> grid, IEnumerable<MatrixAddress> coords, int amount)
    {
        foreach (var coord in coords)
        {
            grid.WriteValueAt(coord, AdjustValue(grid.ReadValueAt(coord) * (long)amount));
        }
    }

    private int AdjustValue(long v)
    {
        while (v < 0)
            v += UpperBound;

        while (v >= UpperBound)
            v -= UpperBound;

        return (int)v;
    }
}