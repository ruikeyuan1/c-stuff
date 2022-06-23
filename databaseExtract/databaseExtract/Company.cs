using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databaseExtract
{
    public class Company
    {
        private List<Rental> rentals = new List<Rental>();

        private List<Container> containers = new List<Container>();

        public Company() { }

        public List<Container> Containers { get { return containers; } }

        public List<Rental> Rentals { get { return rentals; } }

        public void addRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public void addContainer(Container container)
        {
            containers.Add(container);
        }

        public double totalIncome()
        {
            double totalIncome = 0;
            foreach (Rental rental in rentals)
            {
                totalIncome += rental.getPayableCharges();
            }
            return totalIncome;
        }

        public double averageVolume()
        {
            double averageVolume = 0;
            foreach (Rental rental in rentals)
            {
                averageVolume += rental.getVolumeOfContainer();
            }
            averageVolume /= rentals.Count();
            return averageVolume;
        }

        public double longestPeriod()
        {
            double longestPeriod = 0;
            {
                foreach (Rental rental in rentals)
                {
                    if (rental.getPeriod() > longestPeriod)
                    {
                        longestPeriod = rental.getPeriod();
                    }
                }
            }
            return longestPeriod;
        }
    }
}
