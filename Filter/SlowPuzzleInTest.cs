using Pzl.Common;

namespace Pzl.Client.Filter;

public class SlowPuzzleDefinitionInTest() : PuzzleDefinitionInTest(
    tags: [PuzzleTag.Slow],
    name: "Slow Puzzle");