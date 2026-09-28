using Pzl.Common;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Category Six")]
public class Aoc201923 : AocPuzzle
{
    [Puzzle("d95714c17b4e575c231127539580c9ac")]
    public long Part1(string input)
    {
        var network = new CategorySixNetwork(input);
        network.Run();

        return network.FirstNatPacket!.Y;
    }

    [Puzzle("d30f34de7c79a751083a20b903069390")]
    public long Part2(string input)
    {
        var network = new CategorySixNetwork(input);
        network.Run();

        return network.FirstRepeatedNatPacket!.Y;
    }
    
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

    public class CategorySixComputer
    {
        private readonly IntCodeComputer _computer;
        private readonly int _address;
        private readonly Action<int, CategorySixPacket> _sendPacketFunc;
        private readonly Action _hasReadInputFunc;
        private CategorySixComputerMode _inputMode;
        private CategorySixComputerMode _outputMode;
        private CategorySixPacket? _inputPacket;

        private int _outputAddress;
        private long _outputX;
        private long _outputY;

        private Queue<CategorySixPacket> Queue { get; }

        public CategorySixComputer(string program, int address, Action<int, CategorySixPacket> sendPacketFunc, Action hasReadInputFunc)
        {
            _address = address;
            _sendPacketFunc = sendPacketFunc;
            _hasReadInputFunc = hasReadInputFunc;
            _inputMode = CategorySixComputerMode.Address;
            _outputMode = CategorySixComputerMode.Address;
            _computer = new IntCodeComputer(program, ReadInput, WriteOutput);
            _inputPacket = null;
            Queue = new Queue<CategorySixPacket>();
        }

        public void Run()
        {
            _computer.Start(true);
        }

        public void Resume()
        {
            _computer.Resume();
        }

        private long ReadInput()
        {
            if (_inputMode == CategorySixComputerMode.Address)
            {
                _inputMode = CategorySixComputerMode.X;
                _hasReadInputFunc();
                return _address;
            }

            if (_inputMode == CategorySixComputerMode.X)
            {
                if (Queue.Count == 0)
                {
                    return -1;
                }

                _inputPacket = Queue.Dequeue();
                _inputMode = CategorySixComputerMode.Y;
                _hasReadInputFunc();
                return _inputPacket.X;
            }

            if (_inputMode == CategorySixComputerMode.Y)
            {
                var y = _inputPacket?.Y ?? 0;
                _inputPacket = null;
                _inputMode = CategorySixComputerMode.X;
                _hasReadInputFunc();
                return y;
            }

            return 0;
        }

        private bool WriteOutput(long output)
        {
            if (_outputMode == CategorySixComputerMode.Address)
            {
                _outputAddress = (int)output;
                _outputMode = CategorySixComputerMode.X;
            }
            else if (_outputMode == CategorySixComputerMode.X)
            {
                _outputX = output;
                _outputMode = CategorySixComputerMode.Y;
            }
            else if (_outputMode == CategorySixComputerMode.Y)
            {
                _outputY = output;
                _outputMode = CategorySixComputerMode.Address;
                _sendPacketFunc(_outputAddress, new CategorySixPacket(_outputX, _outputY));
            }

            return true;
        }

        public void ReceivePacket(CategorySixPacket packet)
        {
            Queue.Enqueue(packet);
            if (_inputMode == CategorySixComputerMode.Address)
                Run();
        }
    }
    
    public enum CategorySixComputerMode
    {
        Address,
        X,
        Y
    }
    
    public record CategorySixPacket(long X, long Y);
}