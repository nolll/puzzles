using System;
using System.Collections.Generic;
using Core.Computer;

namespace Core.CategorySix
{
    public class CategorySixNetwork
    {
        private readonly Dictionary<int, CategorySixComputer> _computers;

        public long FirstYValueSentTo255 { get; private set; }

        public CategorySixNetwork(string program)
        {
            FirstYValueSentTo255 = 0;
            _computers = new Dictionary<int, CategorySixComputer>();
            for (var i = 0; i < 50; i++)
            {
                _computers[i] = new CategorySixComputer(program, i, SendPacket);
            }
        }

        public void Run()
        {
            foreach (var computer in _computers.Values)
            {
                computer.Run();
            }

            while (FirstYValueSentTo255 == 0)
            {
                foreach (var computer in _computers.Values)
                {
                    computer.Resume();
                }
            }
        }

        private void SendPacket(int address, CategorySixPacket packet)
        {
            if (address == 255 && FirstYValueSentTo255 == 0)
                FirstYValueSentTo255 = packet.Y;
            else
                _computers[address].ReceivePacket(packet);
        }
    }

    public enum CategorySixComputerMode
    {
        Address,
        X,
        Y
    }

    public class CategorySixPacket
    {
        public long X { get; }
        public long Y { get; }

        public CategorySixPacket(long x, long y)
        {
            X = x;
            Y = y;
        }
    }

    public class CategorySixComputer
    {
        private readonly ComputerInterface _computer;
        private readonly int _address;
        private readonly Action<int, CategorySixPacket> _sendPacketFunc;
        private CategorySixComputerMode _inputMode;
        private CategorySixComputerMode _outputMode;
        private CategorySixPacket _inputPacket;

        private int _outputAddress;
        private long _outputX;
        private long _outputY;

        private Queue<CategorySixPacket> Queue { get; }

        public CategorySixComputer(string program, int address, Action<int, CategorySixPacket> sendPacketFunc)
        {
            _address = address;
            _sendPacketFunc = sendPacketFunc;
            _inputMode = CategorySixComputerMode.Address;
            _outputMode = CategorySixComputerMode.Address;
            _computer = new ComputerInterface(program, ReadInput, WriteOutput);
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
                return _inputPacket.X;
            }

            if (_inputMode == CategorySixComputerMode.Y)
            {
                var y = _inputPacket.Y;
                _inputPacket = null;
                _inputMode = CategorySixComputerMode.X;
                return y;
            }

            return 0;
        }

        private void WriteOutput(long output)
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
        }

        public void ReceivePacket(CategorySixPacket packet)
        {
            Queue.Enqueue(packet);
            if (_inputMode == CategorySixComputerMode.Address)
                Run();
        }
    }
}