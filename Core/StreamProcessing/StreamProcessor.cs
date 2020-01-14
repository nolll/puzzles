using System.Linq;
using System.Text;

namespace Core.StreamProcessing
{
    public class StreamProcessor
    {
        public int GroupCount { get; }
        public string Cleaned { get; }
        public int Score { get; }

        public StreamProcessor(string input)
        {
            Cleaned = RemoveGarbage(input);
            GroupCount = Cleaned.Count(o => o == '}');
            Score = GetScore(Cleaned);
        }

        private int GetScore(string cleaned)
        {
            var totalScore = 0;
            var currentScore = 0;
            foreach (var c in cleaned)
            {
                if (c == '{')
                {
                    currentScore += 1;
                }

                if (c == '}')
                {
                    totalScore += currentScore;
                    currentScore -= 1;
                }
            }

            return totalScore;
        }

        private string RemoveGarbage(string input)
        {
            input = input.Replace("!!", "");
            var cleaned = new StringBuilder();
            var isInGarbage = false;
            for (var i = 0; i < input.Length; i++)
            {
                var c = input[i];
                
                if (!isInGarbage)
                {
                    if (c == '<')  
                        isInGarbage = true;
                    else 
                        cleaned.Append(c);
                }
                else
                {
                    if (c == '>' && input[i - 1] != '!')
                        isInGarbage = false;
                }
            }

            return cleaned.ToString();
        }
    }
}