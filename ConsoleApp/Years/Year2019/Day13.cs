using System;
using System.Threading;
using Core.ArcadeCabinet;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day13 : Day
    {
        public Day13() : base(13)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var arcade1 = new Arcade(InputData.ComputerProgramDay13);
            arcade1.Play();

            Console.WriteLine($"Number of block tiles: {arcade1.NumberOfBlockTiles}");

            WritePartTitle();
            var arcade2 = new Arcade(InputData.ComputerProgramDay13);
            arcade2.Play(2);
        }
    }
}