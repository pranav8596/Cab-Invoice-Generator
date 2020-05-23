using CabInvoiceMain;
using NUnit.Framework;
using System;

namespace CabInvoiceTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
        }

        /// <summary>
        /// When given proper distance and Time, should return total fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenProper_ShouldReturnTotalFare()
        {
            double distance = 3.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
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
            double fare = invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5, fare);
        }


        /// <summary>
        /// When given multiple rides, should return number of rides,total fare,average fare
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            Ride[] rides =  {   new Ride(3.0, 5),
                                new Ride(0.1, 1),
                                new Ride(3.0, 5)
                            };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(3, 75.0);
            bool result = summary.Equals(expectedInvoiceSummary);
            Console.WriteLine(result);
            Assert.AreEqual(true, result);
        }
    }
}