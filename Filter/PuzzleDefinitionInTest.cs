using Pzl.Common;

namespace Pzl.Client.Filter;

public class PuzzleDefinitionInTest : PuzzleDefinition
{
    public PuzzleDefinitionInTest(
        IEnumerable<string>? tags = null,
        string? sortId = null,
        string? title = null,
        string? listTitle = null,
        string? name = null,
        string? comment = null,
        bool? isSlow = null,
        bool? needsRewrite = null,
        bool? isFunToOptimize = null)
        : base(
            typeof(Puzzle),
            tags ?? [],
            sortId ?? "",
            title ?? "",
            listTitle ?? "",
            name ?? "",
            comment,
            isSlow ?? false,
            needsRewrite ?? false,
            isFunToOptimize ?? false)
    {
    }
}