using MMABooksBusinessClasses;
using MySql.Data.MySqlClient;
using System.Data;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static bool AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products"
                + "(ProductCode, Description, OnHandQuantity, UnitPrice) "
                + "VALUES (@ProductCode, @Description, @OnHandQuantity,@UnitPrice)";
            MySqlCommand insertCommand =
                     new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue(
                "@Description", product.Description);
            insertCommand.Parameters.AddWithValue(
                "@OnHandQuantity", product.OnHandQuantity);
            insertCommand.Parameters.AddWithValue(
                "@UnitPrice", product.UnitPrice);

            try
            {
                connection.Open();
                int rowsAffected = insertCommand.ExecuteNonQuery();

                // If the number of records inserted is 1, return true; otherwise, return false
                return rowsAffected == 1;
            }
            catch (MySqlException ex)
            {
                // Handle the exception
                throw ex;
              
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool DeleteProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products" +
                "WHERE ProductCode = @ProductCode" +
                "AND Description = @Description" +
                "AND OnHandQuantity = @OnHandQuantity" +
                "AND UnitPrice = @UnitPrice";
            MySqlCommand deleteCommand = new MySqlCommand(@deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            deleteCommand.Parameters.AddWithValue("@Description", product.Description);
            deleteCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            deleteCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);

            try
            {
                connection.Open();
                int rowsAffected = deleteCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {

                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }
        public static Product GetProduct(string ProductCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, OnHandQuantity, UnitPrice"
                + " FROM Products" // Added spaces to fix SQL query
                + " WHERE ProductCode = @ProductCode"; // Corrected WHERE clause
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", ProductCode);

            try
            {
                connection.Open();
                MySqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = (string)prodReader["ProductCode"];
                    product.Description = prodReader["Description"].ToString();
                    product.OnHandQuantity = (int)prodReader["OnHandQuantity"];
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];

                    prodReader.Close();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public static List<Product> GetList()
        {
            List<Product> productList = new List<Product>();

            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity FROM Products";

            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);

            try
            {
                connection.Open();
                MySqlDataReader prodReader = selectCommand.ExecuteReader();

                while (prodReader.Read())
                {
                    // Create a new Product object for each row in the result set
                    Product product = new Product();
                    product.ProductCode = prodReader["ProductCode"].ToString();
                    product.Description = prodReader["Description"].ToString();
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];
                    product.OnHandQuantity = (int)prodReader["OnHandQuantity"];

                    productList.Add(product);
                }
            }
            catch (MySqlException ex)
            {
                // Handle the exception or log it
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return productList;
        }
        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "ProductCode = @NewProductCode, " +
                "Description = @NewDescription, " +
                "OnHandQuantity = @NewOnHandQuantity, " +
                "UnitPrice = @NewUnitPrice " +
                "WHERE ProductCode = @OldProductCode " +
                "AND Description = @OldDescription " +
                "AND OnHandQuantity = @OldOnHandQuantity " +
                "AND UnitPrice = @OldUnitPrice";

            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue("@NewProductCode", newProduct.ProductCode);
            updateCommand.Parameters.AddWithValue("@NewDescription", newProduct.Description);
            updateCommand.Parameters.AddWithValue("@NewOnHandQuantity", newProduct.OnHandQuantity);
            updateCommand.Parameters.AddWithValue("@NewUnitPrice", newProduct.UnitPrice);

            updateCommand.Parameters.AddWithValue("@OldProductCode", oldProduct.ProductCode);
            updateCommand.Parameters.AddWithValue("@OldDescription", oldProduct.Description);
            updateCommand.Parameters.AddWithValue("@OldOnHandQuantity", oldProduct.OnHandQuantity);
            updateCommand.Parameters.AddWithValue("@OldUnitPrice", oldProduct.UnitPrice);

            try
            {
                connection.Open();
                int rowsAffected = updateCommand.ExecuteNonQuery();

                return rowsAffected == 1;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

