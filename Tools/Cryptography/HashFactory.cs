using System.Security.Cryptography;
using System.Text;
using Pzl.Tools.Strings;

namespace Pzl.Tools.Cryptography;

public class HashFactory
{
    private readonly MD5 _md5 = MD5.Create();

    public string StringHash(string str) => StringHash(Encoding.ASCII.GetBytes(str));
    public string StringHash(byte[] bytes) => ByteConverter.ToHexString(ByteHash(bytes));
    public byte[] ByteHash(string str) => ByteHash(Encoding.ASCII.GetBytes(str));
    public byte[] ByteHash(byte[] bytes) => _md5.ComputeHash(bytes);
}