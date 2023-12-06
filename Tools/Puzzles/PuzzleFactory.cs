using System.Reflection;

namespace Pzl.Tools.Puzzles;

public class PuzzleFactory
{
    public List<Puzzle> CreatePuzzles<T>() where T : Puzzle =>
        GetConcreteSubclassesOf<T>()
            .Select(CreatePuzzle<T>)
            .OrderBy(o => o.SortId)
            .ToList();

    private static Puzzle CreatePuzzle<T>(Type t) where T : Puzzle
    {
        if (Activator.CreateInstance(t) is not T puzzle)
            throw new Exception($"Could not create puzzle: {t}");

        return puzzle;
    }

    private static IEnumerable<Type> GetConcreteSubclassesOf<T>() where T : class =>
        Assembly
            .GetAssembly(typeof(T))?
            .GetTypes()
            .Where(o => o.IsSubclassOf(typeof(T)) && o is
            {
                IsClass: true, IsAbstract: false
            })
        ?? new List<Type>();
}