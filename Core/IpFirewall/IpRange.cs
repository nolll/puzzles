namespace Core.IpFirewall
{
    public class IpRange
    {
        public long Start { get; }
        public long End { get; }
        public long Length { get; }

        public IpRange(long start, long end)
        {
            Start = start;
            End = end;
            Length = End - Start + 1;
        }

        public bool IsInRange(long ip)
        {
            return ip >= Start && ip <= End;
        }
    }
}