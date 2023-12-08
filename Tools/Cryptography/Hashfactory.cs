using System.Security.Cryptography;
using System.Text;
using Pzl.Tools.Strings;

namespace Pzl.Tools.Cryptography;

public class Hashfactory
{
    private readonly MD5 _md5 = MD5.Create();

    public string StringHashFromString(string str) => 
        StringHashFromBytes(Encoding.ASCII.GetBytes(str));

    public string StringHashFromBytes(byte[] bytes) => 
        ByteConverter.ToHexString(ByteHashFromBytes(bytes));

    public byte[] ByteHashFromString(string str) => 
        ByteHashFromBytes(Encoding.ASCII.GetBytes(str));

    public byte[] ByteHashFromBytes(byte[] bytes) => 
        _md5.ComputeHash(bytes);
}