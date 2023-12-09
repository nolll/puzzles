using System.Collections.Generic;

namespace Pzl.Common;

public interface IPuzzleProvider
{
    List<PuzzleDefinition> GetPuzzles();
}