using System.Data.Entity;
using SX.WebCore;
using LR.WebUI.Models;

namespace LR.WebUI.Infrastructure
{
    public sealed class DbContext : SxDbContext
    {
        public DbContext() : base("DbContext") { }

        public new DbSet<Article> Articles { get; set; }

        public new DbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}