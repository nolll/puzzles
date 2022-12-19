using System.Linq;
using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day16;

public class Year2022Day16Tests
{
    [Test]
    public void Part1()
    {
        var pipes = new VolcanicPipes();
        var result = pipes.Part1(Input);

        Assert.That(result, Is.EqualTo(1651));
    }

    [Test]
    public void Part1Try2()
    {
        var pipes = new VolcanicPipes();
        var result = pipes.Part1Try2(Input);

        Assert.That(result, Is.EqualTo(1651));
    }

    //[Test]
    //public void Part2()
    //{
    //    var result = 0;

    //    Assert.That(result, Is.EqualTo(0));
    //}

    //[Test]
    //public void CreateMoveCosts()
    //{
    //    var (valves, connections, _) = ValveData.ParseData(Input);
    //    var result = ValveData.BuildMoveCosts(valves, connections);

    //    Assert.That(result.Count, Is.EqualTo(20));
    //    Assert.That(result[("AA", "DD")], Is.EqualTo(1));
    //    Assert.That(result[("AA", "II")], Is.EqualTo(1));
    //    Assert.That(result[("AA", "BB")], Is.EqualTo(1));
    //    Assert.That(result[("BB", "CC")], Is.EqualTo(1));
    //    Assert.That(result[("BB", "AA")], Is.EqualTo(1));
    //    Assert.That(result[("CC", "DD")], Is.EqualTo(1));
    //    Assert.That(result[("CC", "BB")], Is.EqualTo(1));
    //    Assert.That(result[("DD", "CC")], Is.EqualTo(1));
    //    Assert.That(result[("DD", "AA")], Is.EqualTo(1));
    //    Assert.That(result[("DD", "EE")], Is.EqualTo(1));
    //    Assert.That(result[("EE", "FF")], Is.EqualTo(1));
    //    Assert.That(result[("EE", "DD")], Is.EqualTo(1));
    //    Assert.That(result[("FF", "EE")], Is.EqualTo(1));
    //    Assert.That(result[("FF", "GG")], Is.EqualTo(1));
    //    Assert.That(result[("GG", "FF")], Is.EqualTo(1));
    //    Assert.That(result[("GG", "HH")], Is.EqualTo(1));
    //    Assert.That(result[("HH", "GG")], Is.EqualTo(1));
    //    Assert.That(result[("II", "AA")], Is.EqualTo(1));
    //    Assert.That(result[("II", "JJ")], Is.EqualTo(1));
    //    Assert.That(result[("JJ", "II")], Is.EqualTo(1));
    //}

    [Test]
    public void OptimizedValves()
    {
        var (origValves, origConnections, origRates) = ValveData.ParseData(Input);

        var (valves, _, _) = ValveData.OptimizeData(origValves, origConnections, origRates);

        Assert.That(valves.Count, Is.EqualTo(7));
        Assert.That(valves[0], Is.EqualTo("AA"));
        Assert.That(valves[1], Is.EqualTo("BB"));
        Assert.That(valves[2], Is.EqualTo("CC"));
        Assert.That(valves[3], Is.EqualTo("DD"));
        Assert.That(valves[4], Is.EqualTo("EE"));
        Assert.That(valves[5], Is.EqualTo("HH"));
        Assert.That(valves[6], Is.EqualTo("JJ"));
    }

    //[Test]
    //public void OptimizedConnections()
    //{
    //    var (origValves, origConnections, origRates) = ValveData.ParseData(Input);

    //    var (_, connections, _) = ValveData.OptimizeData(origValves, origConnections, origRates);

    //    Assert.That(connections.Count, Is.EqualTo(7));
    //    Assert.That(string.Join(',', connections["AA"].Select(o => o.Valve)), Is.EqualTo("DD,BB,JJ"));
    //    Assert.That(string.Join(',', connections["BB"].Select(o => o.Valve)), Is.EqualTo("CC,AA"));
    //    Assert.That(string.Join(',', connections["CC"].Select(o => o.Valve)), Is.EqualTo("DD,BB"));
    //    Assert.That(string.Join(',', connections["DD"].Select(o => o.Valve)), Is.EqualTo("CC,AA,EE"));
    //    Assert.That(string.Join(',', connections["EE"].Select(o => o.Valve)), Is.EqualTo("DD,HH"));
    //    Assert.That(string.Join(',', connections["HH"].Select(o => o.Valve)), Is.EqualTo("EE"));
    //    Assert.That(string.Join(',', connections["JJ"].Select(o => o.Valve)), Is.EqualTo("AA"));
    //}

    [Test]
    public void OptimizedRates()
    {
        var (origValves, origConnections, origRates) = ValveData.ParseData(Input);
        var (_, _, rates) = ValveData.OptimizeData(origValves, origConnections, origRates);

        Assert.That(rates.Count, Is.EqualTo(7));
        Assert.That(rates["AA"], Is.EqualTo(0));
        Assert.That(rates["BB"], Is.EqualTo(13));
        Assert.That(rates["CC"], Is.EqualTo(2));
        Assert.That(rates["DD"], Is.EqualTo(20));
        Assert.That(rates["EE"], Is.EqualTo(3));
        Assert.That(rates["HH"], Is.EqualTo(22));
        Assert.That(rates["JJ"], Is.EqualTo(21));
    }

    //[Test]
    //public void OptimizedMoveCosts()
    //{
    //    var (origValves, origConnections, origRates) = ValveData.ParseData(Input);
    //    var (_, _, _) = ValveData.OptimizeData(origValves, origConnections, origRates);

    //    //Assert.That(moveCosts.Count, Is.EqualTo(14));
    //    Assert.That(moveCosts[("AA", "DD")], Is.EqualTo(1));
    //    Assert.That(moveCosts[("AA", "JJ")], Is.EqualTo(2));
    //    Assert.That(moveCosts[("AA", "BB")], Is.EqualTo(1));
    //    Assert.That(moveCosts[("BB", "CC")], Is.EqualTo(1));
    //    Assert.That(moveCosts[("BB", "AA")], Is.EqualTo(1));
    //    Assert.That(moveCosts[("CC", "DD")], Is.EqualTo(1));
    //    Assert.That(moveCosts[("CC", "BB")], Is.EqualTo(1));
    //    Assert.That(moveCosts[("DD", "CC")], Is.EqualTo(1));
    //    Assert.That(moveCosts[("DD", "AA")], Is.EqualTo(1));
    //    Assert.That(moveCosts[("DD", "EE")], Is.EqualTo(1));
    //    Assert.That(moveCosts[("EE", "GG")], Is.EqualTo(2));
    //    Assert.That(moveCosts[("EE", "DD")], Is.EqualTo(1));
    //    Assert.That(moveCosts[("HH", "EE")], Is.EqualTo(3));
    //    Assert.That(moveCosts[("JJ", "AA")], Is.EqualTo(2));
    //}

    private const string Input = """ 
Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=2; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE
Valve EE has flow rate=3; tunnels lead to valves FF, DD
Valve FF has flow rate=0; tunnels lead to valves EE, GG
Valve GG has flow rate=0; tunnels lead to valves FF, HH
Valve HH has flow rate=22; tunnel leads to valve GG
Valve II has flow rate=0; tunnels lead to valves AA, JJ
Valve JJ has flow rate=21; tunnel leads to valve II
""";
}