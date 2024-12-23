using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202016;

public class Aoc202016Tests
{
    [Test]
    public void TicketErrorRate()
    {
        const string input = """
                             class: 1-3 or 5-7
                             row: 6-11 or 33-44
                             seat: 13-40 or 45-50

                             your ticket:
                             7,1,14

                             nearby tickets:
                             7,3,47
                             40,4,50
                             55,2,20
                             38,6,12
                             """;

        var validator = new TicketValidator();
        var result = validator.GetErrorRate(input);

        result.Should().Be(71);
    }

    [Test]
    public void FindTicketFields()
    {
        const string input = """
                             class: 0-1 or 4-19
                             row: 0-5 or 8-19
                             seat: 0-13 or 16-19

                             your ticket:
                             11,12,13

                             nearby tickets:
                             3,9,18
                             15,1,5
                             5,14,9
                             """;

        var validator = new TicketValidator();
        var ticket = TicketValidator.FindFields(input);

        ticket.Fields["class"].Should().Be(12);
        ticket.Fields["row"].Should().Be(11);
        ticket.Fields["seat"].Should().Be(13);
    }
}