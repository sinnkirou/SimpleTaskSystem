using SimpleTaskSystem.Persons;
using System.Data.Entity.Migrations;

namespace SimpleTaskSystem.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SimpleTaskSystem";
        }

        protected override void Seed(SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext context)
        {
            context.People.AddOrUpdate(
            p => p.Name,
            new Person { Name = "Isaac Asimov" },
            new Person { Name = "Thomas More" },
            new Person { Name = "George Orwell" },
            new Person { Name = "Douglas Adams" }
            );
        }
    }
}
