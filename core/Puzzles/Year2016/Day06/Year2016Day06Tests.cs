using NUnit.Framework;

namespace Core.Puzzles.Year2016.Day06;

public class Year2016Day06Tests
{
    [Test]
    public void MessageIsCorrect_MostCommon()
    {
        const string input = @"
eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar";

        var reader = new RepetitionCodeReader();
        var coin = reader.ReadMostCommon(input);

        Assert.That(coin, Is.EqualTo("easter"));
    }

    [Test]
    public void MessageIsCorrect_LeastCommon()
    {
        const string input = @"
eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar";

        var reader = new RepetitionCodeReader();
        var coin = reader.ReadLeastCommon(input);

        Assert.That(coin, Is.EqualTo("advent"));
    }
}