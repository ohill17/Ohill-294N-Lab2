using System;
using System.ComponentModel.DataAnnotations;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        //instance variables
        private int customerID;
        private string name;    
        private string address;
        private string city;
        private string state;
        private string zipcode;



        public int CustomerID 
        {
            get
            {
                return customerID;
            }
            set
            {
                if (value > 0)
                    customerID = value;
                else
                    throw new ArgumentOutOfRangeException("You done fucked up the customerid");
            }
        }

        public string Name { 
            get
            {
                return name;
            }
    
            set
            {
                if (value.Trim().Length > 0 && value.Length <= 100)
                    name = value;
                else if(value.Trim().Length >= 0)
                    throw new ArgumentOutOfRangeException("Too Short!");
                else if (value.Trim().Length <= 100)
                    throw new ArgumentOutOfRangeException("Too Long!");
            }
        }
        
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value.Trim().Length > 2 && value.Length <= 50)
                    address = value;
                else
                    throw new ArgumentOutOfRangeException("You done fucked up the address");
            }
        }

public string City
        {
            get
            {
                return city;
            }
             set
            {
                if (value.Trim().Length > 2 && value.Length <= 20)
                    city = value;
                else
                    throw new ArgumentOutOfRangeException("You done fucked up again city");
}
        }
           
public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (value.Trim().Length == 2 )
                    state = value;
                else
                    throw new ArgumentOutOfRangeException("You done fucked up again the state");
            }
        }
        public string ZipCode {
            get
            {
                return zipcode;
            }

            set
            {
                if (value.Length > 4 && value.Length < 11)
                    zipcode = value;
                else
                    throw new ArgumentOutOfRangeException("You done fucked up again the zipcode");
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
