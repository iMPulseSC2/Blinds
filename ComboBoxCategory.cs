using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersiennGiganten_2020
{
    public class ComboBoxCategory
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return Category;
        }
    }
}
