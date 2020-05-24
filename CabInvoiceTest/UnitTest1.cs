using CabInvoiceMain;
using NUnit.Framework;
using System;

namespace CabInvoiceTest
{
    public class Tests
    {
        InvoiceService invoiceService = null;

        [SetUp]
        public void Setup()
        {
            invoiceService = new InvoiceService();
        }

        /// <summary>
        /// When given proper distance and Time, should return total fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenProper_ShouldReturnTotalFare()
        {
            double distance = 3.0;
            int time = 5;
            double fare = invoiceService.CalculateFare(distance, time, RideType.NORMAL);
            Assert.AreEqual(35, fare);
        }

        /// <summary>
        ///  When given less distance and Time, should return minimum fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenLess_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double fare = invoiceService.CalculateFare(distance, time, RideType.PREMIUM);
            Assert.AreEqual(20, fare);
        }

        /// <summary>
        /// When given multiple rides, should return number of rides,total fare,average fare
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            Ride[] rides =  {   new Ride(3.0, 5,RideType.NORMAL),
                                new Ride(0.1, 1,RideType.PREMIUM)                              
                            };
            InvoiceSummary summary = invoiceService.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 55.0);
            bool result = summary.Equals(expectedInvoiceSummary);
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// When given UserID and multiple rides, should return number of rides,total fare,average fare
        /// </summary>
        [Test]
        public void GivenUserIDAndMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            String userId = "pranav805";
            Ride[] rides =  {   new Ride(3.0, 5,RideType.NORMAL),
                                new Ride(0.1, 1,RideType.PREMIUM),
                                new Ride(3.0, 5,RideType.PREMIUM)
                            };
            invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(3, 110.0);
            bool result = summary.Equals(expectedInvoiceSummary);
            Assert.AreEqual(true, result);
        }
       
    }
}