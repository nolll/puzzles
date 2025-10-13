using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Tools.Cryptography;

public static class ColumnarTranspositionCipher
{
    public static string Encrypt(string keyword, string input)
    {
        var keywordLength = keyword.Length;
        var mod = input.Length % keywordLength;
        var paddedLength = mod > 0
            ? input.Length + keywordLength - input.Length % keywordLength
            : input.Length;
        var s = input.PadRight(paddedLength);

        var rowList = new List<string>();
        for (var i = 0; i < paddedLength; i += keywordLength)
        {
            rowList.Add(s.Substring(i, keywordLength));
        }

        var grid = GridBuilder.BuildCharGridWithoutTrim(string.Join(LineBreaks.Single, rowList));
        var encryptedGrid = new Grid<char>(grid.Width, grid.Height, ' ');
        var pickingOrder = GetEncryptSelectionOrder(keyword);

        for (var y = grid.YMin; y <= grid.YMax; y++)
        {
            for (var x = grid.XMin; x <= grid.XMax; x++) 
            {
                var c = grid.ReadValueAt(pickingOrder[x], y);
                encryptedGrid.WriteValueAt(x, y, c);
            }
        }
        
        return string.Join("", encryptedGrid.Transpose().Values);
    }

    public static string Decrypt(string keyword, string input)
    {
        var splitLength = input.Length / keyword.Length;
        var rowList = new List<string>();
        for (var i = 0; i < input.Length; i += splitLength)
        {
            rowList.Add(input.Substring(i, splitLength));
        }

        var grid = GridBuilder.BuildCharGridWithoutTrim(string.Join(LineBreaks.Single, rowList))
            .Transpose();
        var decryptedGrid = new Grid<char>(grid.Width, grid.Height, ' ');
        var pickingOrder = GetDecryptSelectionOrder(keyword);

        for (var y = grid.YMin; y <= grid.YMax; y++)
        {
            for (var x = grid.XMin; x <= grid.XMax; x++)
            {
                var c = grid.ReadValueAt(pickingOrder[x], y);
                decryptedGrid.WriteValueAt(x, y, c);
            }
        }

        return string.Join("", decryptedGrid.Values);
    }

    public static int[] GetEncryptSelectionOrder(string input) =>
        input.ToCharArray()
            .Select((o, index) => (index, character: o))
            .OrderBy(o => o.character)
            .Select(o => o.index)
            .ToArray();

    public static int[] GetDecryptSelectionOrder(string input) =>
        GetEncryptSelectionOrder(input)
            .Select((o, index) => (order: o, index))
            .OrderBy(o => o.order)
            .Select(o => o.index)
            .ToArray();
}