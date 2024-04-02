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

        public DbSet<QuestionResponses> QuestionsResponseTable => Set<QuestionResponses>();

        public DbSet<Patient> PatientTable => Set<Patient>();

        public DbSet<PatientToAssessment> PatientToAssessmentTable => Set<PatientToAssessment>();
        public DbSet<PatientToAssessmentDetails> PatientToAssessmentDetailsTable => Set<PatientToAssessmentDetails>();

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


            //one ques one response
            modelBuilder.Entity<QuestionResponses>()
                .HasOne(a => a.AssessmentQuestion)
                .WithOne(a => a.QuestionResponses)
                .HasForeignKey<QuestionResponses>(a => a.QuestionId);


            //Patient

            modelBuilder.Entity<Patient>()
                   .HasKey(o => o.Id);


                //
                 modelBuilder.Entity<PatientToAssessment>()
                    .HasOne(pa => pa.Patients)
                    .WithMany(p => p.Patient_Assessment)
                    .HasForeignKey(pa => pa.PatientId);


            modelBuilder.Entity<PatientToAssessment>()
                .HasOne(pa => pa.Assessment)
                .WithMany(a => a.Patient_Assessment)
                .HasForeignKey(pa => pa.AssessmentId);


            modelBuilder.Entity<PatientToAssessmentDetails>()
                .HasOne(pad => pad.PatientToAssessment)
                .WithMany(pa => pa.Details)
                .HasForeignKey(pad => pad.Patient_Assessment_Id);


            modelBuilder.Entity<PatientToAssessmentDetails>()
                .HasOne(pad => pad.AssessmentQuestion)  //many
                .WithMany()
                .HasForeignKey(pad => pad.Question_Id)
                .OnDelete(DeleteBehavior.NoAction);


        }

        }
}
