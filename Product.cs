using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PersiennGiganten_2020
{

    public class Product
    {
        public int quantity { get; set; }
        public string priceGroup { get; set; }
        public double width { get; set; }
        public double height { get; set; }

        public Product(int aQuantity, string aPriceGroup, double aWidth, double aHeight)
        {
            quantity = aQuantity;
            priceGroup = aPriceGroup;
            width = aWidth;
            height = aHeight;
        }
    }
    public class Persienner : Product
    {
        public Persienner(int aQuantity, string aPriceGroup, double aWidth, double aHeight) : base(aQuantity, aPriceGroup, aWidth, aHeight)
        {
        }

        public override string ToString()
        {
            return "Persienner";
        }
    }

    public class Rullgardiner : Product
    {
        public Rullgardiner(int aQuantity, string aPriceGroup, double aWidth, double aHeight) : base(aQuantity, aPriceGroup, aWidth, aHeight)
        {
        }
        public override string ToString()
        {

            return "Rullgardiner";
        }
    }

    public class Plissegardiner : Product
    {
        public Plissegardiner(int aQuantity, string aPriceGroup, double aWidth, double aHeight) : base(aQuantity, aPriceGroup, aWidth, aHeight)
        {
        }
        public override string ToString()
        {
            return "Plisségardiner";
        }
    }

    public class Honeycellgardiner : Product
    {
        public Honeycellgardiner(int aQuantity, string aPriceGroup, double aWidth, double aHeight) : base(aQuantity, aPriceGroup, aWidth, aHeight)
        {
        }
        public override string ToString()
        {
            return "Honeycellgardiner";
        }
    }

    public class Lamellgardiner : Product
    {
        public Lamellgardiner(int aQuantity, string aPriceGroup, double aWidth, double aHeight) : base(aQuantity, aPriceGroup, aWidth, aHeight)
        {
        }
        public override string ToString()
        {
            return "Lamellgardiner";
        }
    }
    public class Trapersienner : Product
    {
        public Trapersienner(int aQuantity, string aPriceGroup, double aWidth, double aHeight) : base(aQuantity, aPriceGroup, aWidth, aHeight)
        {
        }
        public override string ToString()
        {
            return "Träpersienner";
        }
    }
}
