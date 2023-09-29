﻿using Common;

namespace Aquaq;

public class AquaqProgram
{
    private const string DebugPuzzle = "9";

    static void Main(string[] args)
    {
        var program = new Program(
            new AquaqPuzzleRepository(),
            new AquaqHelpPrinter());

        program.Run(args, DebugPuzzle);
    }
}