namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(string productCode, string description, decimal unitPrice, int onHandQuantity)
        {
            ProductCode = productCode;
            Description = description;
            UnitPrice = unitPrice;
            OnHandQuantity = onHandQuantity;
        }

        private string productCode;
        private string description;
        private decimal unitPrice;
        private int onHandQuantity;

        public string ProductCode
        {
            get
            {
                return productCode;
            }
            set
            {
                if (value.Length >= 1 && value.Length <= 10)
                {
                    productCode = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Product Code must be between 1 and 10");
                }
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value.Length >= 0 && value.Length <= 50)
                {
                    description = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Description must be between 0 and 50 characters");
                }
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                if (value >= 1.0m && value <= 90.0m)
                {
                    unitPrice = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Price must be between 1.0 and 90.0");
                }
            }
        }

        public int OnHandQuantity
        {
            get
            {
                return onHandQuantity;
            }
            set
            {
                if (value >= 1 && value <= 7000)
                {
                    onHandQuantity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("On hand quantity must be between 1 and 7000");
                }
            }
        }
    }
}