using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersiennGiganten_2020
{
    public static class ExtensionMethods
    {
        public static int RoundOff(int i)
        {
            return ((int)Math.Round(i / 10.0, MidpointRounding.AwayFromZero)) * 10;
        }

        public static int SizeRounded(string sizeText)
        {
            int size = 0;

            int roundedValue = 0;
            if (sizeText != "")
            {
                //Parse to int
                try
                {
                    size = int.Parse(sizeText);
                }
                catch (Exception)
                {

                }
                //Round to closest 10
                int rounded = ExtensionMethods.RoundOff(size);
                roundedValue = rounded;
                return roundedValue;
            }
            return roundedValue;
        }
    }
}
