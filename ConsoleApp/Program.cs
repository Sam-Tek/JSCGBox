using Repositories;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var context = new JSCGContext())
            {
                context.Initialize(true);

                foreach (var item in context.Users)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName}");
                }

            }
        }
    }
}
