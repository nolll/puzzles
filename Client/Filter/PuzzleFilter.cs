using Pzl.Client.Params;
using Pzl.Common;

namespace Pzl.Client.Filter;

public class PuzzleFilter(Parameters parameters)
{
    public IEnumerable<PuzzleDefinition> Filter(IEnumerable<PuzzleDefinition> puzzles) => 
        parameters.Tags.Aggregate(puzzles, (current, tag) => current.Where(o => o.Tags.Contains(tag)));
}