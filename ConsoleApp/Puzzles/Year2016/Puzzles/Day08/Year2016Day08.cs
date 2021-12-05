namespace ConsoleApp.Puzzles.Year2016.Puzzles.Day08
{
    public class Year2016Day08 : Year2016Day
    {
        public override int Day => 8;

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