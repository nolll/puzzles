using System.Reflection;
using AquaQ.Platform;

namespace AquaQ.Puzzles;

public class ChallengeRepository
{
    private readonly List<ChallengeWrapper> _allProblems;

    public ChallengeRepository()
    {
        _allProblems = CreateProblems();
    }

    public ChallengeWrapper? GetChallenge(int? problemId) =>
        problemId != null
            ? _allProblems.FirstOrDefault(o => o.Id == problemId.Value)
            : _allProblems.LastOrDefault();

    public IList<ChallengeWrapper> GetAll() => _allProblems;

    private static List<ChallengeWrapper> CreateProblems() => 
        GetConcreteSubclassesOf<AquaQPuzzle>()
            .Select(CreateProblem)
            .OrderBy(o => o.Id)
            .ToList();

    private static ChallengeWrapper CreateProblem(Type t)
    {
        var id = ChallengeParser.GetChallengeId(t);
        if (Activator.CreateInstance(t) is AquaQPuzzle challenge)
            return new ChallengeWrapper(id, challenge);
        
        throw new Exception($"Could not create Problem {id}");
    }

    private static IEnumerable<Type> GetConcreteSubclassesOf<T>() where T : class =>
        Assembly
            .GetAssembly(typeof(T))?
            .GetTypes()
            .Where(myType =>
                myType.IsSubclassOf(typeof(T)) &&
                myType is
                {
                    IsClass: true,
                    IsAbstract: false
                })
        ?? new List<Type>();
}