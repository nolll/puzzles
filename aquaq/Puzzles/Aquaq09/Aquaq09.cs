using System.Numerics;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq09;

public class Aquaq09 : AquaqPuzzle
{
    public override string Name => "Big Data?";

    protected override PuzzleResult Run()
    {
        var numbers = InputFile.Split(Environment.NewLine)
            .Select(BigInteger.Parse);
        var result = MultiplyLargeNumbers(numbers);

        return new PuzzleResult(result, BigInteger.Parse("15219490042476673293856415300433634433293774002195671040"));
    }

    public static BigInteger MultiplyLargeNumbers(IEnumerable<BigInteger> numbers) 
        => numbers.Aggregate(new BigInteger(1), BigInteger.Multiply);
}