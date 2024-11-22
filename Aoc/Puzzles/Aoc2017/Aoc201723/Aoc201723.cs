using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201723;

[Name("Coprocessor Conflagration")]
public class Aoc201723(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var processor1 = new CoProcessor(input);
        processor1.Run();
        return new PuzzleResult(processor1.MulCount, "971baa2f7382241fa0fb324cff9c6dd6");
    }

    protected override PuzzleResult RunPart2()
    {
        var processor2 = new OptimizedCoProcessor();
        processor2.Run();
        return new PuzzleResult(processor2.H, "06b5b0f0cbb8360d70ca859b120e402e");
    }
}