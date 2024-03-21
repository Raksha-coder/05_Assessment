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


        Task SaveChangesAsync();
    }
}
