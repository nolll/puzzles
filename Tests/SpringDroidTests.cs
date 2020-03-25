using Core.SpringDroidAdventure;
using NUnit.Framework;

namespace Tests
{
    public class SpringDroidTests
    {
        [Test]
        public void JumpsIntoHole()
        {
            const string script = @"
NOT A J
NOT B T
OR T J
NOT C T
OR T J
AND D J
WALK";

            var droid = new SpringDroid(script);
            droid.Run();


        }
    }
}