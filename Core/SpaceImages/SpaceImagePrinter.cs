using System.Collections.Generic;
using System.Text;

namespace Core.SpaceImages
{
    public class SpaceImagePrinter
    {
        public string Print(IList<IList<char>> matrix)
        {
            var sb = new StringBuilder();
            foreach (var row in matrix)
            {
                foreach (var pixel in row)
                {
                    var output = pixel == '1' ? 'X' : ' ';
                    sb.Append(output);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}