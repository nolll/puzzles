﻿using System.Linq;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201904;

public class Aoc201904 : AocPuzzle
{
    public override string Name => "Secure Container";

    protected override PuzzleResult RunPart1()
    {
        var passwordBounds = Input.Split('-');
        var passwordLowerbound = int.Parse(passwordBounds[0]);
        var passwordUpperbound = int.Parse(passwordBounds[1]);

        var passwordFinder = new PasswordFinder();
        var passwords = passwordFinder.FindPart1(passwordLowerbound, passwordUpperbound);
        var passwordCount = passwords.Count();
        return new PuzzleResult(passwordCount, 530);
    }

    protected override PuzzleResult RunPart2()
    {
        var passwordBounds = Input.Split('-');
        var passwordLowerbound = int.Parse(passwordBounds[0]);
        var passwordUpperbound = int.Parse(passwordBounds[1]);

        var passwordFinder = new PasswordFinder();
        var passwords = passwordFinder.FindPart2(passwordLowerbound, passwordUpperbound);
        var passwordCount = passwords.Count();
        return new PuzzleResult(passwordCount, 324);
    }

    private const string Input = "357253-892942";
}