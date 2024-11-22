namespace Pzl.Tools.Cryptography;

public class PlayfairCipher
{
    private const int BoardSize = 5;
    private static string Alphabet => "abcdefghijklmnopqrstuvwxyz";
    private static readonly char[] CipherAlphabet = Alphabet.ToCharArray().Where(o => o != 'j').ToArray();

    private readonly string _keyword;
    private readonly string _board;

    public PlayfairCipher(string keyword)
    {
        _keyword = keyword;
        _board = CreateStringCipherBoard();
    }

    public string CreateStringCipherBoard()
    {
        var distinct = _keyword.Replace(" ", "").ToCharArray().Distinct();
        var otherChars = CipherAlphabet.Where(o => !distinct.Contains(o));
        var combined = distinct.Concat(otherChars);
        return string.Join("", combined);
    }

    public string Encrypt(string input)
    {
        var prepared = PrepareForEncryption(input);
        var bigrams = SplitIntoBigrams(prepared);
        var encrypted = bigrams.Select(EncryptBigram);

        return string.Join("", encrypted);
    }

    public string Decrypt(string input)
    {
        var bigrams = SplitIntoBigrams(input);
        var decrypted = bigrams.Select(DecryptBigram);

        return string.Join("", decrypted);
    }

    private string EncryptBigram(string input)
    {
        if (IsOnSameRow(input))
            return CharsAfter(input);

        if (IsOnSameCol(input))
            return CharsBelow(input);

        return OppositeChars(input);
    }

    private string DecryptBigram(string input)
    {
        if (IsOnSameRow(input))
            return CharsBefore(input);

        if (IsOnSameCol(input))
            return CharsAbove(input);

        return OppositeChars(input);
    }

    private bool IsOnSameRow(string bigram) => IsOnSameRow(bigram[0], bigram[1]);
    private bool IsOnSameRow(char a, char b)
    {
        var aPos = _board.IndexOf(a);
        var bPos = _board.IndexOf(b);

        var aRow = (int)Math.Floor((double)aPos / BoardSize);
        var bRow = (int)Math.Floor((double)bPos / BoardSize);

        return aRow == bRow;
    }

    private bool IsOnSameCol(string bigram) => IsOnSameCol(bigram[0], bigram[1]);
    private bool IsOnSameCol(char a, char b) => _board.IndexOf(a) % BoardSize == _board.IndexOf(b) % BoardSize;

    private string CharsBefore(string input) => CharsToString(CharsBefore((input[0], input[1])));
    private (char a, char b) CharsBefore((char a, char b) chars) => CharsAtHorizontalOffsetFrom(chars, -1);

    private string CharsAfter(string input) => CharsToString(CharsAfter((input[0], input[1])));
    private (char a, char b) CharsAfter((char a, char b) chars) => CharsAtHorizontalOffsetFrom(chars, 1);

    private string CharsBelow(string input) => CharsToString(CharsBelow((input[0], input[1])));
    private (char a, char b) CharsBelow((char a, char b) chars) => CharsAtVerticalOffsetFrom(chars, 1);

    private string CharsAbove(string input) => CharsToString(CharsAbove((input[0], input[1])));
    private (char a, char b) CharsAbove((char a, char b) chars) => CharsAtVerticalOffsetFrom(chars, -1);
    
    private string OppositeChars(string input) => CharsToString(OppositeChars((input[0], input[1])));
    private (char a, char b) OppositeChars((char a, char b) chars)
    {
        var aPos = _board.IndexOf(chars.a);
        var bPos = _board.IndexOf(chars.b);

        var aRow = (int)Math.Floor((double)aPos / BoardSize);
        var bRow = (int)Math.Floor((double)bPos / BoardSize);

        var aCol = aPos % BoardSize;
        var bCol = bPos % BoardSize;

        var aNew = _board[aRow * BoardSize + bCol];
        var bNew = _board[bRow * BoardSize + aCol];
        return (aNew, bNew);
    }

    private static string CharsToString((char a, char b) chars) => $"{chars.a}{chars.b}";
    
    private (char a, char b) CharsAtHorizontalOffsetFrom((char a, char b) chars, int offset) 
        => (CharAtHorizontalOffsetFrom(chars.a, offset), CharAtHorizontalOffsetFrom(chars.b, offset));

    private char CharAtHorizontalOffsetFrom(char c, int offset)
    {
        var aPos = _board.IndexOf(c);
        var aRow = (int)Math.Floor((double)aPos / BoardSize);
        var aCol = aPos % BoardSize;
        return _board[aRow * BoardSize + (aCol + offset + BoardSize) % BoardSize];
    }

    private (char a, char b) CharsAtVerticalOffsetFrom((char a, char b) chars, int offset) 
        => (CharAtVerticalOffsetFrom(chars.a, offset), CharAtVerticalOffsetFrom(chars.b, offset));

    private char CharAtVerticalOffsetFrom(char a, int offset)
    {
        var aPos = _board.IndexOf(a);
        return _board[(aPos + offset * BoardSize + _board.Length) % _board.Length];
    }

    private static string PrepareForEncryption(string input)
    {
        var prepared = $"{input}";

        prepared = CipherAlphabet.Aggregate(prepared, (current, c) => current.Replace($"{c}{c}", $"{c}x{c}"));

        if (prepared.Length % 2 != 0)
            prepared = $"{prepared}x";

        return prepared;
    }

    private static IEnumerable<string> SplitIntoBigrams(string input)
    {
        var bigrams = new List<string>();
        for (var i = 0; i < input.Length; i += 2)
        {
            bigrams.Add(input.Substring(i, 2));
        }

        return bigrams;
    }
}