using Pzl.Common;

namespace Pzl.Everybody;

[HasUniqueInputsForParts]
[PuzzleType(Name, ShortName)]
public abstract class EverybodyPuzzle : ThreePartsPuzzle
{
    public const string Name = "Everybody Codes";
    public const string ShortName = "ec";
}