namespace Tests;

public abstract class PuzzleTest<T> where T : new()
{
    protected static T Sut => new();
}