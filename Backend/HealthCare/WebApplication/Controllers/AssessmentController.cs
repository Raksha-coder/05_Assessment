using Application.AssessmentCQ.Command;
using Application.AssessmentCQ.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AssessmentController : ApiController
    {
        [HttpGet("Assessmentnames")]
        public async Task<IActionResult> GetProducts()
        {
            var _assessmentNames = await Mediator.Send(new getAssessmentName());

            if (_assessmentNames.Status == 200)
            {
                return Ok(_assessmentNames);
            }
            else
            {
                return BadRequest(_assessmentNames);
            }
        }


        [HttpPost("AssismentQuestions")]

        public async Task<IActionResult> PostCart([FromBody] postAssessmentAlongwithQues AssQuestion)
        {
            var Value = await Mediator.Send(AssQuestion);

            if (Value.Status == 200)
            {
                return Ok(Value);
            }
            else
            {
                return BadRequest(Value);
            }


        }

    }
}
