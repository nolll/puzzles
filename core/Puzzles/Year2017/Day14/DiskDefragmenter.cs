using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Common.CoordinateSystems;
using Core.Common.Hashing;

namespace Core.Puzzles.Year2017.Day14;

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

    public static int GetUsedCount(Matrix<char> disk)
    {
        return disk.Values.Count(o => o == '#');
    }

    public static int GetRegionCount(Matrix<char> disk)
    {
        var processed = new Dictionary<string, int>();
        var currentRegion = 0;
        for (var y = 0; y < disk.Height; y++)
        {
            for (var x = 0; x < disk.Width; x++)
            {
                var address = new MatrixAddress(x, y);
                var value = disk.ReadValueAt(address);
                if (value == '#')
                {
                    if (!processed.ContainsKey(address.Id))
                    {
                        currentRegion += 1;
                        var addressesToProcess = new List<MatrixAddress> { address };
                        while (addressesToProcess.Any())
                        {
                            var atp = addressesToProcess.First();
                            disk.MoveTo(atp);
                            processed.Add(atp.Id, currentRegion);
                            addressesToProcess.RemoveAt(0);
                            var adjacent = disk.PerpendicularAdjacentCoords;
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

    private Matrix<char> FillDisk(string key)
    {
        var disk = new Matrix<char>();
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
        
    private string Hex2Binary(string hex)
    {
        return Convert.ToString(Convert.ToInt32(hex, 16), 2).PadLeft(4, '0');
    }

    private string GetHash(string key)
    {
        var hasher = new AsciiKnotHasher(key);
        return hasher.Hash;
    }
}