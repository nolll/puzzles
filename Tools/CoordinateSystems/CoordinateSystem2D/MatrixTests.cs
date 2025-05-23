using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

public class MatrixTests
{
    private const char DefaultValue = '.';
    private const char WriteValue = '#';

    private const string SliceInput = """
                                      ABCD
                                      EFGH
                                      IJKL
                                      MNOP
                                      """;

    [TestCase(0, true)]
    [TestCase(1, false)]
    public void IsAtTopEdge(int y, bool expected)
    {
        var matrix = new Matrix<int>(5, 5);
        matrix.MoveTo(1, y);

        matrix.IsAtTopEdge.Should().Be(expected);
    }

    [TestCase(4, true)]
    [TestCase(3, false)]
    public void IsAtRightEdge(int x, bool expected)
    {
        var matrix = new Matrix<int>(5, 5);
        matrix.MoveTo(x, 1);

        matrix.IsAtRightEdge.Should().Be(expected);
    }

    [TestCase(4, true)]
    [TestCase(3, false)]
    public void IsAtBottomEdge(int y, bool expected)
    {
        var matrix = new Matrix<int>(5, 5);
        matrix.MoveTo(1, y);

        matrix.IsAtBottomEdge.Should().Be(expected);
    }

    [TestCase(0, true)]
    [TestCase(1, false)]
    public void IsAtLeftEdge(int x, bool expected)
    {
        var matrix = new Matrix<int>(5, 5);
        matrix.MoveTo(x, 1);

        matrix.IsAtLeftEdge.Should().Be(expected);
    }

    [TestCase(5, 2)]
    [TestCase(10, 5)]
    public void Center(int size, int expected)
    {
        var matrix = new Matrix<int>(size, size);

        matrix.Center.Tuple.Should().Be((expected, expected));
    }

    [Test]
    public void MoveTo()
    {
        var matrix = new Matrix<int>(5, 5);
        matrix.MoveTo(1, 2);

        matrix.Address.X.Should().Be(1);
        matrix.Address.Y.Should().Be(2);
    }

    [Test]
    public void MoveForward()
    {
        var matrix = new Matrix<int>(5, 5);
        matrix.MoveTo(1, 3);
        matrix.MoveForward();

        matrix.Address.X.Should().Be(1);
        matrix.Address.Y.Should().Be(2);
    }

    [Test]
    public void TurnAndMoveForward()
    {
        var matrix = new Matrix<int>(5, 5);
        matrix.TurnRight();
        matrix.MoveForward();
        matrix.TurnRight();
        matrix.MoveForward();

        matrix.Address.X.Should().Be(1);
        matrix.Address.Y.Should().Be(1);
    }

    [Test]
    public void ExtendAllTo3()
    {
        var matrix = new Matrix<char>(1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections();

        var emptyRowsValue = matrix.ReadValueAt(-1, -1);
        var writtenValue = matrix.ReadValueAt(0, 0);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        matrix.Width.Should().Be(3);
        matrix.Height.Should().Be(3);
    }

    [Test]
    public void ExtendAllTo5()
    {
        var matrix = new Matrix<char>(1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections(2);

        var emptyRowsValue = matrix.ReadValueAt(-2, -2);
        var writtenValue = matrix.ReadValueAt(0, 0);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        matrix.Width.Should().Be(5);
        matrix.Height.Should().Be(5);
    }

    [Test]
    public void OrthogonalAdjacentCoordsExist()
    {
        var matrix = new Matrix<char>(1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections();

        matrix.OrthogonalAdjacentCoords.Count.Should().Be(4);

        var adjacentCoords = matrix.OrthogonalAdjacentCoords;
        var squaresInFirstCol = adjacentCoords.Where(o => o.X == -1).ToList();
        var squaresInFirstRow = adjacentCoords.Where(o => o.Y == -1).ToList();
        squaresInFirstCol.Count.Should().Be(1);
        squaresInFirstRow.Count.Should().Be(1);
    }

    [Test]
    public void AllAdjacentCoordsExists()
    {
        var matrix = new Matrix<char>(1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections();

        matrix.AllAdjacentCoords.Count.Should().Be(8);

        var adjacentCoords = matrix.AllAdjacentCoords;
        var squaresInFirstCol = adjacentCoords.Where(o => o.X == -1).ToList();
        var squaresInFirstRow = adjacentCoords.Where(o => o.Y == -1).ToList();
        squaresInFirstCol.Count.Should().Be(3);
        squaresInFirstRow.Count.Should().Be(3);
    }

    [Test]
    public void Clone()
    {
        const string input = """
                             #..
                             #..
                             .#.
                             """;

        const string expected = """
                                #..
                                #..
                                .#.
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.Clone();

        matrix.Print().Should().Be(expectedMatrix.Print());
    }

    [Test]
    public void CloneAndMultiply()
    {
        const string input = """
                             #..
                             #..
                             .#.
                             """;

        const string expected = """
                                #..#..
                                #..#..
                                .#..#.
                                #..#..
                                #..#..
                                .#..#.
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.Clone(2);

        matrix.Print().Should().Be(expectedMatrix.Print());
    }

    [Test]
    public void RotateRight()
    {
        const string input = """
                             #..
                             #..
                             ...
                             """;

        const string expected = """
                                .##
                                ...
                                ...
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.RotateRight();

        matrix.Print().Should().Be(expectedMatrix.Print());
    }

    [Test]
    public void RotateLeft()
    {
        const string input = """
                             #..
                             #..
                             ...
                             """;

        const string expected = """
                                ...
                                ...
                                ##.
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.RotateLeft();

        matrix.Print().Should().Be(expectedMatrix.Print());
    }

    [Test]
    public void Slice()
    {
        const string expected = """
                                FG
                                JK
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(SliceInput);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.Slice(new MatrixAddress(1, 1), new MatrixAddress(2, 2));

        matrix.Print().Should().Be(expectedMatrix.Print());
    }

    [Test]
    public void SliceFrom()
    {
        const string expected = """
                                FGH
                                JKL
                                NOP
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(SliceInput);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.Slice(new MatrixAddress(1, 1));

        matrix.Print().Should().Be(expectedMatrix.Print());
    }

    [Test]
    public void SliceTo()
    {
        const string expected = """
                                ABC
                                EFG
                                IJK
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(SliceInput);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.Slice(to: new MatrixAddress(2, 2));

        matrix.Print().Should().Be(expectedMatrix.Print());
    }

    [Test]
    public void SliceSize()
    {
        const string expected = """
                                FG
                                JK
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(SliceInput);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.Slice(new MatrixAddress(1, 1), 2, 2);

        matrix.Print().Should().Be(expectedMatrix.Print());
    }

    [Test]
    public void FlipVertical()
    {
        const string input = """
                             #..
                             #..
                             ...
                             """;

        const string expected = """
                                ...
                                #..
                                #..
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.FlipVertical();

        matrix.Print().Should().Be(expectedMatrix.Print());
    }

    [Test]
    public void FlipHorizontal()
    {
        const string input = """
                             #..
                             #..
                             ...
                             """;

        const string expected = """
                                ..#
                                ..#
                                ...
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.FlipHorizontal();

        matrix.Print().Should().Be(expectedMatrix.Print());
    }

    [Test]
    public void Transpose()
    {
        const string input = """
                             #..
                             #..
                             ...
                             """;

        const string expected = """
                                ##.
                                ...
                                ...
                                """;

        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

        matrix = matrix.Transpose();

        matrix.Print().Should().Be(expectedMatrix.Print());
    }
}