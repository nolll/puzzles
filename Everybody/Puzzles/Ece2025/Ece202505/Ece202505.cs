using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202505;

[Name("Fishbone Order")]
public class Ece202505 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = Sword.Parse(input).Quality;
        
        return new PuzzleResult(result, "da8e81f2fb0217604074c546d70d3b9d");
    }

    public PuzzleResult Part2(string input)
    {
        var qualities = ParseSwords(input).Select(o => o.Quality).ToList();
        var result = qualities.Max() - qualities.Min();
        return new PuzzleResult(result, "08078be2afe2fd502f81f20a8088d436");
    }

    public PuzzleResult Part3(string input)
    {
        var swords = ParseSwords(input).OrderDescending().ToArray();
        var checksum = GetChecksum(swords);
        return new PuzzleResult(checksum, "379c8b556406dfefbd579b47d63c2b93");
    }

    private static Sword[] ParseSwords(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        return lines.Select(Sword.Parse).ToArray();
    }

    private static int GetChecksum(Sword[] swords)
    {
        var checksum = 0;
        var num = 1;
        foreach (var sword in swords)
        {
            checksum += num * sword.Id;
            num++;
        }

        return checksum;
    }
    
    public class Sword : IComparable<Sword>
    {
        public int Id { get; }
        public long Quality { get; }
        private SwordSegment[] Segments { get; }

        private Sword(int id, SwordSegment[] segments)
        {
            Id = id;
            Quality = long.Parse(string.Join("", segments.Select(o => o.Spine)));
            Segments = segments;
        }
        
        public static Sword Parse(string input)
        {
            var numbers = Numbers.IntsFromString(input).ToArray();
            var id = numbers.First();
            var segments = new List<SwordSegment>();

            foreach (var n in numbers.Skip(1))
            {
                var index = 0;
                var foundSpot = false;
                while (index < segments.Count)
                {
                    if(n < segments[index].Spine && segments[index].Left == null)
                    {
                        segments[index].Left = n;
                        foundSpot = true;
                        break;
                    }
                
                    if(n > segments[index].Spine && segments[index].Right == null)
                    {
                        segments[index].Right = n;
                        foundSpot = true;
                        break;
                    }

                    index++;
                }
                
                if(!foundSpot)
                    segments.Add(new SwordSegment(n));
            }

            return new Sword(id, segments.ToArray());
        }
        
        public int CompareTo(Sword? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;

            var qualityComparison = Quality.CompareTo(other.Quality);
            if (qualityComparison != 0)
                return qualityComparison;

            for (var i = 0; i < Segments.Length; i++)
            {
                var segmentComparison = Segments[i].CompareTo(other.Segments[i]);
                if (segmentComparison != 0)
                    return segmentComparison;
            }
            
            return Id.CompareTo(other.Id);
        }
    }
    
    public class SwordSegment(int spine) : IComparable<SwordSegment>
    {
        public int? Left { get; set; }
        public int Spine { get; } = spine;
        public int? Right { get; set; }

        private long Score => long.Parse($"{Left}{Spine}{Right}");

        public int CompareTo(SwordSegment? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            
            return Score.CompareTo(other.Score);
        }
    }
}