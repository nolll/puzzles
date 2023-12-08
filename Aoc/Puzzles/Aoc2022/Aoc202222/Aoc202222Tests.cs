using FluentAssertions;
using NUnit.Framework;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202222;

public class Aoc202222Tests
{
    [Test]
    public void Part1()
    {
        var result = Aoc202222.Part1(Input);

        result.Should().Be(6032);
    }

    // todo: write tests for part 2 test data (separate mapping, or sort out general mapping).
    // There are tests for the mapping of the real data though
    
    //[Test]
    //public void Part2()
    //{                            
    //    var puzzle = new Year2022Day22();
    //    var result = puzzle.Part2(Input);

    //    result.Should().Be(5031);
    //}

    [TestCase(0, 100, "up", 50, 50, "right")]
    [TestCase(49, 100, "up", 50, 99, "right")]
    [TestCase(50, 0, "up", 0, 150, "right")]
    [TestCase(99, 0, "up", 0, 199, "right")]
    [TestCase(100, 0, "up", 0, 199, "up")]
    [TestCase(149, 0, "up", 49, 199, "up")]
    public void TestUpTransitions(int fromX, int fromY, string fromDir, int toX, int toY, string toDir)
    {
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);
    }

    [TestCase(149, 0, "right", 99, 149, "left")]
    [TestCase(149, 49, "right", 99, 100, "left")]
    [TestCase(99, 50, "right", 100, 49, "up")]
    [TestCase(99, 99, "right", 149, 49, "up")]
    [TestCase(99, 100, "right", 149, 49, "left")]
    [TestCase(99, 149, "right", 149, 0, "left")]
    [TestCase(49, 150, "right", 50, 149, "up")]
    [TestCase(49, 199, "right", 99, 149, "up")]
    public void TestRightTransitions(int fromX, int fromY, string fromDir, int toX, int toY, string toDir)
    {
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);
    }

    [TestCase(0, 199, "down", 100, 0, "down")]
    [TestCase(49, 199, "down", 149, 0, "down")]
    [TestCase(50, 149, "down", 49, 150, "left")]
    [TestCase(99, 149, "down", 49, 199, "left")]
    [TestCase(100, 49, "down", 99, 50, "left")]
    [TestCase(149, 49, "down", 99, 99, "left")]
    public void TestDownTransitions(int fromX, int fromY, string fromDir, int toX, int toY, string toDir)
    {
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);
    }

    [TestCase(50, 0, "left", 0, 149, "right")]
    [TestCase(50, 49, "left", 0, 100, "right")]
    [TestCase(50, 50, "left", 0, 100, "down")]
    [TestCase(50, 99, "left", 49, 100, "down")]
    [TestCase(0, 100, "left", 50, 49, "right")]
    [TestCase(0, 149, "left", 50, 0, "right")]
    [TestCase(0, 150, "left", 50, 0, "down")]
    [TestCase(0, 199, "left", 99, 0, "down")]
    public void TestLeftTransitions(int fromX, int fromY, string fromDir, int toX, int toY, string toDir)
    {
        TestTransitions(fromX, fromY, fromDir, toX, toY, toDir);
    }

    private void TestTransitions(int fromX, int fromY, string fromDir, int toX, int toY, string toDir)
    {
        var fromDirection = MatrixDirection.Create(fromDir);
        var toDirection = MatrixDirection.Create(toDir);
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