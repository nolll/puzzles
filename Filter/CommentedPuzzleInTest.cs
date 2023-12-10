using Pzl.Common;

namespace Pzl.Client.Filter;

public class CommentedPuzzleDefinitionInTest : PuzzleDefinitionInTest
{
    public CommentedPuzzleDefinitionInTest()
        : base(
            tags: [PuzzleTag.Commented],
            name: "Commented Puzzle",
            comment: "Comment")
    {
    }
}