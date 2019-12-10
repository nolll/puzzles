using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Inputs;

namespace ConsoleApp.Years.Year2018
{
    public class Day01 : Day
    {
        public Day01() : base(1)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var frequencyPuzzle = new FrequencyPuzzle(InputData.FrequencyChanges);
            var resultingFrequency = frequencyPuzzle.ResultingFrequency;
            Console.WriteLine($"Resulting frequency: {resultingFrequency}");

            WritePartTitle();
            var frequencyRepeatPuzzle = new FrequencyRepeatPuzzle(InputData.FrequencyChanges);
            var firstRepeatedFrequency = frequencyRepeatPuzzle.FirstRepeatedFrequency;
            Console.WriteLine($"First repeat: {firstRepeatedFrequency}");
        }
    }

    public class FrequencyPuzzle
    {
        public int ResultingFrequency { get; }

        public FrequencyPuzzle(string input)
        {
            var changes = FrequencyChangeListReader.Read(input);
            ResultingFrequency = changes.Sum();
        }
    }

    public class FrequencyRepeatPuzzle
    {
        public int? FirstRepeatedFrequency { get; }

        public FrequencyRepeatPuzzle(string input)
        {
            var changes = FrequencyChangeListReader.Read(input);
            FirstRepeatedFrequency = GetFirstRepeat(changes);
        }

        private static int? GetFirstRepeat(List<int> changes)
        {
            var sum = 0;
            var uniqueResults = new List<int> { sum };
            int? firstRepeat = null;
            while (firstRepeat == null)
            {
                foreach (var change in changes)
                {
                    sum += change;
                    if (uniqueResults.Contains(sum))
                    {
                        firstRepeat = sum;
                        break;
                    }
                    uniqueResults.Add(sum);
                }
            }
            return firstRepeat;
        }
    }

    public static class StringListReader
    {
        public static List<string> Read(string str)
        {
            return str.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
        }
    }

    public static class IntListReader
    {
        public static List<int> Read(string str)
        {
            return StringListReader.Read(str).Select(ConvertToInt).ToList();
        }

        private static int ConvertToInt(string str)
        {
            return int.Parse(str);
        }
    }
    
    public static class FrequencyChangeListReader
    {
        public static List<int> Read(string str)
        {
            return IntListReader.Read(RemovePlusSigns(str)).ToList();
        }

        private static string RemovePlusSigns(string input)
        {
            return input.Replace("+", "");
        }
    }
}