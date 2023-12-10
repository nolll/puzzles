using Pzl.Common;

namespace Pzl.Client.Filter;

public class CommentedPuzzleDefinitionInTest() : PuzzleDefinitionInTest(
    tags: [PuzzleTag.Commented],
    name: "Commented Puzzle",
    comment: "Comment");