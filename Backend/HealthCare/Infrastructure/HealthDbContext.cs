using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class HealthDbContext: DbContext,IHealthDbContext
    {
        public HealthDbContext(DbContextOptions<HealthDbContext> dbContextOptions) : base(dbContextOptions) { }


        public DbSet<Assessment> AssessmentsTable => Set<Assessment>();
        public DbSet<AssementQuestions> AssementQuestionsTable  => Set<AssementQuestions>();

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assessment>()
                   .HasKey(o => o.Id);

            modelBuilder.Entity<AssementQuestions>()
                    .HasKey(o => o.Id);


            //one to many
            modelBuilder.Entity<Assessment>()
                .HasMany(o => o.AssementsQue)
                .WithOne(o => o.Assessment)
                .HasForeignKey(o => o.AssessmentId);
        }

        }
}
