namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201802;

public class WrongNumberOfSimilarIdsException : Exception
{
    public WrongNumberOfSimilarIdsException(IList<string> ids) 
        : base($"Wrong number of similar ids. Should be two, was {ids.Count}.")
    {
    }
}