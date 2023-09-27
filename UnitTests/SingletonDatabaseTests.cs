

using Autofac;
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

            var totalPopulationFinder = new TotalPopulationFinder();
            var result = totalPopulationFinder.GetTotalPopulation(names);

            Assert.That(result, Is.EqualTo(17800000 + 33200000));
        }

        public class DummyData : IDatabase
        {
            public int GetPopulation(string name)
            {
                return new Dictionary<string, int>
                {
                    ["a"] = 1,
                    ["b"] = 2,
                    ["c"] = 3,
                }[name];
            }
        }

        [Test]
        public void ConfigurablePopulationFinderTest()
        {
            var mokedData = new DummyData();

            var populationFinder = new ConfigurablePopulationFinder(mokedData);

            var names = new[] { "a", "b" };
            var result = populationFinder.GetTotalPopulation(names);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void DIOrdirnaryDatabaseTest()
        {
            var containerBuiler = new ContainerBuilder();
            containerBuiler.RegisterType<OrdirnaryDatabase>()
                .As<IDatabase>()
                .SingleInstance();
            containerBuiler.RegisterType<TotalPopulationFinder>();

            using (var c = containerBuiler.Build())
            {
                var totalPopulationFinder = c.Resolve<TotalPopulationFinder>();
                var names = new[] { "New York", "Tokyo" };
                var result = totalPopulationFinder.GetTotalPopulation(names);

                Assert.That(result, Is.EqualTo(17800000 + 33200000));
            }

        }
    }
}