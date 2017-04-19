namespace MetaPong.Data
{
    using DataModels.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MetaPongContext : DbContext
    {
        public MetaPongContext()
            : base("name=MetaPongContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<MetaPongContext>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<MetaPongContext>());
        }
        
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Game> Games { get; set; }
    }
}