namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201923;

public class CategorySixNetwork
{
    private readonly Dictionary<int, CategorySixComputer> _computers;
    private bool _isIdle;
    private CategorySixPacket? _natPacket;
    private CategorySixPacket? _lastSentNatPacket;
        
    public CategorySixPacket? FirstRepeatedNatPacket { get; private set; }
    public CategorySixPacket? FirstNatPacket { get; private set; }

    public CategorySixNetwork(string program)
    {
        _computers = new Dictionary<int, CategorySixComputer>();
        _isIdle = true;

        for (var i = 0; i < 50; i++)
        {
            _computers[i] = new CategorySixComputer(program, i, SendPacket, HasReadInput);
        }
    }

    public void Run()
    {
        foreach (var computer in _computers.Values)
        {
            computer.Run();
        }

        while (FirstRepeatedNatPacket == null)
        {
            _isIdle = true;

            foreach (var computer in _computers.Values)
            {
                computer.Resume();
            }

            if (_isIdle && _natPacket != null)
            {
                var natPacketRepeated = _lastSentNatPacket != null && _natPacket.X == _lastSentNatPacket.X && _natPacket.Y == _lastSentNatPacket.Y;
                if (natPacketRepeated && FirstRepeatedNatPacket == null)
                {
                    FirstRepeatedNatPacket = _natPacket;
                }

                _lastSentNatPacket = _natPacket;
                SendPacket(0, _natPacket);
                _natPacket = null;
            }
        }
    }

    private void SendPacket(int address, CategorySixPacket packet)
    {
        if (address == 255)
        {
            if (FirstNatPacket == null)
                FirstNatPacket = packet;

            _natPacket = packet;
        }
        else
        {
            _isIdle = false;
            _computers[address].ReceivePacket(packet);
        }
    }

    private void HasReadInput()
    {
        _isIdle = false;
    }
}