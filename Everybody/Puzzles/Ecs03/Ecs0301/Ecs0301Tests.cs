namespace Pzl.Everybody.Puzzles.Ecs03.Ecs0301;

public class Ecs0301Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             2456:rrrrrr ggGgGG bbbbBB
                             7689:rrRrrr ggGggg bbbBBB
                             3145:rrRrRr gggGgg bbbbBB
                             6710:rrrRRr ggGGGg bbBBbB
                             """;

        Sut.Part1(input).Answer.Should().Be("9166");
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             2456:rrrrrr ggGgGG bbbbBB sSsSsS
                             7689:rrRrrr ggGggg bbbBBB ssSSss
                             3145:rrRrRr gggGgg bbbbBB sSsSsS
                             6710:rrrRRr ggGGGg bbBBbB ssSSss
                             """;

        Sut.Part2(input).Answer.Should().Be("2456");
    }

    [Fact]
    public void Part3()
    {
        const string input = """
                             15437:rRrrRR gGGGGG BBBBBB sSSSSS
                             94682:RrRrrR gGGggG bBBBBB ssSSSs
                             56513:RRRrrr ggGGgG bbbBbb ssSsSS
                             76346:rRRrrR GGgggg bbbBBB ssssSs
                             87569:rrRRrR gGGGGg BbbbbB SssSss
                             44191:rrrrrr gGgGGG bBBbbB sSssSS
                             49176:rRRrRr GggggG BbBbbb sSSssS
                             85071:RRrrrr GgGGgg BBbbbb SSsSss
                             44303:rRRrrR gGggGg bBbBBB SsSSSs
                             94978:rrRrRR ggGggG BBbBBb SSSSSS
                             26325:rrRRrr gGGGgg BBbBbb SssssS
                             43463:rrrrRR gGgGgg bBBbBB sSssSs
                             15059:RRrrrR GGgggG bbBBbb sSSsSS
                             85004:RRRrrR GgGgGG bbbBBB sSssss
                             56121:RRrRrr gGgGgg BbbbBB sSsSSs
                             80219:rRRrRR GGGggg BBbbbb SssSSs
                             """;

        Sut.Part3(input).Answer.Should().Be("292320");
    }

    private static Ecs0301 Sut => new();
}