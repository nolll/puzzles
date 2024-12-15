using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202415;

[Name("Warehouse Woes")]
public class Aoc202415 : AocPuzzle
{
    private const char Empty = '.';
    private const char Robot = '@';
    private const char Box = 'O';
    private const char Wall = '#';
    
    public PuzzleResult Part1(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var matrix = MatrixBuilder.BuildCharMatrix(parts[0]);
        var moves = parts[1].Replace(LineBreaks.Single, "").ToCharArray();
        
        matrix.MoveTo(matrix.FindAddresses(Robot).First());
        matrix.WriteValue(Empty);
        
        foreach (var move in moves)
        {
            //var print = matrix.Print();
            
            var direction = GetDirection(move);
            matrix.TurnTo(direction);
            var lastCoord = matrix.Address;
            matrix.MoveForward();
            var currentCoord = matrix.Address;
            
            if (matrix.ReadValue() == Wall)
            {
                matrix.MoveTo(lastCoord);
                continue;
            }

            if (matrix.ReadValue() == Empty)
            {
                continue;
            }
            
            var boxesToMove = new List<MatrixAddress>();
            while (matrix.ReadValue() == Box)
            {
                boxesToMove.Add(matrix.Address);
                matrix.MoveForward();
            }
            
            if (matrix.ReadValue() == Wall)
            {
                boxesToMove.Clear();
                matrix.MoveTo(lastCoord);
            }
            
            if(boxesToMove.Count == 0)
                continue;

            foreach (var box in boxesToMove.Reversed())
            {
                matrix.MoveTo(box);
                matrix.WriteValue(Empty);
                matrix.MoveForward();
                matrix.WriteValue(Box);
            }
            
            matrix.MoveTo(currentCoord);
        }

        var print = matrix.Print();
        var score = 0L;
        foreach (var coord in matrix.Coords)
        {
            if (matrix.ReadValueAt(coord) == Box)
            {
                score += 100 * coord.Y + coord.X;
            }
        }
        
        return new PuzzleResult(score, "8b8573e47a8beee67caf8b6ab4142420");
    }

    private MatrixDirection GetDirection(char dir) =>
        dir switch
        {
            '^' => MatrixDirection.Up,
            '>' => MatrixDirection.Right,
            'v' => MatrixDirection.Down,
            _ => MatrixDirection.Left
        };

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }
}