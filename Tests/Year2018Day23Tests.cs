using System.Linq;
using Core.Puzzles.Year2018.Day23;
using NUnit.Framework;

namespace Tests
{
    public class Year2018Day23Tests
    {
        [Test]
        public void NanobotsInRangeOfStrongestNanobot()
        {
            const string input = @"
pos=<0,0,0>, r=4
pos=<1,0,0>, r=1
pos=<4,0,0>, r=3
pos=<0,2,0>, r=1
pos=<0,5,0>, r=3
pos=<0,0,3>, r=1
pos=<1,1,1>, r=1
pos=<1,1,2>, r=1
pos=<1,3,1>, r=1";

            var formation = new NanobotFormation(input);
            var botCount = formation.GetBotsInRangeOfStrongestBot().Count;

            Assert.That(botCount, Is.EqualTo(7));
        }

        [Test]
        public void CubeDivision1X2X2()
        {
            var cube = new SpaceBox(new Point3d(0, 0, 0), new Point3d(0, 1, 1));
            var subCubes = cube.Divide().ToList();

            Assert.That(subCubes.Count, Is.EqualTo(4));

            Assert.That(subCubes[0].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[0].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[0].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[0].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[0].Max.Y, Is.EqualTo(0));
            Assert.That(subCubes[0].Max.Z, Is.EqualTo(0));

            Assert.That(subCubes[1].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[1].Min.Y, Is.EqualTo(1));
            Assert.That(subCubes[1].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[1].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[1].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[1].Max.Z, Is.EqualTo(0));

            Assert.That(subCubes[2].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[2].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[2].Min.Z, Is.EqualTo(1));
            Assert.That(subCubes[2].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[2].Max.Y, Is.EqualTo(0));
            Assert.That(subCubes[2].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[3].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[3].Min.Y, Is.EqualTo(1));
            Assert.That(subCubes[3].Min.Z, Is.EqualTo(1));
            Assert.That(subCubes[3].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[3].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[3].Max.Z, Is.EqualTo(1));
        }

        [Test]
        public void CubeDivision2X2X2()
        {
            var cube = new SpaceBox(new Point3d(0, 0, 0), new Point3d(1, 1, 1));
            var subCubes = cube.Divide().ToList();

            Assert.That(subCubes.Count, Is.EqualTo(8));
            
            Assert.That(subCubes[0].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[0].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[0].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[0].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[0].Max.Y, Is.EqualTo(0));
            Assert.That(subCubes[0].Max.Z, Is.EqualTo(0));

            Assert.That(subCubes[1].Min.X, Is.EqualTo(1));
            Assert.That(subCubes[1].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[1].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[1].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[1].Max.Y, Is.EqualTo(0));
            Assert.That(subCubes[1].Max.Z, Is.EqualTo(0));

            Assert.That(subCubes[2].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[2].Min.Y, Is.EqualTo(1));
            Assert.That(subCubes[2].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[2].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[2].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[2].Max.Z, Is.EqualTo(0));

            Assert.That(subCubes[3].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[3].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[3].Min.Z, Is.EqualTo(1));
            Assert.That(subCubes[3].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[3].Max.Y, Is.EqualTo(0));
            Assert.That(subCubes[3].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[4].Min.X, Is.EqualTo(1));
            Assert.That(subCubes[4].Min.Y, Is.EqualTo(1));
            Assert.That(subCubes[4].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[4].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[4].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[4].Max.Z, Is.EqualTo(0));

            Assert.That(subCubes[5].Min.X, Is.EqualTo(1));
            Assert.That(subCubes[5].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[5].Min.Z, Is.EqualTo(1));
            Assert.That(subCubes[5].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[5].Max.Y, Is.EqualTo(0));
            Assert.That(subCubes[5].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[6].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[6].Min.Y, Is.EqualTo(1));
            Assert.That(subCubes[6].Min.Z, Is.EqualTo(1));
            Assert.That(subCubes[6].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[6].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[6].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[7].Min.X, Is.EqualTo(1));
            Assert.That(subCubes[7].Min.Y, Is.EqualTo(1));
            Assert.That(subCubes[7].Min.Z, Is.EqualTo(1));
            Assert.That(subCubes[7].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[7].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[7].Max.Z, Is.EqualTo(1));
        }

