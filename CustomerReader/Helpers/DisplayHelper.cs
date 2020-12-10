using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Helpers
{
    public static class DisplayHelper
    {
        public static string BuildCustomersInspectionText(List<Customer> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Customer customer in list)
            {
                sb.AppendFormat("Email: {0}{1}", customer.Email.ToLower(), Environment.NewLine);
                sb.AppendFormat("First Name: {0}{1}", customer.FirstName.Trim().FirstCharToUpper(), Environment.NewLine);
                sb.AppendFormat("Last Name: {0}{1}", customer.LastName.Trim().FirstCharToUpper(), Environment.NewLine);
                sb.AppendFormat("Full Name: {0}{1}", customer.FullName, Environment.NewLine);
                sb.AppendFormat("Phone Number: {0}{1}", customer.Phone, Environment.NewLine);
                sb.AppendFormat("Street Address: {0}{1}", customer.CustomerAddress.StreetAddress, Environment.NewLine);
                sb.AppendFormat("City: {0}{1}", customer.CustomerAddress.City.Trim().FirstCharToUpper(), Environment.NewLine);
                sb.AppendFormat("State: {0}{1}", customer.CustomerAddress.State.ToUpper(), Environment.NewLine);
                sb.AppendFormat("Zip Code: {0}{1}", customer.CustomerAddress.ZipCode, Environment.NewLine);

                sb.AppendLine();
            }

            return sb.ToString();
        }

        
    }
}
