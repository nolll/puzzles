using System.Text;
using Pzl.Common;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Disk Defragmentation")]
public class Aoc201714 : AocPuzzle
{
    [Puzzle("b6c685ad1667d629c3f6a13cc52ee2d0")]
    public int Part1(string input) => new DiskDefragmenter(input).UsedCount;

    [Puzzle("3e2bb366df3fce1977350353f38f3787")]
    public int Part2(string input) => new DiskDefragmenter(input).RegionCount;

    public class DiskDefragmenter
    {
        public int UsedCount { get; }
        public int RegionCount { get; }

        public DiskDefragmenter(string key)
        {
            var disk = FillDisk(key);
            UsedCount = GetUsedCount(disk);
            RegionCount = GetRegionCount(disk);
        }

        private static int GetUsedCount(Grid<char> disk) => disk.Values.Count(o => o == '#');

        private static int GetRegionCount(Grid<char> disk)
        {
            var processed = new Dictionary<string, int>();
            var currentRegion = 0;
            for (var y = 0; y < disk.Height; y++)
            {
                for (var x = 0; x < disk.Width; x++)
                {
                    var address = new Coord(x, y);
                    var value = disk.ReadValueAt(address);
                    if (value == '#')
                    {
                        if (!processed.ContainsKey(address.Id))
                        {
                            currentRegion += 1;
                            var addressesToProcess = new List<Coord> { address };
                            while (addressesToProcess.Any())
                            {
                                var atp = addressesToProcess.First();
                                processed.Add(atp.Id, currentRegion);
                                addressesToProcess.RemoveAt(0);
                                var adjacent = disk.OrthogonalAdjacentCoordsTo(atp);
                                var coordsToAdd = adjacent.Where(o =>
                                    disk.ReadValueAt(o) == '#' &&
                                    !processed.ContainsKey(o.Id) &&
                                    addressesToProcess.All(oo => oo.Id != o.Id));
                                addressesToProcess.AddRange(coordsToAdd);
                            }
                        }
                    }
                }
            }

            return processed.Values.Distinct().Count();
        }

        private static Grid<char> FillDisk(string key)
        {
            var disk = new Grid<char>();
            for (var y = 0; y < 128; y++)
            {
                var hash = GetHash($"{key}-{y}");
                var sb = new StringBuilder();
                foreach (var c in hash)
                {
                    sb.Append(Hex2Binary(c.ToString()));
                }

                var binaryString = sb.ToString();
                var x = 0;
                foreach (var c in binaryString)
                {
                    disk.MoveTo(x, y);
                    var value = c == '1'
                        ? '#'
                        : '.';
                    disk.WriteValue(value);
                    x++;
                }
            }

            return disk;
        }

        private static string Hex2Binary(string hex) => 
            Convert.ToString(Convert.ToInt32(hex, 16), 2).PadLeft(4, '0');

        private static string GetHash(string key) => new AsciiKnotHasher(key).Hash;
    }
}