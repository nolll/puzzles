using Pzl.Common;

namespace Pzl.Client.Filter;

public class PuzzleDefinitionInTest(
    IEnumerable<string>? tags = null,
    string? sortId = null,
    string? title = null,
    string? listTitle = null,
    string? name = null,
    string? comment = null,
    int? numberOfParts = null,
    bool? hasUniqueInputsPerPart = null)
    : PuzzleDefinition(typeof(Puzzle),
        tags ?? [],
        sortId ?? "",
        title ?? "",
        listTitle ?? "",
        name ?? "",
        comment,
        numberOfParts ?? 1,
        hasUniqueInputsPerPart ?? false);

public class PlainPuzzleDefinitionInTest() : PuzzleDefinitionInTest(name: "Plain Puzzle");

public class CommentedPuzzleDefinitionInTest() : PuzzleDefinitionInTest(
    tags: [PuzzleTag.Commented],
    name: "Commented Puzzle",
    comment: "Comment");

public class FunPuzzleDefinitionInTest() : PuzzleDefinitionInTest(
    tags: [PuzzleTag.Fun],
    name: "Fun Puzzle");

public class SlowPuzzleDefinitionInTest() : PuzzleDefinitionInTest(
    tags: [PuzzleTag.Slow],
    name: "Slow Puzzle");