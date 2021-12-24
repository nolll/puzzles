using System;
using System.Collections.Generic;
using System.Linq;
using App.Common.Strings;
using NUnit.Framework;

namespace App.Puzzles.Year2021.Day24;

public class Year2021Day24Tests
{
    [TestCase(1, -1)]
    [TestCase(2, -2)]
    [TestCase(3, -3)]
    public void TestAlu1(long p, int expected)
    {
        const string input = @"
inp x
mul x -1";

        var alu = new Alu(input);
        var result = alu.Process(p);

        Assert.That(result.Memory['x'], Is.EqualTo(expected));
    }

    [TestCase(23, 0)]
    [TestCase(24, 0)]
    [TestCase(25, 0)]
    [TestCase(26, 1)]
    [TestCase(39, 1)]
    public void TestAlu2(long p, int expected)
    {
        const string input = @"
inp z
inp x
mul z 3
eql z x";

        var alu = new Alu(input);
        var result = alu.Process(p);

        Assert.That(result.Memory['z'], Is.EqualTo(expected));
    }

    [TestCase(1, 0, 0, 0, 1)]
    [TestCase(2, 0, 0, 1, 0)]
    [TestCase(3, 0, 0, 1, 1)]
    [TestCase(4, 0, 1, 0, 0)]
    [TestCase(5, 0, 1, 0, 1)]
    [TestCase(6, 0, 1, 1, 0)]
    [TestCase(7, 0, 1, 1, 1)]
    [TestCase(8, 1, 0, 0, 0)]
    [TestCase(9, 1, 0, 0, 1)]
    public void TestAlu2(long p, int expW, int expX, int expY, int expZ)
    {
        const string input = @"
inp w
add z w
mod z 2
div w 2
add y w
mod y 2
div w 2
add x w
mod x 2
div w 2
mod w 2";

        var alu = new Alu(input);
        var result = alu.Process(p);

        Assert.That(result.Memory['w'], Is.EqualTo(expW));
        Assert.That(result.Memory['x'], Is.EqualTo(expX));
        Assert.That(result.Memory['y'], Is.EqualTo(expY));
        Assert.That(result.Memory['z'], Is.EqualTo(expZ));
    }

    [TestCase(13579246899999, 0)]
    public void TestMonad(long p, int expected)
    {
        var alu = new Alu(FullInput);
        var result = alu.Process(p);

        Assert.That(result.Memory['w'], Is.EqualTo(0));
        Assert.That(result.Memory['x'], Is.EqualTo(0));
        Assert.That(result.Memory['y'], Is.EqualTo(0));
        Assert.That(result.Memory['z'], Is.EqualTo(0));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string FullInput = @"
inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 4
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 10
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -6
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 14
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 15
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 6
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 16
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 1
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 7
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 8
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -5
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 11
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 8
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -5
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 3
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -2
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 1
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 8
mul y x
add z y";
}

public class Alu
{
    private IEnumerable<AluInstruction> _instructions;

    public Alu(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input);
        _instructions = lines.Select(ParseInstruction);
    }

    private AluInstruction ParseInstruction(string s)
    {
        var parts = s.Split(' ');
        var operation = parts[0];
        var a = parts[1][..1].ToCharArray().First();
        var b = parts.Length > 2 ? parts[2] : null;

        return new AluInstruction(operation, a, b);
    }

    public AluState Process(long input)
    {
        var inputs = input.ToString().Select(o => int.Parse(o.ToString())).ToList();
        var state = new AluState(inputs);

        foreach (var instruction in _instructions)
        {
            instruction.Execute(state);
        }

        return state;
    }
}

public class AluInstruction
{
    private readonly char _address;
    private readonly string _b;
    public string Operation { get; }

    public AluInstruction(string operation, char address, string b)
    {
        _address = address;
        _b = b;
        Operation = operation;
    }

    public AluState Execute(AluState state)
    {
        //inp a - Read an input value and write it to variable a.
        //add a b - Add the value of a to the value of b, then store the result in variable a.
        //mul a b - Multiply the value of a by the value of b, then store the result in variable a.
        //div a b - Divide the value of a by the value of b, truncate the result to an integer, then store the result in variable a. (Here, "truncate" means to round the value toward zero.)
        //mod a b - Divide the value of a by the value of b, then store the remainder in variable a. (This is also called the modulo operation.)
        //eql a b - If the value of a and b are equal, then store the value 1 in variable a. Otherwise, store the value 0 in variable a.
        if (Operation == "inp")
        {
            var input = state.ReadInput();
            state.Memory[_address] = input;
            return state;
        }

        var value = GetValue(state, _b);
        if (Operation == "add")
        {
            state.Memory[_address] += value;
        }

        if (Operation == "mul")
        {
            state.Memory[_address] *= value;
        }

        if (Operation == "div")
        {
            state.Memory[_address] = (int)Math.Floor((double)state.Memory[_address] / value);
        }

        if (Operation == "mod")
        {
            state.Memory[_address] = state.Memory[_address] % value;
        }

        if (Operation == "eql")
        {
            state.Memory[_address] = state.Memory[_address] == value ? 1 : 0;
        }

        return state;
    }

    private int GetValue(AluState state, string s)
    {
        var isAddress = IsAddress(s);
        if (isAddress)
        {
            var address = s[..1].ToCharArray().First();
            return state.Memory[address];
        }
        else
        {
            return int.Parse(s);
        }
    }

    private static bool IsAddress(string s) => s is "w" or "x" or "y" or "z";
}

public class AluState
{
    public Dictionary<char, int> Memory { get; }
    public List<int> Inputs { get; private set; }

    public AluState(List<int> inputs)
    {
        Inputs = inputs;
        Memory = new Dictionary<char, int>
        {
            { 'w', 0 },
            { 'x', 0 },
            { 'y', 0 },
            { 'z', 0 }
        };
    }

    public int ReadInput()
    {
        var nextInput = Inputs.First();
        Inputs = Inputs.Skip(1).ToList();
        return nextInput;
    }
}