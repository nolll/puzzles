namespace Tests.Aquaq.Puzzles.Aquaq27;

public class Aquaq27Tests
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
    public void SnakeScore() => new Pzl.Aquaq.Puzzles.Aquaq27.Aquaq27().Solve(Input).Should().Be(7995);
}