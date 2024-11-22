namespace Pzl.Aquaq.Puzzles.Aquaq31.RubiksCube;

public static class CubeRotations
{
    public const string Front = "F";
    public const string FrontPrime = "F'";
    public const string Up = "U";
    public const string UpPrime = "U'";
    public const string Left = "L";
    public const string LeftPrime = "L'";
    public const string Right = "R";
    public const string RightPrime = "R'";
    public const string Down = "D";
    public const string DownPrime = "D'";
    public const string Back = "B";
    public const string BackPrime = "B'";
    public const string CubeX = "X";
    public const string CubeXPrime = "X'";
    public const string CubeY = "Y";
    public const string CubeYPrime = "Y'";
    public const string CubeZ = "Z";
    public const string CubeZPrime = "Z'";

    private static readonly string[] All = [
        Front,
        FrontPrime,
        Up,
        UpPrime,
        Left,
        LeftPrime,
        Right,
        RightPrime,
        Down,
        DownPrime,
        Back,
        BackPrime,
        CubeX,
        CubeXPrime,
        CubeY,
        CubeYPrime,
        CubeZ,
        CubeZPrime
    ];

    public static string[] Random(int count)
    {
        var rnd = new Random((int)DateTime.Now.Ticks);
        var rotations = new List<string>();
        for (var i = 0; i < count; i++)
        {
            rotations.Add(All[rnd.Next(All.Length - 1)]);
        }

        return rotations.ToArray();
    }
}