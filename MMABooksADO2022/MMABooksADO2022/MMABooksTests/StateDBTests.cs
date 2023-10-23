using MMABooksBusinessClasses;
using MMABooksDBClasses;
using NUnit.Framework;

namespace MMABooksTests
{
    [TestFixture]
    public class StateDBTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestGetStates()
        {
            List<State> states = StateDB.GetStates();
            Assert.AreEqual(53, states.Count);
            Assert.AreEqual("Alabama", states[0].StateName);
        }
        /*
                [Test]
                public void TestGetStatesDBUnavailable()
                {
                    Assert.Throws<MySqlException>(() => StateDB.GetStates());
                }
        */
    }
}
