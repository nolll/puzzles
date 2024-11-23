using FluentAssertions;
using NUnit.Framework;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202019;

public class Aoc202019Tests
{
    [Test]
    public void NumberOfValidMessagesIs2()
    {
        var validator = new MonsterImageValidator(RulesAndMessages1, false);
        var result = validator.ValidCount();

        result.Should().Be(2);
    }

    [Test]
    public void NumberOfValidMessagesIs3()
    {
        var validator = new MonsterImageValidator(RulesAndMessages2, false);
        var result = validator.ValidCount();

        result.Should().Be(3);
    }

    [TestCase("abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa", false)]
    [TestCase("bbabbbbaabaabba", true)]
    [TestCase("babbbbaabbbbbabbbbbbaabaaabaaa", false)]
    [TestCase("aaabbbbbbaaaabaababaabababbabaaabbababababaaa", false)]
    [TestCase("bbbbbbbaaaabbbbaaabbabaaa", false)]
    [TestCase("bbbababbbbaaaaaaaabbababaaababaabab", false)]
    [TestCase("ababaaaaaabaaab", true)]
    [TestCase("ababaaaaabbbaba", true)]
    [TestCase("baabbaaaabbaaaababbaababb", false)]
    [TestCase("abbbbabbbbaaaababbbbbbaaaababb", false)]
    [TestCase("aaaaabbaabaaaaababaa", false)]
    [TestCase("aaaabbaaaabbaaa", false)]
    [TestCase("aaaabbaabbaaaaaaabbbabbbaaabbaabaaa", false)]
    [TestCase("babaaabbbaaabaababbaabababaaab", false)]
    [TestCase("aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba", false)]
    public void SpecificMessagesIsValid_UnmodifiedRules(string message, bool expected)
    {
        var validator = new MonsterImageValidator(Rules2, false);
        var isValid = validator.IsValid(message);

        isValid.Should().Be(expected);
    }

    [TestCase("abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa", false)]
    [TestCase("bbabbbbaabaabba", true)]
    [TestCase("babbbbaabbbbbabbbbbbaabaaabaaa", true)]
    [TestCase("aaabbbbbbaaaabaababaabababbabaaabbababababaaa", true)]
    [TestCase("bbbbbbbaaaabbbbaaabbabaaa", true)]
    [TestCase("bbbababbbbaaaaaaaabbababaaababaabab", true)]
    [TestCase("ababaaaaaabaaab", true)]
    [TestCase("ababaaaaabbbaba", true)]
    [TestCase("baabbaaaabbaaaababbaababb", true)]
    [TestCase("abbbbabbbbaaaababbbbbbaaaababb", true)]
    [TestCase("aaaaabbaabaaaaababaa", true)]
    [TestCase("aaaabbaaaabbaaa", false)]
    [TestCase("aaaabbaabbaaaaaaabbbabbbaaabbaabaaa", true)]
    [TestCase("babaaabbbaaabaababbaabababaaab", false)]
    [TestCase("aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba", true)]
    public void SpecificMessageIsValid_ModifiedRules(string message, bool expected)
    {
        var validator = new MonsterImageValidator(Rules2, true);
        var isValid = validator.IsValid(message);

        isValid.Should().Be(expected);
    }

    [Test]
    public void NumberOfValidMessagesIs12()
    {
        var validator = new MonsterImageValidator(RulesAndMessages2, true);
        var result = validator.ValidCount();

        result.Should().Be(12);
    }

    private const string Rules1 = """
                                  0: 4 1 5
                                  1: 2 3 | 3 2
                                  2: 4 4 | 5 5
                                  3: 4 5 | 5 4
                                  4: "a"
                                  5: "b"
                                  """;

    private const string Messages1 = """
                                     ababbb
                                     bababa
                                     abbbab
                                     aaabbb
                                     aaaabbb
                                     """;

    private const string Rules2 = """
                                  42: 9 14 | 10 1
                                  9: 14 27 | 1 26
                                  10: 23 14 | 28 1
                                  1: "a"
                                  11: 42 31
                                  5: 1 14 | 15 1
                                  19: 14 1 | 14 14
                                  12: 24 14 | 19 1
                                  16: 15 1 | 14 14
                                  31: 14 17 | 1 13
                                  6: 14 14 | 1 14
                                  2: 1 24 | 14 4
                                  0: 8 11
                                  13: 14 3 | 1 12
                                  15: 1 | 14
                                  17: 14 2 | 1 7
                                  23: 25 1 | 22 14
                                  28: 16 1
                                  4: 1 1
                                  20: 14 14 | 1 15
                                  3: 5 14 | 16 1
                                  27: 1 6 | 14 18
                                  14: "b"
                                  21: 14 1 | 1 14
                                  25: 1 1 | 1 14
                                  22: 14 14
                                  8: 42
                                  26: 14 22 | 1 20
                                  18: 15 15
                                  7: 14 5 | 1 21
                                  24: 14 1
                                  """;

    private const string Messages2 = """
                                     abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa
                                     bbabbbbaabaabba
                                     babbbbaabbbbbabbbbbbaabaaabaaa
                                     aaabbbbbbaaaabaababaabababbabaaabbababababaaa
                                     bbbbbbbaaaabbbbaaabbabaaa
                                     bbbababbbbaaaaaaaabbababaaababaabab
                                     ababaaaaaabaaab
                                     ababaaaaabbbaba
                                     baabbaaaabbaaaababbaababb
                                     abbbbabbbbaaaababbbbbbaaaababb
                                     aaaaabbaabaaaaababaa
                                     aaaabbaaaabbaaa
                                     aaaabbaabbaaaaaaabbbabbbaaabbaabaaa
                                     babaaabbbaaabaababbaabababaaab
                                     aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba
                                     """;

    private static string RulesAndMessages1 => $"{Rules1}{LineBreaks.Double}{Messages1}";
    private static string RulesAndMessages2 => $"{Rules2}{LineBreaks.Double}{Messages2}";
}