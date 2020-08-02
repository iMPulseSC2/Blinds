using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersiennGiganten_2020
{
    public class Quote
    {
        public Customer Customer;
        public List<Product> Product;
        public double price;

        //public string ProductName { get; set; }
        //public int Quantity { get; set; }
        //public double Width { get; set; }
        //public double Height { get; set; }
        //public string Pricegroup { get; set; }
        //public int Discount { get; set; }
        //public double Price { get; set; }
        public Quote()
        {
        }

        public Quote(Customer aCustomer, List<Product> aProduct, double aPrice)
        {
            price = aPrice;
        }

        public string Products()
        {

            return "";
        }
    }

    
}
