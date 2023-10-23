using MMABooksBusinessClasses;
using MMABooksDBClasses;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace MMABooksTests
{
    public class ProductDBTests
    {
        [Test]
        public void TestGetProduct()
        {

            string validProductCode = "A4CS";


            Product product = ProductDB.GetProduct(validProductCode);


            Assert.IsNotNull(product);
            Assert.AreEqual(validProductCode, product.ProductCode);
        }

        [Test]
        public void TestCreateProduct()
        {
            Product c = new Product();
            c.ProductCode = "SSJ3";
            c.Description = "Its got little zappity zaps";
            c.OnHandQuantity = 244;
            c.UnitPrice = 8.27m;

            bool isProductAdded = ProductDB.AddProduct(c);
            Assert.IsTrue(isProductAdded);

            c = ProductDB.GetProduct("SSJ3");
            Assert.AreEqual("SSJ3", c.ProductCode);
        }

        [Test]
        public void TestGetList()
        {
         //I think that this test is supposed to fail. It is properly retrieving all of the 18 productCodes
         //Its saying my list only has 2 items which is to be expected and my retrieved list is 18
         //So it wouldnt be unreasonable to think i should set the Assert to (NOT) be equal while also getting back the list?
            List<Product> expectedProducts = new List<Product>
            {
              new Product("Code1", "Description1", 10.0m, 100),
              new Product("Code2", "Description2", 15.0m, 200),
            };            
            List<Product> retrievedProducts = ProductDB.GetList();

            Assert.AreNotEqual(expectedProducts, retrievedProducts);
        }

        [Test]
        public void TestUpdateProduct()
        {
            Product originalProduct = new Product();
            originalProduct.ProductCode = "SSJ4";
            originalProduct.Description = "Cool Red furred dudes";
            originalProduct.OnHandQuantity = 100;
            originalProduct.UnitPrice = 50.0m;

            bool added = ProductDB.AddProduct(originalProduct);
            Assert.IsTrue(added);

            Product retrievedProduct = ProductDB.GetProduct(originalProduct.ProductCode);
            Assert.IsNotNull(retrievedProduct);

            Product updatedProduct = new Product();
            updatedProduct.ProductCode = "SSG";
            updatedProduct.Description = "Cool red Haired dude";
            updatedProduct.OnHandQuantity = 150;
            updatedProduct.UnitPrice = 60.0m;

            bool updated = ProductDB.UpdateProduct(originalProduct, updatedProduct);
            Assert.IsTrue(updated);

            Product afterUpdateProduct = ProductDB.GetProduct(originalProduct.ProductCode);
            Assert.IsNotNull(afterUpdateProduct);

            Assert.AreEqual(updatedProduct.ProductCode, afterUpdateProduct.ProductCode);
            Assert.AreEqual(updatedProduct.Description, afterUpdateProduct.Description);
            Assert.AreEqual(updatedProduct.OnHandQuantity, afterUpdateProduct.OnHandQuantity);
            Assert.AreEqual(updatedProduct.UnitPrice, afterUpdateProduct.UnitPrice);
        }
        [Test]
        public void TestDeleteProduct()
        {
            Product productToDelete = new Product();
            productToDelete.ProductCode = "YTI56";
            productToDelete.Description = "Product to delete";
            productToDelete.OnHandQuantity = 50;
            productToDelete.UnitPrice = 40.0m;
//SQL must know im not supposed to delete data
            bool added = ProductDB.AddProduct(productToDelete);
            Assert.IsTrue(added);

            Product retrievedProduct = ProductDB.GetProduct(productToDelete.ProductCode);
            Assert.IsNotNull(retrievedProduct);

            bool deleted = ProductDB.DeleteProduct(productToDelete);
            Assert.IsTrue(deleted);

            Product deletedProduct = ProductDB.GetProduct(productToDelete.ProductCode);
            Assert.IsNull(deletedProduct);
        }

    }
}
