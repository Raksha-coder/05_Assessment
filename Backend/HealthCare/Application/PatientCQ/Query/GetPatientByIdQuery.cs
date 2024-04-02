using Application.Responses;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PatientCQ.Query
{
    public class GetPatientByIdQuery: IRequest<CommonResponse<Patient>>
    {
        public int Id { get; set; }
    }

    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, CommonResponse<Patient>>
    {
        public readonly IHealthDbContext _context;
        public GetPatientByIdQueryHandler(IHealthDbContext context)
        {
            _context = context;
        }

        public async Task<CommonResponse<Patient>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {


                var getPatientByIdQuery = await _context.PatientTable.Where(p => p.Id == request.Id).FirstOrDefaultAsync();


                if (getPatientByIdQuery != null)
                {


                    return new CommonResponse<Patient>()
                    {
                        Status = 200,
                        Message = "succesful",
                        Response = new List<Patient>() { getPatientByIdQuery }, //car data 
                        Error = null!

                    };

                }
                else
                {
                    return new CommonResponse<Patient>()
                    {
                        Status = 404,
                        Message = "did not get the patient",
                        Response = null!,
                        Error = null!

                    };
                }
            }
            catch (Exception ex)
            {
                return new CommonResponse<Patient>()
                {
                    Status = 400,
                    Message = "error getting the patient",
                    Response = null!,
                    Error = ex.Message

                };
            
            }
        }
    }
}
