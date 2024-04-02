using Application.DTO_Layer;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AssessmentCQ.Queries
{
    //get by id
    public class getAssessmentsAlongWithQuestion : IRequest<getNameResponse<AssessmentByIdDto>>
    {
        public int Id { get; set; }
    }
    public class getAssessmentsAlongWithQuestionHandler : IRequestHandler<getAssessmentsAlongWithQuestion, getNameResponse<AssessmentByIdDto>>
    {
        public readonly IHealthDbContext _context;
        public getAssessmentsAlongWithQuestionHandler(IHealthDbContext context)
        {
            _context = context;
        }

        public async Task<getNameResponse<AssessmentByIdDto>> Handle(getAssessmentsAlongWithQuestion request, CancellationToken cancellationToken)
        {
            try
            {
         
                var getByid = await _context.AssessmentsTable
                           .Where(a => a.Id == request.Id)
                           .Include(a => a.AssementsQue)
                           .Select(a => new AssessmentByIdDto
                           {
                               Id = a.Id,
                               isActive = a.isActive,
                               Name = a.Name,
                               isScorable = a.isScorable,
                               AssementsQue = a.AssementsQue.Select(q => new AssementQuestionsDto
                               {
                                   Id = q.Id,
                                   isActive = q.isActive,
                                   Questions = q.Questions,
                                   Response_Type = q.Response_Type,
                                   isRequired = q.isRequired
                               }).ToList()
                           })
                           .ToListAsync();



                return new getNameResponse<AssessmentByIdDto>()
                {
                    Status = 200,
                    Message = "success",
                    Response = getByid,
                    Error = null
                };


            }
            catch (Exception ex)
            {
                return new getNameResponse<AssessmentByIdDto>()
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
