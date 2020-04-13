using Microsoft.Data.SqlClient;
using Polly;
using System;
using System.Linq;

namespace PeopleManagement.Data
{
    public class DbInitializer
    {
        public static void Initialize(PeopleManagementContext context)
        {
            Policy
                .Handle<SqlException>()
                .WaitAndRetry(10, attempt => TimeSpan.FromSeconds(3))
                .Execute(() => context.Database.EnsureCreated());

            if (context.People.Any())
            {
                return;   // DB has been seeded
            }

            var male = context.Groups.Add(new Group { Name = "Male" }).Entity;
            var female = context.Groups.Add(new Group { Name = "Female" }).Entity;

            context.SaveChanges();

            var people = new Person[]
            {
                new Person { Name = "Morgan Banks", Group = male },
                new Person { Name = "Freddie Daly", Group = male },
                new Person { Name = "Jennifer Hooper", Group = female },
                new Person { Name = "Evie Charlton", Group = female },
                new Person { Name = "Jodie Griffiths", Group = female }
            };

            foreach (var person in people)
            {
                context.People.Add(person);
            }

            context.SaveChanges();
        }
    }
}
