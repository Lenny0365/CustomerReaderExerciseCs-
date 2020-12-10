using CustomerReader.Helpers;
using CustomerReader.Readers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerReader.Tests
{
    public class ReadersTest
    {
        CustomersReader cr = new CustomersReader();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ValidPathToCsvReturnsCorrectNumbersOfCustomers()
        {
            List<Customer> customers = cr.readCustomersCsv("..\\..\\..\\..\\doc\\customers.csv");
            Assert.AreEqual(3, customers.Count);
        }

        [Test]
        public void ValidPathToXmlReturnsCorrectNumbersOfCustomers()
        {
            List<Customer> customers = cr.readCustomersXml("..\\..\\..\\..\\doc\\customers.xml");
            Assert.AreEqual(1, customers.Count);
        }

        [Test]
        public void ValidPathToJsonReturnsCorrectNumbersOfCustomers()
        {           
            List<Customer> customers = cr.readCustomersJson("..\\..\\..\\..\\doc\\customers.json");
            Assert.AreEqual(2, customers.Count);
        }

 
    }
}
