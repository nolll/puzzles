using NUnit.Framework;

namespace Core.Puzzles.Year2020.Day16;

public class Year2020Day16Tests
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

        Assert.That(result, Is.EqualTo(71));
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

        Assert.That(ticket.Fields["class"], Is.EqualTo(12));
        Assert.That(ticket.Fields["row"], Is.EqualTo(11));
        Assert.That(ticket.Fields["seat"], Is.EqualTo(13));
    }
}