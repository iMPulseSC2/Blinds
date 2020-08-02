using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersiennGiganten_2020
{

    public class DataGrid
    {
        public List<double> listPriceExclTax = new List<double>();
        public string Product { get; set; }
        public int Quantity { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double PriceInclTax { get; set; }
        public double _PriceExclTax;
        public double PriceExclTax
        {
            get { return _PriceExclTax; }
            set
            {
                if (value >= 0)
                {
                    _PriceExclTax = 0;
                }
                else
                {
                    double sum = (PricePerPiece * Convert.ToDouble(Quantity)) * 0.8;
                    _PriceExclTax = value += sum;
                }
            }
        }
        public double PricePerPiece = 556;

        //public static double PriceWithoutTax()
        //{
        //    double sum = 0;
        //    sum = (PricePerPiece * Quantity) * 0.8;

        //    return sum;
        //}
        //public int TotalPriceSum()
        //{
        //    int price = 0;
        //    int convertedPricePerPiece = Convert.ToInt32(PricePerPiece);


        //    price = Quantity* convertedPricePerPiece;
        //    return price;
        //}

        public DataGrid()
        {
        }

        public DataGrid(string aProduct, int aQuantity, double aWidth, double aHeight)
        {
            Product = aProduct;
            Quantity = aQuantity;
            Width = aWidth;
            Height = aHeight;
        }
    }
}
