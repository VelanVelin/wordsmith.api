using Microsoft.EntityFrameworkCore;
using WordSmith.WebApi.Models.ReadModel;
using WordSmith.WebApi.Models.WriteModel;

namespace WordSmith.DataModel
{
    public class SentenceContext : DbContext
    {
        public DbSet<Sentence> Sentences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sentence>().HasKey(c => c.Id);
        }
    }
}