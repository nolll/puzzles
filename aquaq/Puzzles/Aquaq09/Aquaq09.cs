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

        return new PuzzleResult(result, "88483d350a085c8282b9f14aa24309c7");
    }

    public static BigInteger MultiplyLargeNumbers(IEnumerable<BigInteger> numbers) 
        => numbers.Aggregate(new BigInteger(1), BigInteger.Multiply);
}