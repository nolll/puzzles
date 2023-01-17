using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day16;

public class Year2022Day16Tests
{
    [Test]
    public void Part1()
    {
        var pipes = new VolcanicPipes(Input);
        var result = pipes.Part1();

        Assert.That(result, Is.EqualTo(1651));
    }

    [Test]
    public void Part1Linear()
    {
        // https://www.reddit.com/r/adventofcode/comments/znklnh/2022_day_16_some_extra_test_cases_for_day_16/
        var pipes = new VolcanicPipes(LinearInput);
        var result = pipes.Part1();

        Assert.That(result, Is.EqualTo(2640));
    }

    [Test]
    public void Part1Quadratic()
    {
        // https://www.reddit.com/r/adventofcode/comments/znklnh/2022_day_16_some_extra_test_cases_for_day_16/
        var pipes = new VolcanicPipes(QuadraticInput);
        var result = pipes.Part1();

        Assert.That(result, Is.EqualTo(13468));
    }

    [Test]
    public void Part1Circular()
    {
        // https://www.reddit.com/r/adventofcode/comments/znklnh/2022_day_16_some_extra_test_cases_for_day_16/
        var pipes = new VolcanicPipes(CircularInput);
        var result = pipes.Part1();

        Assert.That(result, Is.EqualTo(1288));
    }

