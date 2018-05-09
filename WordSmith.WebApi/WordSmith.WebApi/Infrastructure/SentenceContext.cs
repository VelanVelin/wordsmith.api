using Microsoft.EntityFrameworkCore;
using WordSmith.WebApi.Models.ReadModel;

namespace WordSmith.WebApi.Infrastructure
{
    public class SentenceContext : DbContext
    {
        public SentenceContext(DbContextOptions<SentenceContext> options) : base(options)
        {
            
        }
        public DbSet<Sentence> Sentences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sentence>().HasKey(c => c.Id);
        }
    }
}