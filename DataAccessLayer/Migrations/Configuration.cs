namespace DataAccessLayer.Migrations
{
    using DataLayer.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.ToDoListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.ToDoListContext context)
        {
            context.Users.AddOrUpdate(x => x.UserID,
                new User() { UserID = 1, Username = "Test", Password = "ax0NS/fHwojKxO42+XM5dQ==" },
                new User() { UserID = 2, Username = "Test2", Password = "Fjf/Nkn25cC/3b03/stKdQ==" }
                );

            context.Tasks.AddOrUpdate(x => x.ID,
                new Tasks() { ID = 1,Title = "Title 1", Description = "Description 1", DateAdded = DateTime.Now, DateUpdated = DateTime.Now, Status = true, TaskID = Guid.NewGuid(), UserId = 1 },
                new Tasks() { ID = 2, Title = "Title 2", Description = "Description 2", DateAdded = DateTime.Now, DateUpdated = DateTime.Now, Status = false, TaskID = Guid.NewGuid(), UserId = 1 }
            );

            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
