using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CustomerReader.Readers;
using CustomerReader.Helpers;

namespace CustomerReader
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersReader cr = new CustomersReader();

            var CustomerList = cr.readCustomersCsv("..\\..\\..\\doc\\customers.csv");
            CustomerList.AddRange(cr.readCustomersXml("..\\..\\..\\doc\\customers.xml"));
            CustomerList.AddRange(cr.readCustomersJson("..\\..\\..\\doc\\customers.json"));

            Console.WriteLine("Added this many customers: " + CustomerList.Count + "\n");
            
            Console.WriteLine(DisplayHelper.BuildCustomersInspectionText(CustomerList));
            Console.ReadLine();
        }
    }
}
