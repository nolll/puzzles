using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs02.Ecs0201;

[Name("Nail Down Your Luck")]
public class Ecs0201 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var (matrix, tokens, _) = Parse(input);
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
        var (matrix, tokens, slotCount) = Parse(input);
        var coins = 0;
        
        foreach (var token in tokens)
        {
            var best = (slot: 0, finalSlot: 0, score: 0);
            for (var slot = 1; slot <= slotCount; slot++)
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
        var (matrix, tokens, slotCount) = Parse(input);
        var scores = new Dictionary<(int token, int slot), int>();

        for (var index = 0; index < tokens.Length; index++)
        {
            var token = tokens[index];
            for (var slot = 1; slot <= slotCount; slot++)
            {
                var result = Play(matrix, token, slot);
                scores.Add((index, slot), result.score);
            }
        }

        var allSlots = Enumerable.Range(1, slotCount).ToList();
        var combinations = PermutationGenerator.GetPermutations(allSlots, tokens.Length).ToArray();

        var worst = int.MaxValue;
        var best = int.MinValue;

        foreach (var slots in combinations)
        {
            var score = slots.Select((t, token) => scores[(token, t)]).Sum();

            worst = Math.Min(worst, score);
            best = Math.Max(best, score);
        }

        return new PuzzleResult($"{worst} {best}", "28c4bfb9e7bb062915af989c9b4b8e33");
    }

    private static (int slot, int finalSlot, int score) Play(Matrix<char> matrix, string token, int slot)
    {
        var x = (slot - 1) * 2;
        matrix.MoveTo(x, matrix.YMin);
        var tokenIndex = 0;
        
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

    private static (Matrix<char> m, string[] t, int slotCount) Parse(string input)
    {
        var (input1, input2) = input.Split(LineBreaks.Double);
        var matrix = MatrixBuilder.BuildCharMatrix(input1, '.');
        matrix.ExtendUp();
        var tokens = input2.Split(LineBreaks.Single);
        var slotCount = (matrix.Width + 1) / 2;

        return (matrix, tokens, slotCount);
    }
}