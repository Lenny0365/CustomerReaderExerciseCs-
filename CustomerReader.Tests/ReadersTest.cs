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
        const string strDisplayResult = "Email: email\r\nFirst Name: FirstName\r\nLast Name: LastName\r\nFull Name: FirstName LastName\r\nPhone Number:  phoneNumber\r\nStreet Address: StreetAddress\r\nCity: City\r\nState:  STATE\r\nZip Code:  zipCode\r\n\r\nEmail: someone@somewhere.com\r\nFirst Name: Steve\r\nLast Name: Jones\r\nFull Name: Steve Jones\r\nPhone Number: (414) 213-9809\r\nStreet Address: 123 Cool St.\r\nCity: Pittsfield\r\nState: MA\r\nZip Code: 01201\r\n\r\nEmail: testing@gmail.com\r\nFirst Name: Tester\r\nLast Name: Person\r\nFull Name: Tester Person\r\nPhone Number: (243) 455-6342\r\nStreet Address: 22 Something Rd.\r\nCity: Nowhereville\r\nState: CA\r\nZip Code: 00000\r\n\r\nEmail: johnny@hotmail.com\r\nFirst Name: John\r\nLast Name: Smith\r\nFull Name: John Smith\r\nPhone Number: (413) 111-2222\r\nStreet Address: 33 Example Ave.\r\nCity: Boston\r\nState: MA\r\nZip Code: 02110\r\n\r\nEmail: amanda@aol.com\r\nFirst Name: Amanda\r\nLast Name: Garrison\r\nFull Name: Amanda Garrison\r\nPhone Number: (413) 444-2211\r\nStreet Address: 13 Unlucky St.\r\nCity: Summerville\r\nState: GA\r\nZip Code: 11111\r\n\r\nEmail: barry@unknown.net\r\nFirst Name: Barry\r\nLast Name: Allen\r\nFull Name: Barry Allen\r\nPhone Number: (413) 222-9976\r\nStreet Address: 102 Slow St.\r\nCity: Slothville\r\nState: MA\r\nZip Code: 33333\r\n\r\n";
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

        [Test]
        public void ValidInputAllCustomersListCorrectStringOutput()
        {
            CustomersReader cr = new CustomersReader();

            var CustomerList = cr.readCustomersCsv("..\\..\\..\\..\\doc\\customers.csv");
            CustomerList.AddRange(cr.readCustomersXml("..\\..\\..\\..\\doc\\customers.xml"));
            CustomerList.AddRange(cr.readCustomersJson("..\\..\\..\\..\\doc\\customers.json"));

           

            string result =  DisplayHelper.BuildCustomersInspectionText(CustomerList);
            Assert.AreEqual(strDisplayResult, result);
        }
    }
}
