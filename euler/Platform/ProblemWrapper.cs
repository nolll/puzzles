namespace Euler.Platform;

public class ProblemWrapper
{
    public int Id { get; }
    public EulerPuzzle Problem { get; }

    public ProblemWrapper(int id, EulerPuzzle problem)
    {
        Id = id;
        Problem = problem;
    }
}