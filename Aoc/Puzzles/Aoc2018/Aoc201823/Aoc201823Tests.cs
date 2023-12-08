using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201823;

public class Aoc201823Tests
{
    [Test]
    public void NanobotsInRangeOfStrongestNanobot()
    {
        const string input = """
                             pos=<0,0,0>, r=4
                             pos=<1,0,0>, r=1
                             pos=<4,0,0>, r=3
                             pos=<0,2,0>, r=1
                             pos=<0,5,0>, r=3
                             pos=<0,0,3>, r=1
                             pos=<1,1,1>, r=1
                             pos=<1,1,2>, r=1
                             pos=<1,3,1>, r=1
                             """;

        var formation = new NanobotFormation(input.Trim());
        var botCount = formation.GetBotsInRangeOfStrongestBot().Count;

        botCount.Should().Be(7);
    }

    [Test]
    public void CubeDivision1X2X2()
    {
        var cube = new SpaceBox(new Point3d(0, 0, 0), new Point3d(0, 1, 1));
        var subCubes = cube.Divide().ToList();

        subCubes.Count.Should().Be(4);

        subCubes[0].Min.X.Should().Be(0);
        subCubes[0].Min.Y.Should().Be(0);
        subCubes[0].Min.Z.Should().Be(0);
        subCubes[0].Max.X.Should().Be(0);
        subCubes[0].Max.Y.Should().Be(0);
        subCubes[0].Max.Z.Should().Be(0);

        subCubes[1].Min.X.Should().Be(0);
        subCubes[1].Min.Y.Should().Be(1);
        subCubes[1].Min.Z.Should().Be(0);
        subCubes[1].Max.X.Should().Be(0);
        subCubes[1].Max.Y.Should().Be(1);
        subCubes[1].Max.Z.Should().Be(0);

        subCubes[2].Min.X.Should().Be(0);
        subCubes[2].Min.Y.Should().Be(0);
        subCubes[2].Min.Z.Should().Be(1);
        subCubes[2].Max.X.Should().Be(0);
        subCubes[2].Max.Y.Should().Be(0);
        subCubes[2].Max.Z.Should().Be(1);

        subCubes[3].Min.X.Should().Be(0);
        subCubes[3].Min.Y.Should().Be(1);
        subCubes[3].Min.Z.Should().Be(1);
        subCubes[3].Max.X.Should().Be(0);
        subCubes[3].Max.Y.Should().Be(1);
        subCubes[3].Max.Z.Should().Be(1);
    }

    [Test]
    public void CubeDivision2X2X2()
    {
        var cube = new SpaceBox(new Point3d(0, 0, 0), new Point3d(1, 1, 1));
        var subCubes = cube.Divide().ToList();

        subCubes.Count.Should().Be(8);
            
        subCubes[0].Min.X.Should().Be(0);
        subCubes[0].Min.Y.Should().Be(0);
        subCubes[0].Min.Z.Should().Be(0);
        subCubes[0].Max.X.Should().Be(0);
        subCubes[0].Max.Y.Should().Be(0);
        subCubes[0].Max.Z.Should().Be(0);

        subCubes[1].Min.X.Should().Be(1);
        subCubes[1].Min.Y.Should().Be(0);
        subCubes[1].Min.Z.Should().Be(0);
        subCubes[1].Max.X.Should().Be(1);
        subCubes[1].Max.Y.Should().Be(0);
        subCubes[1].Max.Z.Should().Be(0);

        subCubes[2].Min.X.Should().Be(0);
        subCubes[2].Min.Y.Should().Be(1);
        subCubes[2].Min.Z.Should().Be(0);
        subCubes[2].Max.X.Should().Be(0);
        subCubes[2].Max.Y.Should().Be(1);
        subCubes[2].Max.Z.Should().Be(0);

        subCubes[3].Min.X.Should().Be(0);
        subCubes[3].Min.Y.Should().Be(0);
        subCubes[3].Min.Z.Should().Be(1);
        subCubes[3].Max.X.Should().Be(0);
        subCubes[3].Max.Y.Should().Be(0);
        subCubes[3].Max.Z.Should().Be(1);

        subCubes[4].Min.X.Should().Be(1);
        subCubes[4].Min.Y.Should().Be(1);
        subCubes[4].Min.Z.Should().Be(0);
        subCubes[4].Max.X.Should().Be(1);
        subCubes[4].Max.Y.Should().Be(1);
        subCubes[4].Max.Z.Should().Be(0);

        subCubes[5].Min.X.Should().Be(1);
        subCubes[5].Min.Y.Should().Be(0);
        subCubes[5].Min.Z.Should().Be(1);
        subCubes[5].Max.X.Should().Be(1);
        subCubes[5].Max.Y.Should().Be(0);
        subCubes[5].Max.Z.Should().Be(1);

        subCubes[6].Min.X.Should().Be(0);
        subCubes[6].Min.Y.Should().Be(1);
        subCubes[6].Min.Z.Should().Be(1);
        subCubes[6].Max.X.Should().Be(0);
        subCubes[6].Max.Y.Should().Be(1);
        subCubes[6].Max.Z.Should().Be(1);

        subCubes[7].Min.X.Should().Be(1);
        subCubes[7].Min.Y.Should().Be(1);
        subCubes[7].Min.Z.Should().Be(1);
        subCubes[7].Max.X.Should().Be(1);
        subCubes[7].Max.Y.Should().Be(1);
        subCubes[7].Max.Z.Should().Be(1);
    }

