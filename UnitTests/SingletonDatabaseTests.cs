

using DesignPatterns.Singleton;

namespace UnitTests
{
    public class SingletonDatabaseTests
    {

        [Test]
        public void GetPopulationTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;

            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.InstanceCount, Is.EqualTo(1));
        }

        [Test]
        public void GetTotalPopulationTest()
        {
            var names = new [] { "New York", "Tokyo" };

            var tf = new TotalCapitalFinder();
            var result = tf.GetTotalPopulation(names);

            Assert.That(result, Is.EqualTo(17800000 + 33200000));
        }
    }
}