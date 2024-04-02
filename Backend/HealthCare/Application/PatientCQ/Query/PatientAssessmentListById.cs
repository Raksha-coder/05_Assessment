using Application.DTO_Layer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PatientCQ.Query
{
   
    public class PatientAssessmentListById : IRequest<Tuple<List<PatientAssessmentDTO>>>
    {
        public int Id { get; set; }

       
    }
    public class PatientAssessmentListByIdHandler : IRequestHandler<PatientAssessmentListById, Tuple<List<PatientAssessmentDTO>>>
    {
        public readonly IHealthDbContext _context;
        public PatientAssessmentListByIdHandler(IHealthDbContext context)
        {
            _context = context;
        }

        public async Task<Tuple<List<PatientAssessmentDTO>>> Handle(PatientAssessmentListById request, CancellationToken cancellationToken)
        {
            //assessment name with all question with answer

            var _patientId = await _context.PatientTable.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

            if (_patientId == null)
            {
                return null;
            }


            var query = from t1 in _context.PatientTable
                        join t2 in _context.PatientToAssessmentTable on t1.Id equals t2.PatientId
                        join t3 in _context.AssessmentsTable on t2.AssessmentId equals t3.Id
                        where t1.Id == _patientId.Id
                        select new PatientAssessmentDTO
                        {
                            // Select the properties you need
                            PatientFirstName = t1.Firstname,
                            PatientLastName = t1.Lastname,
                            AssessmentName = new List<ListOfAssessmentNameDTO> {
                                new ListOfAssessmentNameDTO {
                                    Id = t3.Id,
                                    AssessmentId = t2.Id,
                                    Name = t3.Name,
                                    CreatedAt = t2.Assessment_Date,
                                }
                            }
                        };



            return Tuple.Create(query.ToList());




        }
    }

}