    [Test]
    public void CubeDivision4X4X4()
    {
        var cube = new SpaceBox(new Point3d(0, 0, 0), new Point3d(3, 3, 3));
        var subCubes = cube.Divide().ToList();

        subCubes.Count.Should().Be(8);

        subCubes[0].Min.X.Should().Be(0);
        subCubes[0].Min.Y.Should().Be(0);
        subCubes[0].Min.Z.Should().Be(0);
        subCubes[0].Max.X.Should().Be(1);
        subCubes[0].Max.Y.Should().Be(1);
        subCubes[0].Max.Z.Should().Be(1);

        subCubes[1].Min.X.Should().Be(2);
        subCubes[1].Min.Y.Should().Be(0);
        subCubes[1].Min.Z.Should().Be(0);
        subCubes[1].Max.X.Should().Be(3);
        subCubes[1].Max.Y.Should().Be(1);
        subCubes[1].Max.Z.Should().Be(1);

        subCubes[2].Min.X.Should().Be(0);
        subCubes[2].Min.Y.Should().Be(2);
        subCubes[2].Min.Z.Should().Be(0);
        subCubes[2].Max.X.Should().Be(1);
        subCubes[2].Max.Y.Should().Be(3);
        subCubes[2].Max.Z.Should().Be(1);

        subCubes[3].Min.X.Should().Be(0);
        subCubes[3].Min.Y.Should().Be(0);
        subCubes[3].Min.Z.Should().Be(2);
        subCubes[3].Max.X.Should().Be(1);
        subCubes[3].Max.Y.Should().Be(1);
        subCubes[3].Max.Z.Should().Be(3);

        subCubes[4].Min.X.Should().Be(2);
        subCubes[4].Min.Y.Should().Be(2);
        subCubes[4].Min.Z.Should().Be(0);
        subCubes[4].Max.X.Should().Be(3);
        subCubes[4].Max.Y.Should().Be(3);
        subCubes[4].Max.Z.Should().Be(1);

        subCubes[5].Min.X.Should().Be(2);
        subCubes[5].Min.Y.Should().Be(0);
        subCubes[5].Min.Z.Should().Be(2);
        subCubes[5].Max.X.Should().Be(3);
        subCubes[5].Max.Y.Should().Be(1);
        subCubes[5].Max.Z.Should().Be(3);
        
        subCubes[6].Min.X.Should().Be(0);
        subCubes[6].Min.Y.Should().Be(2);
        subCubes[6].Min.Z.Should().Be(2);
        subCubes[6].Max.X.Should().Be(1);
        subCubes[6].Max.Y.Should().Be(3);
        subCubes[6].Max.Z.Should().Be(3);

        subCubes[7].Min.X.Should().Be(2);
        subCubes[7].Min.Y.Should().Be(2);
        subCubes[7].Min.Z.Should().Be(2);
        subCubes[7].Max.X.Should().Be(3);
        subCubes[7].Max.Y.Should().Be(3);
        subCubes[7].Max.Z.Should().Be(3);
    }

    [Test]
    public void CubeDivision5X5X5()
    {
        var cube = new SpaceBox(new Point3d(0, 0, 0), new Point3d(4, 4, 4));
        var subCubes = cube.Divide().ToList();

        subCubes.Count.Should().Be(8);

        subCubes[0].Min.X.Should().Be(0);
        subCubes[0].Min.Y.Should().Be(0);
        subCubes[0].Min.Z.Should().Be(0);
        subCubes[0].Max.X.Should().Be(1);
        subCubes[0].Max.Y.Should().Be(1);
        subCubes[0].Max.Z.Should().Be(1);

        subCubes[1].Min.X.Should().Be(2);
        subCubes[1].Min.Y.Should().Be(0);
        subCubes[1].Min.Z.Should().Be(0);
        subCubes[1].Max.X.Should().Be(4);
        subCubes[1].Max.Y.Should().Be(1);
        subCubes[1].Max.Z.Should().Be(1);

        subCubes[2].Min.X.Should().Be(0);
        subCubes[2].Min.Y.Should().Be(2);
        subCubes[2].Min.Z.Should().Be(0);
        subCubes[2].Max.X.Should().Be(1);
        subCubes[2].Max.Y.Should().Be(4);
        subCubes[2].Max.Z.Should().Be(1);

        subCubes[3].Min.X.Should().Be(0);
        subCubes[3].Min.Y.Should().Be(0);
        subCubes[3].Min.Z.Should().Be(2);
        subCubes[3].Max.X.Should().Be(1);
        subCubes[3].Max.Y.Should().Be(1);
        subCubes[3].Max.Z.Should().Be(4);

        subCubes[4].Min.X.Should().Be(2);
        subCubes[4].Min.Y.Should().Be(2);
        subCubes[4].Min.Z.Should().Be(0);
        subCubes[4].Max.X.Should().Be(4);
        subCubes[4].Max.Y.Should().Be(4);
        subCubes[4].Max.Z.Should().Be(1);

        subCubes[5].Min.X.Should().Be(2);
        subCubes[5].Min.Y.Should().Be(0);
        subCubes[5].Min.Z.Should().Be(2);
        subCubes[5].Max.X.Should().Be(4);
        subCubes[5].Max.Y.Should().Be(1);
        subCubes[5].Max.Z.Should().Be(4);

        subCubes[6].Min.X.Should().Be(0);
        subCubes[6].Min.Y.Should().Be(2);
        subCubes[6].Min.Z.Should().Be(2);
        subCubes[6].Max.X.Should().Be(1);
        subCubes[6].Max.Y.Should().Be(4);
        subCubes[6].Max.Z.Should().Be(4);

        subCubes[7].Min.X.Should().Be(2);
        subCubes[7].Min.Y.Should().Be(2);
        subCubes[7].Min.Z.Should().Be(2);
        subCubes[7].Max.X.Should().Be(4);
        subCubes[7].Max.Y.Should().Be(4);
        subCubes[7].Max.Z.Should().Be(4);
    }

