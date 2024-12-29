using System.Collections;

namespace LinqConversionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Array & List

            int[] numbers = { 1, 2, 3, 4, 5 };

            var evenNumbersAsArray = numbers.Where(n => n % 2 == 0).ToArray();
            var evenNumbersAsList = numbers.Where(n => n % 2 == 0).ToList();

            evenNumbersAsList.Add(5);
            evenNumbersAsArray[1] = 9;

            foreach (var evenNumber in evenNumbersAsList)
            {
                //Console.WriteLine(evenNumber);
            }
            #endregion


            #region Cast & OfType

            ArrayList list = new ArrayList { 1, 2, 3, "hamza", true };

            //var castNumbers = list.Cast<int>().ToList();

            var filteredNumbers = list.OfType<int>().ToList();

            foreach (var number in filteredNumbers)
            {
                // Console.WriteLine(number);
            }

            #endregion


            #region Dictionary


            var employees = new[]
                {
                new { Id = 1, Name = "hamza", Department = "HR", Age = 25 },
                new { Id = 2, Name = "zidan", Department = "IT", Age = 30 },
                new { Id = 3, Name = "haitham", Department = "HR", Age = 35 }
            };

            var employeeDictionary = employees.ToDictionary(emp => emp.Name, emp => emp);

            var emp = employeeDictionary["hamza"];

            //Console.WriteLine($"Id : {emp.Id} , Name :  {emp.Name} ,Department : {emp.Department}");

            #endregion


            #region Lookup

            var items = new[]
                {
                new { Id = 1, Category = "Fruit", Name = "Apple" },
                new { Id = 2, Category = "Fruit", Name = "Banana" },
                new { Id = 3, Category = "Vegetable", Name = "Carrot" }
            };

            var categories = items.ToLookup(item => item.Category);


            foreach (var category in categories)
            {
                Console.WriteLine(category.Key);

                foreach (var item in category)
                {
                    Console.WriteLine(item);
                }
            }
            #endregion


            #region AsEnumerable
            /*
             * 
             * select * from Employees where age > 30 ;
              var query = dbContext.Employees
                                     .Where(e => e.Age > 30) // This will be translated to SQL
                                     .AsEnumerable()          // Switch to in-memory LINQ
                                     .Where(e => e.Name=='hamza'); // Processed in-memory

               Only the first `Where` clause is executed as SQL. 
               The second `Where` operates on the in-memory data.
            */
            #endregion


            #region AsQueryable
            /*
             * select * from Employees where age > 30 &&  name='hamza' ;
             var query = dbContext.Employees
                                  .Where(e => e.Age > 30) // This will be translated to SQL
                                  .Where(e => e.Name=='hamza'); This will be translated to SQL
            */
            #endregion
        }
    }
}