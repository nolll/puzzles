using System;
using System.Linq;

namespace Core.Puzzles.Year2021.Day24;

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

    private long GetValue(AluState state, string s)
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