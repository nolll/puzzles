﻿using System.Linq;

namespace App.Puzzles.Year2018.Day01
{
    public class FrequencyPuzzle
    {
        public int ResultingFrequency { get; }

        public FrequencyPuzzle(string input)
        {
            var changes = FrequencyChangeListReader.Read(input);
            ResultingFrequency = changes.Sum();
        }
    }
}