using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs02.Ecs0201;

[Name("Nail Down Your Luck")]
public class Ecs0201 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var (input1, input2) = input.Split(LineBreaks.Double);
        var matrix = MatrixBuilder.BuildCharMatrix(input1, '.');
        matrix.ExtendUp();
        
        var tokens = input2.Split(LineBreaks.Single);
        var coins = 0;
        
        for (var i = 0; i < tokens.Length; i++)
        {
            var tossSlot = i + 1;
            var x = i * 2;
            matrix.MoveTo(x, matrix.YMin);

            var token = tokens[i];
            var tokenIndex = 0;
            
            var pmatrix = matrix.Clone();
            pmatrix.MoveTo(matrix.Address);
            pmatrix.WriteValue('X');
            
            while (matrix.TryMoveDown())
            {
                if (matrix.ReadValue() == '*')
                    matrix.MoveUp();
                else
                    continue;
                
                var instruction = token[tokenIndex];
                
                if (instruction == 'L')
                {
                    if (!matrix.TryMoveLeft())
                        matrix.MoveRight();
                }
                else
                {
                    if (!matrix.TryMoveRight())
                        matrix.MoveLeft();
                }

                tokenIndex += 1;
            }

            var finalSlot = matrix.Address.X / 2 + 1;
            var win = Math.Max(finalSlot * 2 - tossSlot, 0);
            coins += win;
        }
        
        return new PuzzleResult(coins, "dad5d715238be69f7117d91bb3938a10");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}