    [Test]
    public void CubeDivision4X4X4Negative()
    {
        var cube = new SpaceBox(new Point3d(-3, -3, -3), new Point3d(0, 0, 0));
        var subCubes = cube.Divide().ToList();

        subCubes.Count.Should().Be(8);

        subCubes[0].Min.X.Should().Be(-3);
        subCubes[0].Min.Y.Should().Be(-3);
        subCubes[0].Min.Z.Should().Be(-3);
        subCubes[0].Max.X.Should().Be(-2);
        subCubes[0].Max.Y.Should().Be(-2);
        subCubes[0].Max.Z.Should().Be(-2);

        subCubes[1].Min.X.Should().Be(-1);
        subCubes[1].Min.Y.Should().Be(-3);
        subCubes[1].Min.Z.Should().Be(-3);
        subCubes[1].Max.X.Should().Be(0);
        subCubes[1].Max.Y.Should().Be(-2);
        subCubes[1].Max.Z.Should().Be(-2);

        subCubes[2].Min.X.Should().Be(-3);
        subCubes[2].Min.Y.Should().Be(-1);
        subCubes[2].Min.Z.Should().Be(-3);
        subCubes[2].Max.X.Should().Be(-2);
        subCubes[2].Max.Y.Should().Be(0);
        subCubes[2].Max.Z.Should().Be(-2);

        subCubes[3].Min.X.Should().Be(-3);
        subCubes[3].Min.Y.Should().Be(-3);
        subCubes[3].Min.Z.Should().Be(-1);
        subCubes[3].Max.X.Should().Be(-2);
        subCubes[3].Max.Y.Should().Be(-2);
        subCubes[3].Max.Z.Should().Be(0);

        subCubes[4].Min.X.Should().Be(-1);
        subCubes[4].Min.Y.Should().Be(-1);
        subCubes[4].Min.Z.Should().Be(-3);
        subCubes[4].Max.X.Should().Be(0);
        subCubes[4].Max.Y.Should().Be(0);
        subCubes[4].Max.Z.Should().Be(-2);

        subCubes[5].Min.X.Should().Be(-1);
        subCubes[5].Min.Y.Should().Be(-3);
        subCubes[5].Min.Z.Should().Be(-1);
        subCubes[5].Max.X.Should().Be(0);
        subCubes[5].Max.Y.Should().Be(-2);
        subCubes[5].Max.Z.Should().Be(0);

        subCubes[6].Min.X.Should().Be(-3);
        subCubes[6].Min.Y.Should().Be(-1);
        subCubes[6].Min.Z.Should().Be(-1);
        subCubes[6].Max.X.Should().Be(-2);
        subCubes[6].Max.Y.Should().Be(0);
        subCubes[6].Max.Z.Should().Be(0);

        subCubes[7].Min.X.Should().Be(-1);
        subCubes[7].Min.Y.Should().Be(-1);
        subCubes[7].Min.Z.Should().Be(-1);
        subCubes[7].Max.X.Should().Be(0);
        subCubes[7].Max.Y.Should().Be(0);
        subCubes[7].Max.Z.Should().Be(0);
    }

    [Test]
    public void FindDistanceToBestCoords()
    {
        const string input = """
                             pos=<10,12,12>, r=2
                             pos=<12,14,12>, r=2
                             pos=<16,12,12>, r=4
                             pos=<14,14,14>, r=6
                             pos=<50,50,50>, r=200
                             pos=<10,10,10>, r=5
                             """;

        var formation = new NanobotFormation(input.Trim());
        var distance = formation.FindManhattanDistanceToBestCoords();

        distance.Should().Be(36);
    }
}