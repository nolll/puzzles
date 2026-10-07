using Pzl.Tools.Strings;

namespace Tests;

public abstract class PuzzleTest<T> where T : new()
{
    protected static T Sut => new();
    protected string SpacesToNewLines(string input) => input.Replace(" ", LineBreaks.Single);
}