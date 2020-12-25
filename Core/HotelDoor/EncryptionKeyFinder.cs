using Core.Tools;

namespace Core.HotelDoor
{
    public class EncryptionKeyFinder
    {
        private readonly long _cardPublicKey;
        private readonly long _doorPublicKey;

        public EncryptionKeyFinder(string input)
        {
            var rows = PuzzleInputReader.ReadLines(input);
            _cardPublicKey = long.Parse(rows[0]);
            _doorPublicKey = long.Parse(rows[1]);
        }

        public long FindKey()
        {
            var cardLoopSize = GetLoopSize(_cardPublicKey);
            var roomLoopSize = GetLoopSize(_doorPublicKey);
            var key = GetKey(cardLoopSize, _doorPublicKey);
            return key;
        }

        private long GetLoopSize(long publicKey)
        {
            long value = 1;
            const int subjectNumber = 7;
            long loopSize = 1;
            const int divideBy = 20_201_227;
            while (true)
            {
                value = (value * subjectNumber) % divideBy;
                if (value == publicKey)
                    return loopSize;

                loopSize++;
            }

            return 0;
        }

        private long GetKey(long loopSize, long publicKey)
        {
            long value = 1;
            var subjectNumber = publicKey;
            const int divideBy = 20_201_227;
            for (var i = 0; i < loopSize; i++)
            {
                value = (value * subjectNumber) % divideBy;
            }

            return value;
        }
    }
}