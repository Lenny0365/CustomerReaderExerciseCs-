using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Helpers
{
    public static class ValidationHelper
    {
        public static string ValidateEmail(string email)
        {
            string error = string.Empty;
            try
            {
                System.Net.Mail.MailAddress ma =  new System.Net.Mail.MailAddress(email);
            }
            catch (ArgumentException ae)
            {
                error = ae.Message;
                // log if null or empty
                //Console.WriteLine($"Empty or null value: {error}");
            }
            catch (FormatException fe)
            {
                error = fe.Message;
                // log if invalid frmat
                //Console.WriteLine($"Bad email format: {error}");
            }

            return email;
        }
    }
}
