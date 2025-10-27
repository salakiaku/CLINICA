using CLINICA.APPLICATION.DTOS.Medics.Requests;
using CLINICA.APPLICATION.USECASES.UseCases.Medics.Commands;
using CLINICA.APPLICATION.USECASES.UseCases.Medics.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA.PRESENTATION.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateMedicRequestDTO createMedicRequestDTO)
        {
            var response = await _mediator.Send(new CreateMedicCommand() { CreateMedicRequestDTO = createMedicRequestDTO });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get-list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetList()
        {
            var response = await _mediator.Send(new GetAllMedicQuery());

            if (!response.IsSuccess)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("get-by-id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetByIdMedicQuery() { Id = id});

            if (!response.IsSuccess)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] UpdateMedicRequestDTO updateMedicRequestDTO)
        {
            var response = await _mediator.Send(new UpdateMedicCommand() {  UpdateMedicRequestDTO = updateMedicRequestDTO });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("update-state")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateState([FromBody] UpdateMedicStateRequestDTO updateMedicStateRequestDTO)
        {
            var response = await _mediator.Send(new UpdateMedicStateCommand() { Id = updateMedicStateRequestDTO.Id, State = updateMedicStateRequestDTO.State });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var response = await _mediator.Send(new DeleteMedicCommand() { Id = id });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
