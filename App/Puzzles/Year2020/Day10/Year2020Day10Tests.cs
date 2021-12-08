using NUnit.Framework;

namespace App.Puzzles.Year2020.Day10
{
    public class Year2020Day10Tests
    {
        private const string Input1 = @"
16
10
15
5
1
11
7
19
6
12
4";

        private const string Input2 = @"
28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";

        [TestCase(Input1, 35)]
        [TestCase(Input2, 220)]
        public void PowerAdapterChainIsCorrect(string input, int expected)
        {
            var chain = new PowerAdapterChain(input);
            var product = chain.DifferenceProduct;

            Assert.That(product, Is.EqualTo(expected));
        }

        [TestCase(Input1, 8)]
        [TestCase(Input2, 19208)]
        public void PowerAdapterChainTotalCombinations(string input, int expected)
        {
            var chain = new PowerAdapterChain(input);
            var combinations = chain.GetTotalNumberOfCombinations();

            Assert.That(combinations, Is.EqualTo(expected));
        }
    }
}