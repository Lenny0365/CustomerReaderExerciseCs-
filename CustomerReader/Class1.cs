using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerReader
{
    public class Address
    {
        private string streetAddress;
        public string StreetAddress {
            get {
                string[] words = this.streetAddress.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(" ", words.Select(x => x.Trim().FirstCharToUpper())); }
            set { streetAddress = value; } 
        }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class Customer
    {
        public Customer()
        {
            if(this.CustomerAddress == null)
                this.CustomerAddress = new Address();
        }
        public string Email { get; set; }
        
        private string _phone;

        /// <summary>
        /// StackOverflow
        /// https://stackoverflow.com/questions/679740/fastest-way-to-format-a-phone-number-in-c
        /// This will take a string containing ten digits formatted in any way, 
        /// for example "246 1377801" or even ">> Phone:((246)) 13 - 778 - 01 <<", 
        /// and format it as "(246) 137-7801"
        /// 
        /// (If the string doesn't contain exactly ten digits, you get the original string unchanged.)
        /// </summary>
        public string Phone
        {
            get { return Regex.Replace(_phone,
                        @"^\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*$",
                        "($1$2$3) $4$5$6-$7$8$9$10");
            }
            set { _phone = value; }
        }

        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string FullName 
        {
            get 
            {
                List<string> items = new List<string>();
                if (string.IsNullOrEmpty(_FirstName) == false)
                    items.Add(_FirstName.Trim().FirstCharToUpper());
                if (string.IsNullOrEmpty(_LastName) == false)
                    items.Add(_LastName.Trim().FirstCharToUpper());

                return string.Join(" ", items);
            } 
        }

        public Address CustomerAddress { get; set; }
    }
}
