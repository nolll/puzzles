using System;
using Core.JsonAccounting;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day12 : Day2015
    {
        public Day12() : base(12)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var doc1 = new JsonDoc(FileInput, true);
            Console.WriteLine($"Document sum: {doc1.Sum}");

            WritePartTitle();
            var doc2 = new JsonDoc(FileInput, false);
            Console.WriteLine($"Document sum without red: {doc2.Sum}");
        }
    }
}