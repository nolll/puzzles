using System.Reflection;

namespace Common.Puzzles;

public abstract class PuzzleFactory
{
    public abstract List<Puzzle> CreatePuzzles();

    protected List<Puzzle> CreatePuzzles<T>() where T : Puzzle =>
        GetConcreteSubclassesOf<T>()
            .Select(CreatePuzzle<T>)
            .OrderBy(o => o.Id)
            .ToList();

    protected static Puzzle CreatePuzzle<T>(Type t) where T : Puzzle
    {
        if (Activator.CreateInstance(t) is not T puzzle)
            throw new Exception($"Could not create puzzle: {t}");

        return puzzle;
    }

    protected static IEnumerable<Type> GetConcreteSubclassesOf<T>() where T : class =>
        Assembly
            .GetAssembly(typeof(T))?
            .GetTypes()
            .Where(o => o.IsSubclassOf(typeof(T)) && o is
            {
                IsClass: true, IsAbstract: false
            })
        ?? new List<Type>();
}