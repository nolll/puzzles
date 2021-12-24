using System;

namespace App.Puzzles.Year2021.Day24;

public class Monad
{
    private readonly Alu _alu;

    public Monad(string input)
    {
        _alu = new Alu(input);
    }

    public long Validate(long modelNumber)
    {
        var state = _alu.Process(modelNumber);
        return state.Memory['z'];
    }

    public long FindLargestValidNumber()
    {
        var modelNumber = 99_999_999_999_999;

        while (modelNumber > 0)
        {
            Console.WriteLine(modelNumber);
            if (modelNumber.ToString().Contains('0'))
            {
                var state = _alu.Process(modelNumber);
                var result = state.Memory['z'];
                if (result == 0)
                    return modelNumber;

            }

            modelNumber--;
        }

        return modelNumber;
    }
}