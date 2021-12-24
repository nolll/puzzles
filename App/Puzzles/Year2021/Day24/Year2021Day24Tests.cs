using System;
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
    public void TestMonad(long modelNumber, int expected)
    {
        var monad = new Monad(FullInput);
        var result = monad.Validate(modelNumber);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1, 0, 0, 0, 0)]
    [TestCase(2, 0, 0, 0, 0)]
    [TestCase(3, 0, 0, 0, 0)]
    [TestCase(4, 0, 0, 0, 0)]
    [TestCase(5, 0, 0, 0, 0)]
    [TestCase(6, 0, 0, 0, 0)]
    [TestCase(7, 0, 0, 0, 0)]
    [TestCase(8, 0, 0, 0, 0)]
    [TestCase(9, 0, 0, 0, 0)]
    public void TestReal1(long p, long expW, long expX, long expY, long expZ)
    {
        const string input = @"
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
add z y";

        var alu = new Alu(input);
        var result = alu.Process(p);
        Console.WriteLine(result.ToString());

        //Assert.That(result.Memory['w'], Is.EqualTo(expW));
        //Assert.That(result.Memory['x'], Is.EqualTo(expX));
        //Assert.That(result.Memory['y'], Is.EqualTo(expY));
        //Assert.That(result.Memory['z'], Is.EqualTo(expZ));
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