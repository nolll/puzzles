﻿namespace Core.Puzzles.Year2016.Day08;

public class ScreenSimulatorResult
{
    public int PixelCount { get; }
    public string PrintOut { get; }
    public string Letters { get; }

    public ScreenSimulatorResult(int pixelCount, string printOut, string letters)
    {
        PixelCount = pixelCount;
        PrintOut = printOut;
        Letters = letters;
    }
}