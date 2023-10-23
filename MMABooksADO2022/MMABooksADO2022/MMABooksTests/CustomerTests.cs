using MMABooksBusinessClasses;
using NUnit.Framework;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]
        public void SetUp()
        {
            def = new Customer();
            c = new Customer(1, "Donald, Duck", "101 Main Street", "Detroit", "MI", "10001");
        }
        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreEqual("Donald, Duck", c.Name);
            Assert.AreNotEqual(null, c.Address);
            Assert.AreNotEqual(null, c.City);
            Assert.AreNotEqual(null, c.State);
            Assert.AreNotEqual(null, c.ZipCode);

        }
        [Test]
        public void TestNameSetter()
        {
            c.Name = "Dasie, Duck";
            Assert.AreNotEqual("Donald, Duck", c.Name);
            Assert.AreEqual("Dasie, Duck", c.Name);
        }
        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "AKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKMAKGNGMKMEGKMGKM2KMKMK3MK4MKMGKM");
        }
        [Test]
        public void TestSettersNameToShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "    ");
        }
    }
}
