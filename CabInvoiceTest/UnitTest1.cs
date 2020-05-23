using CabInvoiceMain;
using NUnit.Framework;

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
        /// When given multiple rides, should calculate aggregate total fare for all 
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenProper_ShouldReturnTotalFare()
        {
            Ride[] rides =  {   new Ride(3.0, 5),
                                new Ride(0.1, 1),
                                new Ride(3.0, 5)
                            };
            double fare = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(75, fare);
        }

    }
}