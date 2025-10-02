using CLINICA.APPLICATION.USECASES.UseCases.Analysis.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-list")]
        public async Task<ActionResult> GetList()
        {
            var response = await _mediator.Send(new GetAllAnalysisQuery());

            if(response.IsSuccess)
                return NotFound(response);

            return Ok(response);
        }
        [HttpGet("get-by-id")]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { Id = id }); 

            if(!response.IsSuccess)
                return NotFound(response);

            return Ok(response);
                
        }
    }
}
