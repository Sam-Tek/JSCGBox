using Entities;
using Repositories;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var context = new JSCGContext())
            {
                context.Initialize(true);

                UserRepository userRepository = new UserRepository(context);

                //test add user 
                await userRepository.CreateAsync(new User() 
                { 
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "John@Doe.fr"
                });

                foreach (var item in context.Users)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName}");
                }

            }
        }
    }
}
