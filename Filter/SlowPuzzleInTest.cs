using Pzl.Common;

namespace Pzl.Client.Filter;

public class SlowPuzzleDefinitionInTest : PuzzleDefinitionInTest
{
    public SlowPuzzleDefinitionInTest() 
        : base(
            tags: [PuzzleTag.Slow],
            name : "Slow Puzzle", 
            isSlow : true)
    {
    }
}