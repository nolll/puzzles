namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201820;

public class Aoc201820Tests
{
    [Theory]
    [InlineData("^WNE$", 3)]
    [InlineData("^ENWWW(NEEE|SSE(EE|N))$", 10)]
    [InlineData("^ENNWSWW(NEWS|)SSSEEN(WNSE|)EE(SWEN|)NNN$", 18)]
    [InlineData("^ESSWWN(E|NNENN(EESS(WNSE|)SSS|WWWSSSSE(SW|NNNE)))$", 23)]
    [InlineData("^WSSEESWWWNW(S|NENNEEEENN(ESSSSW(NWSW|SSEN)|WSWWN(E|WWS(E|SS))))$", 31)]
    public void FindRoomThatRequiresMostDoors(string regex, int doorCount)
    {
        var navigator = new RegularMapNavigator(regex);

        navigator.MostDoors.Should().Be(doorCount);
    }
}