using MMABooksBusinessClasses;
using NUnit.Framework;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product c;

        [SetUp]
        public void SetUp()
        {
            def = new Product();
            c = new Product("Goku", "Dah Legend", 9.35m, 231);
        }
        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(0m, def.UnitPrice);
            Assert.AreEqual(0, def.OnHandQuantity);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.ProductCode);
            Assert.AreEqual("Goku", c.ProductCode);
            Assert.AreNotEqual(null, c.Description);
            Assert.AreNotEqual(null, c.UnitPrice);
            Assert.AreNotEqual(null, c.OnHandQuantity);

        }
    }
}
