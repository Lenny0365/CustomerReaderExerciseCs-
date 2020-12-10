1) Renamed class in Program.cs file back to Program (so it would look like normal console app)
2) Fix bug with path to .csv file. 
3) Create new file CustomersReader and move all related to customer retrival functionality to that class. 
4) Change the way we return the customers.
   Now each method return the list of customers (this will help us test it).
5) Move displayCustomers to BuildCustomersInspectionText and return string so we can test it.
6) Change the way we output customer info to use Stringbuilder (we are concatenate multiple strings and we do it for each customer)
7) Modified Customer and Address classes
   a) Removed all public fields and changed them to public auto properties.
   b) Added private fields for some properties needed formatting.
   c) Change String to string 
      (use of language Use language keywords instead of framework type names for type references)
   d) Removed reference to Address class as base class for Customer. Instead add CustomerAddress property

 8) Added string extention to Uppercase first character of the word.
 9) Removed [Console.WriteLine("\nCurrent Element :" + nNode.Name);] debug output in readCustomersXml method.
 10) Added ValidationHelper class with ValidateEmail method.