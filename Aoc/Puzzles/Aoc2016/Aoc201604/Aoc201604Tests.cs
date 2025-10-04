namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201604;

public class Aoc201604Tests
{
    [Theory]
    [InlineData("aaaaa-bbb-z-y-x-123[abxyz]", true)]
    [InlineData("a-b-c-d-e-f-g-h-987[abcde]", true)]
    [InlineData("not-a-real-room-404[oarel]", true)]
    [InlineData("totally-real-room-200[decoy]", false)]
    public void ValidatesRooms(string input, bool expected)
    {
        var room = new Room(input);

        room.IsValid.Should().Be(expected);
    }
}