using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLoader.DAL
{
    public class ActorContext : DbContext
    {
        public ActorContext() : base("ActorContext")
        {
            //Database.SetInitializer<ActorContext>(new CreateDatabaseIfNotExists<ActorContext>());
        }

        public DbSet<Models.Actor> Actors { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
