using System.Text;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201908;

public class SpaceImagePrinter
{
    public string Print(IList<IList<char>> matrix)
    {
        var sb = new StringBuilder();
        foreach (var row in matrix)
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