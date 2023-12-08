using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq27;

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

    [Test] 
    public void SnakeScore() => Aquaq27.CalculateSnakeScore(Input)
        .Should().Be(7995);
}