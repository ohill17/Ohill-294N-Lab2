using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(string productCode, string description, double unitprice, int onhandquantity)
        {
            ProductCode = productcode;
            Description = description;
            UnitPrice = unitprice;
            OnHandQuantity = onhandquantity;
        }
        private string productcode;
        private string description;
        private double unitprice;
        private int onhandquantity;

  public string ProductCode
    {
         get
         {
             return productcode;
         }
         set
         {
             if(value.Length >= 10 && value.Length < 0)
             {
                 value = productcode;
             }
             else
             {
                 throw new ArgumentOutOfRangeException("Product Code must be between 1-10");
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
                if(value.Length >= 50 && value.Length < 0)
                {
                    value = description;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Description must be between 0 and 50 characters");
                }
            }
        }
        public double UnitPrice
        {
            get
            {
                return unitprice;
            }
            set
            {
                if(value >= 90.0 && value < 1.0)
                {
                    value = unitprice;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Price must be between 90.0 and 1.0");
                }
            }
        }
        public int OnHandQuantity
        {
            get
            {
                return onhandquantity;
            }
            set
            {
                if (value >= 7000 && value <= 1)
                {
                    onhandquantity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("On hand quantity must be between 1 and 7000");
                }
            }
        }
    }
   
  
}
