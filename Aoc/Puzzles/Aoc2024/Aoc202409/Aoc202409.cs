using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202409;

[Name("")]
public class Aoc202409 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var nums = input.ToCharArray().Select(o => int.Parse(o.ToString())).ToArray();
        var blocks = new int[nums.Sum()];

        var b = 0;
        var isFile = true;
        for (var i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums[i]; j++)
            {
                blocks[b] = isFile ? i / 2 : -1;
                b++;
            }

            isFile = !isFile;
        }

        var f = 0;
        var r = blocks.Length - 1;

        while (f < r)
        {
            if (blocks[f] > -1)
            {
                f++;
                continue;
            }

            if (blocks[r] == -1)
            {
                r--;
                continue;
            }

            blocks[f] = blocks[r];
            blocks[r] = -1;
            f++;
            r--;
        }

        var checksum = GetChecksum(blocks);
        
        return new PuzzleResult(checksum, "4ca7aa30f44261b47440a1e8e3647d44");
    }

    public PuzzleResult Part2(string input)
    {
        var nums = input.ToCharArray().Select(o => int.Parse(o.ToString())).ToArray();
        var blocks = new int[nums.Sum()];

        var b = 0;
        var isFile = true;
        var filePositions = new List<int>();
        var fileLengths = new List<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var fileLength = 0;
            var filePos = b;
            for (int j = 0; j < nums[i]; j++)
            {
                blocks[b] = isFile ? i / 2 : -1;
                b++;
                fileLength++;
            }
            
            if(isFile)
            {
                filePositions.Add(filePos);
                fileLengths.Add(fileLength);
            }

            isFile = !isFile;
        }

        var fileIndex = fileLengths.Count - 1;
        
        while (fileIndex > 0)
        {
            var f = 0;
            var filePos = filePositions[fileIndex];

            while (f < filePos)
            {
                if (blocks[f] > -1)
                {
                    f++;
                    continue;
                }
                
                var availableSpace = 0;
                var localPos = 0;
                while (f + localPos < blocks.Length && blocks[f + localPos] == -1)
                {
                    availableSpace++;
                    localPos++;
                }
                
                if (fileLengths[fileIndex] <= availableSpace)
                {
                    for (var i = 0; i < fileLengths[fileIndex]; i++)
                    {
                        blocks[f] = blocks[filePositions[fileIndex] + i];
                        blocks[filePositions[fileIndex] + i] = -1;
                        f++;
                    }

                    continue;
                }

                f++;
            }

            fileIndex--;
        }

        var checksum = GetChecksum(blocks);
        
        return new PuzzleResult(checksum, "f3d4ebfe09ec0844f2c28f0c22458833");
    }

    private static long GetChecksum(int[] blocks)
    {
        var checksum = 0L;
        for (var a = 0; a < blocks.Length; a++)
        {
            var v = blocks[a];
            if (v > -1)
                checksum += a * v;
        }

        return checksum;
    }
}