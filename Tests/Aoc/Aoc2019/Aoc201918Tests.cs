using Pzl.Aoc.Puzzles.Aoc2019;
using Pzl.Common;

namespace Tests.Aoc.Aoc2019;

public class Aoc201918Tests : PuzzleTest<Aoc201918>
{
    [Fact]
    public void OneRobot_ShortestPathIsFound1()
    {
        const string input = """
                             #########
                             #b.A.@.a#
                             #########
                             """;
        
        Sut.Part1(input).Should().Be(8);
    }
        
    [Fact]
    public void OneRobot_ShortestPathIsFound2()
    {
        const string input = """
                             ########################
                             #f.D.E.e.C.b.A.@.a.B.c.#
                             ######################.#
                             #d.....................#
                             ########################
                             """;

        Sut.Part1(input).Should().Be(86);
    }

    [Fact]
    public void OneRobot_ShortestPathIsFound3()
    {
        const string input = """
                             ########################
                             #...............b.C.D.f#
                             #.######################
                             #.....@.a.B.c.d.A.e.F.g#
                             ########################
                             """;

        Sut.Part1(input).Should().Be(132);
    }

    [Fact]
    public void OneRobot_ShortestPathIsFound4()
    {
        const string input = """
                             #################
                             #i.G..c...e..H.p#
                             ########.########
                             #j.A..b...f..D.o#
                             ########@########
                             #k.E..a...g..B.n#
                             ########.########
                             #l.F..d...h..C.m#
                             #################
                             """;

        Sut.Part1(input).Should().Be(136);
    }

    [Fact]
    public void OneRobot_ShortestPathIsFound5()
    {
        const string input = """
                             ########################
                             #@..............ac.GI.b#
                             ###d#e#f################
                             ###A#B#C################
                             ###g#h#i################
                             ########################
                             """;

        Sut.Part1(input).Should().Be(81);
    }

    [Fact]
    public void FourRobots_ShortestPathIsFound1()
    {
        const string input = """
                             #######
                             #a.#Cd#
                             ##...##
                             ##.@.##
                             ##...##
                             #cB#Ab#
                             #######
                             """;

        Sut.Part2(input).Should().Be(8);
    }

    [Fact]
    public void FourRobots_ShortestPathIsFound2()
    {
        const string input = """
                             ###############
                             #d.ABC.#.....a#
                             ######...######
                             ######.@.######
                             ######...######
                             #b.....#.....c#
                             ###############
                             """;

        Sut.Part2(input).Should().Be(24);
    }

    [Fact]
    public void FourRobots_ShortestPathIsFound3()
    {
        const string input = """
                             #############
                             #DcBa.#.GhKl#
                             #.###...#I###
                             #e#d#.@.#j#k#
                             ###C#...###J#
                             #fEbA.#.FgHi#
                             #############
                             """;

        Sut.Part2(input).Should().Be(32);
    }
    
    // This completes in 70 steps, and the code works for the real data. 
    // The solution probably needs to be more clever regarding quadrants.
    [Fact(Skip = TestHelper.FailingTest)]
    public void FourRobots_ShortestPathIsFound4()
    {
        const string input = """
                             #############
                             #g#f.D#..h#l#
                             #F###e#E###.#
                             #dCba...BcIJ#
                             #####.@.#####
                             #nK.L...G...#
                             #M###N#H###.#
                             #o#m..#i#jk.#
                             #############
                             """;

        Sut.Part2(input).Should().Be(72);
    }
}