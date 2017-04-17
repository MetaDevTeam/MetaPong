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
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<GameResult> GameResults { get; set; }
    }
}