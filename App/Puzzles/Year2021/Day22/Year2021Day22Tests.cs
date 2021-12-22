using System;
using System.Collections.Generic;
using System.Linq;
using App.Common.CoordinateSystems;
using App.Common.Strings;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace App.Puzzles.Year2021.Day22;

public class Year2021Day22Tests
{
    [Test]
    public void Part1()
    {
        var reactor = new SubmarineReactor();
        var result = reactor.Reboot(Input1);

        Assert.That(result, Is.EqualTo(39));
    }

    [Test]
    public void Part1_2()
    {
        var reactor = new SubmarineReactor();
        var result = reactor.Reboot(Input2);

        Assert.That(result, Is.EqualTo(590784));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input1 = @"
on x=10..12,y=10..12,z=10..12
on x=11..13,y=11..13,z=11..13
off x=9..11,y=9..11,z=9..11
on x=10..10,y=10..10,z=10..10";

    private const string Input2 = @"
on x=-20..26,y=-36..17,z=-47..7
on x=-20..33,y=-21..23,z=-26..28
on x=-22..28,y=-29..23,z=-38..16
on x=-46..7,y=-6..46,z=-50..-1
on x=-49..1,y=-3..46,z=-24..28
on x=2..47,y=-22..22,z=-23..27
on x=-27..23,y=-28..26,z=-21..29
on x=-39..5,y=-6..47,z=-3..44
on x=-30..21,y=-8..43,z=-13..34
on x=-22..26,y=-27..20,z=-29..19
off x=-48..-32,y=26..41,z=-47..-37
on x=-12..35,y=6..50,z=-50..-2
off x=-48..-32,y=-32..-16,z=-15..-5
on x=-18..26,y=-33..15,z=-7..46
off x=-40..-22,y=-38..-28,z=23..41
on x=-16..35,y=-41..10,z=-47..6
off x=-32..-23,y=11..30,z=-14..3
on x=-49..-5,y=-3..45,z=-29..18
off x=18..30,y=-20..-8,z=-3..13
on x=-41..9,y=-7..43,z=-33..15
on x=-54112..-39298,y=-85059..-49293,z=-27449..7877
on x=967..23432,y=45373..81175,z=27513..53682";
}

public class SubmarineReactor
{
    public int Reboot(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input);
        var instructions = lines.Select(ParseInstruction).ToList();

        var matrix = new Matrix3D<char>(50, 50, 50, '.');
        var matrix2 = new Dictionary<(int, int, int), bool>();

        foreach (var instruction in instructions.Where(o => Math.Abs(o.To.X) <= 50 && Math.Abs(o.To.Z) <= 50 && Math.Abs(o.To.Z) <= 50))
        {
            var isOn = instruction.Mode == "on";

            for (var z = instruction.From.Z; z <= instruction.To.Z; z++)
            {
                for (var y = instruction.From.Y; y <= instruction.To.Y; y++)
                {
                    for (var x = instruction.From.X; x <= instruction.To.X; x++)
                    {
                        matrix2[(x, y, z)] = isOn;
                    }
                }
            }
        }

        return matrix2.Values.Count(o => o);
    }

    private RebootInstruction ParseInstruction(string s)
    {
        var parts = s.Split(' ');
        var mode = parts[0];
        var coords = ParseCoords(parts[1]);

        return new RebootInstruction(mode, coords.from, coords.to);
    }

    private (Matrix3DAddress from, Matrix3DAddress to) ParseCoords(string s)
    {
        var parts = s.Split(',').Select(ParseFromTo).ToList();
        var from = new Matrix3DAddress(parts[0].from, parts[1].from, parts[2].from);
        var to = new Matrix3DAddress(parts[0].to, parts[1].to, parts[2].to);
        return (from, to);
    }

    private (int from, int to) ParseFromTo(string s)
    {
        var parts = s[2..].Split("..").Select(int.Parse).ToList();
        return (parts.First(), parts.Last());
    }
}

public class RebootInstruction
{
    public string Mode { get; }
    public Matrix3DAddress From { get; }
    public Matrix3DAddress To { get; }

    public RebootInstruction(string mode, Matrix3DAddress from, Matrix3DAddress to)
    {
        Mode = mode;
        From = @from;
        To = to;
    }
}