using FluentAssertions;
using NUnit.Framework;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202222;

public class Aoc202222Tests
{
    [Test]
    public void Part1() => Aoc202222.Part1(Input).Should().Be(6032);

    // todo: write tests for part 2 test data (separate mapping, or sort out general mapping).
    // There are tests for the mapping of the real data though
    
    //[Test]
    //public void Part2()
    //{                            
    //    var puzzle = new Year2022Day22();
    //    var result = puzzle.Part2(Input);

    //    result.Should().Be(5031);
    //}

    [TestCase(0, 100, '^', 50, 50, '>')]
    [TestCase(49, 100, '^', 50, 99, '>')]
    [TestCase(50, 0, '^', 0, 150, '>')]
    [TestCase(99, 0, '^', 0, 199, '>')]
    [TestCase(100, 0, '^', 0, 199, '^')]
    [TestCase(149, 0, '^', 49, 199, '^')]
    public void TestUpTransitions(int fromX, int fromY, char fromDir, int toX, int toY, char toDir) => 
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);

    [TestCase(149, 0, '>', 99, 149, '<')]
    [TestCase(149, 49, '>', 99, 100, '<')]
    [TestCase(99, 50, '>', 100, 49, '^')]
    [TestCase(99, 99, '>', 149, 49, '^')]
    [TestCase(99, 100, '>', 149, 49, '<')]
    [TestCase(99, 149, '>', 149, 0, '<')]
    [TestCase(49, 150, '>', 50, 149, '^')]
    [TestCase(49, 199, '>', 99, 149, '^')]
    public void TestRightTransitions(int fromX, int fromY, char fromDir, int toX, int toY, char toDir) => 
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);

    [TestCase(0, 199, 'v', 100, 0, 'v')]
    [TestCase(49, 199, 'v', 149, 0, 'v')]
    [TestCase(50, 149, 'v', 49, 150, '<')]
    [TestCase(99, 149, 'v', 49, 199, '<')]
    [TestCase(100, 49, 'v', 99, 50, '<')]
    [TestCase(149, 49, 'v', 99, 99, '<')]
    public void TestDownTransitions(int fromX, int fromY, char fromDir, int toX, int toY, char toDir) => 
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);

    [TestCase(50, 0, '<', 0, 149, '>')]
    [TestCase(50, 49, '<', 0, 100, '>')]
    [TestCase(50, 50, '<', 0, 100, 'v')]
    [TestCase(50, 99, '<', 49, 100, 'v')]
    [TestCase(0, 100, '<', 50, 49, '>')]
    [TestCase(0, 149, '<', 50, 0, '>')]
    [TestCase(0, 150, '<', 50, 0, 'v')]
    [TestCase(0, 199, '<', 99, 0, 'v')]
    public void TestLeftTransitions(int fromX, int fromY, char fromDir, int toX, int toY, char toDir) => 
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);

    private static void TestTransitions(int fromX, int fromY, char fromDir, int toX, int toY, char toDir)
    {
        var fromDirection = MatrixDirection.Get(fromDir);
        var toDirection = MatrixDirection.Get(toDir);
        var (c, d) = Aoc202222.MapExitPosition(new MatrixAddress(fromX, fromY), fromDirection, 50);

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