namespace DbLoader.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<DbLoader.DAL.ActorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbLoader.DAL.ActorContext context)
        {
            var actors = new List<Actor>
            {
                new Actor(new DateTime(2016, 09, 20),0000,0015,"Steve Little", "Onyeka B. Charles", "Mike R. Hale", null)
            };

            context.Actors.AddRange(actors);

            context.SaveChanges();
        }
    }
}
