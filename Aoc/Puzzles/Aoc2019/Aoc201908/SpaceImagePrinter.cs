using System.Text;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201908;

public class SpaceImagePrinter
{
    public string Print(IList<IList<char>> grid)
    {
        var sb = new StringBuilder();
        foreach (var row in grid)
        {
            foreach (var pixel in row)
            {
                var output = pixel == '1' ? '#' : '.';
                sb.Append(output);
            }

            sb.AppendLine();
        }

        return sb.ToString().Trim();
    }
}