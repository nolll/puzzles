using Pzl.Common;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Category Six")]
public class Aoc201923 : AocPuzzle
{
    [Puzzle("d95714c17b4e575c231127539580c9ac")]
    public long Part1(string input)
    {
        var (first, _) = Run(input);
        return first;
    }

    [Puzzle("d30f34de7c79a751083a20b903069390")]
    public long Part2(string input)
    {
        var (_, repeated) = Run(input);
        return repeated;
    }

    private (long, long) Run(string program)
    {
        CategorySixPacket? natPacket = null;
        CategorySixPacket? lastSentNatPacket = null;
        CategorySixPacket? firstRepeatedNatPacket = null;
        CategorySixPacket? firstNatPacket = null;
        var computers = new Dictionary<int, CategorySixComputer>();
        var idle = true;

        for (var i = 0; i < 50; i++)
            computers[i] = new CategorySixComputer(program, i, SendPacket, HasReadInput);

        foreach (var computer in computers.Values)
            computer.Run();

        while (firstRepeatedNatPacket == null)
        {
            idle = true;

            foreach (var computer in computers.Values)
                computer.Resume();

            if (!idle || natPacket == null)
                continue;

            var natPacketRepeated = lastSentNatPacket != null && natPacket.X == lastSentNatPacket.X && natPacket.Y == lastSentNatPacket.Y;
            if (natPacketRepeated && firstRepeatedNatPacket == null)
                firstRepeatedNatPacket = natPacket;

            lastSentNatPacket = natPacket;
            SendPacket(0, natPacket);
            natPacket = null;
        }

        return (firstNatPacket!.Y, firstRepeatedNatPacket.Y);

        void SendPacket(int address, CategorySixPacket packet)
        {
            if (address == 255)
            {
                firstNatPacket ??= packet;
                natPacket = packet;
            }
            else
            {
                idle = false;
                computers[address].ReceivePacket(packet);
            }
        }

        void HasReadInput() => idle = false;
    }

    private class CategorySixComputer
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

        public void Run() => _computer.Start(true);
        public void Resume() => _computer.Resume();

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
                    return -1;

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

    private enum CategorySixComputerMode
    {
        Address,
        X,
        Y
    }

    private record CategorySixPacket(long X, long Y);
}