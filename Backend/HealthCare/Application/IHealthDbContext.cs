using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IHealthDbContext
    {

        DbSet<Assessment> AssessmentsTable { get; }
        DbSet<AssementQuestions> AssementQuestionsTable { get; }

        DbSet<QuestionResponses> QuestionsResponseTable { get; }
        DbSet<Patient> PatientTable { get; }

        DbSet<PatientToAssessment> PatientToAssessmentTable { get; }
        DbSet<PatientToAssessmentDetails> PatientToAssessmentDetailsTable { get; }
        Task SaveChangesAsync();
    }
}
