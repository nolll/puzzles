using System.Reflection;

namespace Common.Puzzles;

public abstract class PuzzleFactory
{
    public abstract List<Puzzle> CreatePuzzles();

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