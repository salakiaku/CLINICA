using CLINICA.APPLICATION.DTOS.Analysis.Requests;
using CLINICA.APPLICATION.DTOS.Exams.Requests;
using CLINICA.APPLICATION.USECASES.UseCases.Analysis.Commands;
using CLINICA.APPLICATION.USECASES.UseCases.Exams.Commands;
using CLINICA.APPLICATION.USECASES.UseCases.Exams.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA.PRESENTATION.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-list")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetList()
        {
            var response = await _mediator.Send(new GetAllExamsQuery());

            if (!response.IsSuccess)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("get-by-id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetByIdExamQuery() { Id = id });

            if (!response.IsSuccess)
                return NotFound(response);

            return Ok(response);

        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create([FromBody] CreateExamRequestDTO createExamRequestDTO)
        {
            var response = await _mediator.Send(new CreateExamCommand() { CreateExamRequestDTO = createExamRequestDTO });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody] UpdateExamRequestDTO updateExamRequestDTO)
        {
            var response = await _mediator.Send(new UpdateExamCommand() { UpdateExamRequestDTO = updateExamRequestDTO });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var response = await _mediator.Send(new DeleteExamCommand() { Id = id });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
    

       [HttpPut("change-state")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ChangeState([FromBody] UpdateExamsStateRequestDTO updateExamsStateRequestDTO)
        {
            var response = await _mediator.Send(new UpdateExamsChangeCommand() { Id = updateExamsStateRequestDTO.Id, State = updateExamsStateRequestDTO.State });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
