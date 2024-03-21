using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??=
            HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
