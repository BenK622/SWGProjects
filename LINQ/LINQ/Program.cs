using System;
using System.Linq;

namespace LINQ
{
    class Program
    {
        /* Practice your LINQ!
         * You can use the methods in Data Loader to load products, customers, and some sample numbers
         * 
         * NumbersA, NumbersB, and NumbersC contain some ints
         * 
         * The product data is flat, with just product information
         * 
         * The customer data is hierarchical as customers have zero to many orders
         */
        static void Main()
        {
            // PrintOutOfStock();
            //InStockMoreThan3();
            //Customers_Washington();
            //ProductNames();
            //PriceIncrease();
            //Products_UpperCase();
            //Products_Even_Number();
            //UnitPriceRename();
            // BLessThanC();  
            //LessThan500();
            //TakeFirstThree();
            //TakeFirstThreeWashington();
            //SkipFirstThree(); 
            //AllExceptFirstTwo(); //do for code review
            // NumbersLessThan6();
             LessThanArrayPosition(); // do for code review
           // NumbersDivByThree();



            Console.ReadLine();
        }

        //1. Find all products that are out of stock.
        private static void PrintOutOfStock()
        {
            var products = DataLoader.LoadProducts();

            //var results = products.Where(p => p.UnitsInStock == 0);
            var results = from p in products
                where p.UnitsInStock == 0
                select p;

            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        //2. Find all products that are in stock and cost more than 3.00 per unit.
        private static void InStockMoreThan3()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                          where p.UnitPrice > 3
                          select p;


            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }

        }
        //3. Find all customers in Washington, print their name then their orders. (Region == "WA")
        private static void Customers_Washington()
        {
            var customers = DataLoader.LoadCustomers();

            var results = from c in customers
                          where c.Region == "WA"
                          select c;
            foreach(var customer in results)
            {
                Console.WriteLine(customer.CompanyName);
                for (int i = 0; i < customer.Orders.Length; i++)
                {
                    Console.WriteLine($"{customer.Orders[i].Total}");
                }
            }
        }
        //4. Create a new sequence with just the names of the products.
        private static void ProductNames()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                          select p.ProductName;
            foreach(var product in results)
            {
                Console.WriteLine(product);
            }
        }
        //5. Create a new sequence of products and unit prices where the unit prices are increased by 25%.
        private static void PriceIncrease()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                          select new
                          {
                              ProductNames = p.ProductName,
                              UnitPrice = p.UnitPrice * (decimal)1.25
                          };
            foreach(var product in results)
            {
                Console.WriteLine($"{product.ProductNames} - {product.UnitPrice}");
            }
        }
        //6. Create a new sequence of just product names in all upper case.
        private static void Products_UpperCase()
        {
            var products = DataLoader.LoadProducts();

          var results = from p in products
                       select p.ProductName.ToUpper();

          //b  var results = products.Select(p => ProductNames.t)

            foreach(var product in results)
            {
                Console.WriteLine(product);
            }

        }
        //7. Create a new sequence with products with even numbers of units in stock.
        private static void Products_Even_Number()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                          where p.UnitsInStock % 2 == 0 && p.UnitsInStock != 0
                          select new
                          {
                              productName = p.ProductName,
                              unitcount = p.UnitsInStock
                          };
            foreach(var product in results)
            {
                Console.WriteLine($"{product.productName}  -- {product.unitcount}");
            }
        }
        //8. Create a new sequence of products with ProductName, Category, and rename UnitPrice to Price.
        private static void UnitPriceRename()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                          select new
                          {
                              ProductName = p.ProductName,
                              Category = p.Category,
                              Price = p.UnitPrice
                          };
            foreach(var product in results)
            {
                Console.WriteLine($"{product.ProductName} - {product.Category} - {product.Price}");
            }


        }
        //9. Make a query that returns all pairs of numbers from both arrays such that the number from numbersB is less than the number from numbersC
        private static void BLessThanC()
        {
            var numbersB = DataLoader.NumbersB;
            var numbersC = DataLoader.NumbersC;

            var results = from b in numbersB
                          from c in numbersC
                          where b < c
                          select new { numbers = b, c };


            foreach (var numbers in results)
            {
                Console.WriteLine($"{numbers}");
            }
        }
        //10. Select CustomerID, OrderID, and Total where the order total is less than 500.00.
        public static void LessThan500()
        {
            var customers = DataLoader.LoadCustomers();

            var results = from customer in customers
                          from orders in customer.Orders
                          where orders.Total < 500
                          select new
                          {
                              CustomerID = customer.CustomerID,
                              OrderId = orders.OrderID,
                              Total = orders.Total
                          };
            foreach(var result in results)
            {
                Console.WriteLine($"{result.CustomerID} - {result.OrderId} - {result.Total}");
            }


        }
        //11. Write a query to take only the first 3 elements from NumbersA.
        public static void TakeFirstThree()
        {
            var numbers = DataLoader.NumbersA;

            var results = numbers.Take(3);

            foreach (var number in results)
            {
                Console.WriteLine($"{number}");
            }
                          

        }
        //12. Get only the first 3 orders from customers in Washington. !!
        public static void TakeFirstThreeWashington()
        {
            var customers = DataLoader.LoadCustomers();

            var results = (from customer in customers
                           from order in customer.Orders
                           where customer.Region == "WA"
                           select new {
                               Customer = customer.CompanyName,
                               Order = order.OrderID,
                           }).Take(3);

            foreach (var order in results)
            {
                Console.WriteLine($"{order.Customer} - {order.Order}");

            }


        }
        //13. Skip the first 3 elements of NumbersA.
        public static void SkipFirstThree()
        {
            var numbersA = DataLoader.NumbersA;

            var results = numbersA.Skip(3);

            foreach (var num in results)
            {
                Console.WriteLine($"{num}");
            }
        }
        //14. Get all except the first two orders from customers in Washington.
        public static void AllExceptFirstTwo()
        {
            var customers = DataLoader.LoadCustomers();

            var results = (from customer in customers
                           from order in customer.Orders
                           where customer.Region == "WA"
                           select new {customer = customer.CompanyName, order = order.OrderID}).Skip(2);

            foreach (var order in results)
            {
                Console.WriteLine($"{order.customer} - {order.order}");
            }

        }
        //15. Get all the elements in NumbersC from the beginning until an element is greater or equal to 6.
        public static void NumbersLessThan6()
        {
            var numbersC = DataLoader.NumbersC;

            var results = numbersC.TakeWhile(num => num <= 6);

            foreach (var r in results)
            {
                Console.WriteLine($"{r}");
            }
                           
        }
        //16. Return elements starting from the beginning of NumbersC until a number is hit that is less than its position in the array.
        public static void LessThanArrayPosition()
        {
            var numbersC = DataLoader.NumbersC;

            var results = numbersC.TakeWhile((num, index) => num >= index);


            foreach (var r in results)
            {
                Console.WriteLine($"{r}");
            }
        }
        //17. Return elements from NumbersC starting from the first element divisible by 3.
        public static void NumbersDivByThree()
        {
            var numbersC = DataLoader.NumbersC;

            var results = numbersC.SkipWhile(num => num % 3 != 0);

            foreach (var r in results)
            {
                Console.WriteLine($"{r}");
            }
        }
        //18. Order products alphabetically by name.
        public static void OrderAlpha()
        {
            var products = DataLoader.LoadProducts();

            

        }
        //19. Order products by UnitsInStock descending.
        //20. Sort the list of products, first by category, and then by unit price, from highest to lowest.
        //21. Reverse NumbersC.


    }
}
