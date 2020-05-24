using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceMain
{
    public class InvoiceService
    {
        //Constants
        public const int CostPerKilometer = 10;
        public const int CostPerMinute = 1;
        public const int MinimumFare = 5;

        public RideRepository rideRepository;

        public InvoiceService()
        {
            this.rideRepository = new RideRepository();
        }
        

        /// <summary>
        /// Calculate the total fare for the given distance and time
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * CostPerKilometer + time * CostPerMinute;            
            return Math.Max(totalFare, MinimumFare);
        }

        /// <summary>
        /// Calculate total fare of all rides 
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach(Ride ride in rides)
            {
                 totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }

        /// <summary>
        /// Add rides for the given UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId, Ride[] rides)
        {
            rideRepository.AddRides(userId, rides);
             
        }

        /// <summary>
        /// Get the invoice summary of all the rides
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateFare(rideRepository.GetRides(userId));
        }
    }
}
