using FluentAssertions;

namespace Pzl.Tools.Combinatorics;

public static class ListAssert
{
    public static void IsEquivalent(IEnumerable<IEnumerable<int>> result, IEnumerable<IEnumerable<int>> expected)
    {
        var r = result.ToList();
        var e = expected.ToList();
        r.Count.Should().Be(e.Count);
        for (var i = 0; i < e.Count; i++)
        {
            r[i].Should().BeEquivalentTo(e[i], o => o.WithStrictOrdering());
        }
    }
}