using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq27Tests : PuzzleTest<Aquaq27>
{
    private const string Input = """
                                                 roulette
                                                 e      l
                                                 v      e
                                                 e      c
                                                 netulg t
                                     invalidly        n i
                                             a        i o
                                             c        y n
                                             h        r sharpness
                                             t        r
                                             i        u
                                             n        c
                                             grumpiness
                                 """;

    [Fact] 
    public void SnakeScore() => new Aquaq27().Solve(Input).Should().Be(7995);
}