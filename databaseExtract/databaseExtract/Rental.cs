using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace databaseExtract
{
    public class Rental
    {
        public Container contain { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public double totalRentalDays { get; set; }

        public double payableCharges { get; set; }

   

        public Rental(Container contain, DateTime startDate, DateTime endDate)
        {
            this.contain = contain;
            this.startDate = startDate; 
            this.endDate = endDate;
            //this.startDate = Convert.ToDateTime(startDate.ToShortDateString());
            //this.endDate = Convert.ToDateTime(endDate.ToShortDateString());
        }

        public double getPeriod()
        {
            double totalRentalDays = endDate.Subtract(startDate).Days;
            return totalRentalDays;
        }

        public double takeawayCharges()
        {
            double theTakeawayCharges = 0;
            if (contain.thecontainervolume > 2)
            {
                theTakeawayCharges = 125;
               
            }
            else
            {
                theTakeawayCharges = 60;
            }
            return theTakeawayCharges;
        }

        public double getVolumeOfContainer()
        {
            double volumeOfContainer = contain.thecontainervolume;
            return volumeOfContainer;
        }

        public double getPayableCharges()
        {
            double payableCharges = contain.getPrice() * getPeriod() + takeawayCharges();
            return payableCharges;
        }
    }
}


