using Puzzles.common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.common.Cryptography;

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

        var matrix = MatrixBuilder.BuildCharMatrixWithoutTrim(string.Join(Environment.NewLine, rowList));
        var encryptedMatrix = new Matrix<char>(matrix.Width, matrix.Height, ' ');
        var pickingOrder = GetEncryptSelectionOrder(keyword);

        for (var y = matrix.YMin; y <= matrix.YMax; y++)
        {
            for (var x = matrix.XMin; x <= matrix.XMax; x++) 
            {
                var c = matrix.ReadValueAt(pickingOrder[x], y);
                encryptedMatrix.WriteValueAt(x, y, c);
            }
        }
        
        return string.Join("", encryptedMatrix.Transpose().Values);
    }

    public static string Decrypt(string keyword, string input)
    {
        var splitLength = input.Length / keyword.Length;
        var rowList = new List<string>();
        for (var i = 0; i < input.Length; i += splitLength)
        {
            rowList.Add(input.Substring(i, splitLength));
        }

        var matrix = MatrixBuilder.BuildCharMatrixWithoutTrim(string.Join(Environment.NewLine, rowList))
            .Transpose();
        var decryptedMatrix = new Matrix<char>(matrix.Width, matrix.Height, ' ');
        var pickingOrder = GetDecryptSelectionOrder(keyword);

        for (var y = matrix.YMin; y <= matrix.YMax; y++)
        {
            for (var x = matrix.XMin; x <= matrix.XMax; x++)
            {
                var c = matrix.ReadValueAt(pickingOrder[x], y);
                decryptedMatrix.WriteValueAt(x, y, c);
            }
        }

        return string.Join("", decryptedMatrix.Values);
    }

    public static int[] GetEncryptSelectionOrder(string input)
    {
        return input.ToCharArray()
            .Select((o, index) => (index, character: o))
            .OrderBy(o => o.character)
            .Select(o => o.index)
            .ToArray();
    }

    public static int[] GetDecryptSelectionOrder(string input)
    {
        return GetEncryptSelectionOrder(input)
            .Select((o, index) => (order: o, index))
            .OrderBy(o => o.order)
            .Select(o => o.index)
            .ToArray();
    }
}