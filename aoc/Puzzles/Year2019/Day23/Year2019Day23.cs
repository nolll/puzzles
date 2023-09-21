﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day23;

public class Year2019Day23 : AocPuzzle
{
    public override string Title => "Category Six";

    public override PuzzleResult RunPart1()
    {
        var network = new CategorySixNetwork(FileInput);
        network.Run();

        return new PuzzleResult(network.FirstNatPacket.Y, 17_541);
    }

    public override PuzzleResult RunPart2()
    {
        var network = new CategorySixNetwork(FileInput);
        network.Run();

        return new PuzzleResult(network.FirstRepeatedNatPacket.Y, 12_415);
    }
}