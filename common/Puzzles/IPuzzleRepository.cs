﻿namespace common.Puzzles;

public interface IPuzzleRepository
{
    PuzzleWrapper? GetPuzzle(string id);
    IList<PuzzleWrapper> GetPuzzles();
}