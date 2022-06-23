using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databaseExtract
{
    public class Container
    {
        public int thecontainervolume { get; set; }

        public Container(int thecontainervolume)
        {
            this.thecontainervolume = thecontainervolume;
        }

        public double getPrice()
        {
            double price = 40 * thecontainervolume;
            return price;
        }
    }
}


