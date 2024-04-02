using Application.Responses;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AssessmentCQ.Queries
{
    public class getAssessmentName : IRequest<getNameResponse<Assessment>>
    {

    }

    public class getAssessmentNameHandler : IRequestHandler<getAssessmentName, getNameResponse<Assessment>>
    {
        public readonly IHealthDbContext _context;
        public getAssessmentNameHandler(IHealthDbContext context)
        {
            _context = context;
        }

        public async Task<getNameResponse<Assessment>> Handle(getAssessmentName request, CancellationToken cancellationToken)
        {
            try
            {
                   var allNames = await _context.AssessmentsTable.ToListAsync();

                return new getNameResponse<Assessment>()
                {
                    Status = 200,
                    Message = "success",
                    Response = allNames,
                    Error = null
                    
                };


            }
            catch (Exception ex)
            {
                return new getNameResponse<Assessment>()
                {
                    Status = 400,
                    Message = "error",
                    Response = null,
                    Error = ex.Message

                };
            }
        }
    }
}
