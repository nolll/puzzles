namespace ConsoleApp.Puzzles.Year2016.Puzzles.Day21
{
    public interface IScrambleInstruction
    {
        string Run(string s);
        string RunBackwards(string s);
    }
}