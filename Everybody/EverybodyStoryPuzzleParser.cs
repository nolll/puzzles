namespace Pzl.Everybody;

public static class EverybodyStoryPuzzleParser
{
    public static (int year, int day) ParseStoryAndPart(Type t)
    {
        var story = int.Parse(t.Name.Substring(3, 2));
        var part = int.Parse(t.Name.Substring(5, 2).TrimStart('0'));
        
        return (story, part);
    }
}