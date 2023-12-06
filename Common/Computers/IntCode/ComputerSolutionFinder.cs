namespace Puzzles.Common.Computers.IntCode;

public class ComputerSolutionFinder
{
    private readonly string _input;

    public ComputerSolutionFinder(string input)
    {
        _input = input;
    }

    private const int LowerBound = 1;
    private const int UpperBound = 99;

    public Result? FindSolution(int target)
    {
        var computer = new ConsoleComputer(_input);
        for (var noun = LowerBound; noun <= UpperBound; noun++)
        {
            for (var verb = LowerBound; verb <= UpperBound; verb++)
            {
                computer.Start(false, noun, verb);
                var result = computer.Result;
                if(result == target)
                    return new Result(noun, verb, target);
            }
        }

        return null;
    }

    public class Result
    {
        public int Noun { get; }
        public int Verb { get; }
        public int Integer { get; }

        public Result(int noun, int verb, int integer)
        {
            Noun = noun;
            Verb = verb;
            Integer = integer;
        }
    }
}