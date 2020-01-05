using System.Collections.Generic;
using System.Linq;

namespace Core.Captcha
{
    public class CaptchaCalculator
    {
        public int Sum { get; }

        public CaptchaCalculator(string input)
        {
            var numbers = input.ToCharArray().Select(o => int.Parse((string) o.ToString())).ToList();
            var matchingNumbers = new List<int>();
            var lastIndex = numbers.Count - 1;
            for (var i = 0; i < numbers.Count; i++)
            {
                var currentValue = numbers[i];
                if (i == lastIndex)
                {
                    if (currentValue == numbers[0])
                    {
                        matchingNumbers.Add(currentValue);
                    }
                }
                else if(currentValue == numbers[i + 1])
                {
                    matchingNumbers.Add(currentValue);
                }
            }

            Sum = matchingNumbers.Sum();
        }
    }
}