using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ecs01.Ecs0102;

public class Ecs0102Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             ADD id=1 left=[10,A] right=[30,H]
                             ADD id=2 left=[15,D] right=[25,I]
                             ADD id=3 left=[12,F] right=[31,J]
                             ADD id=4 left=[5,B] right=[27,L]
                             ADD id=5 left=[3,C] right=[28,M]
                             ADD id=6 left=[20,G] right=[32,K]
                             ADD id=7 left=[4,E] right=[21,N]
                             """;

        Sut.Part1(input).Answer.Should().Be("CFGNLK");
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             ADD id=1 left=[10,A] right=[30,H]
                             ADD id=2 left=[15,D] right=[25,I]
                             ADD id=3 left=[12,F] right=[31,J]
                             ADD id=4 left=[5,B] right=[27,L]
                             ADD id=5 left=[3,C] right=[28,M]
                             SWAP 1
                             SWAP 5
                             ADD id=6 left=[20,G] right=[32,K]
                             ADD id=7 left=[4,E] right=[21,N]
                             """;

        Sut.Part2(input).Answer.Should().Be("MGFLNK");
    }

    [Test]
    public void Part3_1()
    {
        const string input = """
                             ADD id=1 left=[10,A] right=[30,H]
                             ADD id=2 left=[15,D] right=[25,I]
                             ADD id=3 left=[12,F] right=[31,J]
                             ADD id=4 left=[5,B] right=[27,L]
                             ADD id=5 left=[3,C] right=[28,M]
                             SWAP 1
                             SWAP 5
                             ADD id=6 left=[20,G] right=[32,K]
                             ADD id=7 left=[4,E] right=[21,N]
                             SWAP 2
                             """;

        Sut.Part3(input).Answer.Should().Be("DJMGL");
    }
    
    [Test]
    public void Part3_2()
    {
        const string input = """
                             ADD id=1 left=[10,A] right=[30,H]
                             ADD id=2 left=[15,D] right=[25,I]
                             ADD id=3 left=[12,F] right=[31,J]
                             ADD id=4 left=[5,B] right=[27,L]
                             ADD id=5 left=[3,C] right=[28,M]
                             SWAP 1
                             SWAP 5
                             ADD id=6 left=[20,G] right=[32,K]
                             ADD id=7 left=[4,E] right=[21,N]
                             SWAP 2
                             SWAP 5
                             """;

        Sut.Part3(input).Answer.Should().Be("DJCGL");
    }

    private static Ecs0102 Sut => new();
}