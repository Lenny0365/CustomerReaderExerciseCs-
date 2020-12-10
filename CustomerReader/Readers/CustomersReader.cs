using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CustomerReader.Readers
{
    public class CustomersReader
    {
        public CustomersReader()
        {
        }

        /*
         * This method reads customers from a CSV file and returns customers list.
         */
        public List<Customer> readCustomersCsv(String customer_file_path)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                StreamReader br = new StreamReader(File.Open(customer_file_path, FileMode.Open));
                String line = br.ReadLine();

                while (line != null)
                {
                    String[] attributes = line.Split(',');

                    Customer customer = new Customer();
                    customer.Email = attributes[0];
                    customer.FirstName = attributes[1];
                    customer.LastName = attributes[2];
                    customer.Phone = attributes[3];
                    customer.CustomerAddress.StreetAddress = attributes[4];
                    customer.CustomerAddress.City = attributes[5];
                    customer.CustomerAddress.State = attributes[6];
                    customer.CustomerAddress.ZipCode = attributes[7];

                    customers.Add(customer);
                    line = br.ReadLine();
                }
            }
            catch (IOException ex)
            {
                Console.Write("OH NO!!!!");
                Console.Write(ex.StackTrace);
            }

            return customers;
        }

        public List<Customer> readCustomersXml(String customerFilePath)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                var doc = new XmlDocument();
                doc.Load(customerFilePath);

                XmlNodeList nList = doc.GetElementsByTagName("Customers");

                for (int temp = 0; temp < nList.Count; temp++)
                {
                    XmlNode nNode = nList[temp];

                    if (nNode.NodeType == XmlNodeType.Element)
                    {
                        Customer customer = new Customer();
                        XmlElement eElement = (XmlElement)nNode;

                        customer.Email = eElement.GetElementsByTagName("Email").Item(0).InnerText;
                        customer.FirstName = eElement.GetElementsByTagName("FirstName").Item(0).InnerText;
                        customer.LastName = eElement.GetElementsByTagName("LastName").Item(0).InnerText;
                        customer.Phone = eElement.GetElementsByTagName("PhoneNumber").Item(0).InnerText;

                        XmlElement aElement = (XmlElement)eElement.GetElementsByTagName("Address").Item(0);

                        customer.CustomerAddress.StreetAddress = aElement.GetElementsByTagName("StreetAddress").Item(0).InnerText;
                        customer.CustomerAddress.City = aElement.GetElementsByTagName("City").Item(0).InnerText;
                        customer.CustomerAddress.State = aElement.GetElementsByTagName("State").Item(0).InnerText;
                        customer.CustomerAddress.ZipCode = aElement.GetElementsByTagName("ZipCode").Item(0).InnerText;

                        customers.Add(customer);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return customers;
        }


        public List<Customer> readCustomersJson(String customersFilePath)
        {
            JsonTextReader reader = new JsonTextReader(System.IO.File.OpenText(customersFilePath));
            List<Customer> customers = new List<Customer>();

            try
            {
                JArray obj = (JArray)JToken.ReadFrom(reader);

                foreach (JObject o in obj)
                {
                    Customer customer = new Customer();
                    JObject record = (JObject)o;

                    String email = (String)record["Email"];
                    customer.Email = email;

                    String firstName = (String)record["FirstName"];
                    customer.FirstName = firstName;

                    String lastName = (String)record["LastName"];
                    customer.LastName = lastName;

                    String phone = (String)record["PhoneNumber"];
                    customer.Phone = phone;

                    JObject address = (JObject)record["Address"];

                    String streetAddress = (String)address["StreetAddress"];
                    customer.CustomerAddress.StreetAddress = streetAddress;

                    String city = (String)address["City"];
                    customer.CustomerAddress.City = city;

                    String state = (String)address["State"];
                    customer.CustomerAddress.State = state;

                    String zipCode = (String)address["ZipCode"];
                    customer.CustomerAddress.ZipCode = zipCode;

                    customers.Add(customer);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.Write(e.StackTrace);
            }
            catch (IOException e)
            {
                Console.Write(e.StackTrace);
            }
            catch (JsonException e)
            {
                Console.Write(e.StackTrace);
            }

            return customers;
        }
    }
}