        [Test]
        public void CubeDivision4X4X4()
        {
            var cube = new SpaceBox(new Point3d(0, 0, 0), new Point3d(3, 3, 3));
            var subCubes = cube.Divide().ToList();

            Assert.That(subCubes.Count, Is.EqualTo(8));

            Assert.That(subCubes[0].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[0].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[0].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[0].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[0].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[0].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[1].Min.X, Is.EqualTo(2));
            Assert.That(subCubes[1].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[1].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[1].Max.X, Is.EqualTo(3));
            Assert.That(subCubes[1].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[1].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[2].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[2].Min.Y, Is.EqualTo(2));
            Assert.That(subCubes[2].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[2].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[2].Max.Y, Is.EqualTo(3));
            Assert.That(subCubes[2].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[3].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[3].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[3].Min.Z, Is.EqualTo(2));
            Assert.That(subCubes[3].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[3].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[3].Max.Z, Is.EqualTo(3));

            Assert.That(subCubes[4].Min.X, Is.EqualTo(2));
            Assert.That(subCubes[4].Min.Y, Is.EqualTo(2));
            Assert.That(subCubes[4].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[4].Max.X, Is.EqualTo(3));
            Assert.That(subCubes[4].Max.Y, Is.EqualTo(3));
            Assert.That(subCubes[4].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[5].Min.X, Is.EqualTo(2));
            Assert.That(subCubes[5].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[5].Min.Z, Is.EqualTo(2));
            Assert.That(subCubes[5].Max.X, Is.EqualTo(3));
            Assert.That(subCubes[5].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[5].Max.Z, Is.EqualTo(3));

            Assert.That(subCubes[6].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[6].Min.Y, Is.EqualTo(2));
            Assert.That(subCubes[6].Min.Z, Is.EqualTo(2));
            Assert.That(subCubes[6].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[6].Max.Y, Is.EqualTo(3));
            Assert.That(subCubes[6].Max.Z, Is.EqualTo(3));

            Assert.That(subCubes[7].Min.X, Is.EqualTo(2));
            Assert.That(subCubes[7].Min.Y, Is.EqualTo(2));
            Assert.That(subCubes[7].Min.Z, Is.EqualTo(2));
            Assert.That(subCubes[7].Max.X, Is.EqualTo(3));
            Assert.That(subCubes[7].Max.Y, Is.EqualTo(3));
            Assert.That(subCubes[7].Max.Z, Is.EqualTo(3));
        }

        [Test]
        public void CubeDivision5X5X5()
        {
            var cube = new SpaceBox(new Point3d(0, 0, 0), new Point3d(4, 4, 4));
            var subCubes = cube.Divide().ToList();

            Assert.That(subCubes.Count, Is.EqualTo(8));

            Assert.That(subCubes[0].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[0].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[0].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[0].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[0].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[0].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[1].Min.X, Is.EqualTo(2));
            Assert.That(subCubes[1].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[1].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[1].Max.X, Is.EqualTo(4));
            Assert.That(subCubes[1].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[1].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[2].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[2].Min.Y, Is.EqualTo(2));
            Assert.That(subCubes[2].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[2].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[2].Max.Y, Is.EqualTo(4));
            Assert.That(subCubes[2].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[3].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[3].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[3].Min.Z, Is.EqualTo(2));
            Assert.That(subCubes[3].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[3].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[3].Max.Z, Is.EqualTo(4));

            Assert.That(subCubes[4].Min.X, Is.EqualTo(2));
            Assert.That(subCubes[4].Min.Y, Is.EqualTo(2));
            Assert.That(subCubes[4].Min.Z, Is.EqualTo(0));
            Assert.That(subCubes[4].Max.X, Is.EqualTo(4));
            Assert.That(subCubes[4].Max.Y, Is.EqualTo(4));
            Assert.That(subCubes[4].Max.Z, Is.EqualTo(1));

            Assert.That(subCubes[5].Min.X, Is.EqualTo(2));
            Assert.That(subCubes[5].Min.Y, Is.EqualTo(0));
            Assert.That(subCubes[5].Min.Z, Is.EqualTo(2));
            Assert.That(subCubes[5].Max.X, Is.EqualTo(4));
            Assert.That(subCubes[5].Max.Y, Is.EqualTo(1));
            Assert.That(subCubes[5].Max.Z, Is.EqualTo(4));

            Assert.That(subCubes[6].Min.X, Is.EqualTo(0));
            Assert.That(subCubes[6].Min.Y, Is.EqualTo(2));
            Assert.That(subCubes[6].Min.Z, Is.EqualTo(2));
            Assert.That(subCubes[6].Max.X, Is.EqualTo(1));
            Assert.That(subCubes[6].Max.Y, Is.EqualTo(4));
            Assert.That(subCubes[6].Max.Z, Is.EqualTo(4));

            Assert.That(subCubes[7].Min.X, Is.EqualTo(2));
            Assert.That(subCubes[7].Min.Y, Is.EqualTo(2));
            Assert.That(subCubes[7].Min.Z, Is.EqualTo(2));
            Assert.That(subCubes[7].Max.X, Is.EqualTo(4));
            Assert.That(subCubes[7].Max.Y, Is.EqualTo(4));
            Assert.That(subCubes[7].Max.Z, Is.EqualTo(4));
        }

