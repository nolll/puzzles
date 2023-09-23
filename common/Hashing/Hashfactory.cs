using System.Security.Cryptography;
using System.Text;
using Common.Strings;

namespace Common.Hashing;

public class Hashfactory
{
    private readonly MD5 _md5;
    
    public Hashfactory()
    {
        _md5 = MD5.Create();
    }

    public string StringHashFromString(string str)
    {
        return StringHashFromBytes(Encoding.ASCII.GetBytes(str));
    }

    public string StringHashFromBytes(byte[] bytes)
    {
        var hashedBytes = ByteHashFromBytes(bytes);
        return ByteConverter.ToHexString(hashedBytes);
    }

    public byte[] ByteHashFromString(string str)
    {
        return ByteHashFromBytes(Encoding.ASCII.GetBytes(str));
    }

    public byte[] ByteHashFromBytes(byte[] bytes)
    {
        return _md5.ComputeHash(bytes);
    }
}