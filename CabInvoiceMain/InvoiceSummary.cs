using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceMain
{
    public class InvoiceSummary
    {
        public int numOfRides;
        public double totalFare;
        public double averageFare;

        public InvoiceSummary(int numOfRides, double totalFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numOfRides;
        }

        /// <summary>
        /// Override Equals method to check if two objects are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            InvoiceSummary that = (InvoiceSummary) obj;
            bool res1 = numOfRides == that.numOfRides;
            bool res2 = totalFare == that.totalFare;
            bool res3 = averageFare == that.averageFare;
            if (res1 == res2 == res3)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
