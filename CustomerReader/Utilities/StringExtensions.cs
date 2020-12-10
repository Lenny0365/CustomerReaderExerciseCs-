using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader
{
    public static class StringExtensions
    {
        // C# version 8.0
        // public static string FirstCharToUpper(this string input) => input switch
        //{
        //    null => throw new ArgumentNullException(nameof(input)),
        //    "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
        //    _ => input.First().ToString().ToUpper() + input.Substring(1)
        //};

        /// <summary>
        /// StackOverflow
        /// https://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
