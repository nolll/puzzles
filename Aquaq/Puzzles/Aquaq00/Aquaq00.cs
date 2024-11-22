using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq00;

[Name("What's a numpad?")]
public class Aquaq00(string input) : AquaqPuzzle
{
    protected override PuzzleResult Run()
    {
        var keyPresses = StringReader.ReadLines(input)
            .Select(o => o.Trim().Split(' ').ToArray())
            .Select(o => (int.Parse(o[0]), int.Parse(o[1])));

        var result = HandleKeyPresses(keyPresses);

        return new PuzzleResult(result, "7b9dc822e24a14068d6a4c005470f906");
    }

    public static string HandleKeyPresses(IEnumerable<(int key, int count)> input)
    {
        return string.Join("", input.Select(HandleKeyPresses).Where(o => o is not null));
    }

    private static char? HandleKeyPresses((int key, int count) input)
    {
        return input.key switch
        {
            0 when input.count == 1 => ' ',
            2 when input.count == 1 => 'a',
            2 when input.count == 2 => 'b',
            2 when input.count == 3 => 'c',
            3 when input.count == 1 => 'd',
            3 when input.count == 2 => 'e',
            3 when input.count == 3 => 'f',
            4 when input.count == 1 => 'g',
            4 when input.count == 2 => 'h',
            4 when input.count == 3 => 'i',
            5 when input.count == 1 => 'j',
            5 when input.count == 2 => 'k',
            5 when input.count == 3 => 'l',
            6 when input.count == 1 => 'm',
            6 when input.count == 2 => 'n',
            6 when input.count == 3 => 'o',
            7 when input.count == 1 => 'p',
            7 when input.count == 2 => 'q',
            7 when input.count == 3 => 'r',
            7 when input.count == 4 => 's',
            8 when input.count == 1 => 't',
            8 when input.count == 2 => 'u',
            8 when input.count == 3 => 'v',
            9 when input.count == 1 => 'w',
            9 when input.count == 2 => 'x',
            9 when input.count == 3 => 'y',
            9 when input.count == 4 => 'z',
            _ => null
        };
    }
}