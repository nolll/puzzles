using Core.Platform;

namespace Core.Puzzles.Year2016.Day08;

public class Year2016Day08 : Puzzle
{
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