    [Test]
    public void Part1Clustered()
    {
        // https://www.reddit.com/r/adventofcode/comments/znklnh/2022_day_16_some_extra_test_cases_for_day_16/
        var pipes = new VolcanicPipes(ClusteredInput);
        var result = pipes.Part1();

        Assert.That(result, Is.EqualTo(2400));
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

    private const string LinearInput = """
Valve LA has flow rate=22; tunnels lead to valves KA, MA
Valve MA has flow rate=24; tunnels lead to valves LA, NA
Valve NA has flow rate=26; tunnels lead to valves MA, OA
Valve OA has flow rate=28; tunnels lead to valves NA, PA
Valve PA has flow rate=30; tunnels lead to valves OA
Valve AA has flow rate=0; tunnels lead to valves BA
Valve BA has flow rate=2; tunnels lead to valves AA, CA
Valve CA has flow rate=4; tunnels lead to valves BA, DA
Valve DA has flow rate=6; tunnels lead to valves CA, EA
Valve EA has flow rate=8; tunnels lead to valves DA, FA
Valve FA has flow rate=10; tunnels lead to valves EA, GA
Valve GA has flow rate=12; tunnels lead to valves FA, HA
Valve HA has flow rate=14; tunnels lead to valves GA, IA
Valve IA has flow rate=16; tunnels lead to valves HA, JA
Valve JA has flow rate=18; tunnels lead to valves IA, KA
Valve KA has flow rate=20; tunnels lead to valves JA, LA
""";

    private const string QuadraticInput = """
Valve AA has flow rate=0; tunnels lead to valves BA
Valve BA has flow rate=1; tunnels lead to valves AA, CA
Valve CA has flow rate=4; tunnels lead to valves BA, DA
Valve DA has flow rate=9; tunnels lead to valves CA, EA
Valve EA has flow rate=16; tunnels lead to valves DA, FA
Valve FA has flow rate=25; tunnels lead to valves EA, GA
Valve GA has flow rate=36; tunnels lead to valves FA, HA
Valve HA has flow rate=49; tunnels lead to valves GA, IA
Valve IA has flow rate=64; tunnels lead to valves HA, JA
Valve JA has flow rate=81; tunnels lead to valves IA, KA
Valve KA has flow rate=100; tunnels lead to valves JA, LA
Valve LA has flow rate=121; tunnels lead to valves KA, MA
Valve MA has flow rate=144; tunnels lead to valves LA, NA
Valve NA has flow rate=169; tunnels lead to valves MA, OA
Valve OA has flow rate=196; tunnels lead to valves NA, PA
Valve PA has flow rate=225; tunnels lead to valves OA
""";

    private const string CircularInput = """
Valve BA has flow rate=2; tunnels lead to valves AA, CA
Valve CA has flow rate=10; tunnels lead to valves BA, DA
Valve DA has flow rate=2; tunnels lead to valves CA, EA
Valve EA has flow rate=10; tunnels lead to valves DA, FA
Valve FA has flow rate=2; tunnels lead to valves EA, GA
Valve GA has flow rate=10; tunnels lead to valves FA, HA
Valve HA has flow rate=2; tunnels lead to valves GA, IA
Valve IA has flow rate=10; tunnels lead to valves HA, JA
Valve JA has flow rate=2; tunnels lead to valves IA, KA
Valve KA has flow rate=10; tunnels lead to valves JA, LA
Valve LA has flow rate=2; tunnels lead to valves KA, MA
Valve MA has flow rate=10; tunnels lead to valves LA, NA
Valve NA has flow rate=2; tunnels lead to valves MA, OA
Valve OA has flow rate=10; tunnels lead to valves NA, PA
Valve PA has flow rate=2; tunnels lead to valves OA, AA
Valve AA has flow rate=0; tunnels lead to valves BA, PA
""";

    private const string ClusteredInput = """
Valve AK has flow rate=100; tunnels lead to valves AJ, AW, AX, AY, AZ
Valve AW has flow rate=10; tunnels lead to valves AK
Valve AX has flow rate=10; tunnels lead to valves AK
Valve AY has flow rate=10; tunnels lead to valves AK
Valve AZ has flow rate=10; tunnels lead to valves AK
Valve BB has flow rate=0; tunnels lead to valves AA, BC
Valve BC has flow rate=0; tunnels lead to valves BB, BD
Valve BD has flow rate=0; tunnels lead to valves BC, BE
Valve BE has flow rate=0; tunnels lead to valves BD, BF
Valve BF has flow rate=0; tunnels lead to valves BE, BG
Valve BG has flow rate=0; tunnels lead to valves BF, BH
Valve BH has flow rate=0; tunnels lead to valves BG, BI
Valve BI has flow rate=0; tunnels lead to valves BH, BJ
Valve BJ has flow rate=0; tunnels lead to valves BI, BK
Valve BK has flow rate=100; tunnels lead to valves BJ, BW, BX, BY, BZ
Valve BW has flow rate=10; tunnels lead to valves BK
Valve BX has flow rate=10; tunnels lead to valves BK
Valve BY has flow rate=10; tunnels lead to valves BK
Valve BZ has flow rate=10; tunnels lead to valves BK
Valve CB has flow rate=0; tunnels lead to valves AA, CC
Valve CC has flow rate=0; tunnels lead to valves CB, CD
Valve CD has flow rate=0; tunnels lead to valves CC, CE
Valve CE has flow rate=0; tunnels lead to valves CD, CF
Valve CF has flow rate=0; tunnels lead to valves CE, CG
Valve CG has flow rate=0; tunnels lead to valves CF, CH
Valve CH has flow rate=0; tunnels lead to valves CG, CI
Valve CI has flow rate=0; tunnels lead to valves CH, CJ
Valve CJ has flow rate=0; tunnels lead to valves CI, CK
Valve CK has flow rate=100; tunnels lead to valves CJ, CW, CX, CY, CZ
Valve CW has flow rate=10; tunnels lead to valves CK
Valve CX has flow rate=10; tunnels lead to valves CK
Valve CY has flow rate=10; tunnels lead to valves CK
Valve CZ has flow rate=10; tunnels lead to valves CK
Valve AA has flow rate=0; tunnels lead to valves AB, BB, CB
Valve AB has flow rate=0; tunnels lead to valves AA, AC
Valve AC has flow rate=0; tunnels lead to valves AB, AD
Valve AD has flow rate=0; tunnels lead to valves AC, AE
Valve AE has flow rate=0; tunnels lead to valves AD, AF
Valve AF has flow rate=0; tunnels lead to valves AE, AG
Valve AG has flow rate=0; tunnels lead to valves AF, AH
Valve AH has flow rate=0; tunnels lead to valves AG, AI
Valve AI has flow rate=0; tunnels lead to valves AH, AJ
Valve AJ has flow rate=0; tunnels lead to valves AI, AK
""";
}