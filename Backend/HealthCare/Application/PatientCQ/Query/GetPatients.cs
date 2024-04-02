using Application.Responses;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.PatientCQ.Query
{
    public class GetPatients:IRequest<CommonResponse<Patient>>
    {
    }

    public class GetPatientsHandler : IRequestHandler<GetPatients, CommonResponse<Patient>>
    {
        public readonly IHealthDbContext _context;
        public GetPatientsHandler(IHealthDbContext context)
        {
            _context = context;
        }

        public async Task<CommonResponse<Patient>> Handle(GetPatients request, CancellationToken cancellationToken)
        {
            try
            {
                var allPatients = await _context.PatientTable.ToListAsync();

                return new CommonResponse<Patient>()
                {
                    Status = 200,
                    Message = "Successfully added",
                    Response = allPatients,
                    Error = null!
                };
            }
            catch(Exception ex)
            {
                return new CommonResponse<Patient>()
                {
                    Status = 400,
                    Message = "Error Occured",
                    Response = null!,
                    Error = ex.Message
                };
            }
           
        }
    }
}
