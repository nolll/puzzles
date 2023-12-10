using Pzl.Common;

namespace Pzl.Client.Filter;

public class FunPuzzleDefinitionInTest : PuzzleDefinitionInTest
{
    public FunPuzzleDefinitionInTest()
        : base(
            tags: [PuzzleTag.Fun],
            name: "Fun Puzzle",
            isFunToOptimize: true)
    {
    }
}