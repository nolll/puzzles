using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202222;

public class Aoc202222Tests
{
    [Fact]
    public void Part1() => Aoc202222.Part1(Input).Should().Be(6032);

    // todo: write tests for part 2 test data (separate mapping, or sort out general mapping).
    // There are tests for the mapping of the real data though
    
    //[Fact]
    //public void Part2()
    //{                            
    //    var puzzle = new Year2022Day22();
    //    var result = puzzle.Part2(Input);

    //    result.Should().Be(5031);
    //}

    [Theory]
    [InlineData(0, 100, '^', 50, 50, '>')]
    [InlineData(49, 100, '^', 50, 99, '>')]
    [InlineData(50, 0, '^', 0, 150, '>')]
    [InlineData(99, 0, '^', 0, 199, '>')]
    [InlineData(100, 0, '^', 0, 199, '^')]
    [InlineData(149, 0, '^', 49, 199, '^')]
    public void TestUpTransitions(int fromX, int fromY, char fromDir, int toX, int toY, char toDir) => 
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);

    [Theory]
    [InlineData(149, 0, '>', 99, 149, '<')]
    [InlineData(149, 49, '>', 99, 100, '<')]
    [InlineData(99, 50, '>', 100, 49, '^')]
    [InlineData(99, 99, '>', 149, 49, '^')]
    [InlineData(99, 100, '>', 149, 49, '<')]
    [InlineData(99, 149, '>', 149, 0, '<')]
    [InlineData(49, 150, '>', 50, 149, '^')]
    [InlineData(49, 199, '>', 99, 149, '^')]
    public void TestRightTransitions(int fromX, int fromY, char fromDir, int toX, int toY, char toDir) => 
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);

    [Theory]
    [InlineData(0, 199, 'v', 100, 0, 'v')]
    [InlineData(49, 199, 'v', 149, 0, 'v')]
    [InlineData(50, 149, 'v', 49, 150, '<')]
    [InlineData(99, 149, 'v', 49, 199, '<')]
    [InlineData(100, 49, 'v', 99, 50, '<')]
    [InlineData(149, 49, 'v', 99, 99, '<')]
    public void TestDownTransitions(int fromX, int fromY, char fromDir, int toX, int toY, char toDir) => 
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);

    [Theory]
    [InlineData(50, 0, '<', 0, 149, '>')]
    [InlineData(50, 49, '<', 0, 100, '>')]
    [InlineData(50, 50, '<', 0, 100, 'v')]
    [InlineData(50, 99, '<', 49, 100, 'v')]
    [InlineData(0, 100, '<', 50, 49, '>')]
    [InlineData(0, 149, '<', 50, 0, '>')]
    [InlineData(0, 150, '<', 50, 0, 'v')]
    [InlineData(0, 199, '<', 99, 0, 'v')]
    public void TestLeftTransitions(int fromX, int fromY, char fromDir, int toX, int toY, char toDir) => 
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);

    private static void TestTransitions(int fromX, int fromY, char fromDir, int toX, int toY, char toDir)
    {
        var fromDirection = MatrixDirection.Get(fromDir);
        var toDirection = MatrixDirection.Get(toDir);
        var (c, d) = Aoc202222.MapExitPosition(new Coord(fromX, fromY), fromDirection, 50);

        c.X.Should().Be(toX);
        c.Y.Should().Be(toY);
        d.Should().Be(toDirection);
    }

    private const string Input = """
                                         ...#
                                         .#..
                                         #...
                                         ....
                                 ...#.......#
                                 ........#...
                                 ..#....#....
                                 ..........#.
                                         ...#....
                                         .....#..
                                         .#......
                                         ......#.

                                 10R5L5R10L4R5L5
                                 """;
}


/*
Mapping
                  X
            X     1
     X      5     0              
     0      0     0
            
   Y0       ..A.. ..B..
            ..... .....
            H.T.L L.R.J
            ..... .....
            ..C.. ..I..
            
  Y50       ..C..
            .....
            G.F.I
            .....
            ..D..
       
 Y100 ..G.. ..D..
      ..... .....
      H.L.E E.B.J
      ..... .....
      ..F.. ..K..
      
 Y150 ..F..
      .....
      A.B.K
      .....
      ..B..
*/