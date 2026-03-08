using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201723;

[Name("Coprocessor Conflagration")]
public class Aoc201723 : AocPuzzle
{
    [Puzzle("971baa2f7382241fa0fb324cff9c6dd6")]
    public int Part1(string input)
    {
        var processor = new CoProcessor(input);
        processor.Run();
        return processor.MulCount;
    }

    [Puzzle("06b5b0f0cbb8360d70ca859b120e402e")]
    public int Part2(string input)
    {
        var processor = new OptimizedCoProcessor();
        processor.Run();
        return processor.H;
    }
}