        [Test]
        public void CubeDivision4X4X4Negative()
        {
            var cube = new SpaceBox(new Point3d(-3, -3, -3), new Point3d(0, 0, 0));
            var subCubes = cube.Divide().ToList();

            Assert.That(subCubes.Count, Is.EqualTo(8));

            Assert.That(subCubes[0].Min.X, Is.EqualTo(-3));
            Assert.That(subCubes[0].Min.Y, Is.EqualTo(-3));
            Assert.That(subCubes[0].Min.Z, Is.EqualTo(-3));
            Assert.That(subCubes[0].Max.X, Is.EqualTo(-2));
            Assert.That(subCubes[0].Max.Y, Is.EqualTo(-2));
            Assert.That(subCubes[0].Max.Z, Is.EqualTo(-2));

            Assert.That(subCubes[1].Min.X, Is.EqualTo(-1));
            Assert.That(subCubes[1].Min.Y, Is.EqualTo(-3));
            Assert.That(subCubes[1].Min.Z, Is.EqualTo(-3));
            Assert.That(subCubes[1].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[1].Max.Y, Is.EqualTo(-2));
            Assert.That(subCubes[1].Max.Z, Is.EqualTo(-2));

            Assert.That(subCubes[2].Min.X, Is.EqualTo(-3));
            Assert.That(subCubes[2].Min.Y, Is.EqualTo(-1));
            Assert.That(subCubes[2].Min.Z, Is.EqualTo(-3));
            Assert.That(subCubes[2].Max.X, Is.EqualTo(-2));
            Assert.That(subCubes[2].Max.Y, Is.EqualTo(0));
            Assert.That(subCubes[2].Max.Z, Is.EqualTo(-2));

            Assert.That(subCubes[3].Min.X, Is.EqualTo(-3));
            Assert.That(subCubes[3].Min.Y, Is.EqualTo(-3));
            Assert.That(subCubes[3].Min.Z, Is.EqualTo(-1));
            Assert.That(subCubes[3].Max.X, Is.EqualTo(-2));
            Assert.That(subCubes[3].Max.Y, Is.EqualTo(-2));
            Assert.That(subCubes[3].Max.Z, Is.EqualTo(0));

            Assert.That(subCubes[4].Min.X, Is.EqualTo(-1));
            Assert.That(subCubes[4].Min.Y, Is.EqualTo(-1));
            Assert.That(subCubes[4].Min.Z, Is.EqualTo(-3));
            Assert.That(subCubes[4].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[4].Max.Y, Is.EqualTo(0));
            Assert.That(subCubes[4].Max.Z, Is.EqualTo(-2));

            Assert.That(subCubes[5].Min.X, Is.EqualTo(-1));
            Assert.That(subCubes[5].Min.Y, Is.EqualTo(-3));
            Assert.That(subCubes[5].Min.Z, Is.EqualTo(-1));
            Assert.That(subCubes[5].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[5].Max.Y, Is.EqualTo(-2));
            Assert.That(subCubes[5].Max.Z, Is.EqualTo(0));

            Assert.That(subCubes[6].Min.X, Is.EqualTo(-3));
            Assert.That(subCubes[6].Min.Y, Is.EqualTo(-1));
            Assert.That(subCubes[6].Min.Z, Is.EqualTo(-1));
            Assert.That(subCubes[6].Max.X, Is.EqualTo(-2));
            Assert.That(subCubes[6].Max.Y, Is.EqualTo(0));
            Assert.That(subCubes[6].Max.Z, Is.EqualTo(0));

            Assert.That(subCubes[7].Min.X, Is.EqualTo(-1));
            Assert.That(subCubes[7].Min.Y, Is.EqualTo(-1));
            Assert.That(subCubes[7].Min.Z, Is.EqualTo(-1));
            Assert.That(subCubes[7].Max.X, Is.EqualTo(0));
            Assert.That(subCubes[7].Max.Y, Is.EqualTo(0));
            Assert.That(subCubes[7].Max.Z, Is.EqualTo(0));
        }

        [Test]
        public void FindDistanceToBestCoords()
        {
            const string input = @"
pos=<10,12,12>, r=2
pos=<12,14,12>, r=2
pos=<16,12,12>, r=4
pos=<14,14,14>, r=6
pos=<50,50,50>, r=200
pos=<10,10,10>, r=5";

            var formation = new NanobotFormation(input);
            var distance = formation.FindManhattanDistanceToBestCoords();

            Assert.That(distance, Is.EqualTo(36));
        }
    }
}