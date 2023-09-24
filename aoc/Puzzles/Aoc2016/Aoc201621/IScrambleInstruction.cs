namespace Aoc.Puzzles.Aoc2016.Day21;

public interface IScrambleInstruction
{
    string Run(string s);
    string RunBackwards(string s);
}