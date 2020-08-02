using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersiennGiganten_2020
{
    public class Customer
    {
        public string name;
        public int phone;
        public string address;
        public int zipcode;
        public string companyName;

        public Customer(string aName, int aPhone, string aAddress)
        {
            name = aName;
            phone = aPhone;
            address = aAddress;
        }

        public Customer(string aName, int aPhone, string aAddress, int aZipCode)
        {
            name = aName;
            phone = aPhone;
            address = aAddress;
            zipcode = aZipCode;
        }

        public Customer(string aName, int aPhone, string aAddress, int aZipCode, string aCompanyName)
        {
            name = aName;
            phone = aPhone;
            address = aAddress;
            zipcode = aZipCode;
            companyName = aCompanyName;
        }
    }
}
