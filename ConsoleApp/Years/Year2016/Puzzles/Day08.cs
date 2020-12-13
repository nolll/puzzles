using System;
using Core.TwoFactorAuth;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day08 : Day2016
    {
        public Day08() : base(8)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var simulator = new ScreenSimulator(50, 6);
            var simulatorResult = simulator.Run(FileInput);
            return new PuzzleResult(simulatorResult.PixelCount, 121);
        }

        public override PuzzleResult RunPart2()
        {
            var simulator = new ScreenSimulator(50, 6);
            var simulatorResult = simulator.Run(FileInput);
            return new PuzzleResult(simulatorResult.PrintOut, CorrectPrintout.Trim());
        }

        private const string CorrectPrintout = @"
###  #  # ###  #  #  ##  ####  ##  ####  ### #    
#  # #  # #  # #  # #  # #    #  # #      #  #    
#  # #  # #  # #  # #    ###  #  # ###    #  #    
###  #  # ###  #  # #    #    #  # #      #  #    
# #  #  # # #  #  # #  # #    #  # #      #  #    
#  #  ##  #  #  ##   ##  ####  ##  ####  ### ####";
    }
}