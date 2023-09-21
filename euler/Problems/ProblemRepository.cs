using System.Reflection;
using Euler.Platform;

namespace Euler.Problems;

public class ProblemRepository
{
    private readonly List<ProblemWrapper> _allProblems;

    public ProblemRepository()
    {
        _allProblems = CreateProblems();
    }

    public ProblemWrapper? GetProblem(int? problemId) =>
        problemId != null
            ? _allProblems.FirstOrDefault(o => o.Id == problemId.Value)
            : _allProblems.LastOrDefault();

    public IList<ProblemWrapper> GetAll() => _allProblems;

    private static List<ProblemWrapper> CreateProblems() => 
        GetConcreteSubclassesOf<Problem>()
            .Select(CreateProblem)
            .OrderBy(o => o.Id)
            .ToList();

    private static ProblemWrapper CreateProblem(Type t)
    {
        var id = ProblemParser.GetProblemId(t);
        if (Activator.CreateInstance(t) is Problem problem)
            return new ProblemWrapper(id, problem);
        
        throw new Exception($"Could not create Problem {id}");
    }

    private static IEnumerable<Type> GetConcreteSubclassesOf<T>() where T : class =>
        Assembly.GetAssembly(typeof(T))?
            .GetTypes()
            .Where(myType => myType.IsSubclassOf(typeof(T)) && myType is
            {
                IsClass: true, IsAbstract: false
            })
        ?? new List<Type>();
}