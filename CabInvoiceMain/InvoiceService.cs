using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceMain
{
    public class InvoiceService
    {
        //Constants
        public const int CostPerKmForNormal = 10;
        public const int CostPerMinuteForNormal = 1;
        public const int MinimumFareForNormal = 5;

        public const int CostPerKmForPremium = 15;
        public const int CostPerMinuteForPremium = 2;
        public const int MinimumFareForPremium = 20;

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
        public double CalculateFare(double distance, int time, RideType rideType)
        {
            if (rideType.Equals(RideType.NORMAL))
            {
                return SetType(CostPerKmForNormal, CostPerMinuteForNormal, MinimumFareForNormal, distance, time);
            }
            else
            {
                return SetType(CostPerKmForPremium, CostPerMinuteForPremium, MinimumFareForPremium, distance, time);

            }

        }

        /// <summary>
        /// To calculate the fare for a type of ride
        /// </summary>
        /// <param name="costPerKilometerForNormal"></param>
        /// <param name="costPerMinuteForNormal"></param>
        /// <param name="minimumFareForNormal"></param>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private double SetType(int costPerKilometerForNormal, int costPerMinuteForNormal, int minimumFareForNormal, double distance, int time)
        {
            int CostPerKilometer = costPerKilometerForNormal;
            int CostPerMinute = costPerMinuteForNormal;
            int MinimumFare = minimumFareForNormal;

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
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time, ride.rideType);
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
