using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceMain
{
    public class InvoiceGenerator
    {
        //Constants
        public const int CostPerKilometer = 10;
        public const int CostPerMinute = 1;
        public const int MinimumFare = 5;

        /// <summary>
        /// Calculate the total fare for the given distance and time
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * CostPerKilometer + time * CostPerMinute;
            /* if(totalFare < MinimumFare)
             {
                 return MinimumFare;
             }
             else
             {
                 return totalFare;
             }*/
            return Math.Max(totalFare, MinimumFare);
        }

        public double CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach(Ride ride in rides)
            {
                 totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }
    }
}
