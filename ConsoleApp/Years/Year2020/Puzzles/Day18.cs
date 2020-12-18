﻿using Core.ExperimentalEnergySource;
using Core.MathHomework;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day18 : Day2020
    {
        public Day18() : base(18)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var calculator = new HomeworkCalculator();
            var result = calculator.SumOfAll(FileInput);
            return new PuzzleResult(result, 4_297_397_455_886);
        }

    }
}