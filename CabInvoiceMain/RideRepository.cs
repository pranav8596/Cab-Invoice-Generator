using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceMain
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;
        public RideRepository()
        {
            userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRides(string userId, Ride[] rides)
        {           
            List<Ride> list = new List<Ride>();
            list.AddRange(rides);
            userRides.Add(userId, list);
        }

        public Ride[] GetRides(string userId)
        {
            return userRides[userId].ToArray();
        }
    }
}
