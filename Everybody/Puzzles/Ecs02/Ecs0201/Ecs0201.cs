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
            var token = tokens[i];
            var slot = i + 1;
            coins += Play(matrix, token, slot).score;
        }
        
        return new PuzzleResult(coins, "dad5d715238be69f7117d91bb3938a10");
    }

    public PuzzleResult Part2(string input)
    {
        var (input1, input2) = input.Split(LineBreaks.Double);
        var matrix = MatrixBuilder.BuildCharMatrix(input1, '.');
        matrix.ExtendUp();
        
        var tokens = input2.Split(LineBreaks.Single);
        var coins = 0;
        var numSlots = (matrix.Width + 1) / 2;
        
        foreach (var token in tokens)
        {
            var best = (slot: 0, finalSlot: 0, score: 0);
            for (var slot = 1; slot <= numSlots; slot++)
            {
                var result = Play(matrix, token, slot);
                if (result.score > best.score)
                    best = result;
            }
            
            coins += best.score;
        }
        
        return new PuzzleResult(coins, "26c70e45583b5816af23beaeb77e8940");
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
    
    private static (int slot, int finalSlot, int score) Play(Matrix<char> matrix, string token, int slot)
    {
        var x = (slot - 1) * 2;
        matrix.MoveTo(x, matrix.YMin);
        
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
        return (slot, finalSlot, Math.Max(finalSlot * 2 - slot, 0));
    }
}