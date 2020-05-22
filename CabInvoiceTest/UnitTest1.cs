using CabInvoiceMain;
using NUnit.Framework;

namespace CabInvoiceTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTime_WhenProper_ShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 3.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(35, fare);
        }
    }
}