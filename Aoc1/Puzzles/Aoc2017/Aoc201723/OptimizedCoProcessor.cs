namespace Puzzles.Aoc.Puzzles.Aoc2017.Aoc201723;

public class OptimizedCoProcessor
{
    private int _b;
    private int _c;
    private int _d;
    private int _f;

    public int H { get; private set; }

    public void Run()
    {
        _b = _c = 67 * 100 + 100000;
        _c = _b + 17000;

        while (true)
        {
            _f = 1;
            _d = 2;
            do
            {
                if (_b % _d == 0)
                    _f = 0;
                _d++;
            } while (_d != _b);
            if(_f == 0)
                H++;
            if (_b == _c)
                break;
            _b += 17;
        }
    }
}