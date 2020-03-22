using Core.Tools;

namespace Core.FractalArt
{
    public class FractalRule
    {
        private readonly string _input;
        public Matrix<char> Output { get; }

        public FractalRule(string input, string output)
        {
            _input = input;
            Output = MatrixBuilder.BuildCharMatrix(output.Replace("/", "\n"));
        }

        public bool IsMatch(string compare)
        {
            return compare == _input;
        }
    }
}