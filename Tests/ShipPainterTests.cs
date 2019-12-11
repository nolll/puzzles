using Core.ShipPainting;
using NUnit.Framework;

namespace Tests
{
    public class ShipPainterTests
    {
        [Test]
        public void ReturnsInputMemoryAsOutputMemory()
        {
            const string program = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99";

            var shipPainter = new ShipPainter(program);
            var result = shipPainter.Paint();

            Assert.That(result.PaintedPanels, Is.EqualTo(program));
        }
    }
}