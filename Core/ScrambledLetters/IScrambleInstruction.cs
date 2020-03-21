namespace Core.ScrambledLetters
{
    public interface IScrambleInstruction
    {
        string Run(string s);
        string RunBackwards(string s);
    }
}