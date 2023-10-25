namespace Common.Cryptography;

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

        var rows = rowList.ToArray();

        return "";
    }
}