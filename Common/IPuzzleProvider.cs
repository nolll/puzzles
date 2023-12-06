using System.Collections.Generic;

namespace Pzl.Common;

public interface IPuzzleProvider
{
    List<Puzzle> GetPuzzles();
}