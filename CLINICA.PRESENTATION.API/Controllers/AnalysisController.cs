using CLINICA.APPLICATION.DTOS.Analysis.Requests;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Analysis.Commands;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetList()
        {
            var response = await _mediator.Send(new GetAllAnalysisQuery());

            if(!response.IsSuccess)
                return NotFound(response);

            return Ok(response);
        }
        [HttpGet("get-by-id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = id });

            if (!response.IsSuccess)
                return NotFound(response);

            return Ok(response);

        }
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult> Create([FromBody] CreateAnalysisRequestDTO createAnalysisRequestDTO)
        {
            var response = await _mediator.Send(new CreateAnalysisCommand() { CreateAnalysisRequestDTO = createAnalysisRequestDTO});

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody] UpdateAnalysisRequestDTO updateAnalysisRequestDTO)
        {
            var response = await _mediator.Send(new UpdateAnalysisCommand() { UpdateAnalysisRequestDTO = updateAnalysisRequestDTO });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { Id = id });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("change-state")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ChangeState([FromBody] UpdateAnalysisSateRequestDTO updateAnalysisSateRequestDTO)
        {
            var response = await _mediator.Send(new UpdateAnalysisStateCommand() {  Id = updateAnalysisSateRequestDTO.Id, State = updateAnalysisSateRequestDTO.State });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }


    }
}
