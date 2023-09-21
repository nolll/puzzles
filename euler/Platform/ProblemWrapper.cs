namespace Euler.Platform;

public class ProblemWrapper
{
    public int Id { get; }
    public Problem Problem { get; }

    public ProblemWrapper(int id, Problem problem)
    {
        Id = id;
        Problem = problem;
    }
}