using NUnit.Framework;
using Project.Scripts;

public class StatsSpec
{
    public class GetValueTests
    {
        [Test]
        public void NoModifiers_ReturnsBaseValue([Values(100,32)] int value)
        {
            var stat = new Stat();
            stat.SetBaseValue(value);
            Assert.That(stat.Value, Is.EqualTo(value));
        }
    }
}